import pytest
from httpx import AsyncClient

@pytest.mark.asyncio
async def test_health_check(client: AsyncClient):
    response = await client.get("/health")
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "healthy"
    assert "Dungeon Souls" in data["service"]

@pytest.mark.asyncio
async def test_auth_and_player_flow(client: AsyncClient):
    # 1. Register
    reg_payload = {
        "username": "EldoriaHero",
        "email": "hero@eldoria.game",
        "password": "DragonSlayerPassword123!"
    }
    reg_res = await client.post("/api/auth/register", json=reg_payload)
    assert reg_res.status_code == 201
    auth_data = reg_res.json()
    assert "access_token" in auth_data
    assert "refresh_token" in auth_data
    token = auth_data["access_token"]
    headers = {"Authorization": f"Bearer {token}"}

    # 2. Duplicate registration check
    dup_res = await client.post("/api/auth/register", json=reg_payload)
    assert dup_res.status_code == 400

    # 3. Login
    login_payload = {
        "username": "EldoriaHero",
        "password": "DragonSlayerPassword123!"
    }
    login_res = await client.post("/api/auth/login", json=login_payload)
    assert login_res.status_code == 200

    # 4. Get Player Profile
    prof_res = await client.get("/api/player/profile", headers=headers)
    assert prof_res.status_code == 200
    profile = prof_res.json()
    assert profile["name"] == "EldoriaHero"
    assert profile["level"] == 1
    assert profile["class_type"] == "Warrior"

    # 5. Update Profile
    update_res = await client.put("/api/player/profile?level=5&gold=1000", headers=headers)
    assert update_res.status_code == 200
    updated = update_res.json()
    assert updated["level"] == 5
    assert updated["gold"] == 1000

    # 6. Statistics
    stats_res = await client.get("/api/player/statistics", headers=headers)
    assert stats_res.status_code == 200
    stats = stats_res.json()
    assert stats["highest_floor_reached"] == 1

@pytest.mark.asyncio
async def test_inventory_and_save_flow(client: AsyncClient):
    # Register user
    reg_payload = {"username": "Vagabond", "email": "vagabond@dungeon.com", "password": "securepassword"}
    reg_res = await client.post("/api/auth/register", json=reg_payload)
    token = reg_res.json()["access_token"]
    headers = {"Authorization": f"Bearer {token}"}

    # Add Item to inventory
    item_payload = {
        "template_id": "wpn_shadow_blade",
        "item_name": "Shadow Blade",
        "category": "Weapon",
        "rarity": "Legendary",
        "slot": "MainHand",
        "stack_count": 1,
        "affixes_json": [{"name": "of Carnage", "value": 25.0}]
    }
    add_res = await client.post("/api/inventory/items", json=item_payload, headers=headers)
    assert add_res.status_code == 201
    item = add_res.json()
    assert item["item_name"] == "Shadow Blade"
    item_id = item["id"]

    # Get Inventory
    inv_res = await client.get("/api/inventory", headers=headers)
    assert inv_res.status_code == 200
    items = inv_res.json()
    assert len(items) == 1

    # Cloud Save Upload
    save_payload = {
        "slot": 1,
        "save_version": 1,
        "save_payload": {
            "level": 12,
            "gold": 4500,
            "soul_essence": 120,
            "skills": {"w_def_1": 5, "w_fury_1": 3}
        },
        "checksum": "a1b2c3d4e5f6"
    }
    save_res = await client.post("/api/save", json=save_payload, headers=headers)
    assert save_res.status_code == 200
    save_data = save_res.json()
    assert save_data["slot"] == 1
    assert save_data["save_payload"]["level"] == 12

    # Get Cloud Saves
    get_saves_res = await client.get("/api/save", headers=headers)
    assert get_saves_res.status_code == 200
    assert len(get_saves_res.json()) == 1

    # Delete Inventory Item
    del_res = await client.delete(f"/api/inventory/items/{item_id}", headers=headers)
    assert del_res.status_code == 200

@pytest.mark.asyncio
async def test_missions_and_leaderboards(client: AsyncClient):
    reg_payload = {"username": "Champion", "email": "champ@dungeon.com", "password": "championpassword"}
    reg_res = await client.post("/api/auth/register", json=reg_payload)
    token = reg_res.json()["access_token"]
    headers = {"Authorization": f"Bearer {token}"}

    # List Missions
    m_res = await client.get("/api/missions")
    assert m_res.status_code == 200
    missions = m_res.json()
    assert len(missions) >= 2
    first_mission_id = missions[0]["id"]

    # Complete Mission
    comp_res = await client.post(f"/api/missions/{first_mission_id}/complete", headers=headers)
    assert comp_res.status_code == 200
    assert "completed" in comp_res.json()["message"]

    # Submit Leaderboard Score
    lead_post = await client.post("/api/leaderboard/submit?category=HighestFloor&score=25", headers=headers)
    assert lead_post.status_code == 200

    # Get Leaderboard
    lead_res = await client.get("/api/leaderboard?category=HighestFloor")
    assert lead_res.status_code == 200
    lead_data = lead_res.json()
    assert len(lead_data) >= 1
    assert lead_data[0]["player_name"] == "Champion"
    assert lead_data[0]["score"] == 25.0
