using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3dsGamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreatingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "CopiesSold", "IsMultiplayer", "Publisher", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 6440000, false, "Nintendo", new DateTime(2011, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Ocarina of Time 3D" },
                    { 2, 400000, true, "Capcom", new DateTime(2011, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil: The Mercenaries 3D" },
                    { 3, 16760000, true, "Nintendo * The Pokemon Company", new DateTime(2013, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pokémon X and Y" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3);
        }
    }
}
