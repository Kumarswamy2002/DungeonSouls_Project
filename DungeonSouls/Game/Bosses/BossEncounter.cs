using System;
using System.Collections.Generic;
using DungeonSouls.Game.Abilities;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Enemies;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Game.Bosses
{
    public enum BossPhase
    {
        Phase1 = 1,
        Phase2 = 2,
        Phase3 = 3,
        Enraged = 4
    }

    public class BossCharacter : EnemyCharacter
    {
        public string RegionName { get; }
        public BossPhase CurrentPhase { get; private set; }
        public double MaxHealthValue { get; }
        public List<AbilityDefinition> BossAbilities { get; }
        public AbilityCooldownTracker Cooldowns { get; }

        public event Action<BossPhase> OnPhaseChanged;
        public event Action<string> OnBossDialogue;

        public BossCharacter(string entityId, string name, string region, double hp, double atk, double def, int exp, int gold)
            : base(entityId, name, EnemyTier.Boss, hp, atk, def, exp, gold)
        {
            RegionName = region;
            MaxHealthValue = hp;
            CurrentPhase = BossPhase.Phase1;
            BossAbilities = new List<AbilityDefinition>();
            Cooldowns = new AbilityCooldownTracker();
            Perception.SightRange = 16.0;
            Perception.AttackRange = 3.0;
        }

        public void CheckPhaseTransition()
        {
            double healthPercent = (CurrentHealth / MaxHealthValue) * 100.0;
            BossPhase targetPhase = healthPercent switch
            {
                > 70.0 => BossPhase.Phase1,
                > 40.0 => BossPhase.Phase2,
                > 15.0 => BossPhase.Phase3,
                _ => BossPhase.Enraged
            };

            if (targetPhase != CurrentPhase)
            {
                CurrentPhase = targetPhase;
                OnPhaseChanged?.Invoke(CurrentPhase);
                ApplyPhaseBuffs(CurrentPhase);
            }
        }

        private void ApplyPhaseBuffs(BossPhase phase)
        {
            switch (phase)
            {
                case BossPhase.Phase2:
                    Attributes.AddModifier(StatType.AttackPower, new StatModifier(25, StatModType.PercentAdd, this));
                    OnBossDialogue?.Invoke($"{DisplayName}: 'You test my patience, mortal!'");
                    break;
                case BossPhase.Phase3:
                    Attributes.AddModifier(StatType.AttackSpeed, new StatModifier(30, StatModType.PercentAdd, this));
                    Attributes.AddModifier(StatType.MovementSpeed, new StatModifier(20, StatModType.PercentAdd, this));
                    OnBossDialogue?.Invoke($"{DisplayName}: 'Feel the true depth of Eldoria's wrath!'");
                    break;
                case BossPhase.Enraged:
                    Attributes.AddModifier(StatType.AttackPower, new StatModifier(60, StatModType.PercentAdd, this));
                    Attributes.AddModifier(StatType.CriticalChance, new StatModifier(30, StatModType.Flat, this));
                    OnBossDialogue?.Invoke($"{DisplayName}: 'PERISH IN DARKNESS!'");
                    break;
            }
        }

        public void UpdateBoss(double deltaTime, PlayerCharacter player)
        {
            if (!IsAlive) return;

            Cooldowns.Update(deltaTime);
            CheckPhaseTransition();
            UpdateAI(deltaTime, player);

            // Execute special boss ability if available and in range
            if (CurrentState == AI.AIState.Attack || CurrentState == AI.AIState.Chase)
            {
                TryCastBossSpecial(player);
            }
        }

        private void TryCastBossSpecial(PlayerCharacter player)
        {
            foreach (var ability in BossAbilities)
            {
                if (!Cooldowns.IsOnCooldown(ability.Id))
                {
                    double dist = Vector2Int.EuclideanDistance(Position, player.Position);
                    if (dist <= ability.Range)
                    {
                        Cooldowns.TriggerCooldown(ability.Id, ability.CooldownSeconds);
                        player.TakeDamage(new DamageInstance(ability.BaseDamage * (1.0 + (int)CurrentPhase * 0.2), ability.Element, this));
                        if (ability.InflictedStatus.HasValue)
                        {
                            player.StatusEffects.ApplyEffect(ability.InflictedStatus.Value, ability.StatusDuration, ability.StatusPotency, this);
                        }
                        break;
                    }
                }
            }
        }
    }

    public static class BossFactory
    {
        public static BossCharacter CreateBoss(string region)
        {
            return region.ToLower() switch
            {
                "forgotten crypt" or "crypt" => CreateBoneKing(),
                "dark forest" or "forest" => CreateAncientTreant(),
                "ancient ruins" or "ruins" => CreateStoneGuardian(),
                "frozen caverns" or "caverns" => CreateFrostQueen(),
                "lava depths" or "lava" => CreateInfernoLord(),
                "cursed castle" or "castle" => CreateVampireLord(),
                "shadow realm" or "shadow" => CreateShadowBeast(),
                _ => CreateDemonKing() // Abyss
            };
        }

        private static BossCharacter CreateBoneKing()
        {
            var boss = new BossCharacter("boss_bone_king", "The Bone King", "Forgotten Crypt", 850, 45, 25, 1200, 500);
            boss.BossAbilities.Add(new AbilityDefinition("bk_crypt_slam", "Crypt Slam", "Slams ossuary hammer.", DamageType.Physical, AbilityTargetType.AreaOfEffect, 60, 0, 0, 8.0, 3.5, stun: 2.0));
            boss.BossAbilities.Add(new AbilityDefinition("bk_curse_nova", "Curse Nova", "Emits necromantic shockwave.", DamageType.Dark, AbilityTargetType.AreaOfEffect, 40, 0, 0, 12.0, 5.0, status: StatusEffectType.Curse, statusDur: 8.0, statusPotency: 25));
            return boss;
        }

        private static BossCharacter CreateAncientTreant()
        {
            var boss = new BossCharacter("boss_ancient_treant", "Ancient Treant", "Dark Forest", 1100, 50, 35, 1500, 650);
            boss.BossAbilities.Add(new AbilityDefinition("at_root_slam", "Grasping Roots", "Entangles player.", DamageType.Poison, AbilityTargetType.SingleEnemy, 50, 0, 0, 9.0, 6.0, status: StatusEffectType.Slow, statusDur: 5.0, statusPotency: 50));
            return boss;
        }

        private static BossCharacter CreateStoneGuardian()
        {
            var boss = new BossCharacter("boss_stone_guardian", "Stone Guardian", "Ancient Ruins", 1400, 60, 50, 1800, 800);
            boss.BossAbilities.Add(new AbilityDefinition("sg_quake", "Earthquake", "Shatters arena floor.", DamageType.Physical, AbilityTargetType.AreaOfEffect, 75, 0, 0, 10.0, 4.5, knockback: 4));
            return boss;
        }

        private static BossCharacter CreateFrostQueen()
        {
            var boss = new BossCharacter("boss_frost_queen", "Frost Queen Selyna", "Frozen Caverns", 1250, 65, 30, 2200, 950);
            boss.BossAbilities.Add(new AbilityDefinition("fq_blizzard", "Glacial Tempest", "Freezes target area.", DamageType.Ice, AbilityTargetType.AreaOfEffect, 70, 0, 0, 11.0, 6.0, status: StatusEffectType.Freeze, statusDur: 3.0));
            return boss;
        }

        private static BossCharacter CreateInfernoLord()
        {
            var boss = new BossCharacter("boss_inferno_lord", "Ignis the Inferno Lord", "Lava Depths", 1600, 80, 40, 2600, 1200);
            boss.BossAbilities.Add(new AbilityDefinition("il_hellfire", "Hellfire Wave", "Incinerates everything.", DamageType.Fire, AbilityTargetType.AreaOfEffect, 90, 0, 0, 9.0, 7.0, status: StatusEffectType.Burn, statusDur: 6.0, statusPotency: 25));
            return boss;
        }

        private static BossCharacter CreateVampireLord()
        {
            var boss = new BossCharacter("boss_vampire_lord", "Lord Malakor", "Cursed Castle", 1500, 85, 35, 3000, 1500);
            boss.BossAbilities.Add(new AbilityDefinition("vl_blood_drain", "Sanguine Feast", "Drains player life.", DamageType.Dark, AbilityTargetType.SingleEnemy, 80, 0, 0, 8.0, 4.0, status: StatusEffectType.Bleed, statusDur: 5.0, statusPotency: 20));
            return boss;
        }

        private static BossCharacter CreateShadowBeast()
        {
            var boss = new BossCharacter("boss_shadow_beast", "Kael'Thok the Shadow Beast", "Shadow Realm", 1850, 95, 45, 3600, 1800);
            boss.BossAbilities.Add(new AbilityDefinition("sb_void_tear", "Void Cleave", "Rips spatial fabric.", DamageType.Arcane, AbilityTargetType.AreaOfEffect, 110, 0, 0, 10.0, 5.0, status: StatusEffectType.Blind, statusDur: 6.0));
            return boss;
        }

        private static BossCharacter CreateDemonKing()
        {
            var boss = new BossCharacter("boss_demon_king", "Azazel, Demon King of the Abyss", "Abyss", 2500, 120, 60, 5000, 3000);
            boss.BossAbilities.Add(new AbilityDefinition("dk_abyssal_rift", "Abyssal Rupture", "Devastating chaos eruption.", DamageType.Dark, AbilityTargetType.AreaOfEffect, 150, 0, 0, 8.0, 8.0, status: StatusEffectType.Curse, statusDur: 10.0, statusPotency: 40));
            return boss;
        }
    }
}
