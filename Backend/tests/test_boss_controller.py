from Backend.combat.boss_controller import BossController

def test_boss_phase_transitions():
    boss = BossController(1000.0)
    assert boss.get_phase() == 1
    res = boss.take_damage(400.0)
    assert res["phase"] == 2
    res2 = boss.take_damage(350.0)
    assert res2["phase"] == 3
    assert res2["is_enraged"] is True
