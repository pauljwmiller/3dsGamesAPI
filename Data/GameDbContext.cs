using Microsoft.EntityFrameworkCore;
using _3dsGamesAPI.Models;

namespace _3dsGamesAPI.Data
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } //Represents "Games" table
        //Constructor required for dependency injection
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        //Fallback config if no DI is provided
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Avoids overwriting the DI setup
                {
                    optionsBuilder.UseSqlite("Data Source=games.db");
                }
        }
        //Uses seed data by starting with data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    Title = "The Legend of Zelda: Ocarina of Time 3D",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateTime(2011, 6, 19),
                    CopiesSold = 6440000, // Store as an integer (e.g., in units)
                    IsMultiplayer = false
                },
                new Game
                {
                    GameId = 2,
                    Title = "Resident Evil: The Mercenaries 3D",
                    Publisher = "Capcom",
                    ReleaseDate = new DateTime(2011, 6, 28),
                    CopiesSold = 400000,
                    IsMultiplayer = true
                },
                new Game
                {
                    GameId = 3,
                    Title = "Pokémon X and Y",
                    Publisher = "Nintendo * The Pokemon Company",
                    ReleaseDate = new DateTime(2013, 10, 12),
                    CopiesSold = 16760000,
                    IsMultiplayer = true
                }
            );
        }

    }
}