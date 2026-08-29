using System;
using System.Collections.Generic;
using DungeonSouls.Game.Classes;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Player;

namespace DungeonSouls.Game.Skills
{
    public enum SkillType
    {
        Active,
        Passive,
        Ultimate,
        Modifier,
        StatUpgrade
    }

    public class SkillNode
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public SkillType Type { get; }
        public int Tier { get; } // 1, 2, 3, 4
        public int MaxRank { get; }
        public int CurrentRank { get; set; }
        public List<string> RequiredSkillIds { get; }
        public StatType? TargetStat { get; }
        public double StatBonusPerRank { get; }
        public string UnlocksAbilityId { get; }

        public bool IsUnlocked => CurrentRank > 0;
        public bool IsMaxRank => CurrentRank >= MaxRank;

        public SkillNode(
            string id, string name, string desc, SkillType type, int tier, int maxRank,
            List<string> prerequisites = null, StatType? stat = null, double bonusPerRank = 0,
            string unlocksAbilityId = null)
        {
            Id = id;
            Name = name;
            Description = desc;
            Type = type;
            Tier = tier;
            MaxRank = maxRank;
            CurrentRank = 0;
            RequiredSkillIds = prerequisites ?? new List<string>();
            TargetStat = stat;
            StatBonusPerRank = bonusPerRank;
            UnlocksAbilityId = unlocksAbilityId;
        }
    }

    public class SkillBranch
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, SkillNode> Nodes { get; }

        public SkillBranch(string name, string desc)
        {
            Name = name;
            Description = desc;
            Nodes = new Dictionary<string, SkillNode>();
        }

        public void AddNode(SkillNode node)
        {
            Nodes[node.Id] = node;
        }
    }

    public class CharacterSkillTree
    {
        public CharacterClassType ClassType { get; }
        public List<SkillBranch> Branches { get; }
        private readonly Dictionary<string, SkillNode> _allNodes;

        public event Action<SkillNode> OnSkillUpgraded;

        public CharacterSkillTree(CharacterClassType classType)
        {
            ClassType = classType;
            Branches = new List<SkillBranch>();
            _allNodes = new Dictionary<string, SkillNode>();
            BuildTreeForClass(classType);
        }

        private void BuildTreeForClass(CharacterClassType classType)
        {
            switch (classType)
            {
                case CharacterClassType.Warrior:
                    BuildWarriorTree();
                    break;
                case CharacterClassType.Rogue:
                    BuildRogueTree();
                    break;
                case CharacterClassType.Mage:
                    BuildMageTree();
                    break;
                case CharacterClassType.Ranger:
                    BuildRangerTree();
                    break;
                case CharacterClassType.Necromancer:
                    BuildNecromancerTree();
                    break;
                case CharacterClassType.Paladin:
                    BuildPaladinTree();
                    break;
            }
        }

        private void AddBranch(SkillBranch branch)
        {
            Branches.Add(branch);
            foreach (var node in branch.Nodes.Values)
            {
                _allNodes[node.Id] = node;
            }
        }

        private void BuildWarriorTree()
        {
            var defense = new SkillBranch("Juggernaut (Defense)", "Mastery of heavy armor, blocking, and damage mitigation.");
            defense.AddNode(new SkillNode("w_def_1", "Iron Skin", "Increases base defense.", SkillType.Passive, 1, 5, null, StatType.Defense, 5));
            defense.AddNode(new SkillNode("w_def_2", "Tower Shield", "Increases block chance and reduction.", SkillType.Passive, 2, 3, new List<string> { "w_def_1" }, StatType.BlockChance, 4));
            defense.AddNode(new SkillNode("w_def_3", "Unstoppable Fortitude", "Increases maximum health.", SkillType.Passive, 3, 5, new List<string> { "w_def_2" }, StatType.MaxHealth, 30));
            defense.AddNode(new SkillNode("w_def_ult", "Avatar of Iron", "Unlocks Ground Slam ability.", SkillType.Ultimate, 4, 1, new List<string> { "w_def_3" }, unlocksAbilityId: "warrior_ground_slam"));

            var fury = new SkillBranch("Berserker (Fury)", "Harness rage to deal explosive physical damage.");
            fury.AddNode(new SkillNode("w_fury_1", "Brute Force", "Increases attack power.", SkillType.Passive, 1, 5, null, StatType.AttackPower, 4));
            fury.AddNode(new SkillNode("w_fury_2", "Bloodthirst", "Adds physical life steal.", SkillType.Passive, 2, 3, new List<string> { "w_fury_1" }, StatType.LifeStealPercent, 3));
            fury.AddNode(new SkillNode("w_fury_3", "Heavy Impact", "Increases critical damage.", SkillType.Passive, 3, 5, new List<string> { "w_fury_2" }, StatType.CriticalDamage, 15));
            fury.AddNode(new SkillNode("w_fury_ult", "Berserk Stance", "Unlocks Berserk ability.", SkillType.Ultimate, 4, 1, new List<string> { "w_fury_3" }, unlocksAbilityId: "warrior_berserk"));

            var arms = new SkillBranch("Weapon Mastery", "Increases swing speed, attack range, and armor penetration.");
            arms.AddNode(new SkillNode("w_arms_1", "Swift Swings", "Increases attack speed.", SkillType.Passive, 1, 5, null, StatType.AttackSpeed, 0.05));
            arms.AddNode(new SkillNode("w_arms_2", "Sunder Armor", "Increases armor penetration.", SkillType.Passive, 2, 3, new List<string> { "w_arms_1" }, StatType.ArmorPenetration, 10));
            arms.AddNode(new SkillNode("w_arms_3", "Executioner", "Increases critical strike chance.", SkillType.Passive, 3, 5, new List<string> { "w_arms_2" }, StatType.CriticalChance, 3));
            arms.AddNode(new SkillNode("w_arms_ult", "Whirlwind Mastery", "Unlocks Whirlwind ability.", SkillType.Ultimate, 4, 1, new List<string> { "w_arms_3" }, unlocksAbilityId: "warrior_whirlwind"));

            AddBranch(defense);
            AddBranch(fury);
            AddBranch(arms);
        }

        private void BuildRogueTree()
        {
            var shadow = new SkillBranch("Shadow Arts", "Stealth, deception, and high mobility.");
            shadow.AddNode(new SkillNode("r_shad_1", "Fleet Footwork", "Increases movement speed.", SkillType.Passive, 1, 5, null, StatType.MovementSpeed, 0.3));
            shadow.AddNode(new SkillNode("r_shad_2", "Evasion", "Increases dodge chance.", SkillType.Passive, 2, 3, new List<string> { "r_shad_1" }, StatType.DodgeChance, 4));
            shadow.AddNode(new SkillNode("r_shad_ult", "Shadow Step Mastery", "Unlocks Shadow Step ability.", SkillType.Ultimate, 3, 1, new List<string> { "r_shad_2" }, unlocksAbilityId: "rogue_shadow_step"));

            var assassination = new SkillBranch("Assassination", "Lethal critical strikes and precision burst.");
            assassination.AddNode(new SkillNode("r_as_1", "Keen Edge", "Increases critical chance.", SkillType.Passive, 1, 5, null, StatType.CriticalChance, 3));
            assassination.AddNode(new SkillNode("r_as_2", "Lethality", "Increases critical damage.", SkillType.Passive, 2, 3, new List<string> { "r_as_1" }, StatType.CriticalDamage, 20));
            assassination.AddNode(new SkillNode("r_as_ult", "Backstab Mastery", "Unlocks Backstab ability.", SkillType.Ultimate, 3, 1, new List<string> { "r_as_2" }, unlocksAbilityId: "rogue_backstab"));

            AddBranch(shadow);
            AddBranch(assassination);
        }

        private void BuildMageTree()
        {
            var pyro = new SkillBranch("Pyromancy", "Explosive fire damage and persistent burns.");
            pyro.AddNode(new SkillNode("m_pyro_1", "Kindling", "Increases spell power.", SkillType.Passive, 1, 5, null, StatType.SpellPower, 5));
            pyro.AddNode(new SkillNode("m_pyro_2", "Arcane Focus", "Increases max mana and mana regen.", SkillType.Passive, 2, 3, new List<string> { "m_pyro_1" }, StatType.ManaRegen, 1.5));
            pyro.AddNode(new SkillNode("m_pyro_ult", "Cataclysm", "Unlocks Meteor ability.", SkillType.Ultimate, 3, 1, new List<string> { "m_pyro_2" }, unlocksAbilityId: "mage_meteor"));

            var cryo = new SkillBranch("Cryomancy", "Frost slowing and elemental shielding.");
            cryo.AddNode(new SkillNode("m_cryo_1", "Glacial Barrier", "Increases magic resistance and defense.", SkillType.Passive, 1, 5, null, StatType.MagicResistance, 4));
            cryo.AddNode(new SkillNode("m_cryo_2", "Deep Freeze", "Unlocks Ice Spike ability.", SkillType.Active, 2, 1, new List<string> { "m_cryo_1" }, unlocksAbilityId: "mage_ice_spike"));

            AddBranch(pyro);
            AddBranch(cryo);
        }

        private void BuildRangerTree()
        {
            var archery = new SkillBranch("Marksmanship", "High accuracy and multishot capabilities.");
            archery.AddNode(new SkillNode("rng_1", "Eagle Eye", "Increases attack power.", SkillType.Passive, 1, 5, null, StatType.AttackPower, 4));
            archery.AddNode(new SkillNode("rng_2", "Quick Draw", "Increases attack speed.", SkillType.Passive, 2, 3, new List<string> { "rng_1" }, StatType.AttackSpeed, 0.08));
            archery.AddNode(new SkillNode("rng_ult", "Hail of Arrows", "Unlocks Rain of Arrows.", SkillType.Ultimate, 3, 1, new List<string> { "rng_2" }, unlocksAbilityId: "ranger_rain_of_arrows"));

            AddBranch(archery);
        }

        private void BuildNecromancerTree()
        {
            var occult = new SkillBranch("Dark Arts", "Life drain, summon strength, and corpse detonation.");
            occult.AddNode(new SkillNode("nec_1", "Soul Feast", "Increases life steal percent.", SkillType.Passive, 1, 5, null, StatType.LifeStealPercent, 2));
            occult.AddNode(new SkillNode("nec_2", "Grim Harvest", "Increases spell power.", SkillType.Passive, 2, 3, new List<string> { "nec_1" }, StatType.SpellPower, 6));
            occult.AddNode(new SkillNode("nec_ult", "Raise the Dead", "Unlocks Raise Dead ability.", SkillType.Ultimate, 3, 1, new List<string> { "nec_2" }, unlocksAbilityId: "necro_raise_dead"));

            AddBranch(occult);
        }

        private void BuildPaladinTree()
        {
            var holy = new SkillBranch("Radiance", "Divine shielding, healing, and holy retribution.");
            holy.AddNode(new SkillNode("pal_1", "Blessed Resolve", "Increases max health and armor.", SkillType.Passive, 1, 5, null, StatType.MaxHealth, 25));
            holy.AddNode(new SkillNode("pal_2", "Sanctuary Ward", "Increases magic resistance.", SkillType.Passive, 2, 3, new List<string> { "pal_1" }, StatType.MagicResistance, 5));
            holy.AddNode(new SkillNode("pal_ult", "Heavenly Judgment", "Unlocks Judgment ability.", SkillType.Ultimate, 3, 1, new List<string> { "pal_2" }, unlocksAbilityId: "paladin_judgment"));

            AddBranch(holy);
        }

        public bool CanUpgradeSkill(string skillId, PlayerCharacter player)
        {
            if (player.UnspentSkillPoints <= 0) return false;
            if (!_allNodes.TryGetValue(skillId, out var node)) return false;
            if (node.IsMaxRank) return false;

            // Check prerequisites
            foreach (var reqId in node.RequiredSkillIds)
            {
                if (!_allNodes.TryGetValue(reqId, out var reqNode) || reqNode.CurrentRank == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool UpgradeSkill(string skillId, PlayerCharacter player)
        {
            if (!CanUpgradeSkill(skillId, player)) return false;

            var node = _allNodes[skillId];
            player.UnspentSkillPoints--;
            node.CurrentRank++;

            // Apply stat modifications if passive
            if (node.TargetStat.HasValue && node.StatBonusPerRank > 0)
            {
                player.Attributes.AddModifier(
                    node.TargetStat.Value,
                    new StatModifier(node.StatBonusPerRank, StatModType.Flat, node)
                );
            }

            OnSkillUpgraded?.Invoke(node);
            return true;
        }

        public SkillNode GetNode(string skillId)
        {
            _allNodes.TryGetValue(skillId, out var node);
            return node;
        }
    }
}
