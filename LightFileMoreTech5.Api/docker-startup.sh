#!/bin/bash

./bundle --connection "User ID=postgres;Password=miva;Host=${DB_HOST};Port=5432;Database=HackDB;Pooling=false; Connection Idle Lifetime=10; Max Auto Prepare=20;"
dotnet LightFileMoreTech5.dll