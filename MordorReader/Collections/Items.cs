namespace MordorReader;

public class Items
{
	public string Version { get; set; } = "";

	public short Count { get; set; }

	public short GeneralStoreCode { get; set; }

	public List<Item> ItemList { get; } = new();

	public List<Item> ItemsById => ItemList.OrderBy(item => item.ID).ToList();

	public List<Item> ItemsByName => ItemList.OrderBy(item => item.Name).ToList();
}
