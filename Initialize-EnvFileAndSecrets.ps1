#!/usr/bin/env pwsh

dotnet user-secrets init --project Backend

if (Test-Path -Path .env) {
    exit
}

$key = [Convert]::ToBase64String([System.Security.Cryptography.RandomNumberGenerator]::GetBytes(64))
dotnet user-secrets set Jwt:Key $key --project Backend

$dbPassword = "passwordVeryStronk"

Out-File -FilePath .env -InputObject "JWT_SECRET=$key
DB_NAME=NewsMap
DB_USER=NewsMap
DB_PASSWORD=$dbPassword
DB_CONNECTION_STRING=Host=db;Database=`${DB_NAME};Username=`${DB_USER};Password=`${DB_PASSWORD}
ENVIRONMENT=Release"
