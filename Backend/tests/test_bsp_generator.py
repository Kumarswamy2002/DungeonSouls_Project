from Backend.procedural.bsp_generator import BSPDungeonGenerator

def test_bsp_dungeon_generation():
    gen = BSPDungeonGenerator(60, 60)
    res = gen.generate()
    assert res["room_count"] == 4
    assert len(res["rooms"]) == 4
