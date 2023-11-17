// ReSharper disable NotAccessedField.Global
namespace MordorReader;

public class Character
{
    public string Name = "";
    public int Race;
    public int Alignment;
    public int Sex;
    public float DaysOld;
    public int CurrentMP;
    public int DungeonLevel;
    public int CurrentX;
    public int CurrentY;
    public float Atk;
    public float Def;
    public Stats BaseStats = null!;
    public Stats ModifiedStats = null!;
    public HeldItem[] InventoryItems = new HeldItem[41]; 
    public HeldItem[] BankItems = new HeldItem[41]; 
    public short[] EquippedItems = new short[36];
    public long UnusedDamageMod;
    public short Unused1;
    public short Direction; // 1 = North, 2 = East, 3 = South, 4 = West
    public short Unused2;
    public long TotalExperience;
    public long GoldOnHand;
    public short CurrentHp;
    public short MaxHp;
    public long GoldInBank;
    public int ExtraSwings;
    public int ActiveGuild;
    public GuildStatus[] GuildStatuses = new GuildStatus[16];
    public Companion[] Companions = new Companion[5];
    public short HandsOccupied;
    public short M58DC;
    public short RezChance;
    public string CharacterPerformingRez = "";
    public long[] MiscCharacterInfo = new long[9];
    public short[] CharacterOptions = new short[6];
    public short[] StatusEffects = new short[8];
    public short[] Resistances = new short[12];
    public int TempBuffs;
    public short[] TempResistances = new short[12];
    public short DeadType;
    public short CarriedCorpseID;
    public string Password = "";
    public SavedWindowState[] SavedWindowStates = new SavedWindowState[21];
    public short RecordLineNumber;
    public int XpNeededToPin;
    public int AbilitiesFromEquippedItems;
    public short[] ResistsFromItems = new short[12];
    public short[] EquippedItemsInHands = new short[2];
    public short SomeADPlaceholderMaybe;
    public short[] BufferSlots = new short[11];
    public short CurrentAreaNum;
    public short Unused3;
    public short Unused4;
    public MapCoordinates SanctuaryCoordinates = new();
    public short[] LocationAwareness = new short[3];

    public float TotalAtkFromGuilds => GuildStatuses.Sum(status => status.Atk);
    public float TotalDefFromGuilds => GuildStatuses.Sum(status => status.Def);
    public override string ToString() => Name;
}
