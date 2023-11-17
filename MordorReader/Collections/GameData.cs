namespace MordorReader;

public class GameData
{
    public string Version = "";

    public int NumRaces;
    public int NumGuilds;
    public int NumItemSubtypes;
    public int NumItemTypes;
    public int NumMonsterSubtypes;
    public int NumMonsterTypes;

    public List<RaceInfo> Races = new();
    public List<GuildInfo> Guilds = new();
    public List<ItemSubtype> ItemSubtypes = new();
    public List<ItemType> ItemTypes = new();
    public List<MonsterSubtype> MonsterSubtypes = new();
    public List<MonsterPrimaryType> MonsterTypes = new();
}
