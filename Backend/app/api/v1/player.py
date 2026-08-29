from fastapi import APIRouter, Depends, HTTPException, Header
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select
from typing import Optional
from app.database.session import get_db
from app.database.models import User, Player, PlayerStatistics
from app.schemas.schemas import PlayerProfileResponse, PlayerStatsResponse, PlayerCreateRequest
from app.core.security import decode_token

router = APIRouter(prefix="/player", tags=["Player"])

async def get_current_user(authorization: Optional[str] = Header(None), db: AsyncSession = Depends(get_db)) -> User:
    if not authorization or not authorization.startswith("Bearer "):
        raise HTTPException(status_code=401, detail="Missing or invalid authorization header")
    token = authorization.split(" ")[1]
    payload = decode_token(token)
    if not payload:
        raise HTTPException(status_code=401, detail="Invalid token")
    user_id = payload.get("sub")
    result = await db.execute(select(User).where(User.id == user_id))
    user = result.scalars().first()
    if not user:
        raise HTTPException(status_code=401, detail="User not found")
    return user

@router.get("/profile", response_model=PlayerProfileResponse)
async def get_player_profile(current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player character not found")
    return player

@router.put("/profile", response_model=PlayerProfileResponse)
async def update_player_profile(level: Optional[int] = None, gold: Optional[int] = None, soul_essence: Optional[int] = None, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player character not found")
    if level is not None:
        player.level = level
    if gold is not None:
        player.gold = gold
    if soul_essence is not None:
        player.soul_essence = soul_essence
    await db.commit()
    await db.refresh(player)
    return player

@router.get("/statistics", response_model=PlayerStatsResponse)
async def get_player_statistics(current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")
    stats_res = await db.execute(select(PlayerStatistics).where(PlayerStatistics.player_id == player.id))
    stats = stats_res.scalars().first()
    if not stats:
        stats = PlayerStatistics(player_id=player.id)
        db.add(stats)
        await db.commit()
        await db.refresh(stats)
    return stats
