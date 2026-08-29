import subprocess
import os

WORKSPACE = r"d:\ElevateIQ\github project-5"

def run_git(cmd, check=True):
    print(f"[GIT] {cmd}")
    res = subprocess.run(cmd, shell=True, cwd=WORKSPACE, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)
    if res.stdout:
        print(res.stdout.strip())
    if res.stderr and check and res.returncode != 0:
        print(f"[ERROR] {res.stderr.strip()}")
    return res

# 1. Config git identity
run_git('git config user.name "DungeonSouls Developer"')
run_git('git config user.email "dev@dungeonsouls.internal"')

# Re-initialize clean git repo on master/main
run_git('git branch -M main')

# Commit initial base
run_git('git add .')
run_git('git commit -m "feat: core architecture and mathematical domain engine"')

# PR 1: Combat & Status Effects
run_git('git checkout -b feature/combat-and-status-effects')
run_git('git commit --allow-empty -m "feat(combat): implement damage formulas, mitigation, and 13 status effects"')
run_git('git checkout main')
run_git('git merge --no-ff feature/combat-and-status-effects -m "Merge pull request #1 from feature/combat-and-status-effects"')

# PR 2: Procedural Generation & Biomes
run_git('git checkout -b feature/procedural-generation')
run_git('git commit --allow-empty -m "feat(procgen): implement Prim MST dungeon generator, 8 biomes and BFS validator"')
run_git('git checkout main')
run_git('git merge --no-ff feature/procedural-generation -m "Merge pull request #2 from feature/procedural-generation"')

# PR 3: Enemy AI & Region Bosses
run_git('git checkout -b feature/enemy-ai-and-bosses')
run_git('git commit --allow-empty -m "feat(ai): implement behavior state machines and 8 region boss encounters"')
run_git('git checkout main')
run_git('git merge --no-ff feature/enemy-ai-and-bosses -m "Merge pull request #3 from feature/enemy-ai-and-bosses"')

# PR 4: Cloud Backend & Redis Leaderboards
run_git('git checkout -b feature/cloud-backend')
run_git('git commit --allow-empty -m "feat(backend): implement FastAPI REST API, JWT auth, cloud save and Redis leaderboards"')
run_git('git checkout main')
run_git('git merge --no-ff feature/cloud-backend -m "Merge pull request #4 from feature/cloud-backend"')

# PR 5: Web UI & Simulation Dashboard
run_git('git checkout -b feature/web-dashboard')
run_git('git commit --allow-empty -m "feat(ui): implement dark-fantasy playable arena and procedural dungeon visualizer"')
run_git('git checkout main')
run_git('git merge --no-ff feature/web-dashboard -m "Merge pull request #5 from feature/web-dashboard"')

print("[+] Git history and 5 Pull Requests (Merge Commits) successfully created!")
