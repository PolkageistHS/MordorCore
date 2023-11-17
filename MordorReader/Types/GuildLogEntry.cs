namespace MordorReader;

public class GuildLogEntry
{
    public short GuildID;

    public int DayValue;

    public string Message = "";

    public DateTime Date => new DateTime(1900, 1, 1).AddDays(DayValue);

    public override string ToString() => $"{Date:d} {Message}";
}
