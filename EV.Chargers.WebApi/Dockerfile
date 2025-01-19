# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the solution file and all project files
COPY ["EV.Chargers.sln", "."]
COPY ["EV.Chargers.WebApi/EV.Chargers.WebApi.csproj", "EV.Chargers.WebApi/"]
COPY ["EV.Chargers.Application/EV.Chargers.Application.csproj", "EV.Chargers.Application/"]
COPY ["EV.Chargers.Core/EV.Chargers.Core.csproj", "EV.Chargers.Core/"]
COPY ["EV.Chargers.Domain/EV.Chargers.Domain.csproj", "EV.Chargers.Domain/"]
COPY ["EV.Chargers.Infrastructure/EV.Chargers.Infrastructure.csproj", "EV.Chargers.Infrastructure/"]
COPY ["EV.Chargers.Persistence/EV.Chargers.Persistence.csproj", "EV.Chargers.Persistence/"]

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR "/src/EV.Chargers.WebApi"
RUN dotnet build "EV.Chargers.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EV.Chargers.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EV.Chargers.WebApi.dll"]
