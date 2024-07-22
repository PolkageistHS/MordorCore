namespace MordorCore.Models.DataFiles;

[DataRecordLength(16)]
public class DATA15Confinement : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = "";
    
    [NewRecord]
    public short Count { get; set; }

    private short _totalRecords;
    [NewRecord]
    public short TotalRecords
    {
        get => _totalRecords;
        set
        {
            _totalRecords = value;
            if (Monsters.Length == 0)
            {
                Monsters = new ConfinementMonster[value];
            }
        }
    }

    public ConfinementMonster[] Monsters { get; set; } = [];
}
