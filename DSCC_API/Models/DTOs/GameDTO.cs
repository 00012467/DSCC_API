namespace DSCC_API.Models.DTOs;

// DTO of Game model without Id. GameGenreId is used instead of Genre to properly retrieve data
public class GameDTO
{
    public required string GameName { get; set; }
    public required string DeveloperName { get; set; }
    public required string EngineName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Guid GameGenreId { get; set; }
}