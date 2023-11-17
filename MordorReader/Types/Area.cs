namespace MordorReader;

public class Area
{
    public int SpawnMask;
    public short LairID;
    public List<MonsterTypeMask> SpawnFlags => Helpers.ParseEnum<MonsterTypeMask>(SpawnMask);
    public string GetSpawns() => string.Join(", ", SpawnFlags);

    public override string ToString() => $"Lair: {LairID}, Spawns: {GetSpawns()}";
}
