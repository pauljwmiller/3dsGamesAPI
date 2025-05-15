# 3dsGamesAPI
A full-stack web app made using C# and .NET/Entity Framework Core, SQLite, a REACT + Vite frontend, and the Axios library for API communication from frontend to backend.

This API lets users view a list of 3DS games (frontend + backend) and perform CRUD operations on a database of 3DS games (backend).

## Features
- CRUD Operations: Manage games with endpoints to create/read/update/delete
- SQLite Integration: Persistant storage for database
- Seeding Data: Predefined seed data for some 3DS games
- RESTful API design
- Now connects to 

## Prerequisites:
- Install:
1. .NET SDK
2. SQLite
3. Node.js

## Getting Started
### Backend Setup commands
cd 3dsGamesAPI
dotnet restore
dotnet ef database update
dotnet run

Open web browser to http://localhost:5155.
### Frontend Setup Commands
cd 3ds-ui
npm install
npm run dev

Open web browser to http://localhost:5173. Axios fetches from /api/games via Vite proxy.
