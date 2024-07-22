namespace MordorCore.Models.DataFiles;

[DataRecordLength(160)]
public class DATA05Monsters : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    [NewRecord]
    public short Unused { get; set; }

    private short _count;

    [NewRecord]
    public short Count
    {
        get => _count;
        set
        {
            _count = value;
            if (MonstersList.Length == 0)
            {
                MonstersList = new Monster[value];
            }
        }
    }

    public Monster[] MonstersList { get; set; } = [];
}
