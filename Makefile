.PHONY: test run server build clean

run:
	python run_game_simulation.py

server:
	python -m uvicorn app.main:app --app-dir Backend --host 0.0.0.0 --port 8000 --reload

test:
	pytest Backend/tests -v

build:
	docker build -t dungeon-souls-api:latest Backend/

clean:
	find . -type f -name "*.pyc" -delete
	find . -type d -name "__pycache__" -delete
