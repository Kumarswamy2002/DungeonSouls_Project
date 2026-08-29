"""
2D Fog of War & Visibility Polygon Engine
"""
import math
from typing import List, Set, Tuple

class FogOfWarGrid:
    def __init__(self, width: int, height: int):
        self.width = width
        self.height = height
        self.explored: Set[Tuple[int, int]] = set()

    def reveal_circle(self, center_x: int, center_y: int, radius: int) -> Set[Tuple[int, int]]:
        visible = set()
        for x in range(center_x - radius, center_x + radius + 1):
            for y in range(center_y - radius, center_y + radius + 1):
                if 0 <= x < self.width and 0 <= y < self.height:
                    dist = math.hypot(x - center_x, y - center_y)
                    if dist <= radius:
                        pos = (x, y)
                        visible.add(pos)
                        self.explored.add(pos)
        return visible
