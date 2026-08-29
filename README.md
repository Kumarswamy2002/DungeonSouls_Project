# ⚔️ DUNGEON SOULS
### *Dark-Fantasy Action RPG & Roguelite Core Engine*

[![Backend Tests](https://github.com/dungeon-souls/game/actions/workflows/tests.yml/badge.svg)](https://github.com/dungeon-souls/game/actions/workflows/tests.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![FastAPI](https://img.shields.io/badge/FastAPI-0.110+-009688.svg?logo=fastapi&logoColor=white)](https://fastapi.tiangolo.com)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED.svg?logo=docker&logoColor=white)](https://www.docker.com/)

**Dungeon Souls** is a dark-fantasy Action RPG / Roguelite engineered for rapid tactical combat, deterministic procedural dungeon generation, advanced AI state machines, modular RPG character building, and cloud-synced persistence.

---

## 🏛️ Key Highlights & Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                 PRESENTATION LAYER (Unity UI)               │
│   HUD | Inventory UI | Skill Tree | Boss Bar | Run Summary  │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                 APPLICATION & COORDINATION                  │
│    Combat Engine | Quest Manager | Dungeon Coordinator      │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                 CORE DOMAIN LAYER (Decoupled C#)            │
│  Stat Engine | Damage Calc | 6 Classes | AI | 8 Biome Gen   │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│             INFRASTRUCTURE & CLOUD BACKEND                  │
│    FastAPI | PostgreSQL 16 | Redis 7 | JWT | Cloud Save     │
└─────────────────────────────────────────────────────────────┘
```

---

## 🎮 Gameplay Features

### 1. 6 Distinct Character Classes
- **Warrior**: Frontline juggernaut (Shield Bash, Whirlwind, Ground Slam, Berserk).
- **Rogue**: Shadow assassin (Dash, Backstab, Smoke Bomb, Shadow Step).
- **Mage**: Elemental devastation (Fireball, Ice Spike, Lightning, Meteor).
- **Ranger**: Precision marksman (Multi Shot, Piercing Arrow, Poison Arrow, Rain of Arrows).
- **Necromancer**: Undead master (Summon Skeleton, Life Drain, Bone Storm, Raise Dead).
- **Paladin**: Holy guardian (Holy Strike, Heal, Divine Shield, Judgment).

### 2. Deep RPG Progression & Skill Trees
- Branching 3-tier skill trees per class with active, passive, and ultimate abilities.
- Centralized stat system with flat, additive percent, and multiplicative percent modifier pipelines.
- 9 equipment slots (Main Hand, Off Hand, Helmet, Chest, Gloves, Boots, Ring 1, Ring 2, Amulet) with random dynamic affixes across 6 rarity tiers (Common to Mythic).

### 3. Deterministic Procedural Dungeon Generation
- 8 unique regional biomes: *Forgotten Crypt, Dark Forest, Ancient Ruins, Frozen Caverns, Lava Depths, Cursed Castle, Shadow Realm, Abyss*.
- Guaranteed graph invariants: 100% path connectivity via Prim Minimum Spanning Tree (MST), boss room reachability verification, and zero orphaned rooms.

### 4. 8 Multi-Phase Region Bosses
- Complex phase state machines triggered dynamically by health thresholds (100% $\to$ 70% $\to$ 40% $\to$ Enrage $<15\%$).

---

## 🚀 Quickstart & Setup

### 1. Running Backend (FastAPI + PostgreSQL + Redis)
```bash
cd Docker
docker-compose up --build -d
```
The REST API documentation will be instantly accessible at:
- **Interactive Swagger UI**: [http://localhost:8000/docs](http://localhost:8000/docs)
- **ReDoc UI**: [http://localhost:8000/redoc](http://localhost:8000/redoc)

### 2. Running Automated Backend Tests
```bash
# Set PYTHONPATH and execute pytest
$env:PYTHONPATH="Backend"
python -m pytest Backend/tests -v
```

---

## 📂 Repository Structure

```
DungeonSouls/
├── Game/
│   ├── Core/                # Vector math, Random, EventBus, Primitives
│   ├── Combat/              # Damage formulas, Mitigation, Combatant interfaces
│   ├── StatusEffects/       # Reusable 13 status effects & damage absorption
│   ├── Player/              # Character controller, Experience (1-50), Stat allocation
│   ├── Classes/             # 6 Class definitions & baseline buffs
│   ├── Abilities/           # Cooldown tracker & ability definitions
│   ├── Skills/              # Branching skill trees & prerequisite validation
│   ├── Items/               # Rarity, Weapons (9 types), Equipment (9 slots)
│   ├── Inventory/           # Grid inventory, stacking, equipping
│   ├── Loot/                # Drop tables, rarity rolling, random affixes
│   ├── Crafting/            # Crafting recipes, Relics, and Shrines
│   ├── Enemies/             # Perception, AI state machine, Common/Advanced/Elite archetypes
│   ├── Bosses/              # 8 Region Bosses with health-threshold phase changes
│   ├── Dungeon/             # Tilemaps, rooms, corridors, biome configs
│   ├── ProceduralGeneration/# Prim MST dungeon generator & Invariant verifier
│   ├── NPC/ & World/        # Sanctuary hub world & NPC profiles
│   ├── Dialogue/ & Quests/  # Branching dialogue graph & Quest tracker
│   └── SaveSystem/          # Versioned JSON serializer & Run loop
├── UI/                      # HUD viewmodels, Run summary, and screen controllers
├── Tools/                   # ASCII Dungeon Visualizer & Balance Loot Simulator
├── Tests/                   # Unit & Integration test suites
Backend/                     # Python / FastAPI backend with SQLAlchemy & Redis
Docker/                      # Dockerfile, docker-compose.yml, init.sql
Documentation/               # Deep-dive architecture and game design manuals
```

---

## 📜 License
Released under the [MIT License](LICENSE).
