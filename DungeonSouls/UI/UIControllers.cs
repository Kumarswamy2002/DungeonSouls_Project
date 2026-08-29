using System;
using System.Collections.Generic;
using DungeonSouls.Game.Abilities;
using DungeonSouls.Game.Bosses;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Inventory;
using DungeonSouls.Game.Items;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.Progression;
using DungeonSouls.Game.Skills;

namespace DungeonSouls.UI.HUD
{
    public class HUDViewModel
    {
        public double CurrentHealth { get; set; }
        public double MaxHealth { get; set; }
        public double CurrentMana { get; set; }
        public double MaxMana { get; set; }
        public double CurrentStamina { get; set; }
        public double MaxStamina { get; set; }
        public int Level { get; set; }
        public long CurrentExp { get; set; }
        public long ExpToNextLevel { get; set; }
        public long Gold { get; set; }
        public long SoulEssence { get; set; }
        public int CurrentFloor { get; set; }

        public string ActiveBossName { get; set; }
        public double BossHealthPercent { get; set; }
        public bool IsBossActive { get; set; }
    }

    public class HUDController
    {
        private readonly PlayerCharacter _player;
        public HUDViewModel ViewModel { get; }

        public event Action<HUDViewModel> OnViewModelUpdated;

        public HUDController(PlayerCharacter player)
        {
            _player = player;
            ViewModel = new HUDViewModel();
            _player.OnHealthChanged += (cur, max) => Refresh();
            _player.OnManaChanged += (cur, max) => Refresh();
            _player.OnStaminaChanged += (cur, max) => Refresh();
            _player.OnLevelUp += (lvl) => Refresh();
            Refresh();
        }

        public void Refresh()
        {
            ViewModel.CurrentHealth = _player.CurrentHealth;
            ViewModel.MaxHealth = _player.Attributes.GetValue(StatType.MaxHealth);
            ViewModel.CurrentMana = _player.CurrentMana;
            ViewModel.MaxMana = _player.Attributes.GetValue(StatType.MaxMana);
            ViewModel.CurrentStamina = _player.CurrentStamina;
            ViewModel.MaxStamina = _player.Attributes.GetValue(StatType.MaxStamina);
            ViewModel.Level = _player.Level;
            ViewModel.CurrentExp = _player.CurrentExperience;
            ViewModel.ExpToNextLevel = _player.ExperienceToNextLevel;
            ViewModel.Gold = _player.Gold;
            ViewModel.SoulEssence = _player.SoulEssence;

            OnViewModelUpdated?.Invoke(ViewModel);
        }

        public void SetBossTarget(BossCharacter boss)
        {
            if (boss != null && boss.IsAlive)
            {
                ViewModel.IsBossActive = true;
                ViewModel.ActiveBossName = boss.DisplayName;
                ViewModel.BossHealthPercent = (boss.CurrentHealth / boss.MaxHealthValue) * 100.0;
            }
            else
            {
                ViewModel.IsBossActive = false;
                ViewModel.ActiveBossName = null;
                ViewModel.BossHealthPercent = 0;
            }
            OnViewModelUpdated?.Invoke(ViewModel);
        }
    }
}

namespace DungeonSouls.UI.RunSummary
{
    public class RunSummaryUIController
    {
        public bool IsVisible { get; private set; }
        public RunStatistics DisplayedStats { get; private set; }

        public event Action<RunStatistics> OnShowSummary;

        public void Show(RunStatistics stats)
        {
            DisplayedStats = stats;
            IsVisible = true;
            OnShowSummary?.Invoke(stats);
        }

        public void Close()
        {
            IsVisible = false;
        }
    }
}
