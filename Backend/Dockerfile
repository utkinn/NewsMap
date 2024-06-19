FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

ARG BUILD_ENVIRONMENT=Debug

COPY . .
RUN dotnet restore
RUN dotnet publish -c $BUILD_ENVIRONMENT -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=0 /app/out .
ENTRYPOINT ["dotnet", "NewsMap.dll"]
