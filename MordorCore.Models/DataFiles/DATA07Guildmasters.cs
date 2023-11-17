namespace MordorCore.Models.DataFiles;

[DataRecordLength(128)]
public class DATA07Guildmasters : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    public List<Guildmaster> GuildmasterList { get; set; } = new(12);
}
