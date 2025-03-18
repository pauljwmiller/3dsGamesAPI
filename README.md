# 3dsGamesAPI
3ds games web api using C# and .NET/Entity Framework Core, as well as SQLite.
This API lets users perform CRUD operations on a database of 3DS games.

## Features
- CRUD Operations: Manage games with endpoints to create/read/update/delete
- SQLite Integration: Persistant storage for database
- Seeding Data: Predefined seed data for some 3DS games
- RESTful API design

## Prerequisites:
- Install:
1. .NET SDK
2. SQLite

## Getting Started
1. Clone the repo
2. Install dependencies -- Restore the NuGet packages with dotnet restore.
3. Configure the database -- Ensure your ConnectionStrings match your db path.
4. Apply migrations with dotnet ef database update
5. Run the API with dotnet run
