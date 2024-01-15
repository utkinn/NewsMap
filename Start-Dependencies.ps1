#!/usr/bin/env pwsh

docker compose -f docker-compose.yml -f docker-compose.dev.yml up -d --build db
