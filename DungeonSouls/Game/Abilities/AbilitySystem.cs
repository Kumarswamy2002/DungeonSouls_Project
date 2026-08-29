using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Game.Abilities
{
    public enum AbilityTargetType
    {
        Self,
        SingleEnemy,
        AreaOfEffect,
        DirectionalCone,
        DirectionalLine
    }

    public class AbilityDefinition
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DamageType Element { get; }
        public AbilityTargetType TargetType { get; }
        public double BaseDamage { get; }
        public double ManaCost { get; }
        public double StaminaCost { get; }
        public double CooldownSeconds { get; }
        public double Range { get; }
        public double Radius { get; }
        public double CastTime { get; }
        public StatusEffectType? InflictedStatus { get; }
        public double StatusDuration { get; }
        public double StatusPotency { get; }
        public double KnockbackForce { get; }
        public double StunDuration { get; }

        public AbilityDefinition(
            string id, string name, string desc, DamageType element, AbilityTargetType targetType,
            double baseDamage, double manaCost, double staminaCost, double cooldown,
            double range = 1.0, double radius = 0.0, double castTime = 0.0,
            StatusEffectType? status = null, double statusDur = 0, double statusPotency = 0,
            double knockback = 0, double stun = 0)
        {
            Id = id;
            Name = name;
            Description = desc;
            Element = element;
            TargetType = targetType;
            BaseDamage = baseDamage;
            ManaCost = manaCost;
            StaminaCost = staminaCost;
            CooldownSeconds = cooldown;
            Range = range;
            Radius = radius;
            CastTime = castTime;
            InflictedStatus = status;
            StatusDuration = statusDur;
            StatusPotency = statusPotency;
            KnockbackForce = knockback;
            StunDuration = stun;
        }
    }

    public class AbilityCooldownTracker
    {
        private readonly Dictionary<string, double> _cooldowns = new Dictionary<string, double>();

        public bool IsOnCooldown(string abilityId)
        {
            return _cooldowns.TryGetValue(abilityId, out var remaining) && remaining > 0;
        }

        public double GetRemainingCooldown(string abilityId)
        {
            return _cooldowns.TryGetValue(abilityId, out var remaining) ? Math.Max(0, remaining) : 0;
        }

        public void TriggerCooldown(string abilityId, double duration)
        {
            _cooldowns[abilityId] = duration;
        }

        public void Update(double deltaTime)
        {
            var keys = new List<string>(_cooldowns.Keys);
            foreach (var key in keys)
            {
                _cooldowns[key] -= deltaTime;
                if (_cooldowns[key] <= 0)
                {
                    _cooldowns.Remove(key);
                }
            }
        }

        public void ResetAll()
        {
            _cooldowns.Clear();
        }
    }
}
