namespace MordorCore.Models.DataFiles;

[DataRecordLength(125)]
public class DATA03Items : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = "";

    [NewRecord]
    public short GeneralStoreCode { get; set; }

    private short _count;
    [NewRecord]
    public short Count
    {
        get => _count;
        set
        {
            _count = value;
            if (ItemList.Length == 0)
                ItemList = new Item[value];
        }
    }

    public Item[] ItemList { get; set; } = { };
}
