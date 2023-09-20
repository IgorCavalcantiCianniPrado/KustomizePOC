FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/KustomizePocConsole.csproj", "src/KustomizePocConsole/"]
COPY ["src/Program.cs", "src/KustomizePocConsole/"]
RUN dotnet restore "src/KustomizePocConsole/KustomizePocConsole.csproj"
COPY . .
WORKDIR "src/KustomizePocConsole/"
RUN dotnet build "KustomizePocConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KustomizePocConsole.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/appsettings.json", "/app/"]
ENTRYPOINT ["dotnet", "KustomizePocConsole.dll"]