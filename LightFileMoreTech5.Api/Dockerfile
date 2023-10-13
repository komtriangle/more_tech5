FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LightFileMoreTech5.Api/LightFireMoreTech5.csproj", "LightFireMoreTech5.Api"]
COPY ["LightFireMoreTech5.Data/LightFireMoreTech5.Data.csproj", "LightFireMoreTech5.Data/"]
RUN dotnet restore "LightFileMoreTech5.Api/LightFireMoreTech5.csproj"
COPY . .
WORKDIR "/src/LightFireMoreTech5"
RUN dotnet build "LightFireMoreTech5.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LightFileMoreTech5.Api/LightFireMoreTech5.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LightFireMoreTech5.dll"]