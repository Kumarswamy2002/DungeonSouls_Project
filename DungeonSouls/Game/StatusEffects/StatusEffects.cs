using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;

namespace DungeonSouls.Game.StatusEffects
{
    public enum StatusEffectType
    {
        Burn,
        Poison,
        Bleed,
        Freeze,
        Slow,
        Stun,
        Blind,
        Silence,
        Curse,
        Regeneration,
        Shield,
        AttackBoost,
        DefenseBoost
    }

    public class ActiveStatusEffect
    {
        public StatusEffectType Type { get; }
        public double DurationRemaining { get; set; }
        public double TotalDuration { get; }
        public double TickInterval { get; }
        public double TimeUntilNextTick { get; set; }
        public double Potency { get; set; }
        public int Stacks { get; set; }
        public int MaxStacks { get; }
        public ICombatant Source { get; }
        public double ShieldAbsorptionRemaining { get; set; }

        public ActiveStatusEffect(StatusEffectType type, double duration, double potency, ICombatant source, int maxStacks = 1, double tickInterval = 1.0)
        {
            Type = type;
            TotalDuration = duration;
            DurationRemaining = duration;
            Potency = potency;
            Source = source;
            MaxStacks = maxStacks;
            Stacks = 1;
            TickInterval = tickInterval;
            TimeUntilNextTick = tickInterval;
            ShieldAbsorptionRemaining = type == StatusEffectType.Shield ? potency : 0;
        }

        public bool IsExpired => DurationRemaining <= 0;
    }

    public class StatusEffectContainer
    {
        private readonly ICombatant _owner;
        private readonly Dictionary<StatusEffectType, ActiveStatusEffect> _activeEffects;
        private readonly List<StatModifier> _activeModifiers;

        public event Action<StatusEffectType, int> OnEffectApplied;
        public event Action<StatusEffectType> OnEffectRemoved;

        public StatusEffectContainer(ICombatant owner)
        {
            _owner = owner;
            _activeEffects = new Dictionary<StatusEffectType, ActiveStatusEffect>();
            _activeModifiers = new List<StatModifier>();
        }

        public bool HasEffect(StatusEffectType type) => _activeEffects.ContainsKey(type);
        public bool IsStunned => HasEffect(StatusEffectType.Stun) || HasEffect(StatusEffectType.Freeze);
        public bool IsSilenced => HasEffect(StatusEffectType.Silence);

        public void ApplyEffect(StatusEffectType type, double duration, double potency, ICombatant source, int maxStacks = 1, double tickInterval = 1.0)
        {
            if (_activeEffects.TryGetValue(type, out var existing))
            {
                // Refresh duration and stack
                existing.DurationRemaining = Math.Max(existing.DurationRemaining, duration);
                if (existing.Stacks < existing.MaxStacks)
                {
                    existing.Stacks++;
                    existing.Potency += potency;
                }
                OnEffectApplied?.Invoke(type, existing.Stacks);
            }
            else
            {
                var effect = new ActiveStatusEffect(type, duration, potency, source, maxStacks, tickInterval);
                _activeEffects[type] = effect;
                ApplyStatModifiers(effect);
                OnEffectApplied?.Invoke(type, 1);
            }
        }

        public void RemoveEffect(StatusEffectType type)
        {
            if (_activeEffects.TryGetValue(type, out var effect))
            {
                RemoveStatModifiers(effect);
                _activeEffects.Remove(type);
                OnEffectRemoved?.Invoke(type);
            }
        }

        public void ClearAll()
        {
            foreach (var type in new List<StatusEffectType>(_activeEffects.Keys))
            {
                RemoveEffect(type);
            }
        }

        public void Update(double deltaTime)
        {
            var keys = new List<StatusEffectType>(_activeEffects.Keys);
            foreach (var key in keys)
            {
                if (!_activeEffects.TryGetValue(key, out var effect)) continue;

                effect.DurationRemaining -= deltaTime;
                effect.TimeUntilNextTick -= deltaTime;

                if (effect.TimeUntilNextTick <= 0)
                {
                    effect.TimeUntilNextTick += effect.TickInterval;
                    ExecuteTick(effect);
                }

                if (effect.IsExpired)
                {
                    RemoveEffect(key);
                }
            }
        }

        private void ExecuteTick(ActiveStatusEffect effect)
        {
            if (!_owner.IsAlive) return;

            switch (effect.Type)
            {
                case StatusEffectType.Burn:
                    _owner.TakeDamage(new DamageInstance(effect.Potency * effect.Stacks, DamageType.Fire, effect.Source));
                    break;
                case StatusEffectType.Poison:
                    _owner.TakeDamage(new DamageInstance(effect.Potency * effect.Stacks, DamageType.Poison, effect.Source));
                    break;
                case StatusEffectType.Bleed:
                    _owner.TakeDamage(new DamageInstance(effect.Potency * effect.Stacks, DamageType.Physical, effect.Source));
                    break;
                case StatusEffectType.Regeneration:
                    _owner.Heal(effect.Potency * effect.Stacks, effect.Source);
                    break;
            }
        }

        public double AbsorbDamage(double incomingDamage)
        {
            if (_activeEffects.TryGetValue(StatusEffectType.Shield, out var shieldEffect))
            {
                if (shieldEffect.ShieldAbsorptionRemaining >= incomingDamage)
                {
                    shieldEffect.ShieldAbsorptionRemaining -= incomingDamage;
                    return 0;
                }
                else
                {
                    double leftover = incomingDamage - shieldEffect.ShieldAbsorptionRemaining;
                    shieldEffect.ShieldAbsorptionRemaining = 0;
                    RemoveEffect(StatusEffectType.Shield);
                    return leftover;
                }
            }
            return incomingDamage;
        }

        private void ApplyStatModifiers(ActiveStatusEffect effect)
        {
            switch (effect.Type)
            {
                case StatusEffectType.Slow:
                    _owner.Attributes.AddModifier(StatType.MovementSpeed, new StatModifier(-effect.Potency, StatModType.PercentAdd, effect));
                    _owner.Attributes.AddModifier(StatType.AttackSpeed, new StatModifier(-effect.Potency * 0.5, StatModType.PercentAdd, effect));
                    break;
                case StatusEffectType.AttackBoost:
                    _owner.Attributes.AddModifier(StatType.AttackPower, new StatModifier(effect.Potency, StatModType.PercentAdd, effect));
                    _owner.Attributes.AddModifier(StatType.SpellPower, new StatModifier(effect.Potency, StatModType.PercentAdd, effect));
                    break;
                case StatusEffectType.DefenseBoost:
                    _owner.Attributes.AddModifier(StatType.Defense, new StatModifier(effect.Potency, StatModType.PercentAdd, effect));
                    _owner.Attributes.AddModifier(StatType.MagicResistance, new StatModifier(effect.Potency, StatModType.PercentAdd, effect));
                    break;
                case StatusEffectType.Curse:
                    _owner.Attributes.AddModifier(StatType.Defense, new StatModifier(-effect.Potency, StatModType.PercentAdd, effect));
                    _owner.Attributes.AddModifier(StatType.MagicResistance, new StatModifier(-effect.Potency, StatModType.PercentAdd, effect));
                    break;
            }
        }

        private void RemoveStatModifiers(ActiveStatusEffect effect)
        {
            _owner.Attributes.RemoveAllModifiersFromSource(effect);
        }
    }
}
