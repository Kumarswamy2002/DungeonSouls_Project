using System;
using System.Collections.Generic;
using DungeonSouls.Game.Classes;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Inventory;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Player;

namespace DungeonSouls.Game.Dialogue
{
    public class DialogueChoice
    {
        public string Text { get; set; }
        public string NextNodeId { get; set; }
        public Func<PlayerCharacter, bool> Condition { get; set; }
        public Action<PlayerCharacter> OnSelected { get; set; }

        public DialogueChoice(string text, string nextNodeId, Func<PlayerCharacter, bool> condition = null, Action<PlayerCharacter> onSelected = null)
        {
            Text = text;
            NextNodeId = nextNodeId;
            Condition = condition;
            OnSelected = onSelected;
        }

        public bool IsAvailable(PlayerCharacter player) => Condition == null || Condition(player);
    }

    public class DialogueNode
    {
        public string Id { get; }
        public string SpeakerName { get; }
        public string Text { get; }
        public List<DialogueChoice> Choices { get; }

        public DialogueNode(string id, string speaker, string text)
        {
            Id = id;
            SpeakerName = speaker;
            Text = text;
            Choices = new List<DialogueChoice>();
        }
    }

    public class DialogueGraph
    {
        public string RootNodeId { get; }
        public Dictionary<string, DialogueNode> Nodes { get; }

        public DialogueGraph(string rootNodeId)
        {
            RootNodeId = rootNodeId;
            Nodes = new Dictionary<string, DialogueNode>();
        }

        public void AddNode(DialogueNode node) => Nodes[node.Id] = node;
        public DialogueNode GetNode(string nodeId) => Nodes.TryGetValue(nodeId, out var n) ? n : null;
    }
}

namespace DungeonSouls.Game.Quests
{
    public enum QuestType
    {
        Kill,
        Collect,
        Explore,
        Boss,
        Challenge,
        Daily
    }

    public enum QuestState
    {
        Available,
        Accepted,
        InProgress,
        ObjectivesComplete,
        Completed,
        Failed
    }

    public class QuestObjective
    {
        public string Description { get; }
        public string TargetId { get; }
        public int TargetAmount { get; }
        public int CurrentAmount { get; set; }
        public bool IsComplete => CurrentAmount >= TargetAmount;

        public QuestObjective(string desc, string targetId, int amount)
        {
            Description = desc;
            TargetId = targetId;
            TargetAmount = amount;
            CurrentAmount = 0;
        }
    }

    public class Quest
    {
        public string Id { get; }
        public string Title { get; }
        public string Description { get; }
        public QuestType Type { get; }
        public QuestState State { get; set; }
        public int RequiredPlayerLevel { get; }
        public List<QuestObjective> Objectives { get; }
        public int GoldReward { get; }
        public long ExpReward { get; }
        public ItemInstance ItemReward { get; }

        public Quest(string id, string title, string desc, QuestType type, int reqLevel, int gold, long exp, ItemInstance itemReward = null)
        {
            Id = id;
            Title = title;
            Description = desc;
            Type = type;
            State = QuestState.Available;
            RequiredPlayerLevel = reqLevel;
            Objectives = new List<QuestObjective>();
            GoldReward = gold;
            ExpReward = exp;
            ItemReward = itemReward;
        }

        public bool CheckCompletion()
        {
            foreach (var obj in Objectives)
            {
                if (!obj.IsComplete) return false;
            }
            State = QuestState.ObjectivesComplete;
            return true;
        }
    }

    public class QuestManager
    {
        private readonly PlayerCharacter _player;
        private readonly InventoryManager _inventory;
        private readonly List<Quest> _allQuests;

        public event Action<Quest> OnQuestAccepted;
        public event Action<Quest> OnQuestCompleted;
        public event Action<Quest> OnQuestUpdated;

        public QuestManager(PlayerCharacter player, InventoryManager inventory)
        {
            _player = player;
            _inventory = inventory;
            _allQuests = new List<Quest>();

            EventBus.Subscribe<EnemyKilledEvent>(HandleEnemyKilled);
            EventBus.Subscribe<ItemLootedEvent>(HandleItemLooted);
            PopulateStarterQuests();
        }

        private void PopulateStarterQuests()
        {
            var q1 = new Quest("quest_crypt_cleanse", "Purge the Crypt", "Defeat the undead fiends haunting the Forgotten Crypt.", QuestType.Kill, 1, 100, 300);
            q1.Objectives.Add(new QuestObjective("Defeat Skeletons", "enemy_skeleton", 5));
            q1.Objectives.Add(new QuestObjective("Defeat Zombies", "enemy_zombie", 3));
            _allQuests.Add(q1);

            var q2 = new Quest("quest_slay_bone_king", "The Crown of Bones", "Defeat the Bone King residing at the heart of the crypt.", QuestType.Boss, 2, 250, 800);
            q2.Objectives.Add(new QuestObjective("Slay the Bone King", "boss_bone_king", 1));
            _allQuests.Add(q2);
        }

        public IReadOnlyList<Quest> AllQuests => _allQuests;

        public bool AcceptQuest(string questId)
        {
            var quest = _allQuests.Find(q => q.Id == questId);
            if (quest == null || quest.State != QuestState.Available) return false;
            if (_player.Level < quest.RequiredPlayerLevel) return false;

            quest.State = QuestState.InProgress;
            OnQuestAccepted?.Invoke(quest);
            return true;
        }

        public bool TurnInQuest(string questId)
        {
            var quest = _allQuests.Find(q => q.Id == questId);
            if (quest == null || quest.State != QuestState.ObjectivesComplete) return false;

            quest.State = QuestState.Completed;
            _player.Gold += quest.GoldReward;
            _player.AddExperience(quest.ExpReward);

            if (quest.ItemReward != null)
            {
                _inventory.AddItem(quest.ItemReward);
            }

            OnQuestCompleted?.Invoke(quest);
            return true;
        }

        private void HandleEnemyKilled(EnemyKilledEvent e)
        {
            foreach (var q in _allQuests)
            {
                if (q.State != QuestState.InProgress) continue;

                bool updated = false;
                foreach (var obj in q.Objectives)
                {
                    if (obj.TargetId == e.EnemyId && !obj.IsComplete)
                    {
                        obj.CurrentAmount++;
                        updated = true;
                    }
                }

                if (updated)
                {
                    q.CheckCompletion();
                    OnQuestUpdated?.Invoke(q);
                }
            }
        }

        private void HandleItemLooted(ItemLootedEvent e)
        {
            foreach (var q in _allQuests)
            {
                if (q.State != QuestState.InProgress) continue;

                bool updated = false;
                foreach (var obj in q.Objectives)
                {
                    if (obj.TargetId == e.ItemId && !obj.IsComplete)
                    {
                        obj.CurrentAmount += e.Quantity;
                        updated = true;
                    }
                }

                if (updated)
                {
                    q.CheckCompletion();
                    OnQuestUpdated?.Invoke(q);
                }
            }
        }
    }
}
