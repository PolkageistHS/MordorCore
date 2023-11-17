namespace MordorReader;

public class DungeonState
{
    public short LevelCount;
    public short[] SpawnCounts = null!;
    public List<AreaSpawn> AreaSpawns = new();
}
