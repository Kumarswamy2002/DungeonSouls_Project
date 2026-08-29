import os
from typing import AsyncGenerator
from sqlalchemy.ext.asyncio import create_async_engine, AsyncSession, async_sessionmaker
from app.core.config import settings
from app.database.models import Base

# Determine database engine
# If running inside Docker/Postgres environment or if explicitly configured, use postgres; otherwise fallback to aiosqlite
use_postgres = os.getenv("USE_POSTGRES", "false").lower() == "true" or os.getenv("POSTGRES_SERVER") == "postgres"

if use_postgres:
    database_url = settings.DATABASE_URL
else:
    database_url = "sqlite+aiosqlite:///./dungeon_souls.db"

engine = create_async_engine(database_url, echo=False)

AsyncSessionLocal = async_sessionmaker(
    bind=engine,
    class_=AsyncSession,
    expire_on_commit=False,
    autocommit=False,
    autoflush=False
)

async def get_db() -> AsyncGenerator[AsyncSession, None]:
    async with AsyncSessionLocal() as session:
        try:
            yield session
        finally:
            await session.close()
