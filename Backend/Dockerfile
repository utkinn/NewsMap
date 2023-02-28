FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app

ARG BUILD_ENVIRONMENT=Release

COPY . .
RUN dotnet restore
RUN dotnet publish -c $BUILD_ENVIRONMENT -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=0 /app/out .
ENTRYPOINT ["dotnet", "Backend.dll"]
