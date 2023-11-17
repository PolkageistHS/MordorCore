namespace MordorReader;

public class GeneralStore
{
    public string Version = "";

    public short Header1;

    public short Count;

    public List<StoreItem> Items = new();

    public List<StoreItem> ItemsById => Items.OrderBy(item => item.RowNumber).ToList();
}
