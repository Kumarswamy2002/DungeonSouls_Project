-- Dungeon Souls Database Initialization Script
CREATE TABLE IF NOT EXISTS users (
    id VARCHAR(36) PRIMARY KEY,
    username VARCHAR(64) UNIQUE NOT NULL,
    email VARCHAR(128) UNIQUE NOT NULL,
    hashed_password VARCHAR(256) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    is_superuser BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS players (
    id VARCHAR(36) PRIMARY KEY,
    user_id VARCHAR(36) REFERENCES users(id) ON DELETE CASCADE,
    name VARCHAR(64) NOT NULL,
    class_type VARCHAR(32) NOT NULL,
    level INTEGER DEFAULT 1,
    experience BIGINT DEFAULT 0,
    gold BIGINT DEFAULT 0,
    soul_essence BIGINT DEFAULT 0,
    unspent_stat_points INTEGER DEFAULT 0,
    unspent_skill_points INTEGER DEFAULT 0,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS player_statistics (
    id VARCHAR(36) PRIMARY KEY,
    player_id VARCHAR(36) UNIQUE REFERENCES players(id) ON DELETE CASCADE,
    runs_attempted INTEGER DEFAULT 0,
    runs_completed INTEGER DEFAULT 0,
    enemies_killed BIGINT DEFAULT 0,
    bosses_defeated INTEGER DEFAULT 0,
    total_damage_dealt DOUBLE PRECISION DEFAULT 0.0,
    total_damage_taken DOUBLE PRECISION DEFAULT 0.0,
    highest_floor_reached INTEGER DEFAULT 1,
    total_playtime_seconds DOUBLE PRECISION DEFAULT 0.0
);

CREATE TABLE IF NOT EXISTS inventory (
    id VARCHAR(36) PRIMARY KEY,
    player_id VARCHAR(36) REFERENCES players(id) ON DELETE CASCADE,
    template_id VARCHAR(64) NOT NULL,
    item_name VARCHAR(128) NOT NULL,
    category VARCHAR(32) NOT NULL,
    rarity VARCHAR(32) NOT NULL,
    slot VARCHAR(32),
    stack_count INTEGER DEFAULT 1,
    affixes_json JSONB DEFAULT '[]'::jsonb,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS save_games (
    id VARCHAR(36) PRIMARY KEY,
    player_id VARCHAR(36) REFERENCES players(id) ON DELETE CASCADE,
    slot INTEGER DEFAULT 1,
    save_version INTEGER DEFAULT 1,
    save_payload JSONB NOT NULL,
    checksum VARCHAR(64),
    created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS leaderboards (
    id VARCHAR(36) PRIMARY KEY,
    player_id VARCHAR(36) REFERENCES players(id) ON DELETE CASCADE,
    player_name VARCHAR(64) NOT NULL,
    category VARCHAR(32) NOT NULL,
    score DOUBLE PRECISION NOT NULL,
    recorded_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS idx_leaderboards_category_score ON leaderboards (category, score DESC);
CREATE INDEX IF NOT EXISTS idx_inventory_player ON inventory (player_id);
CREATE INDEX IF NOT EXISTS idx_save_games_player_slot ON save_games (player_id, slot);
