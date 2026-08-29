from Backend.leaderboard.speedrun_validator import SpeedrunValidator

def test_speedrun_validation_legit():
    run = {"run_id": "r1", "seed": "seed_123", "elapsed_seconds": 120.0, "gold_collected": 1200, "bosses_defeated": 3, "score": 5000}
    res = SpeedrunValidator.validate_run(run)
    assert res["valid"] is True
    assert len(res["verification_hash"]) == 64
