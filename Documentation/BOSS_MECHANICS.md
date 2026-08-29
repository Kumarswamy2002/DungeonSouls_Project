# Dungeon Souls — Boss Encounter Mechanics & Guide

Dungeon Souls features 8 regional boss encounters, each architected with a multi-phase state machine, enrage thresholds, unique elemental affinities, and distinct attack patterns.

---

## Boss Roster

| Region | Boss Name | Elemental Damage | Phase Thresholds | Core Mechanics |
|---|---|---|---|---|
| **Forgotten Crypt** | **The Bone King** | Physical / Dark | 100% / 70% / 40% / 15% | Ossuary Hammer Slam, Curse Nova, Skeleton Minion Summons |
| **Dark Forest** | **Ancient Treant** | Poison / Physical | 100% / 70% / 40% / 15% | Grasping Roots, Poison Spore Pods, Entangling Brambles |
| **Ancient Ruins** | **Stone Guardian** | Physical / Arcane | 100% / 70% / 40% / 15% | Ground Tremor, Falling Boulders, Invulnerability Shields |
| **Frozen Caverns** | **Frost Queen Selyna** | Ice | 100% / 70% / 40% / 15% | Glacial Tempest, Freeze Beams, Ice Shard Barrage |
| **Lava Depths** | **Ignis the Inferno Lord** | Fire | 100% / 70% / 40% / 15% | Hellfire Eruption, Magma Pools, Burning Aura |
| **Cursed Castle** | **Lord Malakor** | Dark / Physical | 100% / 70% / 40% / 15% | Sanguine Feast (Life Drain), Bat Swarm, Teleport Backstab |
| **Shadow Realm** | **Kael'Thok the Shadow Beast**| Dark / Arcane | 100% / 70% / 40% / 15% | Void Tear, Blindness Nova, Spatial Distortions |
| **Abyss** | **Azazel, Demon King** | True / Dark / Fire | 100% / 70% / 40% / 15% | Abyssal Rupture, Chaos Storm, Cataclysmic Enrage |

---

## Phase Progression Framework

```
   100% HP (Phase 1: Basic Attack & Telegraphs)
      │
      ▼
   70% HP  (Phase 2: +25% Attack Power, Adds Secondary Ability)
      │
      ▼
   40% HP  (Phase 3: +30% Attack Speed & Movement Speed, Arena Hazards)
      │
      ▼
   15% HP  (Enraged: +60% Attack Power, +30% Critical Chance, Relentless Assault)
```
