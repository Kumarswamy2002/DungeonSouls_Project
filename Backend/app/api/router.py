from fastapi import APIRouter
from app.api.v1.auth import router as auth_router
from app.api.v1.player import router as player_router
from app.api.v1.inventory import router as inventory_router
from app.api.v1.missions import router as missions_router
from app.api.v1.save import router as save_router
from app.api.v1.leaderboard import router as leaderboard_router

api_router = APIRouter(prefix="/api")
api_router.include_router(auth_router)
api_router.include_router(player_router)
api_router.include_router(inventory_router)
api_router.include_router(missions_router)
api_router.include_router(save_router)
api_router.include_router(leaderboard_router)
