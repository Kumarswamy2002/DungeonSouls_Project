using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DungeonSouls.Game.Classes;
using DungeonSouls.Game.Inventory;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.Skills;

namespace DungeonSouls.Game.SaveSystem
{
    public class SaveGameData
    {
        public int SaveVersion { get; set; } = 1;
        public string SaveId { get; set; }
        public DateTime LastSavedUtc { get; set; }
        public string PlayerName { get; set; }
        public CharacterClassType ClassType { get; set; }
        public int Level { get; set; }
        public long CurrentExperience { get; set; }
        public long Gold { get; set; }
        public long SoulEssence { get; set; }
        public int UnspentStatPoints { get; set; }
        public int UnspentSkillPoints { get; set; }
        public int HighestFloorReached { get; set; }
        public int TotalRunsAttempted { get; set; }
        public int TotalBossesDefeated { get; set; }
        public Dictionary<string, int> SkillRanks { get; set; } = new Dictionary<string, int>();
        public List<string> UnlockedAchievements { get; set; } = new List<string>();
    }

    public static class SaveManager
    {
        public static string SerializeSave(SaveGameData data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(data, options);
        }

        public static SaveGameData DeserializeSave(string json)
        {
            var data = JsonSerializer.Deserialize<SaveGameData>(json);
            if (data != null && data.SaveVersion < 1)
            {
                // Future migration hooks
                data.SaveVersion = 1;
            }
            return data;
        }
    }
}

namespace DungeonSouls.Game.Progression
{
    public class RunStatistics
    {
        public int FloorReached { get; set; } = 1;
        public int EnemiesDefeated { get; set; }
        public int BossesDefeated { get; set; }
        public double DamageDealt { get; set; }
        public double DamageTaken { get; set; }
        public long GoldCollected { get; set; }
        public long SoulEssenceGained { get; set; }
        public double RunDurationSeconds { get; set; }
        public bool ClearedRun { get; set; }

        public void RecordEnemyKill(bool isBoss, int gold, int soulEssence)
        {
            EnemiesDefeated++;
            if (isBoss) BossesDefeated++;
            GoldCollected += gold;
            SoulEssenceGained += soulEssence;
        }
    }

    public class RunCoordinator
    {
        public PlayerCharacter Player { get; }
        public RunStatistics CurrentRunStats { get; private set; }
        public bool IsRunActive { get; private set; }

        public event Action<RunStatistics> OnRunFinished;

        public RunCoordinator(PlayerCharacter player)
        {
            Player = player;
            CurrentRunStats = new RunStatistics();
            Player.OnDeath += HandlePlayerDeath;
        }

        public void StartNewRun(int startingFloor = 1)
        {
            CurrentRunStats = new RunStatistics { FloorReached = startingFloor };
            IsRunActive = true;
        }

        public void UpdateRun(double deltaTime)
        {
            if (IsRunActive)
            {
                CurrentRunStats.RunDurationSeconds += deltaTime;
            }
        }

        private void HandlePlayerDeath()
        {
            if (IsRunActive)
            {
                IsRunActive = false;
                CurrentRunStats.ClearedRun = false;
                // Retain permanent soul essence in Sanctuary
                Player.SoulEssence += CurrentRunStats.SoulEssenceGained;
                OnRunFinished?.Invoke(CurrentRunStats);
            }
        }

        public void CompleteRunVictory()
        {
            if (IsRunActive)
            {
                IsRunActive = false;
                CurrentRunStats.ClearedRun = true;
                Player.SoulEssence += CurrentRunStats.SoulEssenceGained * 2; // Victory bonus
                OnRunFinished?.Invoke(CurrentRunStats);
            }
        }
    }
}

namespace DungeonSouls.Game.Audio
{
    public enum MusicTrackType
    {
        MainMenu,
        Sanctuary,
        DungeonExploration,
        Combat,
        BossFight,
        Victory,
        Defeat
    }

    public class AudioManager
    {
        public MusicTrackType CurrentTrack { get; private set; }
        public float MasterVolume { get; set; } = 1.0f;
        public float MusicVolume { get; set; } = 0.8f;
        public float SfxVolume { get; set; } = 0.9f;

        public event Action<MusicTrackType> OnTrackChanged;

        public void PlayTrack(MusicTrackType track)
        {
            if (CurrentTrack != track)
            {
                CurrentTrack = track;
                OnTrackChanged?.Invoke(track);
            }
        }
    }
}
