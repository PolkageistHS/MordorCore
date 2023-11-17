namespace MordorCore.Models.DataFiles;

[DataRecordLength(28)]
public class DATA10DungeonState : IMordorDataFile
{
    [NewRecord]
    public short LevelCount { get; set; }

    [NewRecord]
    public short[] SpawnCounts { get; set; } = new short[15];
    
    public List<AreaSpawn> AreaSpawns { get; set; } = new();
}
