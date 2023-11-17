namespace MordorCore.Models.DataFiles;

[DataRecordLength(2900)]
public class DATA04Characters : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    [NewRecord]
    public short CharacterCount { get; set; }

    public List<Character> CharacterList { get; set; } = new();
}
