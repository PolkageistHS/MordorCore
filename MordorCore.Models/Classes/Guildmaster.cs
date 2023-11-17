namespace MordorCore.Models.Classes;

public class Guildmaster
{
    [NewRecord]
    public string Name { get; set; } = "";

    public short Level { get; set; }
}
