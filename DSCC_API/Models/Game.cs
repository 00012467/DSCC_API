namespace DSCC_API.Models;

public class Game
{
    public Guid GameId { get; set; }
    public required string GameName { get; set; }
    public required string DeveloperName { get; set; }
    public required string EngineName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Genre? GameGenre { get; set; }
}