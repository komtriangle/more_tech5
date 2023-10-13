#!/bin/bash

DOCKERFILE_PATH="./dockerItems/Dockerfile"
DOCKER_COMPOSE_PATH="./dockerItems/docker-compose.yml"
DOCKER_IMAGE_NAME="hack-image"

echo "Шаг 1: Сборка Docker-образа из Dockerfile"
docker build -t $DOCKER_IMAGE_NAME -f $DOCKERFILE_PATH .

if [ $? -eq 0 ]; then
  echo "Сборка Docker-образа завершена успешно"
else
  echo "Сборка Docker-образа завершилась с ошибкой"
  exit 1
fi

echo "Шаг 2: Запуск Docker Compose"
docker-compose -f $DOCKER_COMPOSE_PATH up -d

if [ $? -eq 0 ]; then
  echo "Docker Compose успешно запущен"
else
  echo "Запуск Docker Compose завершился с ошибкой"
  exit 1
fi

exit 0