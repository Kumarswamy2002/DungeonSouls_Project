from typing import AsyncGenerator
from sqlalchemy.ext.asyncio import create_async_engine, AsyncSession, async_sessionmaker
from app.core.config import settings
from app.database.models import Base

# Create SQLite fallback or PostgreSQL async engine
database_url = settings.DATABASE_URL
if "sqlite" in database_url.lower():
    engine = create_async_engine(database_url, echo=False)
else:
    # Use SQLite in-memory / local fallback if postgres isn't running during standalone tests
    try:
        engine = create_async_engine(database_url, echo=False, pool_pre_ping=True)
    except Exception:
        engine = create_async_engine("sqlite+aiosqlite:///./dungeon_souls.db", echo=False)

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
