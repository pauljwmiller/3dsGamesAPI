using _3dsGamesAPI.Models; // For game model
using Microsoft.AspNetCore.Mvc; // For API controllers and HTTP responses
using System.Linq; // For Linq queries
using Microsoft.EntityFrameworkCore; // For database interactions
using _3dsGamesAPI.Data; // For GameDbContext, etc.

namespace _3dsGamesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        public readonly GameDbContext _context;

        //Constructor: initializes the GameDbContext via Dependency Injection
        public GamesController(GameDbContext context)
        {
            _context = context;
        }

        //GET: api/games (Retrieve all games)
        [HttpGet]
        public IActionResult GetAllGames()
        {
            var games = _context.Games.ToList(); // Fetch all games
            return Ok(games);
        }
        //GET: api/games/{id} (Retrieve a single game by ID)
        [HttpGet("{id}")]  
        public IActionResult GetGameById(int id)
        {
            var game = _context.Games.Find(id);

            if (game == null)
            {
                return NotFound(); //Return 400 if game does not exist
            }
            return Ok(game); // Return the game details as a200 OK response
        }

        //POST: api/games (Add a new game)
        [HttpPost]
        public IActionResult AddGame([FromBody] Game game)
        {
            if (game == null)
            { 
                return BadRequest(); // Return 400 if request body is invalid
            }

            _context.Games.Add(game); // Add the game to the database
            _context.SaveChanges(); // Save the changes to the database

            return CreatedAtAction(nameof(GetGameById), new { id = game.GameId }, game);
            // Return 201 with the URI of the new resource
        }

        //PUT: api/games/{id} (Update an existing game)
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] Game updatedGame)
        {
            if (updatedGame == null || id != updatedGame.GameId)
            {
                return BadRequest(); //Return 400 if request is invalid
            }

            var existingGame = _context.Games.Find(id); //Find the game by its ID
            if (existingGame == null)
            {
                return NotFound(); //Return 404 if game does not exist
            }

            existingGame.Title = updatedGame.Title;
            existingGame.Publisher = updatedGame.Publisher;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.CopiesSold = updatedGame.CopiesSold;
            existingGame.IsMultiplayer = updatedGame.IsMultiplayer;

            _context.SaveChanges(); //Save the changes to the database

            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/games/{id} (Delete a game)
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _context.Games.Find(id); // Find the game to delete
            if (game == null)
            {
                return NotFound(); // Return 404 if game does not exist
            }

            _context.Games.Remove(game); //Remove the game from the database
            _context.SaveChanges(); //Save the changes to database
            return NoContent(); //Return 204 No Content
        }
    }
}
