namespace MordorCore.Models.Classes;

public class ItemType
{
    [NewRecord]
    public string Name { get; set; } = null!;

    public short IsEquippable { get; set; }

    public override string ToString() => Name;
}
