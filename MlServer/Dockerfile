#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["MlServer/MlServer.csproj", "MlServer/"]
COPY ["DataTransferObjects/DataTransferObjects.csproj", "DataTransferObjects/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "MlServer/MlServer.csproj"
COPY . .
WORKDIR "/src/MlServer"
RUN dotnet build "MlServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MlServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MlServer.dll"]