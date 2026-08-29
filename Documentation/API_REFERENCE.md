# Dungeon Souls — API Reference Specification

Base URL: `http://localhost:8000/api`

## Authentication

### `POST /auth/register`
Creates a new player account and initializes default character and statistical records.

**Request Body:**
```json
{
  "username": "SoulboundHero",
  "email": "hero@eldoria.com",
  "password": "SuperSecretPassword123!"
}
```

**Response (201 Created):**
```json
{
  "access_token": "eyJhbGciOiJIUzI1Ni...",
  "refresh_token": "eyJhbGciOiJIUzI1Ni...",
  "token_type": "bearer",
  "expires_in_seconds": 86400
}
```

### `POST /auth/login`
Authenticates existing credentials.

**Request Body:**
```json
{
  "username": "SoulboundHero",
  "password": "SuperSecretPassword123!"
}
```

---

## Player & Statistics

### `GET /player/profile`
Retrieves character profile, levels, gold, soul essence, and unspent stat points.

**Headers:** `Authorization: Bearer <access_token>`

**Response (200 OK):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "SoulboundHero",
  "class_type": "Warrior",
  "level": 12,
  "experience": 45000,
  "gold": 3200,
  "soul_essence": 150,
  "unspent_stat_points": 5,
  "unspent_skill_points": 2,
  "created_at": "2026-08-29T10:00:00Z"
}
```

---

## Cloud Save

### `POST /save`
Uploads serialized binary / JSON game state.

**Request Body:**
```json
{
  "slot": 1,
  "save_version": 1,
  "save_payload": {
    "level": 12,
    "gold": 3200,
    "skills": {
      "w_def_1": 5,
      "w_fury_1": 3
    }
  },
  "checksum": "d41d8cd98f00b204e9800998ecf8427e"
}
```

---

## Leaderboard

### `GET /leaderboard?category=HighestFloor&limit=10`
Retrieves top player rankings.

**Response (200 OK):**
```json
[
  {
    "player_name": "SoulboundHero",
    "category": "HighestFloor",
    "score": 45.0,
    "recorded_at": "2026-08-29T11:00:00Z"
  }
]
```
