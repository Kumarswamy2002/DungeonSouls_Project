from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select
from typing import List, Optional
from app.database.session import get_db
from app.database.models import User, Player, SaveGame
from app.schemas.schemas import SaveGameUploadRequest, SaveGameResponse
from app.api.v1.player import get_current_user

router = APIRouter(prefix="/save", tags=["Cloud Save"])

@router.post("", response_model=SaveGameResponse, status_code=status.HTTP_200_OK)
async def upload_save(req: SaveGameUploadRequest, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")

    save_res = await db.execute(select(SaveGame).where((SaveGame.player_id == player.id) & (SaveGame.slot == req.slot)))
    save_game = save_res.scalars().first()

    if save_game:
        save_game.save_payload = req.save_payload
        save_game.save_version = req.save_version
        save_game.checksum = req.checksum
    else:
        save_game = SaveGame(
            player_id=player.id,
            slot=req.slot,
            save_version=req.save_version,
            save_payload=req.save_payload,
            checksum=req.checksum
        )
        db.add(save_game)

    await db.commit()
    await db.refresh(save_game)
    return save_game

@router.get("", response_model=List[SaveGameResponse])
async def get_saves(current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")

    saves_res = await db.execute(select(SaveGame).where(SaveGame.player_id == player.id))
    return saves_res.scalars().all()

@router.delete("/{slot}")
async def delete_save_slot(slot: int, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")

    save_res = await db.execute(select(SaveGame).where((SaveGame.player_id == player.id) & (SaveGame.slot == slot)))
    save_game = save_res.scalars().first()
    if not save_game:
        raise HTTPException(status_code=404, detail=f"Save slot {slot} not found")

    await db.delete(save_game)
    await db.commit()
    return {"message": f"Save slot {slot} deleted"}
