using System;
using System.Collections.Generic;

namespace DungeonSouls.Game.Combat
{
    public enum StatType
    {
        MaxHealth,
        MaxMana,
        MaxStamina,
        HealthRegen,
        ManaRegen,
        StaminaRegen,
        Strength,
        Dexterity,
        Intelligence,
        Defense,
        MagicResistance,
        AttackPower,
        SpellPower,
        CriticalChance,
        CriticalDamage,
        AttackSpeed,
        MovementSpeed,
        ArmorPenetration,
        LifeStealPercent,
        CooldownReductionPercent,
        DodgeChance,
        BlockChance,
        BlockFlatReduction
    }

    public enum StatModType
    {
        Flat = 100,
        PercentAdd = 200,
        PercentMult = 300
    }

    public class StatModifier
    {
        public double Value { get; }
        public StatModType Type { get; }
        public int Order { get; }
        public object Source { get; }

        public StatModifier(double value, StatModType type, int order, object source)
        {
            Value = value;
            Type = type;
            Order = order;
            Source = source;
        }

        public StatModifier(double value, StatModType type) : this(value, type, (int)type, null) { }
        public StatModifier(double value, StatModType type, object source) : this(value, type, (int)type, source) { }
    }

    public class CharacterStat
    {
        public double BaseValue { get; set; }
        private readonly List<StatModifier> _modifiers;
        private bool _isDirty = true;
        private double _cachedValue;

        public event Action<CharacterStat> OnValueChanged;

        public CharacterStat(double baseValue = 0)
        {
            BaseValue = baseValue;
            _modifiers = new List<StatModifier>();
            _cachedValue = baseValue;
        }

        public double Value
        {
            get
            {
                if (_isDirty)
                {
                    _cachedValue = CalculateFinalValue();
                    _isDirty = false;
                }
                return _cachedValue;
            }
        }

        public void AddModifier(StatModifier mod)
        {
            _modifiers.Add(mod);
            _modifiers.Sort((a, b) => a.Order.CompareTo(b.Order));
            _isDirty = true;
            OnValueChanged?.Invoke(this);
        }

        public bool RemoveModifier(StatModifier mod)
        {
            if (_modifiers.Remove(mod))
            {
                _isDirty = true;
                OnValueChanged?.Invoke(this);
                return true;
            }
            return false;
        }

        public bool RemoveAllModifiersFromSource(object source)
        {
            int removed = _modifiers.RemoveAll(mod => mod.Source == source);
            if (removed > 0)
            {
                _isDirty = true;
                OnValueChanged?.Invoke(this);
                return true;
            }
            return false;
        }

        public void ClearModifiers()
        {
            if (_modifiers.Count > 0)
            {
                _modifiers.Clear();
                _isDirty = true;
                OnValueChanged?.Invoke(this);
            }
        }

        private double CalculateFinalValue()
        {
            double finalValue = BaseValue;
            double sumPercentAdd = 0;

            for (int i = 0; i < _modifiers.Count; i++)
            {
                var mod = _modifiers[i];
                if (mod.Type == StatModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;
                    if (i + 1 >= _modifiers.Count || _modifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1.0 + (sumPercentAdd / 100.0);
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    finalValue *= 1.0 + (mod.Value / 100.0);
                }
            }

            return Math.Round(finalValue, 4);
        }
    }

    public class AttributeSet
    {
        private readonly Dictionary<StatType, CharacterStat> _stats;

        public event Action<StatType, CharacterStat> OnStatChanged;

        public AttributeSet()
        {
            _stats = new Dictionary<StatType, CharacterStat>();
            foreach (StatType statType in Enum.GetValues(typeof(StatType)))
            {
                var stat = new CharacterStat(0);
                stat.OnValueChanged += (s) => OnStatChanged?.Invoke(statType, s);
                _stats[statType] = stat;
            }

            SetDefaultBaseValues();
        }

        private void SetDefaultBaseValues()
        {
            SetBase(StatType.MaxHealth, 100);
            SetBase(StatType.MaxMana, 50);
            SetBase(StatType.MaxStamina, 100);
            SetBase(StatType.HealthRegen, 1.0);
            SetBase(StatType.ManaRegen, 2.0);
            SetBase(StatType.StaminaRegen, 15.0);
            SetBase(StatType.Strength, 10);
            SetBase(StatType.Dexterity, 10);
            SetBase(StatType.Intelligence, 10);
            SetBase(StatType.Defense, 10);
            SetBase(StatType.MagicResistance, 5);
            SetBase(StatType.AttackPower, 15);
            SetBase(StatType.SpellPower, 10);
            SetBase(StatType.CriticalChance, 5.0);    // 5%
            SetBase(StatType.CriticalDamage, 150.0);  // 150%
            SetBase(StatType.AttackSpeed, 1.0);      // 1.0 attacks/sec
            SetBase(StatType.MovementSpeed, 5.0);    // 5.0 units/sec
            SetBase(StatType.ArmorPenetration, 0);
            SetBase(StatType.LifeStealPercent, 0);
            SetBase(StatType.CooldownReductionPercent, 0);
            SetBase(StatType.DodgeChance, 3.0);      // 3%
            SetBase(StatType.BlockChance, 0);
            SetBase(StatType.BlockFlatReduction, 0);
        }

        public CharacterStat GetStat(StatType type) => _stats[type];
        public double GetValue(StatType type) => _stats[type].Value;

        public void SetBase(StatType type, double value)
        {
            _stats[type].BaseValue = value;
        }

        public void AddModifier(StatType type, StatModifier mod)
        {
            _stats[type].AddModifier(mod);
        }

        public void RemoveModifier(StatType type, StatModifier mod)
        {
            _stats[type].RemoveModifier(mod);
        }

        public void RemoveAllModifiersFromSource(object source)
        {
            foreach (var stat in _stats.Values)
            {
                stat.RemoveAllModifiersFromSource(source);
            }
        }
    }
}
