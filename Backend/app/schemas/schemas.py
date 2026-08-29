from datetime import datetime
from typing import Optional, List, Any, Dict
from pydantic import BaseModel, EmailStr, Field, ConfigDict

# Auth Schemas
class UserRegisterRequest(BaseModel):
    username: str = Field(..., min_length=3, max_length=32)
    email: EmailStr
    password: str = Field(..., min_length=6)

class UserLoginRequest(BaseModel):
    username: str
    password: str

class TokenResponse(BaseModel):
    access_token: str
    refresh_token: str
    token_type: str = "bearer"
    expires_in_seconds: int

class TokenRefreshRequest(BaseModel):
    refresh_token: str

# Player Schemas
class PlayerCreateRequest(BaseModel):
    name: str = Field(..., min_length=2, max_length=32)
    class_type: str = "Warrior"

class PlayerProfileResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    id: str
    name: str
    class_type: str
    level: int
    experience: int
    gold: int
    soul_essence: int
    unspent_stat_points: int
    unspent_skill_points: int
    created_at: datetime

class PlayerStatsResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    runs_attempted: int
    runs_completed: int
    enemies_killed: int
    bosses_defeated: int
    total_damage_dealt: float
    total_damage_taken: float
    highest_floor_reached: int
    total_playtime_seconds: float

# Inventory Schemas
class InventoryItemSchema(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    id: str
    template_id: str
    item_name: str
    category: str
    rarity: str
    slot: Optional[str] = None
    stack_count: int
    affixes_json: List[Any] = []

class AddItemRequest(BaseModel):
    template_id: str
    item_name: str
    category: str
    rarity: str
    slot: Optional[str] = None
    stack_count: int = 1
    affixes_json: List[Any] = []

# Save Schemas
class SaveGameUploadRequest(BaseModel):
    slot: int = 1
    save_version: int = 1
    save_payload: Dict[str, Any]
    checksum: Optional[str] = None

class SaveGameResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    id: str
    player_id: str
    slot: int
    save_version: int
    save_payload: Dict[str, Any]
    updated_at: datetime

# Mission Schemas
class MissionResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    id: str
    code: str
    title: str
    description: str
    mission_type: str
    gold_reward: int
    exp_reward: int

class MissionProgressResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    mission_id: str
    title: str
    state: str
    current_progress: int
    target_progress: int

# Leaderboard Schemas
class LeaderboardEntry(BaseModel):
    model_config = ConfigDict(from_attributes=True)
    player_name: str
    category: str
    score: float
    recorded_at: datetime
