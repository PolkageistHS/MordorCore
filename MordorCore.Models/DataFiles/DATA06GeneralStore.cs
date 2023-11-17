namespace MordorCore.Models.DataFiles;

[DataRecordLength(16)]
public class DATA06GeneralStore : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = "";

    [NewRecord]
    public short Header1 { get; set; }

    [NewRecord]
    public short AllItemsCount { get; set; }

    public List<StoreItem> Items { get; set; } = new();
}
