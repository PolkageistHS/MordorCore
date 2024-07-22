namespace MordorCore.Models.DataFiles;

[DataRecordLength(75)]
public class DATA02Spells : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    private short _count;
    [NewRecord]
    public short Count
    {
        get => _count;
        set
        {
            _count = value;
            if (Spells.Length == 0)
            {
                Spells = new Spell[value];
            }
        }
    }

    public Spell[] Spells { get; set; } = [];
}
