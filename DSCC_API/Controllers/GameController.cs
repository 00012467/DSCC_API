using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSCC_API.Data;
using DSCC_API.Models;
using DSCC_API.Models.DTOs;

namespace DSCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameDbContext _context;

        public GameController(GameDbContext context)
        {
            _context = context;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            // Include method is used, so Genre model will be included in the Game objects
            return await _context.Games
                .Include(game=>game.GameGenre)
                .ToListAsync();
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            
            if (game == null)
                return NotFound();
            
            // Reference method is used, so Genre model will be included in the Game object
            await _context.Entry(game!)
                .Reference(g => g!.GameGenre)
                .LoadAsync();
            
            return game;
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, GameDTO game)
        {
            var oldGame = await _context.Games.FindAsync(id);

            if (oldGame == null)
                return NotFound();
            
            _context.Entry(oldGame).State = EntityState.Modified;
            
            // Updates Game with the help of GameDTO
            oldGame.GameGenre = await _context.Genres.FindAsync(game.GameGenreId);
            oldGame.GameName = game.GameName;
            oldGame.DeveloperName = game.DeveloperName;
            oldGame.EngineName = game.EngineName;
            oldGame.ReleaseDate = game.ReleaseDate;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Game
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(GameDTO gameDTO)
        {
            var game = new Game
            {
                GameName = gameDTO.GameName,
                DeveloperName = gameDTO.DeveloperName,
                EngineName = gameDTO.EngineName,
                ReleaseDate = gameDTO.ReleaseDate,
                GameGenre = await _context.Genres.FindAsync(gameDTO.GameGenreId)
            };
            try
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();
                return Ok(game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(Guid id)
        {
            return (_context.Games?.Any(e => e.GameId == id)).GetValueOrDefault();
        }
    }
}