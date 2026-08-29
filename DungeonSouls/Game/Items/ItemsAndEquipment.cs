using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;

namespace DungeonSouls.Game.Items
{
    public enum ItemRarity
    {
        Common = 0,
        Uncommon = 1,
        Rare = 2,
        Epic = 3,
        Legendary = 4,
        Mythic = 5
    }

    public enum ItemCategory
    {
        Weapon,
        Armor,
        Relic,
        Consumable,
        Material,
        QuestItem
    }

    public enum EquipmentSlot
    {
        MainHand,
        OffHand,
        Helmet,
        Chest,
        Gloves,
        Boots,
        Ring1,
        Ring2,
        Amulet
    }

    public enum WeaponType
    {
        Sword,
        Axe,
        Hammer,
        Dagger,
        Spear,
        Bow,
        Staff,
        Wand,
        Shield
    }

    public class ItemAffix
    {
        public string Name { get; }
        public StatType TargetStat { get; }
        public StatModType ModifierType { get; }
        public double Value { get; }

        public ItemAffix(string name, StatType targetStat, StatModType modType, double value)
        {
            Name = name;
            TargetStat = targetStat;
            ModifierType = modType;
            Value = value;
        }

        public override string ToString()
        {
            string sign = Value >= 0 ? "+" : "";
            string suffix = ModifierType == StatModType.Flat ? "" : "%";
            return $"{sign}{Value}{suffix} {TargetStat}";
        }
    }

    public class ItemInstance
    {
        public string InstanceId { get; }
        public string TemplateId { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; }
        public ItemRarity Rarity { get; set; }
        public EquipmentSlot? EquipSlot { get; set; }
        public WeaponType? WeaponType { get; set; }
        public int StackCount { get; set; }
        public int MaxStack { get; }
        public int BuyValue { get; set; }
        public int SellValue => Math.Max(1, BuyValue / 3);
        public int RequiredLevel { get; set; }
        public double BaseDamage { get; set; }
        public double BaseDefense { get; set; }
        public double AttackSpeed { get; set; }
        public double Range { get; set; }
        public DamageType DamageType { get; set; }
        public List<ItemAffix> Affixes { get; }

        public ItemInstance(
            string templateId, string name, string desc, ItemCategory category, ItemRarity rarity,
            EquipmentSlot? slot = null, int maxStack = 1, int buyValue = 10, int reqLevel = 1)
        {
            InstanceId = Guid.NewGuid().ToString();
            TemplateId = templateId;
            Name = name;
            Description = desc;
            Category = category;
            Rarity = rarity;
            EquipSlot = slot;
            StackCount = 1;
            MaxStack = maxStack;
            BuyValue = buyValue;
            RequiredLevel = reqLevel;
            BaseDamage = 0;
            BaseDefense = 0;
            AttackSpeed = 1.0;
            Range = 1.5;
            DamageType = DamageType.Physical;
            Affixes = new List<ItemAffix>();
        }
    }
}
