using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Items;

namespace DungeonSouls.Game.Loot
{
    public class LootTableEntry
    {
        public string TemplateId { get; set; }
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public EquipmentSlot? Slot { get; set; }
        public WeaponType? WeaponType { get; set; }
        public double BaseDamage { get; set; }
        public double BaseDefense { get; set; }
        public int Weight { get; set; }

        public LootTableEntry(string templateId, string name, ItemCategory category, int weight, EquipmentSlot? slot = null, WeaponType? weaponType = null, double baseDmg = 0, double baseDef = 0)
        {
            TemplateId = templateId;
            Name = name;
            Category = category;
            Weight = weight;
            Slot = slot;
            WeaponType = weaponType;
            BaseDamage = baseDmg;
            BaseDefense = baseDef;
        }
    }

    public class LootGenerator
    {
        private readonly IRandomProvider _random;
        private readonly List<LootTableEntry> _table;

        public LootGenerator(IRandomProvider random = null)
        {
            _random = random ?? new DeterministicRandom(Environment.TickCount);
            _table = new List<LootTableEntry>();
            PopulateDefaultTable();
        }

        private void PopulateDefaultTable()
        {
            _table.Add(new LootTableEntry("wpn_shadow_blade", "Shadow Blade", ItemCategory.Weapon, 15, EquipmentSlot.MainHand, WeaponType.Sword, baseDmg: 28));
            _table.Add(new LootTableEntry("wpn_battleaxe", "Executioner Axe", ItemCategory.Weapon, 15, EquipmentSlot.MainHand, WeaponType.Axe, baseDmg: 35));
            _table.Add(new LootTableEntry("wpn_warhammer", "Titan Hammer", ItemCategory.Weapon, 10, EquipmentSlot.MainHand, WeaponType.Hammer, baseDmg: 42));
            _table.Add(new LootTableEntry("wpn_dagger", "Viper Dagger", ItemCategory.Weapon, 15, EquipmentSlot.MainHand, WeaponType.Dagger, baseDmg: 20));
            _table.Add(new LootTableEntry("wpn_bow", "Windrunner Bow", ItemCategory.Weapon, 15, EquipmentSlot.MainHand, WeaponType.Bow, baseDmg: 26));
            _table.Add(new LootTableEntry("wpn_staff", "Archmage Staff", ItemCategory.Weapon, 15, EquipmentSlot.MainHand, WeaponType.Staff, baseDmg: 22));
            _table.Add(new LootTableEntry("wpn_shield", "Aegis Shield", ItemCategory.Armor, 15, EquipmentSlot.OffHand, WeaponType.Shield, baseDef: 18));
            _table.Add(new LootTableEntry("arm_chest_iron", "Knight Cuirass", ItemCategory.Armor, 20, EquipmentSlot.Chest, baseDef: 30));
            _table.Add(new LootTableEntry("arm_helm_iron", "Iron Greathelm", ItemCategory.Armor, 20, EquipmentSlot.Helmet, baseDef: 16));
            _table.Add(new LootTableEntry("arm_boots_iron", "Greaves of Steel", ItemCategory.Armor, 20, EquipmentSlot.Boots, baseDef: 14));
            _table.Add(new LootTableEntry("arm_gloves_iron", "Gauntlets of Might", ItemCategory.Armor, 20, EquipmentSlot.Gloves, baseDef: 12));
            _table.Add(new LootTableEntry("acc_ring_fury", "Ring of Fury", ItemCategory.Armor, 25, EquipmentSlot.Ring1));
            _table.Add(new LootTableEntry("acc_amulet_life", "Amulet of Vitality", ItemCategory.Armor, 25, EquipmentSlot.Amulet));
            _table.Add(new LootTableEntry("mat_iron_ore", "Iron Ore", ItemCategory.Material, 40));
            _table.Add(new LootTableEntry("mat_magic_crystal", "Magic Crystal", ItemCategory.Material, 30));
            _table.Add(new LootTableEntry("con_health_potion", "Greater Health Potion", ItemCategory.Consumable, 50));
        }

        public ItemInstance GenerateItem(int dungeonFloor, ItemRarity? forcedRarity = null)
        {
            int totalWeight = 0;
            foreach (var e in _table) totalWeight += e.Weight;
            int roll = _random.Next(totalWeight);
            int current = 0;
            LootTableEntry chosen = _table[0];

            foreach (var e in _table)
            {
                current += e.Weight;
                if (roll < current)
                {
                    chosen = e;
                    break;
                }
            }

            var rarity = forcedRarity ?? RollRarity(dungeonFloor);
            var item = new ItemInstance(
                chosen.TemplateId,
                $"{rarity} {chosen.Name}",
                $"A powerful {rarity.ToString().ToLower()} artifact found in the dungeon depths.",
                chosen.Category,
                rarity,
                chosen.Slot,
                maxStack: chosen.Category == ItemCategory.Material || chosen.Category == ItemCategory.Consumable ? 99 : 1,
                buyValue: (int)(25 * (int)(rarity + 1) * (1 + dungeonFloor * 0.2)),
                reqLevel: Math.Max(1, dungeonFloor)
            );

            item.WeaponType = chosen.WeaponType;
            item.BaseDamage = chosen.BaseDamage * (1.0 + (int)rarity * 0.3);
            item.BaseDefense = chosen.BaseDefense * (1.0 + (int)rarity * 0.3);

            // Generate Random Affixes based on rarity
            int affixCount = (int)rarity;
            for (int i = 0; i < affixCount; i++)
            {
                item.Affixes.Add(GenerateRandomAffix(rarity));
            }

            return item;
        }

        public ItemRarity RollRarity(int dungeonFloor)
        {
            double r = _random.NextDouble() * 100.0;
            double mythicChance = 0.5 + dungeonFloor * 0.2;
            double legendaryChance = 2.5 + dungeonFloor * 0.5;
            double epicChance = 8.0 + dungeonFloor * 1.0;
            double rareChance = 20.0 + dungeonFloor * 1.5;
            double uncommonChance = 35.0;

            if (r < mythicChance) return ItemRarity.Mythic;
            r -= mythicChance;
            if (r < legendaryChance) return ItemRarity.Legendary;
            r -= legendaryChance;
            if (r < epicChance) return ItemRarity.Epic;
            r -= epicChance;
            if (r < rareChance) return ItemRarity.Rare;
            r -= rareChance;
            if (r < uncommonChance) return ItemRarity.Uncommon;
            return ItemRarity.Common;
        }

        private ItemAffix GenerateRandomAffix(ItemRarity rarity)
        {
            int statRoll = _random.Next(7);
            double mult = 1.0 + ((int)rarity * 0.4);

            return statRoll switch
            {
                0 => new ItemAffix("of Carnage", StatType.AttackPower, StatModType.PercentAdd, Math.Round(5 * mult, 1)),
                1 => new ItemAffix("of the Colossus", StatType.MaxHealth, StatModType.Flat, Math.Round(20 * mult, 0)),
                2 => new ItemAffix("of the Eagle", StatType.CriticalChance, StatModType.Flat, Math.Round(2.5 * mult, 1)),
                3 => new ItemAffix("of Quickness", StatType.AttackSpeed, StatModType.PercentAdd, Math.Round(4 * mult, 1)),
                4 => new ItemAffix("of the Leech", StatType.LifeStealPercent, StatModType.Flat, Math.Round(1.5 * mult, 1)),
                5 => new ItemAffix("of Fortification", StatType.Defense, StatModType.Flat, Math.Round(8 * mult, 0)),
                _ => new ItemAffix("of Swiftness", StatType.MovementSpeed, StatModType.PercentAdd, Math.Round(3 * mult, 1))
            };
        }
    }
}
