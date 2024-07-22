namespace MordorCore.Models.Classes;

public class AutomapTile
{
    [SkipProperty]
    public short X { get; set; }

    [SkipProperty]
    public short Y { get; set; }

    [NewRecord]
    public int Tile { get; set; }
}
