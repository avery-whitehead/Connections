using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Connections.Models
{
    /// <summary>
    /// Represents a Connections puzzle
    /// </summary>
    [Index(nameof(ShareId), IsUnique = true)]
    public class Puzzle
    {
        /// <summary>
        /// Incrementing ID used to uniquely identify puzzle in the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Short ID used for sharing, also unique
        /// </summary>
        [StringLength(8)]
        public required string ShareId { get; set; }

        /// <summary>
        /// Friendly title
        /// </summary>
        [MaxLength(255)]
        public required string Title { get; set; }

        /// <summary>
        /// Name of person who created puzzle
        /// </summary>
        [MaxLength(255)]
        public required string CreatedBy { get; set; }

        /// <summary>
        /// Date/time puzzle was created
        /// </summary>
        public required DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Groups in the puzzle
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; } = [];

        /// <summary>
        /// Helper property that stores the group tiles and their states in
        /// a single array
        /// </summary>
        
        [NotMapped]
        public IEnumerable<Tile> Tiles { get; set; } = [];
    }
}
