from Backend.items.relic_synergy import RelicSynergyEngine

def test_synergy_detection():
    relics = ["FIRE_ORB", "POISON_VIAL", "SHIELD_RUNE"]
    syns = RelicSynergyEngine.evaluate_synergies(relics)
    assert "COMBUSTION_EXPLOSION" in syns
    assert len(syns) == 1
