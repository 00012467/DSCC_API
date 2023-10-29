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
    public class GenreController : ControllerBase
    {
        private readonly GameDbContext _context;

        public GenreController(GameDbContext context)
        {
            _context = context;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
                return NotFound();

            return genre;
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(Guid id, GenreDTO genre)
        {
            var oldGenre = await _context.Genres.FindAsync(id);

            if (oldGenre == null)
                return NotFound();
            
            _context.Entry(oldGenre).State = EntityState.Modified;
            oldGenre.GenreName = genre.GenreName;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Genre
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            
            // Returns created genre 
            return CreatedAtAction("GetGenre", new { id = genre.GenreId }, genre); 
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                return NotFound();

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Checks whether database has the genre with this id
        private bool GenreExists(Guid id)
        {
            return (_context.Genres?.Any(e => e.GenreId == id)).GetValueOrDefault();
        }
    }
}