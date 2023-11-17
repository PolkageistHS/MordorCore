namespace MordorCore.Models.Classes;

public class AreaSpawn
{
    public MonsterSpawn MonsterSpawnGroup1 { get; set; } = null!;

    public MonsterSpawn MonsterSpawnGroup2 { get; set; } = null!;
    
    public MonsterSpawn MonsterSpawnGroup3 { get; set; } = null!;
    
    public MonsterSpawn MonsterSpawnGroup4 { get; set; } = null!;

    public TreasureSpawn Treasure { get; set; } = null!;
}
