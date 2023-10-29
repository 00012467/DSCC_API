using DSCC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_API.Data;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
        
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Game> Games { get; set; }
}