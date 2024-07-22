namespace MordorCore.Models.DataFiles;

[DataRecordLength(100)]
public class DATA13Library : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    [NewRecord]
    public short MonstersFound { get; set; }

    [NewRecord]
    public short ItemsFound { get; set; }

    private short _totalMonsters;
    [NewRecord]
    public short TotalMonsters
    {
        get => _totalMonsters;
        set
        {
            _totalMonsters = value;
            if (Monsters.Length == 0)
            {
                Monsters = new LibraryRecord[value];
            }
        }
    }

    private short _totalItems;
    [NewRecord]
    public short TotalItems
    {
        get => _totalItems;
        set
        {
            _totalItems = value;
            if (Items.Length == 0)
            {
                Items = new LibraryRecord[value];
            }
        }
    }

    public LibraryRecord[] Monsters { get; set; } = [];

    public LibraryRecord[] Items { get; set; } = [];
}
