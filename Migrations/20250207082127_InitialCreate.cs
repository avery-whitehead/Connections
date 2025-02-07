using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Connections.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puzzles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    PuzzleId = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Member1 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Member2 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Member3 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Member4 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => new { x.PuzzleId, x.Difficulty });
                    table.ForeignKey(
                        name: "FK_Groups_Puzzles_PuzzleId",
                        column: x => x.PuzzleId,
                        principalTable: "Puzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ShareId", "Title" },
                values: new object[] { 1, "avery", new DateTimeOffset(new DateTime(2025, 2, 7, 0, 21, 26, 974, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, -8, 0, 0, 0)), "test1234", "Example Puzzle" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Difficulty", "PuzzleId", "Description", "Member1", "Member2", "Member3", "Member4" },
                values: new object[,]
                {
                    { 1, 1, "Parts of a Bicycle Wheel", "Spoke", "Hub", "Rim", "Tire" },
                    { 2, 1, "Types of Fabric", "Cotton", "Silk", "Wool", "Linen" },
                    { 3, 1, "To Regard", "Deem", "Rate", "Judge", "Reckon" },
                    { 4, 1, "Last words of David Lynch titles", "Peaks", "Empire", "Drive", "Velvet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_ShareId",
                table: "Puzzles",
                column: "ShareId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Puzzles");
        }
    }
}
