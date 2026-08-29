using System;
using System.Collections.Generic;
using DungeonSouls.Game.Abilities;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Game.Classes
{
    public enum CharacterClassType
    {
        Warrior,
        Rogue,
        Mage,
        Ranger,
        Necromancer,
        Paladin
    }

    public abstract class CharacterClass
    {
        public abstract CharacterClassType Type { get; }
        public abstract string DisplayName { get; }
        public abstract string Description { get; }
        public abstract List<AbilityDefinition> Abilities { get; }

        public abstract void ApplyBaseClassBonuses(PlayerCharacter player);
    }

    public class WarriorClass : CharacterClass
    {
        public override CharacterClassType Type => CharacterClassType.Warrior;
        public override string DisplayName => "Warrior";
        public override string Description => "Frontline juggernaut specializing in high defense, crowd control, and devastating melee blows.";

        public override List<AbilityDefinition> Abilities => new List<AbilityDefinition>
        {
            new AbilityDefinition("warrior_shield_bash", "Shield Bash", "Slam your shield into an enemy, dealing physical damage and stunning them.", 
                DamageType.Physical, AbilityTargetType.SingleEnemy, baseDamage: 35, manaCost: 0, staminaCost: 20, cooldown: 6.0, range: 1.5, stun: 2.0, knockback: 3),

            new AbilityDefinition("warrior_whirlwind", "Whirlwind", "Spin rapidly, slicing all surrounding foes with intense physical damage.", 
                DamageType.Physical, AbilityTargetType.AreaOfEffect, baseDamage: 60, manaCost: 0, staminaCost: 35, cooldown: 8.0, radius: 2.5),

            new AbilityDefinition("warrior_ground_slam", "Ground Slam", "Slam the earth, causing an eruption that damages and slows all nearby enemies.", 
                DamageType.Physical, AbilityTargetType.AreaOfEffect, baseDamage: 50, manaCost: 0, staminaCost: 25, cooldown: 10.0, radius: 3.0, 
                status: StatusEffectType.Slow, statusDur: 4.0, statusPotency: 40),

            new AbilityDefinition("warrior_berserk", "Berserk", "Enter a ferocious state, drastically boosting attack power at the cost of defense.", 
                DamageType.Physical, AbilityTargetType.Self, baseDamage: 0, manaCost: 0, staminaCost: 30, cooldown: 25.0, 
                status: StatusEffectType.AttackBoost, statusDur: 10.0, statusPotency: 50)
        };

        public override void ApplyBaseClassBonuses(PlayerCharacter player)
        {
            player.Attributes.SetBase(StatType.MaxHealth, 150);
            player.Attributes.SetBase(StatType.Defense, 25);
            player.Attributes.SetBase(StatType.AttackPower, 20);
            player.Attributes.SetBase(StatType.BlockChance, 20);
            player.Attributes.SetBase(StatType.BlockFlatReduction, 15);
        }
    }

    public class RogueClass : CharacterClass
    {
        public override CharacterClassType Type => CharacterClassType.Rogue;
        public override string DisplayName => "Rogue";
        public override string Description => "Lethal assassin moving through shadows with extreme agility, critical strikes, and poison.";

        public override List<AbilityDefinition> Abilities => new List<AbilityDefinition>
        {
            new AbilityDefinition("rogue_dash", "Dash", "Instantly dash forward, piercing through enemies and granting brief invulnerability.", 
                DamageType.Physical, AbilityTargetType.DirectionalLine, baseDamage: 30, manaCost: 0, staminaCost: 20, cooldown: 4.0, range: 4.0),

            new AbilityDefinition("rogue_backstab", "Backstab", "Strike an enemy from behind with deadly precision, dealing massive critical damage.", 
                DamageType.Physical, AbilityTargetType.SingleEnemy, baseDamage: 90, manaCost: 0, staminaCost: 30, cooldown: 7.0, range: 1.2),

            new AbilityDefinition("rogue_smoke_bomb", "Smoke Bomb", "Toss a smoke canister that blinds all enemies in an area.", 
                DamageType.Physical, AbilityTargetType.AreaOfEffect, baseDamage: 10, manaCost: 0, staminaCost: 25, cooldown: 14.0, radius: 3.5, 
                status: StatusEffectType.Blind, statusDur: 5.0, statusPotency: 50),

            new AbilityDefinition("rogue_shadow_step", "Shadow Step", "Teleport directly behind target enemy and gain a critical damage boost.", 
                DamageType.Dark, AbilityTargetType.SingleEnemy, baseDamage: 45, manaCost: 0, staminaCost: 25, cooldown: 12.0, range: 6.0, 
                status: StatusEffectType.AttackBoost, statusDur: 4.0, statusPotency: 40)
        };

        public override void ApplyBaseClassBonuses(PlayerCharacter player)
        {
            player.Attributes.SetBase(StatType.MaxHealth, 90);
            player.Attributes.SetBase(StatType.Dexterity, 25);
            player.Attributes.SetBase(StatType.CriticalChance, 20);
            player.Attributes.SetBase(StatType.CriticalDamage, 200);
            player.Attributes.SetBase(StatType.DodgeChance, 15);
            player.Attributes.SetBase(StatType.MovementSpeed, 6.0);
        }
    }

    public class MageClass : CharacterClass
    {
        public override CharacterClassType Type => CharacterClassType.Mage;
        public override string DisplayName => "Mage";
        public override string Description => "Master of elemental forces commanding fire, frost, and lightning to obliterate hordes.";

        public override List<AbilityDefinition> Abilities => new List<AbilityDefinition>
        {
            new AbilityDefinition("mage_fireball", "Fireball", "Hurls an exploding sphere of flame that burns enemies.", 
                DamageType.Fire, AbilityTargetType.AreaOfEffect, baseDamage: 75, manaCost: 25, staminaCost: 0, cooldown: 2.5, range: 7.0, radius: 2.0, 
                status: StatusEffectType.Burn, statusDur: 4.0, statusPotency: 15),

            new AbilityDefinition("mage_ice_spike", "Ice Spike", "Launches a piercing shard of glacial frost that freezes targets.", 
                DamageType.Ice, AbilityTargetType.DirectionalLine, baseDamage: 60, manaCost: 30, staminaCost: 0, cooldown: 5.0, range: 8.0, 
                status: StatusEffectType.Freeze, statusDur: 3.0, statusPotency: 1),

            new AbilityDefinition("mage_lightning", "Lightning", "Calls down an instantaneous bolt of electricity that arcs between targets.", 
                DamageType.Lightning, AbilityTargetType.AreaOfEffect, baseDamage: 85, manaCost: 40, staminaCost: 0, cooldown: 8.0, range: 6.0, radius: 3.0),

            new AbilityDefinition("mage_meteor", "Meteor", "Summons a cataclysmic meteor from the sky, decimating a wide area with catastrophic fire damage.", 
                DamageType.Fire, AbilityTargetType.AreaOfEffect, baseDamage: 220, manaCost: 80, staminaCost: 0, cooldown: 22.0, range: 8.0, radius: 4.5, castTime: 1.2)
        };

        public override void ApplyBaseClassBonuses(PlayerCharacter player)
        {
            player.Attributes.SetBase(StatType.MaxHealth, 80);
            player.Attributes.SetBase(StatType.MaxMana, 160);
            player.Attributes.SetBase(StatType.ManaRegen, 6.0);
            player.Attributes.SetBase(StatType.Intelligence, 30);
            player.Attributes.SetBase(StatType.SpellPower, 35);
            player.Attributes.SetBase(StatType.MagicResistance, 20);
        }
    }

    public class RangerClass : CharacterClass
    {
        public override CharacterClassType Type => CharacterClassType.Ranger;
        public override string DisplayName => "Ranger";
        public override string Description => "Long-range marksman armed with bow, trick arrows, and exceptional kiting capability.";

        public override List<AbilityDefinition> Abilities => new List<AbilityDefinition>
        {
            new AbilityDefinition("ranger_multi_shot", "Multi Shot", "Fires a fan of 5 arrows at enemies in front of you.", 
                DamageType.Physical, AbilityTargetType.DirectionalCone, baseDamage: 40, manaCost: 15, staminaCost: 15, cooldown: 3.5, range: 7.0),

            new AbilityDefinition("ranger_piercing_arrow", "Piercing Arrow", "Fires a high-velocity arrow that penetrates all foes in a straight line.", 
                DamageType.Physical, AbilityTargetType.DirectionalLine, baseDamage: 80, manaCost: 20, staminaCost: 15, cooldown: 6.0, range: 10.0),

            new AbilityDefinition("ranger_poison_arrow", "Poison Arrow", "Shoots an envenomed arrow that inflicts heavy damage over time.", 
                DamageType.Poison, AbilityTargetType.SingleEnemy, baseDamage: 45, manaCost: 20, staminaCost: 10, cooldown: 5.0, range: 8.0, 
                status: StatusEffectType.Poison, statusDur: 6.0, statusPotency: 12),

            new AbilityDefinition("ranger_rain_of_arrows", "Rain of Arrows", "Unleashes a barrage of arrows over a targeted circular area.", 
                DamageType.Physical, AbilityTargetType.AreaOfEffect, baseDamage: 130, manaCost: 45, staminaCost: 20, cooldown: 18.0, range: 8.0, radius: 3.5)
        };

        public override void ApplyBaseClassBonuses(PlayerCharacter player)
        {
            player.Attributes.SetBase(StatType.MaxHealth, 95);
            player.Attributes.SetBase(StatType.Dexterity, 25);
            player.Attributes.SetBase(StatType.AttackPower, 25);
            player.Attributes.SetBase(StatType.AttackSpeed, 1.25);
            player.Attributes.SetBase(StatType.MovementSpeed, 5.8);
        }
    }

    public class NecromancerClass : CharacterClass
    {
        public override CharacterClassType Type => CharacterClassType.Necromancer;
        public override string DisplayName => "Necromancer";
        public override string Description => "Dark spellcaster siphoning life from enemies and summoning undead minions.";

        public override List<AbilityDefinition> Abilities => new List<AbilityDefinition>
        {
            new AbilityDefinition("necro_summon_skeleton", "Summon Skeleton", "Raises a skeleton warrior to fight by your side.", 
                DamageType.Dark, AbilityTargetType.Self, baseDamage: 0, manaCost: 35, staminaCost: 0, cooldown: 10.0),

            new AbilityDefinition("necro_life_drain", "Life Drain", "Channels a beam of dark energy that drains life from the target to heal yourself.", 
                DamageType.Dark, AbilityTargetType.SingleEnemy, baseDamage: 55, manaCost: 30, staminaCost: 0, cooldown: 5.0, range: 6.0),

            new AbilityDefinition("necro_bone_storm", "Bone Storm", "Summons a swirling cyclone of razor-sharp bones around yourself.", 
                DamageType.Physical, AbilityTargetType.AreaOfEffect, baseDamage: 90, manaCost: 45, staminaCost: 0, cooldown: 12.0, radius: 2.8),

            new AbilityDefinition("necro_raise_dead", "Raise Dead", "Detonates fallen corpses to deal catastrophic dark damage to surrounding enemies.", 
                DamageType.Dark, AbilityTargetType.AreaOfEffect, baseDamage: 160, manaCost: 60, staminaCost: 0, cooldown: 20.0, range: 7.0, radius: 4.0)
        };

        public override void ApplyBaseClassBonuses(PlayerCharacter player)
        {
            player.Attributes.SetBase(StatType.MaxHealth, 100);
            player.Attributes.SetBase(StatType.MaxMana, 140);
            player.Attributes.SetBase(StatType.SpellPower, 25);
            player.Attributes.SetBase(StatType.LifeStealPercent, 10);
            player.Attributes.SetBase(StatType.MagicResistance, 15);
        }
    }

    public class PaladinClass : CharacterClass
    {
        public override CharacterClassType Type => CharacterClassType.Paladin;
        public override string DisplayName => "Paladin";
        public override string Description => "Holy guardian wielding divine smites, protective wards, and radiant restoration.";

        public override List<AbilityDefinition> Abilities => new List<AbilityDefinition>
        {
            new AbilityDefinition("paladin_holy_strike", "Holy Strike", "Infuses weapon with radiant energy, dealing physical and holy damage.", 
                DamageType.Holy, AbilityTargetType.SingleEnemy, baseDamage: 50, manaCost: 15, staminaCost: 15, cooldown: 4.0, range: 1.5),

            new AbilityDefinition("paladin_heal", "Heal", "Channels divine light to immediately restore a large amount of health.", 
                DamageType.Holy, AbilityTargetType.Self, baseDamage: 0, manaCost: 35, staminaCost: 0, cooldown: 8.0, 
                status: StatusEffectType.Regeneration, statusDur: 5.0, statusPotency: 15),

            new AbilityDefinition("paladin_divine_shield", "Divine Shield", "Conjures a sacred barrier absorbing incoming damage and purifying debuffs.", 
                DamageType.Holy, AbilityTargetType.Self, baseDamage: 0, manaCost: 40, staminaCost: 0, cooldown: 20.0, 
                status: StatusEffectType.Shield, statusDur: 6.0, statusPotency: 120),

            new AbilityDefinition("paladin_judgment", "Judgment", "Calls down radiant judgment from the heavens to smite and stun all dark entities.", 
                DamageType.Holy, AbilityTargetType.AreaOfEffect, baseDamage: 140, manaCost: 55, staminaCost: 15, cooldown: 18.0, range: 6.0, radius: 3.5, stun: 2.5)
        };

        public override void ApplyBaseClassBonuses(PlayerCharacter player)
        {
            player.Attributes.SetBase(StatType.MaxHealth, 130);
            player.Attributes.SetBase(StatType.MaxMana, 100);
            player.Attributes.SetBase(StatType.Defense, 20);
            player.Attributes.SetBase(StatType.MagicResistance, 20);
            player.Attributes.SetBase(StatType.BlockChance, 15);
            player.Attributes.SetBase(StatType.BlockFlatReduction, 12);
        }
    }

    public static class ClassFactory
    {
        public static CharacterClass Create(CharacterClassType type) => type switch
        {
            CharacterClassType.Warrior => new WarriorClass(),
            CharacterClassType.Rogue => new RogueClass(),
            CharacterClassType.Mage => new MageClass(),
            CharacterClassType.Ranger => new RangerClass(),
            CharacterClassType.Necromancer => new NecromancerClass(),
            CharacterClassType.Paladin => new PaladinClass(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
