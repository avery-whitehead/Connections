namespace Connections.Models
{
    public class Tile
    {
        public string Label { get; set; } = "";
        public TileState State { get; set; } = TileState.DEFAULT;
        public string SolvedColour { get; set; } = "";
    }

    public enum TileState
    {
        DEFAULT = 0,
        SELECTED = 1,
        CORRECT = 2,
        DISABLED = 3
    }
}
