using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Player;

namespace DungeonSouls.Game.Inventory
{
    public class EquipmentManager
    {
        private readonly PlayerCharacter _player;
        private readonly Dictionary<EquipmentSlot, ItemInstance> _equippedItems;

        public event Action<EquipmentSlot, ItemInstance> OnItemEquipped;
        public event Action<EquipmentSlot, ItemInstance> OnItemUnequipped;

        public EquipmentManager(PlayerCharacter player)
        {
            _player = player;
            _equippedItems = new Dictionary<EquipmentSlot, ItemInstance>();
        }

        public ItemInstance GetEquipped(EquipmentSlot slot)
        {
            _equippedItems.TryGetValue(slot, out var item);
            return item;
        }

        public bool Equip(ItemInstance item, out ItemInstance previousItem)
        {
            previousItem = null;
            if (item == null || !item.EquipSlot.HasValue) return false;
            if (_player.Level < item.RequiredLevel) return false;

            var slot = item.EquipSlot.Value;
            if (_equippedItems.TryGetValue(slot, out var existing))
            {
                Unequip(slot);
                previousItem = existing;
            }

            _equippedItems[slot] = item;
            ApplyItemStats(item);
            OnItemEquipped?.Invoke(slot, item);
            return true;
        }

        public bool Unequip(EquipmentSlot slot)
        {
            if (_equippedItems.TryGetValue(slot, out var item))
            {
                RemoveItemStats(item);
                _equippedItems.Remove(slot);
                OnItemUnequipped?.Invoke(slot, item);
                return true;
            }
            return false;
        }

        private void ApplyItemStats(ItemInstance item)
        {
            if (item.BaseDamage > 0)
            {
                _player.Attributes.AddModifier(StatType.AttackPower, new StatModifier(item.BaseDamage, StatModType.Flat, item));
            }
            if (item.BaseDefense > 0)
            {
                _player.Attributes.AddModifier(StatType.Defense, new StatModifier(item.BaseDefense, StatModType.Flat, item));
            }

            foreach (var affix in item.Affixes)
            {
                _player.Attributes.AddModifier(affix.TargetStat, new StatModifier(affix.Value, affix.ModifierType, item));
            }
        }

        private void RemoveItemStats(ItemInstance item)
        {
            _player.Attributes.RemoveAllModifiersFromSource(item);
        }

        public IReadOnlyDictionary<EquipmentSlot, ItemInstance> AllEquipped => _equippedItems;
    }

    public class InventoryManager
    {
        public int Capacity { get; set; }
        private readonly List<ItemInstance> _slots;

        public event Action OnInventoryChanged;

        public InventoryManager(int capacity = 30)
        {
            Capacity = capacity;
            _slots = new List<ItemInstance>();
        }

        public IReadOnlyList<ItemInstance> Items => _slots;
        public int Count => _slots.Count;
        public bool IsFull => _slots.Count >= Capacity;

        public bool AddItem(ItemInstance item)
        {
            if (item == null) return false;

            // 1. Try stackable items
            if (item.MaxStack > 1)
            {
                var existing = _slots.Find(i => i.TemplateId == item.TemplateId && i.StackCount < i.MaxStack);
                if (existing != null)
                {
                    int space = existing.MaxStack - existing.StackCount;
                    int toAdd = Math.Min(space, item.StackCount);
                    existing.StackCount += toAdd;
                    item.StackCount -= toAdd;

                    if (item.StackCount <= 0)
                    {
                        OnInventoryChanged?.Invoke();
                        return true;
                    }
                }
            }

            // 2. Add to new slot if space
            if (_slots.Count < Capacity)
            {
                _slots.Add(item);
                OnInventoryChanged?.Invoke();
                return true;
            }

            return false;
        }

        public bool RemoveItem(string instanceId, int count = 1)
        {
            var item = _slots.Find(i => i.InstanceId == instanceId);
            if (item == null) return false;

            if (item.StackCount > count)
            {
                item.StackCount -= count;
            }
            else
            {
                _slots.Remove(item);
            }

            OnInventoryChanged?.Invoke();
            return true;
        }

        public void SortByRarity()
        {
            _slots.Sort((a, b) => b.Rarity.CompareTo(a.Rarity));
            OnInventoryChanged?.Invoke();
        }

        public void SortByName()
        {
            _slots.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
            OnInventoryChanged?.Invoke();
        }

        public void Clear()
        {
            _slots.Clear();
            OnInventoryChanged?.Invoke();
        }
    }
}
