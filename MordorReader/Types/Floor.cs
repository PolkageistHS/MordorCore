namespace MordorReader;

public class Floor
{
    public int Width;
    public int Height;
    public int LevelNum;
    public short AreaCount;
    public short TeleporterCount;
    public short ChuteCount;
    public List<MapTile> Tiles = new();
    public List<Area> Areas = new();
    public List<Teleporter> Teleporters = new();
    public List<Chute> Chutes = new();

    public List<MapTile> TilesSorted => 
        Tiles.OrderBy(tile => tile.X)
             .ThenBy(tile => tile.Y)
             .ToList();

    public List<IGrouping<short, MapTile>> TilesByArea => 
        TilesSorted.GroupBy(tile => tile.Area)
                   .OrderBy(grouping => grouping.Key)
                   .ToList();
}
