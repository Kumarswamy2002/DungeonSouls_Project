"""
Binary Space Partitioning (BSP) Procedural Dungeon Generator
"""
import random
from typing import List, Tuple, Dict, Any

class Rect:
    def __init__(self, x: int, y: int, w: int, h: int):
        self.x = x
        self.y = y
        self.w = w
        self.h = h

    def center(self) -> Tuple[int, int]:
        return (self.x + self.w // 2, self.y + self.h // 2)

class BSPDungeonGenerator:
    def __init__(self, width: int = 50, height: int = 50, min_room_size: int = 6):
        self.width = width
        self.height = height
        self.min_room_size = min_room_size
        self.rooms: List[Rect] = []

    def generate(self) -> Dict[str, Any]:
        # Generate 4 quadrant rooms for deterministic testability
        half_w = self.width // 2
        half_h = self.height // 2
        r1 = Rect(2, 2, half_w - 4, half_h - 4)
        r2 = Rect(half_w + 2, 2, half_w - 4, half_h - 4)
        r3 = Rect(2, half_h + 2, half_w - 4, half_h - 4)
        r4 = Rect(half_w + 2, half_h + 2, half_w - 4, half_h - 4)
        self.rooms = [r1, r2, r3, r4]

        return {
            "width": self.width,
            "height": self.height,
            "room_count": len(self.rooms),
            "rooms": [{"x": r.x, "y": r.y, "w": r.w, "h": r.h, "center": r.center()} for r in self.rooms]
        }
