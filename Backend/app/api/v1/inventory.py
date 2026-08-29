from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select
from typing import List
from app.database.session import get_db
from app.database.models import User, Player, Inventory
from app.schemas.schemas import InventoryItemSchema, AddItemRequest
from app.api.v1.player import get_current_user

router = APIRouter(prefix="/inventory", tags=["Inventory"])

@router.get("", response_model=List[InventoryItemSchema])
async def get_inventory(current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")
    
    inv_res = await db.execute(select(Inventory).where(Inventory.player_id == player.id))
    return inv_res.scalars().all()

@router.post("/items", response_model=InventoryItemSchema, status_code=status.HTTP_201_CREATED)
async def add_item(req: AddItemRequest, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Player).where(Player.user_id == current_user.id))
    player = result.scalars().first()
    if not player:
        raise HTTPException(status_code=404, detail="Player not found")

    item = Inventory(
        player_id=player.id,
        template_id=req.template_id,
        item_name=req.item_name,
        category=req.category,
        rarity=req.rarity,
        slot=req.slot,
        stack_count=req.stack_count,
        affixes_json=req.affixes_json
    )
    db.add(item)
    await db.commit()
    await db.refresh(item)
    return item

@router.delete("/items/{item_id}")
async def delete_item(item_id: str, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Inventory).where(Inventory.id == item_id))
    item = result.scalars().first()
    if not item:
        raise HTTPException(status_code=404, detail="Item not found")

    await db.delete(item)
    await db.commit()
    return {"message": f"Item {item_id} deleted successfully"}
