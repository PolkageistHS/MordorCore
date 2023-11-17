namespace MordorReader;

public class Guildmaster
{
    public string Name = "";

    public short Level;

    /// <inheritdoc />
    public override string ToString() => $"{Name} ({Level})";
}
