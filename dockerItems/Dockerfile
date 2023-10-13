# Используем базовый образ и устанавливаем libgdiplus
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get -y update
RUN apt install -y libgdiplus

# Собираем проект
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Устанавливаем рабочий каталог и копируем файлы проекта
WORKDIR /src
COPY ["./LightFileMoreTech5.Api/LightFileMoreTech5.csproj", "LightFileMoreTech5.Api/"]
RUN dotnet restore "LightFileMoreTech5.Api/LightFileMoreTech5.csproj"
COPY . .

# Остальные этапы сборки оставляем без изменений

# Собираем проект
RUN dotnet build "LightFileMoreTech5.Api/LightFileMoreTech5.csproj" -c Release -o /app/build

# Публикуем проект
RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools

FROM build AS publish
RUN dotnet publish "LightFileMoreTech5.Api/LightFileMoreTech5.csproj" -c Release -o /app/publish

# На этом этапе копируем файлы в финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "LightFileMoreTech5.Api/LightFileMoreTech5.dll"]
