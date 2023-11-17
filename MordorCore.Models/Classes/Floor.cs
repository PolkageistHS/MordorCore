namespace MordorCore.Models.Classes;

public class Floor
{
    public short Width { get; set; }

    public short Height { get; set; }
    
    public short LevelNum { get; set; }
    
    public short AreaCount { get; set; }
    
    public short TeleporterCount { get; set; }
    
    public short ChuteCount { get; set; }
    
    public List<DungeonMapTile> Tiles { get; set; } = new();
    
    public List<Area> Areas { get; set; } = new();
    
    public List<Teleporter> Teleporters { get; set; } = new();
    
    public List<Chute> Chutes { get; set; } = new();
}
