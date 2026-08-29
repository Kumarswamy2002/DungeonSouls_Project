using System;
using System.Collections.Generic;

namespace DungeonSouls.Game.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T Value { get; }
        public string Error { get; }

        protected Result(bool isSuccess, T value, string error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string error) => new Result<T>(false, default, error);
    }

    public static class EventBus
    {
        private static readonly Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

        public static void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (!_subscribers.TryGetValue(type, out var list))
            {
                list = new List<Delegate>();
                _subscribers[type] = list;
            }
            list.Add(handler);
        }

        public static void Unsubscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (_subscribers.TryGetValue(type, out var list))
            {
                list.Remove(handler);
            }
        }

        public static void Publish<T>(T eventArgs)
        {
            var type = typeof(T);
            if (_subscribers.TryGetValue(type, out var list))
            {
                var copy = new List<Delegate>(list);
                foreach (var handler in copy)
                {
                    ((Action<T>)handler)?.Invoke(eventArgs);
                }
            }
        }

        public static void Clear()
        {
            _subscribers.Clear();
        }
    }

    public struct PlayerLeveledUpEvent
    {
        public int NewLevel { get; }
        public int UnspentStatPoints { get; }
        public int UnspentSkillPoints { get; }

        public PlayerLeveledUpEvent(int newLevel, int statPoints, int skillPoints)
        {
            NewLevel = newLevel;
            UnspentStatPoints = statPoints;
            UnspentSkillPoints = skillPoints;
        }
    }

    public struct EnemyKilledEvent
    {
        public string EnemyId { get; }
        public string EnemyName { get; }
        public bool IsBoss { get; }
        public int ExpReward { get; }
        public int GoldReward { get; }
        public Vector2Int Position { get; }

        public EnemyKilledEvent(string enemyId, string enemyName, bool isBoss, int exp, int gold, Vector2Int pos)
        {
            EnemyId = enemyId;
            EnemyName = enemyName;
            IsBoss = isBoss;
            ExpReward = exp;
            GoldReward = gold;
            Position = pos;
        }
    }

    public struct ItemLootedEvent
    {
        public string ItemId { get; }
        public string ItemName { get; }
        public int Quantity { get; }

        public ItemLootedEvent(string itemId, string itemName, int quantity)
        {
            ItemId = itemId;
            ItemName = itemName;
            Quantity = quantity;
        }
    }

    public struct DungeonFloorCompletedEvent
    {
        public int FloorNumber { get; }
        public string BiomeName { get; }
        public float ClearTimeSeconds { get; }

        public DungeonFloorCompletedEvent(int floor, string biome, float clearTime)
        {
            FloorNumber = floor;
            BiomeName = biome;
            ClearTimeSeconds = clearTime;
        }
    }
}
