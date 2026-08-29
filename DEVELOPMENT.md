# Development Guide — Dungeon Souls

## 1. Development Principles
- **Separation of Concerns**: Pure domain code (Combat, Stats, AI, Dungeon generation) must remain isolated from Unity MonoBehaviours.
- **Deterministic Simulations**: All gameplay logic depends on `IRandomProvider` or explicit seeds to enable 100% reproducible tests.
- **Event-Driven Decoupling**: Systems communicate through `EventBus.Publish<T>` rather than tightly coupled direct dependencies.

## 2. Adding a New Character Class
1. Add new enum value to `CharacterClassType`.
2. Inherit from `CharacterClass` in `DungeonSouls/Game/Classes/CharacterClasses.cs`.
3. Implement `ApplyBaseClassBonuses(PlayerCharacter player)`.
4. Register unique abilities in `DungeonSouls/Game/Abilities/` and link them in `SkillTree.cs`.

## 3. Adding a New Biome
1. Add new biome identifier to `DungeonBiome` enum in `DungeonData.cs`.
2. Configure environmental hazards, tile colors, and enemy drop multipliers in `ProceduralDungeonGenerator.cs`.
3. Register the region's boss in `BossFactory.CreateBoss(string region)`.

## 4. Git Commit Conventions
Follow Conventional Commits:
- `feat:` New feature or system
- `fix:` Bug fix
- `test:` Unit or integration test addition
- `docs:` Documentation update
- `refactor:` Code restructuring without behavior change
