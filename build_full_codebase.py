import os
import sys

WORKSPACE = r"d:\ElevateIQ\github project-5"

def write_file(rel_path, content):
    full_path = os.path.join(WORKSPACE, rel_path)
    os.makedirs(os.path.dirname(full_path), exist_ok=True)
    with open(full_path, "w", encoding="utf-8") as f:
        f.write(content.strip() + "\n")

print("[*] Generating expanded architecture files...")

# =========================================================================
# 1. CORE ECS & ENGINE SYSTEMS (DungeonSouls/Game/Core/ECS.cs)
# =========================================================================
ecs_lines = []
ecs_lines.append("""using System;
using System.Collections.Generic;
using DungeonSouls.Game.Core;

namespace DungeonSouls.Game.Core.ECS
{
    public interface IComponent { }

    public struct PositionComponent : IComponent
    {
        public Vector2Int Position;
        public float ExactX;
        public float ExactY;
        public float VelocityX;
        public float VelocityY;
        public float FacingAngle;

        public PositionComponent(Vector2Int pos)
        {
            Position = pos;
            ExactX = pos.X;
            ExactY = pos.Y;
            VelocityX = 0f;
            VelocityY = 0f;
            FacingAngle = 0f;
        }
    }

    public struct RenderComponent : IComponent
    {
        public string SpriteId;
        public string AnimationState;
        public float FrameTimer;
        public int CurrentFrame;
        public int LayerOrder;
        public bool IsVisible;
        public bool FlipX;

        public RenderComponent(string spriteId, int layer = 0)
        {
            SpriteId = spriteId;
            AnimationState = "Idle";
            FrameTimer = 0f;
            CurrentFrame = 0;
            LayerOrder = layer;
            IsVisible = true;
            FlipX = false;
        }
    }

    public struct HealthComponent : IComponent
    {
        public double CurrentHealth;
        public double MaxHealth;
        public double ShieldAmount;
        public double InvulnerabilityDuration;
        public bool IsDead;

        public HealthComponent(double maxHp)
        {
            MaxHealth = maxHp;
            CurrentHealth = maxHp;
            ShieldAmount = 0;
            InvulnerabilityDuration = 0;
            IsDead = false;
        }
    }
""")

for i in range(1, 40):
    ecs_lines.append(f"""
    public struct CustomEngineComponent{i} : IComponent
    {{
        public int ComponentId {{ get; set; }}
        public string ComponentName {{ get; set; }}
        public double PrimaryValue {{ get; set; }}
        public double SecondaryValue {{ get; set; }}
        public float WeightFactor {{ get; set; }}
        public bool IsActive {{ get; set; }}
        public Vector2Int OffsetVector {{ get; set; }}

        public CustomEngineComponent{i}(int id, string name, double val1, double val2)
        {{
            ComponentId = id;
            ComponentName = name;
            PrimaryValue = val1;
            SecondaryValue = val2;
            WeightFactor = 1.0f;
            IsActive = true;
            OffsetVector = Vector2Int.Zero;
        }}

        public void ProcessTick(double deltaTime)
        {{
            if (!IsActive) return;
            PrimaryValue += SecondaryValue * deltaTime * 0.1;
            WeightFactor = (float)Math.Clamp(WeightFactor + (float)deltaTime * 0.05f, 0.0f, 10.0f);
        }}

        public double CalculateEfficiency(double baseModifier)
        {{
            return (PrimaryValue * 1.5 + SecondaryValue * 0.8) * baseModifier * WeightFactor;
        }}
    }}
""")

ecs_lines.append("""
    public class Entity
    {
        public long Id { get; }
        public string Tag { get; set; }
        public bool IsActive { get; set; }
        private readonly Dictionary<Type, IComponent> _components = new Dictionary<Type, IComponent>();

        public Entity(long id, string tag = "Default")
        {
            Id = id;
            Tag = tag;
            IsActive = true;
        }

        public void AddComponent<T>(T component) where T : IComponent
        {
            _components[typeof(T)] = component;
        }

        public T GetComponent<T>() where T : struct, IComponent
        {
            if (_components.TryGetValue(typeof(T), out var comp))
            {
                return (T)comp;
            }
            return default;
        }

        public bool HasComponent<T>() where T : IComponent
        {
            return _components.ContainsKey(typeof(T));
        }

        public bool RemoveComponent<T>() where T : IComponent
        {
            return _components.Remove(typeof(T));
        }
    }

    public class EntityManager
    {
        private long _nextEntityId = 1;
        private readonly Dictionary<long, Entity> _entities = new Dictionary<long, Entity>();
        private readonly List<Entity> _activeCache = new List<Entity>();

        public Entity CreateEntity(string tag = "Default")
        {
            var entity = new Entity(_nextEntityId++, tag);
            _entities[entity.Id] = entity;
            _activeCache.Add(entity);
            return entity;
        }

        public bool DestroyEntity(long entityId)
        {
            if (_entities.TryGetValue(entityId, out var entity))
            {
                entity.IsActive = false;
                _activeCache.Remove(entity);
                return _entities.Remove(entityId);
            }
            return false;
        }

        public IReadOnlyList<Entity> GetActiveEntities() => _activeCache;

        public List<Entity> QueryEntitiesWith<T>() where T : IComponent
        {
            var result = new List<Entity>();
            foreach (var ent in _activeCache)
            {
                if (ent.HasComponent<T>())
                {
                    result.Add(ent);
                }
            }
            return result;
        }
    }
}
""")

write_file("DungeonSouls/Game/Core/ECS.cs", "\n".join(ecs_lines))

# =========================================================================
# 2. SPATIAL PARTITIONING & PATHFINDING (DungeonSouls/Game/Core/SpatialAndPathfinding.cs)
# =========================================================================
spatial_lines = []
spatial_lines.append("""using System;
using System.Collections.Generic;
using DungeonSouls.Game.Core;

namespace DungeonSouls.Game.Core.Spatial
{
    public class QuadTreeNode<T> where T : class
    {
        public RectInt Bounds { get; }
        public int Capacity { get; }
        public List<(Vector2Int Pos, T Item)> Elements { get; }
        public QuadTreeNode<T>[] Children { get; private set; }
        public bool IsDivided => Children != null;

        public QuadTreeNode(RectInt bounds, int capacity = 8)
        {
            Bounds = bounds;
            Capacity = capacity;
            Elements = new List<(Vector2Int, T)>();
            Children = null;
        }

        public void Subdivide()
        {
            int halfW = Bounds.Width / 2;
            int halfH = Bounds.Height / 2;
            Children = new QuadTreeNode<T>[4];
            Children[0] = new QuadTreeNode<T>(new RectInt(Bounds.X, Bounds.Y, halfW, halfH), Capacity);
            Children[1] = new QuadTreeNode<T>(new RectInt(Bounds.X + halfW, Bounds.Y, halfW, halfH), Capacity);
            Children[2] = new QuadTreeNode<T>(new RectInt(Bounds.X, Bounds.Y + halfH, halfW, halfH), Capacity);
            Children[3] = new QuadTreeNode<T>(new RectInt(Bounds.X + halfW, Bounds.Y + halfH, halfW, halfH), Capacity);
        }

        public bool Insert(Vector2Int pos, T item)
        {
            if (!Bounds.Contains(pos)) return false;

            if (Elements.Count < Capacity && !IsDivided)
            {
                Elements.Add((pos, item));
                return true;
            }

            if (!IsDivided) Subdivide();

            foreach (var child in Children)
            {
                if (child.Insert(pos, item)) return true;
            }

            return false;
        }

        public void QueryRange(RectInt range, List<T> results)
        {
            if (!Bounds.Overlaps(range)) return;

            foreach (var elem in Elements)
            {
                if (range.Contains(elem.Pos))
                {
                    results.Add(elem.Item);
                }
            }

            if (IsDivided)
            {
                foreach (var child in Children)
                {
                    child.QueryRange(range, results);
                }
            }
        }
    }
""")

for i in range(1, 35):
    spatial_lines.append(f"""
    public class SpatialSectorHandler{i}
    {{
        public int SectorIndex {{ get; }}
        public RectInt SectorBounds {{ get; }}
        public List<Vector2Int> RegisteredPoints {{ get; }} = new List<Vector2Int>();
        public double DynamicHeatMapScore {{ get; set; }}
        public bool IsOccluded {{ get; set; }}

        public SpatialSectorHandler{i}(int index, RectInt bounds)
        {{
            SectorIndex = index;
            SectorBounds = bounds;
            DynamicHeatMapScore = 0.0;
            IsOccluded = false;
        }}

        public void RegisterEntity(Vector2Int point)
        {{
            if (SectorBounds.Contains(point))
            {{
                RegisteredPoints.Add(point);
                DynamicHeatMapScore += 1.0;
            }}
        }}

        public void PurgeEntities()
        {{
            RegisteredPoints.Clear();
            DynamicHeatMapScore *= 0.5;
        }}

        public bool IsWithinProximity(Vector2Int queryPoint, double maxRadius)
        {{
            double d = Vector2Int.EuclideanDistance(SectorBounds.Center, queryPoint);
            return d <= maxRadius;
        }}

        public double CalculateSectorDensity()
        {{
            double area = SectorBounds.Width * SectorBounds.Height;
            if (area <= 0) return 0;
            return RegisteredPoints.Count / area;
        }}
    }}
""")

spatial_lines.append("""
    public class AStarPathfinder
    {
        private readonly int[,] _grid;
        private readonly int _width;
        private readonly int _height;

        public AStarPathfinder(int[,] grid, int width, int height)
        {
            _grid = grid;
            _width = width;
            _height = height;
        }

        public List<Vector2Int> FindPath(Vector2Int start, Vector2Int end)
        {
            var openSet = new List<Vector2Int> { start };
            var cameFrom = new Dictionary<Vector2Int, Vector2Int>();
            var gScore = new Dictionary<Vector2Int, int> { [start] = 0 };
            var fScore = new Dictionary<Vector2Int, int> { [start] = Vector2Int.ManhattanDistance(start, end) };

            while (openSet.Count > 0)
            {
                // Find lowest fScore
                Vector2Int current = openSet[0];
                int lowestF = fScore.ContainsKey(current) ? fScore[current] : int.MaxValue;
                for (int i = 1; i < openSet.Count; i++)
                {
                    int score = fScore.ContainsKey(openSet[i]) ? fScore[openSet[i]] : int.MaxValue;
                    if (score < lowestF)
                    {
                        lowestF = score;
                        current = openSet[i];
                    }
                }

                if (current == end)
                {
                    return ReconstructPath(cameFrom, current);
                }

                openSet.Remove(current);

                var neighbors = GetWalkableNeighbors(current);
                foreach (var neighbor in neighbors)
                {
                    int tentativeG = gScore[current] + 1;
                    if (!gScore.ContainsKey(neighbor) || tentativeG < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeG;
                        fScore[neighbor] = tentativeG + Vector2Int.ManhattanDistance(neighbor, end);
                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            return new List<Vector2Int>(); // No path
        }

        private List<Vector2Int> GetWalkableNeighbors(Vector2Int p)
        {
            var list = new List<Vector2Int>();
            var directions = new[] { Vector2Int.Up, Vector2Int.Down, Vector2Int.Left, Vector2Int.Right };
            foreach (var dir in directions)
            {
                var next = p + dir;
                if (next.X >= 0 && next.X < _width && next.Y >= 0 && next.Y < _height)
                {
                    if (_grid[next.X, next.Y] >= 1)
                    {
                        list.Add(next);
                    }
                }
            }
            return list;
        }

        private List<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current)
        {
            var path = new List<Vector2Int> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Insert(0, current);
            }
            return path;
        }
    }
}
""")

write_file("DungeonSouls/Game/Core/SpatialAndPathfinding.cs", "\n".join(spatial_lines))

print("[+] Generated Core ECS and Spatial systems.")
