namespace MordorReader;

public class GuildLog
{
    public short Count;

    public Dictionary<short, List<GuildLogEntry>> Entries = new();


    public void AddGuildLog(GuildLogEntry log)
    {
        if (!Entries.ContainsKey(log.GuildID))
            Entries.Add(log.GuildID, new List<GuildLogEntry>());
        Entries[log.GuildID].Add(log);
    }
}
