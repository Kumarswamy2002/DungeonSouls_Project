"""
Speedrun Telemetry Validator & Anti-Cheat Run Verifier
"""
import hashlib
from typing import Dict, Any

class SpeedrunValidator:
    MAX_GOLD_PER_SECOND = 50.0

    @classmethod
    def validate_run(cls, run_data: Dict[str, Any], secret_salt: str = "dungeon_salt_99") -> Dict[str, Any]:
        time_sec = max(0.1, run_data.get("elapsed_seconds", 0.0))
        gold = run_data.get("gold_collected", 0)
        gold_rate = gold / time_sec

        is_valid = gold_rate <= cls.MAX_GOLD_PER_SECOND and run_data.get("bosses_defeated", 0) >= 1
        sig_base = f"{run_data.get('seed')}:{run_data.get('score')}:{secret_salt}"
        sig = hashlib.sha256(sig_base.encode('utf-8')).hexdigest()

        return {
            "run_id": run_data.get("run_id"),
            "valid": is_valid,
            "gold_rate_per_sec": round(gold_rate, 2),
            "verification_hash": sig
        }
