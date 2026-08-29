using System;

namespace DungeonSouls.Game.Core
{
    public struct Vector2Int : IEquatable<Vector2Int>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2Int Zero => new Vector2Int(0, 0);
        public static Vector2Int One => new Vector2Int(1, 1);
        public static Vector2Int Up => new Vector2Int(0, 1);
        public static Vector2Int Down => new Vector2Int(0, -1);
        public static Vector2Int Left => new Vector2Int(-1, 0);
        public static Vector2Int Right => new Vector2Int(1, 0);

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);
        public static Vector2Int operator *(Vector2Int a, int scalar) => new Vector2Int(a.X * scalar, a.Y * scalar);
        public static bool operator ==(Vector2Int a, Vector2Int b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2Int a, Vector2Int b) => !(a == b);

        public double Magnitude => Math.Sqrt(X * X + Y * Y);
        public int SqrMagnitude => X * X + Y * Y;

        public static int ManhattanDistance(Vector2Int a, Vector2Int b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public static double EuclideanDistance(Vector2Int a, Vector2Int b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public bool Equals(Vector2Int other) => X == other.X && Y == other.Y;
        public override bool Equals(object obj) => obj is Vector2Int other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => $"({X}, {Y})";
    }

    public struct RectInt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public RectInt(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int XMin => X;
        public int XMax => X + Width;
        public int YMin => Y;
        public int YMax => Y + Height;

        public Vector2Int Center => new Vector2Int(X + Width / 2, Y + Height / 2);

        public bool Contains(Vector2Int point)
        {
            return point.X >= X && point.X < X + Width && point.Y >= Y && point.Y < Y + Height;
        }

        public bool Overlaps(RectInt other, int padding = 0)
        {
            return X - padding < other.XMax + padding &&
                   XMax + padding > other.X - padding &&
                   Y - padding < other.YMax + padding &&
                   YMax + padding > other.Y - padding;
        }

        public override string ToString() => $"Rect({X}, {Y}, {Width}x{Height})";
    }

    public interface IRandomProvider
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
        double NextDouble();
        float NextFloat(float min, float max);
        bool NextBool(double chance = 0.5);
    }

    public class DeterministicRandom : IRandomProvider
    {
        private readonly Random _random;
        public int Seed { get; }

        public DeterministicRandom(int seed)
        {
            Seed = seed;
            _random = new Random(seed);
        }

        public int Next() => _random.Next();
        public int Next(int maxValue) => _random.Next(maxValue);
        public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
        public double NextDouble() => _random.NextDouble();
        public float NextFloat(float min, float max) => (float)(min + _random.NextDouble() * (max - min));
        public bool NextBool(double chance = 0.5) => _random.NextDouble() < chance;
    }
}
