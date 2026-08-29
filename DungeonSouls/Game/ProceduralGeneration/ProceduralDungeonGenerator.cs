using System;
using System.Collections.Generic;
using DungeonSouls.Game.Bosses;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Dungeon;
using DungeonSouls.Game.Enemies;
using DungeonSouls.Game.Loot;

namespace DungeonSouls.Game.ProceduralGeneration
{
    public class DungeonGenerationConfig
    {
        public int GridWidth { get; set; } = 80;
        public int GridHeight { get; set; } = 80;
        public int TargetRoomCount { get; set; } = 12;
        public int MinRoomSize { get; set; } = 6;
        public int MaxRoomSize { get; set; } = 14;
        public int RoomPadding { get; set; } = 3;
        public int MaxPlacementAttempts { get; set; } = 150;
        public double ExtraLoopChance { get; set; } = 0.25;
    }

    public class DungeonValidationReport
    {
        public bool IsValid { get; set; }
        public bool HasEntrance { get; set; }
        public bool HasBoss { get; set; }
        public bool IsBossReachable { get; set; }
        public int TotalRooms { get; set; }
        public int ReachableRooms { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ProceduralDungeonGenerator
    {
        private readonly DungeonGenerationConfig _config;

        public ProceduralDungeonGenerator(DungeonGenerationConfig config = null)
        {
            _config = config ?? new DungeonGenerationConfig();
        }

        public DungeonFloor GenerateDungeon(int floorNumber, int seed, DungeonBiome biome)
        {
            var random = new DeterministicRandom(seed);
            var dungeon = new DungeonFloor(floorNumber, seed, biome, _config.GridWidth, _config.GridHeight);

            // 1. Place Rooms
            PlaceRooms(dungeon, random);

            // 2. Connect Rooms via MST + Extra Loops
            ConnectRooms(dungeon, random);

            // 3. Rasterize into Tilemap
            RasterizeTiles(dungeon);

            // 4. Assign Room Roles (Entrance, Boss, Treasure, Shop, etc.)
            AssignRoomRoles(dungeon, random);

            // 5. Populate Enemies and Loot
            PopulateEntities(dungeon, random);

            return dungeon;
        }

        private void PlaceRooms(DungeonFloor dungeon, IRandomProvider random)
        {
            int placed = 0;
            int attempts = 0;

            while (placed < _config.TargetRoomCount && attempts < _config.MaxPlacementAttempts)
            {
                attempts++;
                int w = random.Next(_config.MinRoomSize, _config.MaxRoomSize + 1);
                int h = random.Next(_config.MinRoomSize, _config.MaxRoomSize + 1);
                int x = random.Next(2, dungeon.GridWidth - w - 2);
                int y = random.Next(2, dungeon.GridHeight - h - 2);

                var newBounds = new RectInt(x, y, w, h);
                bool overlaps = false;

                foreach (var room in dungeon.Rooms)
                {
                    if (newBounds.Overlaps(room.Bounds, _config.RoomPadding))
                    {
                        overlaps = true;
                        break;
                    }
                }

                if (!overlaps)
                {
                    var room = new DungeonRoom(placed, newBounds, RoomType.Combat);
                    dungeon.Rooms.Add(room);
                    placed++;
                }
            }
        }

        private void ConnectRooms(DungeonFloor dungeon, IRandomProvider random)
        {
            if (dungeon.Rooms.Count < 2) return;

            // Build Minimum Spanning Tree (MST) using Prim's algorithm
            var inTree = new HashSet<int> { 0 };
            var notInTree = new HashSet<int>();
            for (int i = 1; i < dungeon.Rooms.Count; i++) notInTree.Add(i);

            while (notInTree.Count > 0)
            {
                int bestU = -1;
                int bestV = -1;
                double bestDist = double.MaxValue;

                foreach (int u in inTree)
                {
                    var posU = dungeon.Rooms[u].Center;
                    foreach (int v in notInTree)
                    {
                        var posV = dungeon.Rooms[v].Center;
                        double dist = Vector2Int.EuclideanDistance(posU, posV);
                        if (dist < bestDist)
                        {
                            bestDist = dist;
                            bestU = u;
                            bestV = v;
                        }
                    }
                }

                if (bestU != -1 && bestV != -1)
                {
                    inTree.Add(bestV);
                    notInTree.Remove(bestV);
                    AddCorridor(dungeon, bestU, bestV);
                }
            }

            // Add extra loop corridors for nonlinear dungeon layout
            for (int i = 0; i < dungeon.Rooms.Count; i++)
            {
                for (int j = i + 1; j < dungeon.Rooms.Count; j++)
                {
                    if (!dungeon.Rooms[i].ConnectedRoomIds.Contains(j))
                    {
                        if (random.NextDouble() < _config.ExtraLoopChance)
                        {
                            double dist = Vector2Int.EuclideanDistance(dungeon.Rooms[i].Center, dungeon.Rooms[j].Center);
                            if (dist < 30.0) // Only connect nearby rooms
                            {
                                AddCorridor(dungeon, i, j);
                            }
                        }
                    }
                }
            }
        }

        private void AddCorridor(DungeonFloor dungeon, int roomA, int roomB)
        {
            dungeon.Rooms[roomA].ConnectedRoomIds.Add(roomB);
            dungeon.Rooms[roomB].ConnectedRoomIds.Add(roomA);
            var corridor = new DungeonCorridor(dungeon.Rooms[roomA].Center, dungeon.Rooms[roomB].Center);
            dungeon.Corridors.Add(corridor);
        }

        private void RasterizeTiles(DungeonFloor dungeon)
        {
            // Carve Rooms
            foreach (var room in dungeon.Rooms)
            {
                for (int x = room.Bounds.XMin; x < room.Bounds.XMax; x++)
                {
                    for (int y = room.Bounds.YMin; y < room.Bounds.YMax; y++)
                    {
                        dungeon.Tiles[x, y] = 1; // Floor
                    }
                }
            }

            // Carve Corridors
            foreach (var corridor in dungeon.Corridors)
            {
                foreach (var pt in corridor.PathPoints)
                {
                    if (pt.X >= 0 && pt.X < dungeon.GridWidth && pt.Y >= 0 && pt.Y < dungeon.GridHeight)
                    {
                        dungeon.Tiles[pt.X, pt.Y] = 2; // Corridor
                    }
                }
            }
        }

        private void AssignRoomRoles(DungeonFloor dungeon, IRandomProvider random)
        {
            if (dungeon.Rooms.Count == 0) return;

            // Entrance is Room 0
            dungeon.Rooms[0].Type = RoomType.Entrance;
            dungeon.EntranceRoom = dungeon.Rooms[0];

            // Boss room is the furthest room from Entrance
            int bossRoomIndex = 0;
            double maxDist = 0;
            for (int i = 1; i < dungeon.Rooms.Count; i++)
            {
                double dist = Vector2Int.EuclideanDistance(dungeon.Rooms[0].Center, dungeon.Rooms[i].Center);
                if (dist > maxDist)
                {
                    maxDist = dist;
                    bossRoomIndex = i;
                }
            }

            dungeon.Rooms[bossRoomIndex].Type = RoomType.Boss;
            dungeon.BossRoom = dungeon.Rooms[bossRoomIndex];

            // Assign other room types
            var unassigned = new List<int>();
            for (int i = 1; i < dungeon.Rooms.Count; i++)
            {
                if (i != bossRoomIndex) unassigned.Add(i);
            }

            if (unassigned.Count > 0)
            {
                int treasureIdx = unassigned[random.Next(unassigned.Count)];
                dungeon.Rooms[treasureIdx].Type = RoomType.Treasure;
                unassigned.Remove(treasureIdx);
            }

            if (unassigned.Count > 0)
            {
                int shopIdx = unassigned[random.Next(unassigned.Count)];
                dungeon.Rooms[shopIdx].Type = RoomType.Shop;
                unassigned.Remove(shopIdx);
            }

            if (unassigned.Count > 0)
            {
                int eliteIdx = unassigned[random.Next(unassigned.Count)];
                dungeon.Rooms[eliteIdx].Type = RoomType.Elite;
                unassigned.Remove(eliteIdx);
            }

            if (unassigned.Count > 0)
            {
                int puzzleIdx = unassigned[random.Next(unassigned.Count)];
                dungeon.Rooms[puzzleIdx].Type = RoomType.Puzzle;
                unassigned.Remove(puzzleIdx);
            }

            if (unassigned.Count > 0)
            {
                int secretIdx = unassigned[random.Next(unassigned.Count)];
                dungeon.Rooms[secretIdx].Type = RoomType.Secret;
                unassigned.Remove(secretIdx);
            }
        }

        private void PopulateEntities(DungeonFloor dungeon, IRandomProvider random)
        {
            var lootGen = new LootGenerator(random);

            foreach (var room in dungeon.Rooms)
            {
                switch (room.Type)
                {
                    case RoomType.Combat:
                        int enemyCount = random.Next(2, 5);
                        for (int i = 0; i < enemyCount; i++)
                        {
                            string enemyType = random.Next(3) switch { 0 => "skeleton", 1 => "goblin", _ => "zombie" };
                            var enemy = EnemyFactory.CreateEnemy(enemyType, dungeon.FloorNumber);
                            enemy.Position = room.Center + new Vector2Int(random.Next(-2, 3), random.Next(-2, 3));
                            room.SpawnedEnemies.Add(enemy);
                        }
                        break;

                    case RoomType.Elite:
                        var elite = EnemyFactory.CreateEnemy("elite_knight", dungeon.FloorNumber);
                        elite.Position = room.Center;
                        room.SpawnedEnemies.Add(elite);
                        room.PlacedLoot.Add(lootGen.GenerateItem(dungeon.FloorNumber, ItemRarity.Rare));
                        break;

                    case RoomType.Treasure:
                    case RoomType.Secret:
                        var rarity = room.Type == RoomType.Secret ? ItemRarity.Legendary : ItemRarity.Epic;
                        room.PlacedLoot.Add(lootGen.GenerateItem(dungeon.FloorNumber, rarity));
                        break;

                    case RoomType.Boss:
                        string regionName = dungeon.Biome.ToString();
                        var boss = BossFactory.CreateBoss(regionName);
                        boss.Position = room.Center;
                        room.SpawnedEnemies.Add(boss);
                        break;

                    case RoomType.Trap:
                        room.TrapsAndHazards.Add("SpikeTrap");
                        room.TrapsAndHazards.Add("PoisonCloud");
                        break;
                }
            }
        }

        public static DungeonValidationReport Validate(DungeonFloor dungeon)
        {
            var report = new DungeonValidationReport
            {
                TotalRooms = dungeon.Rooms.Count,
                HasEntrance = dungeon.EntranceRoom != null,
                HasBoss = dungeon.BossRoom != null
            };

            if (!report.HasEntrance || !report.HasBoss)
            {
                report.IsValid = false;
                report.ErrorMessage = "Dungeon missing Entrance or Boss Room.";
                return report;
            }

            // BFS Reachability from Entrance Room
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(dungeon.EntranceRoom.Id);
            visited.Add(dungeon.EntranceRoom.Id);

            while (queue.Count > 0)
            {
                int curId = queue.Dequeue();
                var room = dungeon.Rooms.Find(r => r.Id == curId);
                if (room != null)
                {
                    foreach (var neighbor in room.ConnectedRoomIds)
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            report.ReachableRooms = visited.Count;
            report.IsBossReachable = visited.Contains(dungeon.BossRoom.Id);
            report.IsValid = report.IsBossReachable && (visited.Count == dungeon.Rooms.Count);

            if (!report.IsValid)
            {
                report.ErrorMessage = $"Reachability failed. Total: {dungeon.Rooms.Count}, Reachable: {visited.Count}, BossReachable: {report.IsBossReachable}";
            }

            return report;
        }
    }
}
