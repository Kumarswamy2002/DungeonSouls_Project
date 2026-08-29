from Backend.render.fog_of_war import FogOfWarGrid

def test_fog_of_war_reveal():
    fog = FogOfWarGrid(100, 100)
    visible = fog.reveal_circle(50, 50, 5)
    assert (50, 50) in visible
    assert (50, 50) in fog.explored
    assert (0, 0) not in fog.explored
