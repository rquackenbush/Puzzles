#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Puzzle1.csproj", "Puzzle1/"]
RUN dotnet restore "Puzzle1/Puzzle1.csproj"
WORKDIR "/Puzzle1"
COPY . .
RUN dotnet publish "Puzzle1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Puzzle1.dll"]