namespace MordorReader;

public class GuildLog
{
    public short Count;

    public readonly Dictionary<short, List<GuildLogEntry>> Entries = [];

    public void AddGuildLog(GuildLogEntry log)
    {
        if (!Entries.ContainsKey(log.GuildID))
        {
            Entries.Add(log.GuildID, []);
        }
        Entries[log.GuildID].Add(log);
    }
}
