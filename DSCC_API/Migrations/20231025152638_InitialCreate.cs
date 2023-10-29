using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSCC_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameGenreGenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GameGenreGenreId",
                        column: x => x.GameGenreGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameGenreGenreId",
                table: "Games",
                column: "GameGenreGenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
