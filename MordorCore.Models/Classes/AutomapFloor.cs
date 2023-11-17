namespace MordorCore.Models.Classes;

public class AutomapFloor
{
    [SkipRecord]
    public short FloorNumber { get; set; }

    [NewRecord]
    public List<AutomapTile> Tiles { get; set; } = new();
}
