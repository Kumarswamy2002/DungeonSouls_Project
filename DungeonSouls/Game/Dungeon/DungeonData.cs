using System;
using System.Collections.Generic;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Enemies;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Loot;

namespace DungeonSouls.Game.Dungeon
{
    public enum DungeonBiome
    {
        ForgottenCrypt,
        DarkForest,
        AncientRuins,
        FrozenCaverns,
        LavaDepths,
        CursedCastle,
        ShadowRealm,
        Abyss
    }

    public enum RoomType
    {
        Entrance,
        Combat,
        Treasure,
        Shop,
        Healing,
        Puzzle,
        Trap,
        Elite,
        Secret,
        Event,
        Boss
    }

    public class DungeonRoom
    {
        public int Id { get; }
        public RectInt Bounds { get; }
        public RoomType Type { get; set; }
        public List<int> ConnectedRoomIds { get; }
        public List<EnemyCharacter> SpawnedEnemies { get; }
        public List<ItemInstance> PlacedLoot { get; }
        public List<string> TrapsAndHazards { get; }
        public bool IsCleared { get; set; }
        public bool IsDiscovered { get; set; }

        public Vector2Int Center => Bounds.Center;

        public DungeonRoom(int id, RectInt bounds, RoomType type)
        {
            Id = id;
            Bounds = bounds;
            Type = type;
            ConnectedRoomIds = new List<int>();
            SpawnedEnemies = new List<EnemyCharacter>();
            PlacedLoot = new List<ItemInstance>();
            TrapsAndHazards = new List<string>();
            IsCleared = type == RoomType.Entrance || type == RoomType.Healing || type == RoomType.Shop;
            IsDiscovered = false;
        }
    }

    public class DungeonCorridor
    {
        public Vector2Int Start { get; }
        public Vector2Int End { get; }
        public List<Vector2Int> PathPoints { get; }

        public DungeonCorridor(Vector2Int start, Vector2Int end)
        {
            Start = start;
            End = end;
            PathPoints = new List<Vector2Int>();
            GenerateLPath(start, end);
        }

        private void GenerateLPath(Vector2Int start, Vector2Int end)
        {
            // First along X, then along Y
            int xDir = Math.Sign(end.X - start.X);
            int curX = start.X;
            while (curX != end.X)
            {
                PathPoints.Add(new Vector2Int(curX, start.Y));
                curX += xDir;
            }

            int yDir = Math.Sign(end.Y - start.Y);
            int curY = start.Y;
            while (curY != end.Y)
            {
                PathPoints.Add(new Vector2Int(end.X, curY));
                curY += yDir;
            }
            PathPoints.Add(end);
        }
    }

    public class DungeonFloor
    {
        public int FloorNumber { get; }
        public int Seed { get; }
        public DungeonBiome Biome { get; }
        public int GridWidth { get; }
        public int GridHeight { get; }
        public int[,] Tiles { get; } // 0 = Void/Wall, 1 = Floor, 2 = Corridor, 3 = Door, 4 = SecretDoor
        public List<DungeonRoom> Rooms { get; }
        public List<DungeonCorridor> Corridors { get; }
        public DungeonRoom EntranceRoom { get; set; }
        public DungeonRoom BossRoom { get; set; }

        public DungeonFloor(int floorNum, int seed, DungeonBiome biome, int width = 80, int height = 80)
        {
            FloorNumber = floorNum;
            Seed = seed;
            Biome = biome;
            GridWidth = width;
            GridHeight = height;
            Tiles = new int[width, height];
            Rooms = new List<DungeonRoom>();
            Corridors = new List<DungeonCorridor>();
        }

        public bool IsWalkable(int x, int y)
        {
            if (x < 0 || x >= GridWidth || y < 0 || y >= GridHeight) return false;
            return Tiles[x, y] >= 1;
        }
    }
}
