using System;
using System.Collections.Generic;
using DungeonSouls.Game.Classes;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Inventory;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Player;

namespace DungeonSouls.Game.NPC
{
    public enum NPCType
    {
        Blacksmith,
        Merchant,
        Mage,
        Healer,
        QuestMaster,
        Alchemist,
        StorageKeeper,
        ClassTrainer,
        StoryNPC
    }

    public class NPCCharacter
    {
        public string Id { get; }
        public string Name { get; }
        public NPCType Type { get; }
        public string Title { get; }
        public int ReputationWithPlayer { get; set; }

        public NPCCharacter(string id, string name, NPCType type, string title)
        {
            Id = id;
            Name = name;
            Type = type;
            Title = title;
            ReputationWithPlayer = 0;
        }
    }
}

namespace DungeonSouls.Game.World
{
    public class SanctuaryHub
    {
        public List<NPC.NPCCharacter> NPCs { get; }
        public bool PortalActive { get; set; } = true;
        public int CurrentDungeonTierUnlocked { get; set; } = 1;

        public SanctuaryHub()
        {
            NPCs = new List<NPC.NPCCharacter>
            {
                new NPC.NPCCharacter("npc_blacksmith", "Goran the Ironforged", NPC.NPCType.Blacksmith, "Master Armorsmith"),
                new NPC.NPCCharacter("npc_merchant", "Lyra Silvertongue", NPC.NPCType.Merchant, "Traveling Trader"),
                new NPC.NPCCharacter("npc_alchemist", "Eldrin the Brewer", NPC.NPCType.Alchemist, "Grand Herbalist"),
                new NPC.NPCCharacter("npc_healer", "Sister Beatrice", NPC.NPCType.Healer, "Priestess of the Dawn"),
                new NPC.NPCCharacter("npc_questmaster", "Commander Valerie", NPC.NPCType.QuestMaster, "Warden of Eldoria"),
                new NPC.NPCCharacter("npc_trainer", "Master Kaiden", NPC.NPCType.ClassTrainer, "Combat Veteran"),
                new NPC.NPCCharacter("npc_storage", "Barnaby", NPC.NPCType.StorageKeeper, "Vault Keeper")
            };
        }
    }
}
