namespace MordorCore.Models.DataFiles;

[DataRecordLength(260)]
public class DATA01GameData : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    private short _numRaces;
    [NewRecord]
    public short NumRaces
    {
        get => _numRaces;
        set
        {
            _numRaces = value;
            if (Races.Length == 0)
            {
                Races = new Race[value];
            }
        }
    }

    private short _numGuilds;
    [NewRecord]
    public short NumGuilds
    {
        get => _numGuilds;
        set
        {
            _numGuilds = value;
            if (Guilds.Length == 0)
            {
                Guilds = new Guild[value];
            }
        }
    }

    private short _numItemSubtypes;
    [NewRecord]
    public short NumItemSubtypes
    {
        get => _numItemSubtypes;
        set
        {
            _numItemSubtypes = value;
            if (ItemSubtypes.Length == 0)
            {
                ItemSubtypes = new ItemSubtype[value];
            }
        }
    }

    private short _numItemTypes;
    [NewRecord]
    public short NumItemTypes
    {
        get => _numItemTypes;
        set
        {
            _numItemTypes = value;
            if (ItemTypes.Length == 0)
            {
                ItemTypes = new ItemType[value];
            }
        }
    }

    private short _numMonsterSubtypes;
    [NewRecord]
    public short NumMonsterSubtypes
    {
        get => _numMonsterSubtypes;
        set
        {
            _numMonsterSubtypes = value;
            if (MonsterSubtypes.Length == 0)
            {
                MonsterSubtypes = new MonsterSubtype[value];
            }
        }
    }

    private short _numMonsterTypes;
    [NewRecord]
    public short NumMonsterTypes
    {
        get => _numMonsterTypes;
        set
        {
            _numMonsterTypes = value;
            if (MonsterTypes.Length == 0)
            {
                MonsterTypes = new MonsterType[value];
            }
        }
    }

    public Race[] Races { get; set; } = [];

    public Guild[] Guilds { get; set; } = [];

    public ItemSubtype[] ItemSubtypes { get; set; } = [];

    public ItemType[] ItemTypes { get; set; } = [];

    public MonsterSubtype[] MonsterSubtypes { get; set; } = [];

    public MonsterType[] MonsterTypes { get; set; } = [];
}
