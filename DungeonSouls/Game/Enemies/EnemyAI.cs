using System;
using System.Collections.Generic;
using DungeonSouls.Game.Combat;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Player;
using DungeonSouls.Game.StatusEffects;

namespace DungeonSouls.Game.AI
{
    public enum AIState
    {
        Idle,
        Patrol,
        Wander,
        Detect,
        Chase,
        Attack,
        Flee,
        Search,
        Stunned,
        Dead
    }

    public class EnemyPerception
    {
        public double SightRange { get; set; } = 8.0;
        public double HearingRange { get; set; } = 12.0;
        public double AttackRange { get; set; } = 1.5;
        public double LoseTargetRange { get; set; } = 14.0;

        public bool CanSeeTarget(Vector2Int myPos, Vector2Int targetPos)
        {
            double dist = Vector2Int.EuclideanDistance(myPos, targetPos);
            return dist <= SightRange;
        }

        public bool IsInAttackRange(Vector2Int myPos, Vector2Int targetPos)
        {
            double dist = Vector2Int.EuclideanDistance(myPos, targetPos);
            return dist <= AttackRange;
        }
    }
}

namespace DungeonSouls.Game.Enemies
{
    public enum EnemyTier
    {
        Common,
        Advanced,
        Elite,
        Boss
    }

    public class EnemyCharacter : ICombatant
    {
        public string EntityId { get; }
        public string DisplayName { get; }
        public bool IsPlayer => false;
        public bool IsAlive => CurrentHealth > 0;
        public Vector2Int Position { get; set; }
        public AttributeSet Attributes { get; }
        public StatusEffectContainer StatusEffects { get; }
        public AI.EnemyPerception Perception { get; }
        public AI.AIState CurrentState { get; set; }
        public EnemyTier Tier { get; }

        public double CurrentHealth { get; private set; }
        public double CurrentMana { get; private set; }
        public double CurrentStamina { get; private set; }

        public int ExpValue { get; set; }
        public int GoldReward { get; set; }
        public double AttackCooldown { get; set; } = 1.5;
        public double TimeUntilNextAttack { get; set; } = 0;

        public event Action<DamageResult> OnDamageTaken;
        public event Action OnDeath;

        public EnemyCharacter(string entityId, string name, EnemyTier tier, double hp, double atk, double def, int exp, int gold)
        {
            EntityId = entityId;
            DisplayName = name;
            Tier = tier;
            Attributes = new AttributeSet();
            StatusEffects = new StatusEffectContainer(this);
            Perception = new AI.EnemyPerception();
            CurrentState = AI.AIState.Idle;

            Attributes.SetBase(StatType.MaxHealth, hp);
            Attributes.SetBase(StatType.AttackPower, atk);
            Attributes.SetBase(StatType.Defense, def);
            Attributes.SetBase(StatType.MovementSpeed, 3.5);

            CurrentHealth = hp;
            CurrentMana = 50;
            CurrentStamina = 100;
            ExpValue = exp;
            GoldReward = gold;
            Position = Vector2Int.Zero;
        }

        public void UpdateAI(double deltaTime, PlayerCharacter player)
        {
            if (!IsAlive) return;

            StatusEffects.Update(deltaTime);
            if (TimeUntilNextAttack > 0) TimeUntilNextAttack -= deltaTime;

            if (StatusEffects.IsStunned)
            {
                CurrentState = AI.AIState.Stunned;
                return;
            }

            if (player == null || !player.IsAlive)
            {
                CurrentState = AI.AIState.Idle;
                return;
            }

            double distToPlayer = Vector2Int.EuclideanDistance(Position, player.Position);

            // State Machine Transition
            switch (CurrentState)
            {
                case AI.AIState.Idle:
                case AI.AIState.Patrol:
                case AI.AIState.Wander:
                    if (distToPlayer <= Perception.SightRange)
                    {
                        CurrentState = AI.AIState.Chase;
                    }
                    break;

                case AI.AIState.Chase:
                    if (distToPlayer > Perception.LoseTargetRange)
                    {
                        CurrentState = AI.AIState.Idle;
                    }
                    else if (distToPlayer <= Perception.AttackRange)
                    {
                        CurrentState = AI.AIState.Attack;
                    }
                    else
                    {
                        // Move towards player
                        StepTowards(player.Position);
                    }
                    break;

                case AI.AIState.Attack:
                    if (distToPlayer > Perception.AttackRange)
                    {
                        CurrentState = AI.AIState.Chase;
                    }
                    else if (TimeUntilNextAttack <= 0)
                    {
                        PerformAttack(player);
                    }
                    break;

                case AI.AIState.Stunned:
                    if (!StatusEffects.IsStunned)
                    {
                        CurrentState = AI.AIState.Chase;
                    }
                    break;
            }
        }

        private void StepTowards(Vector2Int targetPos)
        {
            int dx = Math.Sign(targetPos.X - Position.X);
            int dy = Math.Sign(targetPos.Y - Position.Y);
            Position = new Vector2Int(Position.X + dx, Position.Y + dy);
        }

        protected virtual void PerformAttack(PlayerCharacter player)
        {
            TimeUntilNextAttack = AttackCooldown;
            double dmg = Attributes.GetValue(StatType.AttackPower);
            player.TakeDamage(new DamageInstance(dmg, DamageType.Physical, this));
        }

        public DamageResult TakeDamage(DamageInstance damage)
        {
            if (!IsAlive) return new DamageResult { HitResult = HitResultType.Immune };

            var result = DamageCalculator.CalculateDamage(damage, damage.Source, this);
            double absorbed = StatusEffects.AbsorbDamage(result.FinalDamageDealt);
            CurrentHealth = Math.Max(0, CurrentHealth - absorbed);

            OnDamageTaken?.Invoke(result);

            if (CurrentState == AI.AIState.Idle)
            {
                CurrentState = AI.AIState.Chase;
            }

            if (CurrentHealth <= 0)
            {
                result.WasLethal = true;
                CurrentState = AI.AIState.Dead;
                OnDeath?.Invoke();
                EventBus.Publish(new EnemyKilledEvent(EntityId, DisplayName, Tier == EnemyTier.Boss, ExpValue, GoldReward, Position));
            }

            return result;
        }

        public void Heal(double amount, ICombatant source = null)
        {
            if (!IsAlive) return;
            CurrentHealth = Math.Min(Attributes.GetValue(StatType.MaxHealth), CurrentHealth + amount);
        }

        public void RestoreMana(double amount) => CurrentMana = Math.Min(Attributes.GetValue(StatType.MaxMana), CurrentMana + amount);
        public void RestoreStamina(double amount) => CurrentStamina = Math.Min(Attributes.GetValue(StatType.MaxStamina), CurrentStamina + amount);
        public bool ConsumeStamina(double amount) { if (CurrentStamina >= amount) { CurrentStamina -= amount; return true; } return false; }
        public bool ConsumeMana(double amount) { if (CurrentMana >= amount) { CurrentMana -= amount; return true; } return false; }
        public void ApplyKnockback(Vector2Int direction, double force) => Position += direction * (int)Math.Max(1, Math.Round(force));
        public void ApplyStun(double durationSeconds) { StatusEffects.ApplyEffect(StatusEffectType.Stun, durationSeconds, 1.0, null); CurrentState = AI.AIState.Stunned; }
    }

    public static class EnemyFactory
    {
        public static EnemyCharacter CreateEnemy(string type, int floorLevel)
        {
            double scale = 1.0 + (floorLevel - 1) * 0.25;

            return type.ToLower() switch
            {
                "goblin" => new EnemyCharacter("enemy_goblin", "Goblin Scavenger", EnemyTier.Common, 45 * scale, 12 * scale, 5 * scale, (int)(25 * scale), (int)(10 * scale)),
                "skeleton" => new EnemyCharacter("enemy_skeleton", "Skeletal Warrior", EnemyTier.Common, 60 * scale, 16 * scale, 10 * scale, (int)(35 * scale), (int)(15 * scale)),
                "zombie" => new EnemyCharacter("enemy_zombie", "Plague Zombie", EnemyTier.Common, 90 * scale, 14 * scale, 8 * scale, (int)(40 * scale), (int)(12 * scale)),
                "slime" => new EnemyCharacter("enemy_slime", "Corrosive Slime", EnemyTier.Common, 50 * scale, 10 * scale, 15 * scale, (int)(30 * scale), (int)(14 * scale)),
                "orc" => new EnemyCharacter("enemy_orc", "Orc Marauder", EnemyTier.Advanced, 150 * scale, 28 * scale, 20 * scale, (int)(80 * scale), (int)(40 * scale)),
                "dark_knight" => new EnemyCharacter("enemy_dark_knight", "Dark Knight", EnemyTier.Advanced, 220 * scale, 35 * scale, 30 * scale, (int)(120 * scale), (int)(60 * scale)),
                "witch" => new EnemyCharacter("enemy_witch", "Coven Witch", EnemyTier.Advanced, 110 * scale, 32 * scale, 12 * scale, (int)(100 * scale), (int)(55 * scale)),
                "elite_knight" => new EnemyCharacter("enemy_elite_knight", "Elite Dread Knight", EnemyTier.Elite, 350 * scale, 48 * scale, 40 * scale, (int)(250 * scale), (int)(150 * scale)),
                "elite_demon" => new EnemyCharacter("enemy_elite_demon", "Elite Pit Demon", EnemyTier.Elite, 420 * scale, 55 * scale, 35 * scale, (int)(300 * scale), (int)(180 * scale)),
                _ => new EnemyCharacter("enemy_bat", "Dungeon Bat", EnemyTier.Common, 30 * scale, 8 * scale, 2 * scale, (int)(20 * scale), (int)(8 * scale))
            };
        }
    }
}
