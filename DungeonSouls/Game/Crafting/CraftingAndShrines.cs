using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Inventory;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Game.Crafting
{
    public class CraftingIngredient
    {
        public string TemplateId { get; }
        public string ItemName { get; }
        public int QuantityRequired { get; }

        public CraftingIngredient(string templateId, string itemName, int quantity)
        {
            TemplateId = templateId;
            ItemName = itemName;
            QuantityRequired = quantity;
        }
    }

    public class CraftingRecipe
    {
        public string RecipeId { get; }
        public string OutputName { get; }
        public ItemCategory Category { get; }
        public int GoldCost { get; }
        public List<CraftingIngredient> Ingredients { get; }
        public ItemInstance ResultTemplate { get; }

        public CraftingRecipe(string id, string name, ItemCategory category, int goldCost, List<CraftingIngredient> ingredients, ItemInstance result)
        {
            RecipeId = id;
            OutputName = name;
            Category = category;
            GoldCost = goldCost;
            Ingredients = ingredients;
            ResultTemplate = result;
        }
    }

    public class CraftingStation
    {
        public string StationName { get; }
        public List<CraftingRecipe> Recipes { get; }

        public CraftingStation(string name)
        {
            StationName = name;
            Recipes = new List<CraftingRecipe>();
            PopulateDefaultRecipes();
        }

        private void PopulateDefaultRecipes()
        {
            var ironSword = new ItemInstance("wpn_crafted_iron_sword", "Masterwork Broadsword", "A sturdy blade forged from refined iron and crystal.", ItemCategory.Weapon, ItemRarity.Rare, EquipmentSlot.MainHand)
            {
                BaseDamage = 45,
                WeaponType = WeaponType.Sword
            };
            ironSword.Affixes.Add(new ItemAffix("of Sharpness", StatType.AttackPower, StatModType.PercentAdd, 15));

            Recipes.Add(new CraftingRecipe("recipe_iron_sword", "Masterwork Broadsword", ItemCategory.Weapon, 150, new List<CraftingIngredient>
            {
                new CraftingIngredient("mat_iron_ore", "Iron Ore", 5),
                new CraftingIngredient("mat_magic_crystal", "Magic Crystal", 2)
            }, ironSword));

            var greaterPotion = new ItemInstance("con_health_potion", "Greater Health Potion", "Restores 150 health.", ItemCategory.Consumable, ItemRarity.Uncommon, maxStack: 99);
            Recipes.Add(new CraftingRecipe("recipe_hp_potion", "Greater Health Potion", ItemCategory.Consumable, 50, new List<CraftingIngredient>
            {
                new CraftingIngredient("mat_magic_crystal", "Magic Crystal", 1)
            }, greaterPotion));
        }

        public bool CanCraft(CraftingRecipe recipe, PlayerCharacter player, InventoryManager inventory)
        {
            if (player.Gold < recipe.GoldCost) return false;
            if (inventory.IsFull) return false;

            foreach (var ing in recipe.Ingredients)
            {
                int countInBag = 0;
                foreach (var item in inventory.Items)
                {
                    if (item.TemplateId == ing.TemplateId) countInBag += item.StackCount;
                }
                if (countInBag < ing.QuantityRequired) return false;
            }

            return true;
        }

        public bool Craft(CraftingRecipe recipe, PlayerCharacter player, InventoryManager inventory)
        {
            if (!CanCraft(recipe, player, inventory)) return false;

            player.Gold -= recipe.GoldCost;
            foreach (var ing in recipe.Ingredients)
            {
                int needed = ing.QuantityRequired;
                for (int i = inventory.Items.Count - 1; i >= 0 && needed > 0; i--)
                {
                    var item = inventory.Items[i];
                    if (item.TemplateId == ing.TemplateId)
                    {
                        int remove = Math.Min(needed, item.StackCount);
                        inventory.RemoveItem(item.InstanceId, remove);
                        needed -= remove;
                    }
                }
            }

            // Create fresh instance
            var craftedItem = new ItemInstance(recipe.ResultTemplate.TemplateId, recipe.ResultTemplate.Name, recipe.ResultTemplate.Description, recipe.ResultTemplate.Category, recipe.ResultTemplate.Rarity, recipe.ResultTemplate.EquipSlot, recipe.ResultTemplate.MaxStack)
            {
                BaseDamage = recipe.ResultTemplate.BaseDamage,
                BaseDefense = recipe.ResultTemplate.BaseDefense,
                WeaponType = recipe.ResultTemplate.WeaponType
            };
            foreach (var aff in recipe.ResultTemplate.Affixes)
            {
                craftedItem.Affixes.Add(aff);
            }

            inventory.AddItem(craftedItem);
            return true;
        }
    }
}

namespace DungeonSouls.Game.Relics
{
    public class RelicInstance
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public StatType BonusStat { get; }
        public StatModType ModType { get; }
        public double Value { get; }

        public RelicInstance(string id, string name, string desc, StatType stat, StatModType modType, double value)
        {
            Id = id;
            Name = name;
            Description = desc;
            BonusStat = stat;
            ModType = modType;
            Value = value;
        }
    }

    public class RelicManager
    {
        private readonly PlayerCharacter _player;
        private readonly List<RelicInstance> _activeRelics;

        public event Action<RelicInstance> OnRelicAcquired;

        public RelicManager(PlayerCharacter player)
        {
            _player = player;
            _activeRelics = new List<RelicInstance>();
        }

        public IReadOnlyList<RelicInstance> ActiveRelics => _activeRelics;

        public void AddRelic(RelicInstance relic)
        {
            _activeRelics.Add(relic);
            _player.Attributes.AddModifier(relic.BonusStat, new StatModifier(relic.Value, relic.ModType, relic));
            OnRelicAcquired?.Invoke(relic);
        }
    }
}

namespace DungeonSouls.Game.Shrines
{
    public enum ShrineType
    {
        BloodShrine,     // Sacrifice HP for Attack Power
        ManaShrine,      // Instant Mana recharge + Spell Power boost
        FortitudeShrine, // Gain Shield & Defense
        GreedShrine      // Gain Gold, take damage
    }

    public class Shrine
    {
        public string Id { get; }
        public ShrineType Type { get; }
        public string Name { get; }
        public string Prompt { get; }
        public bool IsUsed { get; private set; }

        public Shrine(string id, ShrineType type, string name, string prompt)
        {
            Id = id;
            Type = type;
            Name = name;
            Prompt = prompt;
            IsUsed = false;
        }

        public bool Activate(PlayerCharacter player)
        {
            if (IsUsed || !player.IsAlive) return false;

            switch (Type)
            {
                case ShrineType.BloodShrine:
                    double hpCost = player.Attributes.GetValue(StatType.MaxHealth) * 0.25;
                    if (player.CurrentHealth <= hpCost) return false;
                    player.TakeDamage(new DamageInstance(hpCost, DamageType.TrueDamage));
                    player.StatusEffects.ApplyEffect(StatusEffectType.AttackBoost, 30.0, 40.0, player);
                    break;
                case ShrineType.ManaShrine:
                    player.RestoreMana(player.Attributes.GetValue(StatType.MaxMana));
                    player.Attributes.AddModifier(StatType.SpellPower, new StatModifier(25, StatModType.PercentAdd, this));
                    break;
                case ShrineType.FortitudeShrine:
                    player.StatusEffects.ApplyEffect(StatusEffectType.Shield, 60.0, 150.0, player);
                    player.StatusEffects.ApplyEffect(StatusEffectType.DefenseBoost, 60.0, 30.0, player);
                    break;
                case ShrineType.GreedShrine:
                    player.Gold += 200;
                    player.TakeDamage(new DamageInstance(30, DamageType.TrueDamage));
                    break;
            }

            IsUsed = true;
            return true;
        }
    }
}
