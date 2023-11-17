namespace MordorReader;

public class Library
{
    public string Version = "";
    public short MonstersFound;
    public short ItemsFound;
    public short TotalMonsters;
    public short TotalItems;
    public List<LibraryRecord> Monsters = new();
    public List<LibraryRecord> Items = new();

    public List<LibraryRecord> MonstersByID => Monsters.OrderBy(record => record.ID).ToList();
    public List<LibraryRecord> ItemsByID => Items.OrderBy(record => record.ID).ToList();
}
