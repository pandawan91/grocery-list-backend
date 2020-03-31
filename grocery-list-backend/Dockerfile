#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["grocery-list-backend/grocery-list-backend.csproj", "grocery-list-backend/"]
RUN dotnet restore "grocery-list-backend/grocery-list-backend.csproj"
COPY . .
WORKDIR "/src/grocery-list-backend"
RUN dotnet build "grocery-list-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "grocery-list-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "grocery-list-backend.dll"]