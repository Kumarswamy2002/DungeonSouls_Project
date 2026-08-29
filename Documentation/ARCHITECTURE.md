# Dungeon Souls — Technical Architecture Document

## 1. Architectural Philosophy
Dungeon Souls is architected using **Clean Architecture** and **Domain-Driven Design (DDD)** principles to completely separate pure gameplay domain simulation from the rendering / presentation engines (Unity).

```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                       │
│    Unity MonoBehaviours, UI Toolkit / uGUI, Audio Sources   │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                    Application Layer                        │
│    Combat Coordinator, Run Coordinator, Quest Coordinator   │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                      Domain Layer                           │
│   AttributeSet, DamageCalculator, StatusEffects, AI Engine,  │
│   Procedural Dungeon Generator, Items, Classes, Relics      │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                   Infrastructure Layer                      │
│   Save/Load JSON Serializer, REST API Client, Event Bus     │
└─────────────────────────────────────────────────────────────┘
```

## 2. Core Domain Systems

### Attribute & Stat Engine
Stats are decoupled into base values and sorted `StatModifier` pipelines (`Flat`, `PercentAdd`, `PercentMult`). Modifications automatically trigger recalculations and propagate events without duplicate state tracking.

### Damage Mitigation Formula
Physical and magical mitigation follow a hyperbola diminishing returns curve:
$$\text{Reduction} = \frac{\text{Defense}}{\text{Defense} + 100}$$

$$\text{Final Damage} = (\text{Base Damage} \times \text{Scaling}) \times (1 - \text{Reduction}) \times \text{Crit Multiplier}$$

### Procedural Dungeon Generation Pipeline
1. **Room Packing**: Iterative non-overlapping bounding rect placement.
2. **Graph Connection**: Minimum Spanning Tree (MST) using Prim's algorithm ensures 100% graph connectivity with 0 orphaned rooms.
3. **Loop Generation**: Probabilistic Delaunay edge inclusion for tactical nonlinear loops.
4. **Role Assignment**: Furthest room from entrance designated as Boss Room.
5. **Invariant Verification**: Automated BFS flood-fill guarantees player reachability to all critical points before loading the scene.

## 3. Backend Cloud Architecture
- **Framework**: Python 3.12 / FastAPI (Async ASGI).
- **Persistence**: PostgreSQL 16 with async SQLAlchemy 2.0 ORM.
- **Caching & High Scores**: Redis 7 Sorted Sets (`ZADD`, `ZRANGEBYSCORE`).
- **Security**: PBKDF2-HMAC-SHA256 password hashing + HS256 JWT tokens.
