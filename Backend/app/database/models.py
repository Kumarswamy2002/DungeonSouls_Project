import uuid
from datetime import datetime, timezone
from sqlalchemy import (
    Column, String, Integer, BigInteger, Float, Boolean, DateTime, ForeignKey, Text, JSON
)
from sqlalchemy.orm import declarative_base, relationship

Base = declarative_base()

def generate_uuid() -> str:
    return str(uuid.uuid4())

class User(Base):
    __tablename__ = "users"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    username = Column(String(64), unique=True, index=True, nullable=False)
    email = Column(String(128), unique=True, index=True, nullable=False)
    hashed_password = Column(String(256), nullable=False)
    is_active = Column(Boolean, default=True)
    is_superuser = Column(Boolean, default=False)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc))
    updated_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), onupdate=lambda: datetime.now(timezone.utc))

    players = relationship("Player", back_populates="user", cascade="all, delete-orphan")

class Player(Base):
    __tablename__ = "players"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    user_id = Column(String(36), ForeignKey("users.id"), nullable=False)
    name = Column(String(64), nullable=False)
    class_type = Column(String(32), nullable=False) # Warrior, Rogue, Mage, Ranger, Necromancer, Paladin
    level = Column(Integer, default=1)
    experience = Column(BigInteger, default=0)
    gold = Column(BigInteger, default=0)
    soul_essence = Column(BigInteger, default=0)
    unspent_stat_points = Column(Integer, default=0)
    unspent_skill_points = Column(Integer, default=0)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc))
    updated_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), onupdate=lambda: datetime.now(timezone.utc))

    user = relationship("User", back_populates="players")
    statistics = relationship("PlayerStatistics", back_populates="player", uselist=False, cascade="all, delete-orphan")
    inventory = relationship("Inventory", back_populates="player", cascade="all, delete-orphan")
    save_games = relationship("SaveGame", back_populates="player", cascade="all, delete-orphan")

class PlayerStatistics(Base):
    __tablename__ = "player_statistics"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    player_id = Column(String(36), ForeignKey("players.id"), unique=True, nullable=False)
    runs_attempted = Column(Integer, default=0)
    runs_completed = Column(Integer, default=0)
    enemies_killed = Column(BigInteger, default=0)
    bosses_defeated = Column(Integer, default=0)
    total_damage_dealt = Column(Float, default=0.0)
    total_damage_taken = Column(Float, default=0.0)
    highest_floor_reached = Column(Integer, default=1)
    total_playtime_seconds = Column(Float, default=0.0)

    player = relationship("Player", back_populates="statistics")

class Inventory(Base):
    __tablename__ = "inventory"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    player_id = Column(String(36), ForeignKey("players.id"), nullable=False)
    template_id = Column(String(64), nullable=False)
    item_name = Column(String(128), nullable=False)
    category = Column(String(32), nullable=False)
    rarity = Column(String(32), nullable=False)
    slot = Column(String(32), nullable=True)
    stack_count = Column(Integer, default=1)
    affixes_json = Column(JSON, default=list)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc))

    player = relationship("Player", back_populates="inventory")

class Mission(Base):
    __tablename__ = "missions"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    code = Column(String(64), unique=True, nullable=False)
    title = Column(String(128), nullable=False)
    description = Column(Text, nullable=False)
    mission_type = Column(String(32), nullable=False)
    gold_reward = Column(Integer, default=100)
    exp_reward = Column(BigInteger, default=250)

class MissionProgress(Base):
    __tablename__ = "mission_progress"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    player_id = Column(String(36), ForeignKey("players.id"), nullable=False)
    mission_id = Column(String(36), ForeignKey("missions.id"), nullable=False)
    state = Column(String(32), default="InProgress") # InProgress, Completed, Claimed
    current_progress = Column(Integer, default=0)
    target_progress = Column(Integer, default=1)
    updated_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), onupdate=lambda: datetime.now(timezone.utc))

class SaveGame(Base):
    __tablename__ = "save_games"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    player_id = Column(String(36), ForeignKey("players.id"), nullable=False)
    slot = Column(Integer, default=1)
    save_version = Column(Integer, default=1)
    save_payload = Column(JSON, nullable=False)
    checksum = Column(String(64), nullable=True)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc))
    updated_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), onupdate=lambda: datetime.now(timezone.utc))

    player = relationship("Player", back_populates="save_games")

class Leaderboard(Base):
    __tablename__ = "leaderboards"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    player_id = Column(String(36), ForeignKey("players.id"), nullable=False)
    player_name = Column(String(64), nullable=False)
    category = Column(String(32), nullable=False) # HighestFloor, SpeedRun, BossScore
    score = Column(Float, nullable=False)
    recorded_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc))
