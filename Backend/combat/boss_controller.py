"""
Multi-Phase Boss Encounter Controller
"""
from typing import Dict, Any

class BossController:
    def __init__(self, max_hp: float = 1000.0):
        self.max_hp = max_hp
        self.current_hp = max_hp

    def get_phase(self) -> int:
        hp_percent = self.current_hp / self.max_hp
        if hp_percent > 0.66:
            return 1
        elif hp_percent > 0.33:
            return 2
        return 3

    def take_damage(self, amount: float) -> Dict[str, Any]:
        self.current_hp = max(0.0, self.current_hp - amount)
        phase = self.get_phase()
        return {
            "current_hp": self.current_hp,
            "phase": phase,
            "is_enraged": phase == 3,
            "telegraph_delay_sec": 1.5 if phase == 1 else (1.0 if phase == 2 else 0.5)
        }
