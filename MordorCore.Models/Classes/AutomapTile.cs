namespace MordorCore.Models.Classes;

public class AutomapTile
{
    [SkipRecord]
    public short X { get; set; }

    [SkipRecord]
    public short Y { get; set; }

    [NewRecord]
    public int Tile { get; set; }
}
