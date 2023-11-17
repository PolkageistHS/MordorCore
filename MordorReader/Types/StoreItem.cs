namespace MordorReader;

public class StoreItem
{
    public short RowNumber;

    public short ItemID;

    public short UnalignedQty;

    public short GoodQty;

    public short NeutralQty;

    public short EvilQty;

    /// <inheritdoc />
    public override string ToString() => $"ItemID: {RowNumber}, {UnalignedQty}/{GoodQty}/{NeutralQty}/{EvilQty}";
}
