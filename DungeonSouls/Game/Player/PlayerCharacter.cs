using System;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Game.Player
{
    public enum PlayerMovementState
    {
        Idle,
        Walking,
        Sprinting,
        Dodging,
        Dashing,
        Blocking,
        Attacking,
        Casting,
        Stunned,
        Dead
    }

    public class PlayerCharacter : ICombatant
    {
        public string EntityId { get; }
        public string DisplayName { get; set; }
        public bool IsPlayer => true;
        public bool IsAlive => CurrentHealth > 0;
        public Vector2Int Position { get; set; }
        public AttributeSet Attributes { get; }
        public StatusEffectContainer StatusEffects { get; }

        public double CurrentHealth { get; private set; }
        public double CurrentMana { get; private set; }
        public double CurrentStamina { get; private set; }

        public int Level { get; private set; }
        public long CurrentExperience { get; private set; }
        public long ExperienceToNextLevel => CalculateExpForLevel(Level);
        public int UnspentStatPoints { get; set; }
        public int UnspentSkillPoints { get; set; }
        public long Gold { get; set; }
        public long SoulEssence { get; set; }

        public PlayerMovementState MovementState { get; set; }
        public bool IsInvulnerable => MovementState == PlayerMovementState.Dodging;

        public event Action<double, double> OnHealthChanged;
        public event Action<double, double> OnManaChanged;
        public event Action<double, double> OnStaminaChanged;
        public event Action<int> OnLevelUp;
        public event Action OnDeath;

        public PlayerCharacter(string entityId, string displayName)
        {
            EntityId = entityId;
            DisplayName = displayName;
            Attributes = new AttributeSet();
            StatusEffects = new StatusEffectContainer(this);
            Level = 1;
            CurrentExperience = 0;
            UnspentStatPoints = 0;
            UnspentSkillPoints = 0;
            Gold = 0;
            SoulEssence = 0;
            Position = Vector2Int.Zero;
            MovementState = PlayerMovementState.Idle;

            CurrentHealth = Attributes.GetValue(StatType.MaxHealth);
            CurrentMana = Attributes.GetValue(StatType.MaxMana);
            CurrentStamina = Attributes.GetValue(StatType.MaxStamina);

            Attributes.OnStatChanged += HandleStatChanged;
        }

        private void HandleStatChanged(StatType stat, CharacterStat characterStat)
        {
            if (stat == StatType.MaxHealth && CurrentHealth > characterStat.Value)
                CurrentHealth = characterStat.Value;
            if (stat == StatType.MaxMana && CurrentMana > characterStat.Value)
                CurrentMana = characterStat.Value;
            if (stat == StatType.MaxStamina && CurrentStamina > characterStat.Value)
                CurrentStamina = characterStat.Value;
        }

        public void Update(double deltaTime)
        {
            if (!IsAlive) return;

            // 1. Status effects
            StatusEffects.Update(deltaTime);

            // 2. Regeneration
            if (CurrentHealth < Attributes.GetValue(StatType.MaxHealth))
            {
                double regen = Attributes.GetValue(StatType.HealthRegen) * deltaTime;
                CurrentHealth = Math.Min(Attributes.GetValue(StatType.MaxHealth), CurrentHealth + regen);
                OnHealthChanged?.Invoke(CurrentHealth, Attributes.GetValue(StatType.MaxHealth));
            }

            if (CurrentMana < Attributes.GetValue(StatType.MaxMana))
            {
                double regen = Attributes.GetValue(StatType.ManaRegen) * deltaTime;
                CurrentMana = Math.Min(Attributes.GetValue(StatType.MaxMana), CurrentMana + regen);
                OnManaChanged?.Invoke(CurrentMana, Attributes.GetValue(StatType.MaxMana));
            }

            if (MovementState != PlayerMovementState.Sprinting && CurrentStamina < Attributes.GetValue(StatType.MaxStamina))
            {
                double regen = Attributes.GetValue(StatType.StaminaRegen) * deltaTime;
                CurrentStamina = Math.Min(Attributes.GetValue(StatType.MaxStamina), CurrentStamina + regen);
                OnStaminaChanged?.Invoke(CurrentStamina, Attributes.GetValue(StatType.MaxStamina));
            }
        }

        public DamageResult TakeDamage(DamageInstance damage)
        {
            if (!IsAlive || IsInvulnerable)
            {
                return new DamageResult { HitResult = HitResultType.Immune, FinalDamageDealt = 0 };
            }

            var result = DamageCalculator.CalculateDamage(damage, damage.Source, this);
            double absorbed = StatusEffects.AbsorbDamage(result.FinalDamageDealt);
            CurrentHealth = Math.Max(0, CurrentHealth - absorbed);

            OnHealthChanged?.Invoke(CurrentHealth, Attributes.GetValue(StatType.MaxHealth));

            if (CurrentHealth <= 0)
            {
                result.WasLethal = true;
                MovementState = PlayerMovementState.Dead;
                OnDeath?.Invoke();
            }

            return result;
        }

        public void Heal(double amount, ICombatant source = null)
        {
            if (!IsAlive || amount <= 0) return;
            double maxHp = Attributes.GetValue(StatType.MaxHealth);
            CurrentHealth = Math.Min(maxHp, CurrentHealth + amount);
            OnHealthChanged?.Invoke(CurrentHealth, maxHp);
        }

        public void RestoreMana(double amount)
        {
            if (!IsAlive || amount <= 0) return;
            double maxMana = Attributes.GetValue(StatType.MaxMana);
            CurrentMana = Math.Min(maxMana, CurrentMana + amount);
            OnManaChanged?.Invoke(CurrentMana, maxMana);
        }

        public void RestoreStamina(double amount)
        {
            if (!IsAlive || amount <= 0) return;
            double maxStamina = Attributes.GetValue(StatType.MaxStamina);
            CurrentStamina = Math.Min(maxStamina, CurrentStamina + amount);
            OnStaminaChanged?.Invoke(CurrentStamina, maxStamina);
        }

        public bool ConsumeStamina(double amount)
        {
            if (CurrentStamina >= amount)
            {
                CurrentStamina -= amount;
                OnStaminaChanged?.Invoke(CurrentStamina, Attributes.GetValue(StatType.MaxStamina));
                return true;
            }
            return false;
        }

        public bool ConsumeMana(double amount)
        {
            if (CurrentMana >= amount)
            {
                CurrentMana -= amount;
                OnManaChanged?.Invoke(CurrentMana, Attributes.GetValue(StatType.MaxMana));
                return true;
            }
            return false;
        }

        public void ApplyKnockback(Vector2Int direction, double force)
        {
            if (force > 0)
            {
                Position += direction * (int)Math.Max(1, Math.Round(force));
            }
        }

        public void ApplyStun(double durationSeconds)
        {
            if (durationSeconds > 0)
            {
                StatusEffects.ApplyEffect(StatusEffectType.Stun, durationSeconds, 1.0, null);
                MovementState = PlayerMovementState.Stunned;
            }
        }

        public void AddExperience(long exp)
        {
            if (Level >= 50 || exp <= 0) return;

            CurrentExperience += exp;
            while (Level < 50 && CurrentExperience >= ExperienceToNextLevel)
            {
                CurrentExperience -= ExperienceToNextLevel;
                Level++;
                UnspentStatPoints += 5;
                UnspentSkillPoints += 1;

                // Base stat increase per level
                Attributes.SetBase(StatType.MaxHealth, Attributes.GetStat(StatType.MaxHealth).BaseValue + 15);
                Attributes.SetBase(StatType.MaxMana, Attributes.GetStat(StatType.MaxMana).BaseValue + 8);
                Attributes.SetBase(StatType.MaxStamina, Attributes.GetStat(StatType.MaxStamina).BaseValue + 5);
                Attributes.SetBase(StatType.AttackPower, Attributes.GetStat(StatType.AttackPower).BaseValue + 2);
                Attributes.SetBase(StatType.SpellPower, Attributes.GetStat(StatType.SpellPower).BaseValue + 2);

                CurrentHealth = Attributes.GetValue(StatType.MaxHealth);
                CurrentMana = Attributes.GetValue(StatType.MaxMana);
                CurrentStamina = Attributes.GetValue(StatType.MaxStamina);

                OnLevelUp?.Invoke(Level);
                EventBus.Publish(new PlayerLeveledUpEvent(Level, UnspentStatPoints, UnspentSkillPoints));
            }
        }

        public static long CalculateExpForLevel(int level)
        {
            // Exponential RPG level curve: Base 100 * level^1.8
            return (long)(100 * Math.Pow(level, 1.8));
        }

        public bool AllocateStatPoint(StatType stat)
        {
            if (UnspentStatPoints <= 0) return false;

            double increment = stat switch
            {
                StatType.Strength => 2,
                StatType.Dexterity => 2,
                StatType.Intelligence => 2,
                StatType.Defense => 3,
                StatType.MagicResistance => 2,
                StatType.MaxHealth => 20,
                StatType.MaxMana => 15,
                StatType.MaxStamina => 10,
                _ => 0
            };

            if (increment <= 0) return false;

            UnspentStatPoints--;
            Attributes.SetBase(stat, Attributes.GetStat(stat).BaseValue + increment);
            return true;
        }
    }
}
