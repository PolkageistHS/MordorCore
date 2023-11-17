namespace MordorCore.Models.DataFiles;

[DataRecordLength(35)]
public class DATA12PartyGroups : IMordorDataFile
{
    public short Count { get; set; }

    public List<string[]> Groups { get; set; } = new();
}
