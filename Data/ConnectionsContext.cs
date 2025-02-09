using Connections.Models;
using Microsoft.EntityFrameworkCore;

namespace Connections.Data
{
    public class ConnectionsContext(DbContextOptions<ConnectionsContext> options) : DbContext(options)
    {
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Puzzle>().HasData
            (
                new Puzzle
                { 
                    Id = 1,
                    ShareId = "test1234",
                    Title = "Example Puzzle",
                    CreatedBy = "avery",
                    CreatedOn = DateTime.Now
                }
            );

            modelBuilder.Entity<Group>().HasData
            (
                new Group
                {
                    PuzzleId = 1,
                    Description = "Parts of a Bicycle Wheel",
                    Difficulty = Difficulty.YELLOW,
                    Member1 = "Spoke",
                    Member2 = "Hub",
                    Member3 = "Rim",
                    Member4 = "Tire"
                },
                new Group
                {
                    PuzzleId = 1,
                    Description = "Types of Fabric",
                    Difficulty = Difficulty.GREEN,
                    Member1 = "Cotton",
                    Member2 = "Silk",
                    Member3 = "Wool",
                    Member4 = "Linen"
                },
                new Group
                {
                    PuzzleId = 1,
                    Description = "To Regard",
                    Difficulty = Difficulty.BLUE,
                    Member1 = "Deem",
                    Member2 = "Rate",
                    Member3 = "Judge",
                    Member4 = "Reckon"
                },
                new Group
                {
                    PuzzleId = 1,
                    Description = "Last words of David Lynch titles",
                    Difficulty = Difficulty.PURPLE,
                    Member1 = "Peaks",
                    Member2 = "Empire",
                    Member3 = "Drive",
                    Member4 = "Velvet"
                }
            );
        }

    }
}
