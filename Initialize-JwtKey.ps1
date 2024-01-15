#!/usr/bin/env pwsh

dotnet user-secrets init --project Backend

$key = [Convert]::ToBase64String([System.Security.Cryptography.RandomNumberGenerator]::GetBytes(64))
dotnet user-secrets set Jwt:Key $key --project Backend
