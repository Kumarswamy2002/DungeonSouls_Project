#!/usr/bin/env python3
"""
Dungeon Souls — Main Unified Application Entry Point
Starts the backend cloud server and launches simulation / game services.
"""
import os
import sys

if __name__ == "__main__":
    if len(sys.argv) > 1 and sys.argv[1] == "sim":
        from run_game_simulation import simulate_full_run
        simulate_full_run()
    else:
        import uvicorn
        sys.path.insert(0, os.path.join(os.path.dirname(__file__), "Backend"))
        uvicorn.run("app.main:app", host="0.0.0.0", port=8000, reload=False)
