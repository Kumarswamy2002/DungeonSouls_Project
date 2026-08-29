"""
Relic Synergy & Elemental Enchantment Resolver
"""
from typing import List, Dict, Any, Set

class RelicSynergyEngine:
    SYNERGIES = {
        frozenset(["FIRE_ORB", "POISON_VIAL"]): "COMBUSTION_EXPLOSION",
        frozenset(["LIGHTNING_ROD", "WATER_FLASK"]): "CHAIN_ELECTROCUTION",
        frozenset(["VAMPIRE_FANG", "BLOOD_PENDANT"]): "ESSENCE_SIPHON"
    }

    @classmethod
    def evaluate_synergies(cls, active_relics: List[str]) -> List[str]:
        relic_set = set(active_relics)
        unlocked = []
        for combo, effect in cls.SYNERGIES.items():
            if combo.issubset(relic_set):
                unlocked.append(effect)
        return unlocked
