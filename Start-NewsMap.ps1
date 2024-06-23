#!/usr/bin/env pwsh

.\Initialize-EnvFileAndSecrets.ps1
docker compose up -d --build db
Set-Location Backend
dotnet restore
dotnet tool install -g dotnet-ef
dotnet ef database update
dotnet run
