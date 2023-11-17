namespace MordorCore.Models.Classes;

public class MonsterType
{
    [NewRecord]
    public string Name { get; set; } = null!;

    public short Unused { get; set; }
}
