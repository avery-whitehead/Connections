using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Connections.Models
{
    /// <summary>
    /// Represents one of four groups/matches/rows inside a puzzle
    /// </summary>
    [PrimaryKey(nameof(PuzzleId), nameof(Difficulty))]
    public class Group
    {
        /// <summary>
        /// ID of the puzzle this group belongs to
        /// </summary>
        [ForeignKey(nameof(Puzzle))]
        public required int PuzzleId { get; set; }

        /// <summary>
        /// Label describing the connection of this group
        /// </summary>
        [MaxLength(255)]
        public required string Description { get; set; }

        /// <summary>
        /// Difficulty of the group from 1 (easiest) to 4 (hardest)
        /// </summary>
        [Range(1, 4)]
        public required Difficulty Difficulty { get; set; }

        /// <summary>
        /// The first member of this group
        /// </summary>
        [MaxLength(55)]
        public required string Member1 { get; set; }

        /// <summary>
        /// The second member of this group
        /// </summary>
        [MaxLength(55)]
        public required string Member2 { get; set; }

        /// <summary>
        /// The third member of this group
        /// </summary>
        [MaxLength(55)]
        public required string Member3 { get; set; }

        /// <summary>
        /// The fourth member of this group
        /// </summary>
        [MaxLength(55)]
        public required string Member4 { get; set; }
    }

    public enum Difficulty
    {
        YELLOW = 1,
        GREEN = 2,
        BLUE = 3,
        PURPLE = 4
    }
}