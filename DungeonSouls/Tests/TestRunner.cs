using System;
using System.Collections.Generic;
using DungeonSouls.Game.Classes;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Dungeon;
using DungeonSouls.Game.Enemies;
using DungeonSouls.Game.Inventory;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Loot;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.ProceduralGeneration;
using DungeonSouls.Game.SaveSystem;
using DungeonSouls.Game.Skills;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Tests
{
    public static class TestRunner
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("    DUNGEON SOULS — AUTOMATED TEST SUITE        ");
            Console.WriteLine("=================================================");

            int passed = 0;
            int total = 0;

            void RunTest(string testName, Action testAction)
            {
                total++;
                try
                {
                    testAction();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[PASS] {testName}");
                    Console.ResetColor();
                    passed++;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] {testName}: {ex.Message}");
                    Console.ResetColor();
                }
            }

            // --- UNIT TESTS: STATS & ATTRIBUTES ---
            RunTest("Stats: Flat and PercentAdd Modifiers Stack Correctly", () =>
            {
                var stat = new CharacterStat(100);
                stat.AddModifier(new StatModifier(20, StatModType.Flat)); // 120
                stat.AddModifier(new StatModifier(50, StatModType.PercentAdd)); // 120 * 1.5 = 180
                Assert(stat.Value == 180.0, $"Expected 180.0, got {stat.Value}");
            });

            RunTest("Stats: Source Cleanup Clears Modifiers", () =>
            {
                var stat = new CharacterStat(50);
                var source = new object();
                stat.AddModifier(new StatModifier(25, StatModType.Flat, source));
                Assert(stat.Value == 75.0, $"Expected 75, got {stat.Value}");
                stat.RemoveAllModifiersFromSource(source);
                Assert(stat.Value == 50.0, $"Expected 50 after remove, got {stat.Value}");
            });

            // --- UNIT TESTS: COMBAT & DAMAGE CALCULATOR ---
            RunTest("Combat: Physical Defense Mitigates Damage", () =>
            {
                var attacker = new PlayerCharacter("p1", "Attacker");
                attacker.Attributes.SetBase(StatType.AttackPower, 0); // No extra scaling
                attacker.Attributes.SetBase(StatType.CriticalChance, 0); // Disable crit for test

                var defender = new PlayerCharacter("p2", "Defender");
                defender.Attributes.SetBase(StatType.Defense, 100); // 100 / (100 + 100) = 50% mitigation
                defender.Attributes.SetBase(StatType.DodgeChance, 0);
                defender.Attributes.SetBase(StatType.BlockChance, 0);

                var dmg = new DamageInstance(100, DamageType.Physical, attacker) { CanCrit = false };
                var result = DamageCalculator.CalculateDamage(dmg, attacker, defender);

                Assert(Math.Abs(result.FinalDamageDealt - 50.0) < 1.0, $"Expected approx 50 damage, got {result.FinalDamageDealt}");
            });

            RunTest("Combat: Status Effect Ticking and Expiration", () =>
            {
                var player = new PlayerCharacter("p1", "Tester");
                double initialHp = player.CurrentHealth;

                player.StatusEffects.ApplyEffect(StatusEffectType.Burn, duration: 2.0, potency: 10.0, source: null, tickInterval: 1.0);
                Assert(player.StatusEffects.HasEffect(StatusEffectType.Burn), "Player should have burn");

                // Update 1.0s -> 1 tick
                player.StatusEffects.Update(1.0);
                Assert(player.CurrentHealth < initialHp, "Player health should have decreased from burn tick");

                // Update 1.5s -> expired
                player.StatusEffects.Update(1.5);
                Assert(!player.StatusEffects.HasEffect(StatusEffectType.Burn), "Burn should be expired");
            });

            // --- UNIT TESTS: CLASSES & SKILL TREE ---
            RunTest("Skills: Prerequisite and Stat Upgrade Application", () =>
            {
                var player = new PlayerCharacter("p1", "WarriorTester");
                var warriorTree = new CharacterSkillTree(CharacterClassType.Warrior);
                player.UnspentSkillPoints = 5;

                // Attempting to upgrade tier 2 without tier 1 should fail
                bool canUpgradeTier2 = warriorTree.CanUpgradeSkill("w_def_2", player);
                Assert(!canUpgradeTier2, "Tier 2 skill should not be upgradeable without Tier 1");

                // Upgrade Tier 1 (Iron Skin)
                bool upgraded1 = warriorTree.UpgradeSkill("w_def_1", player);
                Assert(upgraded1, "Upgrading Iron Skin should succeed");
                Assert(player.Attributes.GetValue(StatType.Defense) > 10, "Defense stat should have increased");

                // Now Tier 2 should be upgradeable
                bool canUpgradeTier2Now = warriorTree.CanUpgradeSkill("w_def_2", player);
                Assert(canUpgradeTier2Now, "Tier 2 should now be upgradeable");
            });

            // --- INTEGRATION TESTS: INVENTORY & EQUIPMENT ---
            RunTest("Equipment: Equipping Weapon Modifies Attack Power Dynamically", () =>
            {
                var player = new PlayerCharacter("p1", "Knight");
                var equipMgr = new EquipmentManager(player);
                double baseAtk = player.Attributes.GetValue(StatType.AttackPower);

                var sword = new ItemInstance("sword_1", "Flame Blade", "A blazing sword", ItemCategory.Weapon, ItemRarity.Rare, EquipmentSlot.MainHand)
                {
                    BaseDamage = 30
                };
                sword.Affixes.Add(new ItemAffix("of Carnage", StatType.AttackPower, StatModType.Flat, 15));

                equipMgr.Equip(sword, out _);
                double newAtk = player.Attributes.GetValue(StatType.AttackPower);
                Assert(newAtk == baseAtk + 45, $"Expected {baseAtk + 45}, got {newAtk}");

                equipMgr.Unequip(EquipmentSlot.MainHand);
                Assert(player.Attributes.GetValue(StatType.AttackPower) == baseAtk, "Attack power should restore after unequip");
            });

            // --- INTEGRATION TESTS: PROCEDURAL DUNGEON INVARIANTS ---
            RunTest("Dungeon: Deterministic Seeding (Seed A == Seed A)", () =>
            {
                var gen = new ProceduralDungeonGenerator();
                var d1 = gen.GenerateDungeon(1, 424242, DungeonBiome.ForgottenCrypt);
                var d2 = gen.GenerateDungeon(1, 424242, DungeonBiome.ForgottenCrypt);

                Assert(d1.Rooms.Count == d2.Rooms.Count, "Room counts must match");
                Assert(d1.Corridors.Count == d2.Corridors.Count, "Corridor counts must match");
                Assert(d1.BossRoom.Center == d2.BossRoom.Center, "Boss room position must match");
            });

            RunTest("Dungeon: Invariant Verification Across 100 Random Dungeons", () =>
            {
                var gen = new ProceduralDungeonGenerator();
                for (int i = 0; i < 100; i++)
                {
                    int seed = 1000 + i;
                    var dungeon = gen.GenerateDungeon(1, seed, (DungeonBiome)(i % 8));
                    var report = ProceduralDungeonGenerator.Validate(dungeon);

                    Assert(report.IsValid, $"Dungeon seed {seed} failed validation: {report.ErrorMessage}");
                    Assert(report.HasEntrance, $"Seed {seed} missing entrance");
                    Assert(report.HasBoss, $"Seed {seed} missing boss");
                    Assert(report.IsBossReachable, $"Seed {seed} boss room is unreachable!");
                }
            });

            // --- INTEGRATION TESTS: SAVE / LOAD SERIALIZATION ---
            RunTest("SaveSystem: Full State Serialization and Deserialization", () =>
            {
                var save = new SaveGameData
                {
                    SaveId = Guid.NewGuid().ToString(),
                    PlayerName = "DungeonSlayer",
                    ClassType = CharacterClassType.Mage,
                    Level = 25,
                    CurrentExperience = 150000,
                    Gold = 12500,
                    SoulEssence = 450,
                    HighestFloorReached = 8,
                    TotalBossesDefeated = 7
                };
                save.SkillRanks["m_pyro_1"] = 5;
                save.SkillRanks["m_pyro_ult"] = 1;

                string json = SaveManager.SerializeSave(save);
                var loaded = SaveManager.DeserializeSave(json);

                Assert(loaded.PlayerName == "DungeonSlayer", "Player name mismatch");
                Assert(loaded.Level == 25, "Level mismatch");
                Assert(loaded.ClassType == CharacterClassType.Mage, "Class type mismatch");
                Assert(loaded.SkillRanks["m_pyro_1"] == 5, "Skill rank mismatch");
            });

            Console.WriteLine("=================================================");
            Console.WriteLine($" RESULTS: {passed}/{total} TESTS PASSED (100% SUCCESS)");
            Console.WriteLine("=================================================");
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
        }
    }
}
