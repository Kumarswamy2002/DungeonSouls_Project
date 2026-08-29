using System;
using System.Collections.Generic;
using DungeonSouls.Game.Core;

namespace DungeonSouls.Game.Combat
{
    public enum DamageType
    {
        Physical,
        Fire,
        Ice,
        Lightning,
        Poison,
        Dark,
        Holy,
        Arcane,
        TrueDamage
    }

    public enum HitResultType
    {
        Hit,
        Critical,
        Blocked,
        Parried,
        Dodged,
        Immune
    }

    public struct DamageInstance
    {
        public double BaseAmount { get; set; }
        public DamageType Type { get; set; }
        public bool CanCrit { get; set; }
        public double ArmorPenetration { get; set; }
        public double KnockbackForce { get; set; }
        public double StunDuration { get; set; }
        public ICombatant Source { get; set; }
        public string SourceAbilityId { get; set; }

        public DamageInstance(double amount, DamageType type, ICombatant source = null)
        {
            BaseAmount = amount;
            Type = type;
            CanCrit = true;
            ArmorPenetration = 0;
            KnockbackForce = 0;
            StunDuration = 0;
            Source = source;
            SourceAbilityId = null;
        }
    }

    public struct DamageResult
    {
        public double RawDamage { get; set; }
        public double MitigatedDamage { get; set; }
        public double FinalDamageDealt { get; set; }
        public DamageType DamageType { get; set; }
        public HitResultType HitResult { get; set; }
        public bool WasLethal { get; set; }
        public double LifeStolen { get; set; }
        public double KnockbackForce { get; set; }
        public double StunDuration { get; set; }

        public override string ToString()
        {
            return $"DamageResult: {FinalDamageDealt:F1} ({DamageType}) [{HitResult}] {(WasLethal ? "LETHAL" : "")}";
        }
    }

    public interface ICombatant
    {
        string EntityId { get; }
        string DisplayName { get; }
        bool IsPlayer { get; }
        bool IsAlive { get; }
        Vector2Int Position { get; set; }
        AttributeSet Attributes { get; }
        double CurrentHealth { get; }
        double CurrentMana { get; }
        double CurrentStamina { get; }

        DamageResult TakeDamage(DamageInstance damage);
        void Heal(double amount, ICombatant source = null);
        void RestoreMana(double amount);
        void RestoreStamina(double amount);
        bool ConsumeStamina(double amount);
        bool ConsumeMana(double amount);
        void ApplyKnockback(Vector2Int direction, double force);
        void ApplyStun(double durationSeconds);
    }

    public static class DamageCalculator
    {
        private static readonly Random _rng = new Random();

        public static DamageResult CalculateDamage(DamageInstance incoming, ICombatant attacker, ICombatant defender)
        {
            var result = new DamageResult
            {
                RawDamage = incoming.BaseAmount,
                DamageType = incoming.Type,
                KnockbackForce = incoming.KnockbackForce,
                StunDuration = incoming.StunDuration
            };

            if (defender == null || !defender.IsAlive)
            {
                result.HitResult = HitResultType.Immune;
                return result;
            }

            // 1. Check Dodge
            double dodgeChance = defender.Attributes.GetValue(StatType.DodgeChance);
            if (_rng.NextDouble() * 100.0 < dodgeChance && incoming.Type != DamageType.TrueDamage)
            {
                result.HitResult = HitResultType.Dodged;
                result.FinalDamageDealt = 0;
                return result;
            }

            // 2. Check Block / Parry
            double blockChance = defender.Attributes.GetValue(StatType.BlockChance);
            bool isBlocked = _rng.NextDouble() * 100.0 < blockChance && incoming.Type != DamageType.TrueDamage;

            // 3. Attacker Scaling & Criticals
            double attackPower = attacker != null ? attacker.Attributes.GetValue(StatType.AttackPower) : 10;
            double spellPower = attacker != null ? attacker.Attributes.GetValue(StatType.SpellPower) : 10;
            double scalingMultiplier = (incoming.Type == DamageType.Physical) 
                ? (1.0 + attackPower / 100.0) 
                : (1.0 + spellPower / 100.0);

            double scaledDamage = incoming.BaseAmount * scalingMultiplier;

            bool isCrit = false;
            if (incoming.CanCrit && attacker != null)
            {
                double critChance = attacker.Attributes.GetValue(StatType.CriticalChance);
                if (_rng.NextDouble() * 100.0 < critChance)
                {
                    double critMultiplier = attacker.Attributes.GetValue(StatType.CriticalDamage) / 100.0;
                    scaledDamage *= critMultiplier;
                    isCrit = true;
                }
            }

            // 4. Defense and Resistance Mitigation
            double finalDamage = scaledDamage;
            if (incoming.Type != DamageType.TrueDamage)
            {
                if (incoming.Type == DamageType.Physical)
                {
                    double defense = Math.Max(0, defender.Attributes.GetValue(StatType.Defense) - incoming.ArmorPenetration);
                    // Diminishing returns formula: Reduction = Defense / (Defense + 100)
                    double reduction = defense / (defense + 100.0);
                    finalDamage *= (1.0 - reduction);
                }
                else
                {
                    double magicResist = defender.Attributes.GetValue(StatType.MagicResistance);
                    double reduction = magicResist / (magicResist + 100.0);
                    finalDamage *= (1.0 - reduction);
                }

                if (isBlocked)
                {
                    double flatBlock = defender.Attributes.GetValue(StatType.BlockFlatReduction);
                    finalDamage = Math.Max(1.0, (finalDamage * 0.5) - flatBlock);
                }
            }

            finalDamage = Math.Max(1.0, Math.Round(finalDamage, 2));

            result.MitigatedDamage = scaledDamage - finalDamage;
            result.FinalDamageDealt = finalDamage;
            result.HitResult = isBlocked ? HitResultType.Blocked : (isCrit ? HitResultType.Critical : HitResultType.Hit);

            // 5. Life Steal
            if (attacker != null && incoming.Type == DamageType.Physical)
            {
                double lifeStealPercent = attacker.Attributes.GetValue(StatType.LifeStealPercent);
                if (lifeStealPercent > 0)
                {
                    double stolen = finalDamage * (lifeStealPercent / 100.0);
                    result.LifeStolen = stolen;
                    attacker.Heal(stolen, attacker);
                }
            }

            return result;
        }
    }
}
