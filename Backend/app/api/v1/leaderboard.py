from fastapi import APIRouter, Depends, HTTPException, Query
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select, desc
from typing import List
from app.database.session import get_db
from app.database.models import User, Player, Leaderboard
from app.schemas.schemas import LeaderboardEntry
from app.api.v1.player import get_current_user

router = APIRouter(prefix="/leaderboard", tags=["Leaderboard"])

@router.get("", response_model=List[LeaderboardEntry])
async def get_leaderboard(
    category: str = Query("HighestFloor", description="HighestFloor, SpeedRun, BossScore"),
    limit: int = Query(20, ge=1, le=100),
    db: AsyncSession = Depends(get_db)
):
    query = select(Leaderboard).where(Leaderboard.category == category).order_by(desc(Leaderboard.score)).limit(limit)
    result = await db.execute(query)
    entries = result.scalars().all()
    return entries

@router.post("/submit")
async def submit_score(
    category: str,
    score: float,
    current_user: User = Depends(get_current_user),
    db: AsyncSession = Depends(get_db)
):
    p_res = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = p_res.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")

    entry = Leaderboard(
        player_id=player.id,
        player_name=player.name,
        category=category,
        score=score
    )
    db.add(entry)
    await db.commit()
    return {"message": "Score submitted successfully", "player": player.name, "category": category, "score": score}
