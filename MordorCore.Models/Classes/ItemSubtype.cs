namespace MordorCore.Models.Classes;

public class ItemSubtype
{
    [NewRecord]
    public string Name { get; set; } = null!;

    public short ItemType { get; set; }

    public override string ToString() => Name;
}
