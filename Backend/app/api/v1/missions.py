from fastapi import APIRouter, Depends, HTTPException
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select
from typing import List
from app.database.session import get_db
from app.database.models import User, Player, Mission, MissionProgress
from app.schemas.schemas import MissionResponse, MissionProgressResponse
from app.api.v1.player import get_current_user

router = APIRouter(prefix="/missions", tags=["Missions"])

@router.get("", response_model=List[MissionResponse])
async def list_missions(db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Mission))
    missions = result.scalars().all()
    if not missions:
        # Seed default starter missions
        m1 = Mission(code="m_crypt_1", title="Crypt Cleansing", description="Defeat 10 undead fiends in Forgotten Crypt", mission_type="Daily", gold_reward=150, exp_reward=500)
        m2 = Mission(code="m_boss_1", title="Slayer of Kings", description="Defeat the Bone King without dying", mission_type="Boss", gold_reward=500, exp_reward=1500)
        db.add_all([m1, m2])
        await db.commit()
        result = await db.execute(select(Mission))
        missions = result.scalars().all()
    return missions

@router.get("/{mission_id}", response_model=MissionResponse)
async def get_mission_by_id(mission_id: str, db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Mission).where(Mission.id == mission_id))
    mission = result.scalars().first()
    if not mission:
        raise HTTPException(status_code=404, detail="Mission not found")
    return mission

@router.post("/{mission_id}/complete")
async def complete_mission(mission_id: str, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Mission).where(Mission.id == mission_id))
    mission = result.scalars().first()
    if not mission:
        raise HTTPException(status_code=404, detail="Mission not found")

    p_res = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = p_res.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")

    player.gold += mission.gold_reward
    player.experience += mission.exp_reward
    await db.commit()

    return {
        "message": f"Mission '{mission.title}' completed!",
        "gold_reward": mission.gold_reward,
        "exp_reward": mission.exp_reward
    }
