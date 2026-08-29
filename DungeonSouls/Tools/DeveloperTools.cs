using System;
using System.Collections.Generic;
using System.Text;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Dungeon;
using DungeonSouls.Game.Enemies;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Loot;
using DungeonSouls.Game.ProceduralGeneration;

namespace DungeonSouls.Tools
{
    public static class DungeonVisualizerTool
    {
        public static string RenderAsciiMap(DungeonFloor dungeon)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== DUNGEON FLOOR {dungeon.FloorNumber} (Biome: {dungeon.Biome}, Seed: {dungeon.Seed}) ===");
            sb.AppendLine($"Rooms: {dungeon.Rooms.Count}, Corridors: {dungeon.Corridors.Count}");

            for (int y = 0; y < dungeon.GridHeight; y++)
            {
                for (int x = 0; x < dungeon.GridWidth; x++)
                {
                    int tile = dungeon.Tiles[x, y];
                    bool isEntity = false;

                    // Check room centers
                    foreach (var r in dungeon.Rooms)
                    {
                        if (r.Center.X == x && r.Center.Y == y)
                        {
                            char c = r.Type switch
                            {
                                RoomType.Entrance => 'E',
                                RoomType.Boss => 'B',
                                RoomType.Treasure => 'T',
                                RoomType.Shop => '$',
                                RoomType.Elite => 'X',
                                RoomType.Secret => '?',
                                _ => 'R'
                            };
                            sb.Append(c);
                            isEntity = true;
                            break;
                        }
                    }

                    if (!isEntity)
                    {
                        sb.Append(tile switch
                        {
                            0 => ' ',
                            1 => '.',
                            2 => '#',
                            _ => '?'
                        });
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public static class BalanceSimulatorTool
    {
        public static void SimulateCombatEncounters(int sampleSize = 1000)
        {
            var lootGen = new LootGenerator();
            var rarityCounts = new Dictionary<ItemRarity, int>();
            foreach (ItemRarity r in Enum.GetValues(typeof(ItemRarity))) rarityCounts[r] = 0;

            for (int i = 0; i < sampleSize; i++)
            {
                var item = lootGen.GenerateItem(5);
                rarityCounts[item.Rarity]++;
            }

            Console.WriteLine($"[Loot Simulation ({sampleSize} drops at Floor 5)]:");
            foreach (var kvp in rarityCounts)
            {
                Console.WriteLine($"  {kvp.Key,-12}: {kvp.Value,4} ({(kvp.Value * 100.0 / sampleSize):F1}%)");
            }
        }
    }
}
