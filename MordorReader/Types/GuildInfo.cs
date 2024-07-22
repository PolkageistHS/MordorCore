namespace MordorReader;

public class GuildInfo
{
    public string Name = "";
    public short AverageHits;
    public short MaxLevel;
    public short MH;
    public float ExpFactor;
    public short Unused1;
    public short[] ReqStats = new short[7];
    public int Alignment;
    public float[] AbilityRates = new float[7];
    public short Quested;
    public float Unused2;
    public short QuestPercentage;
    public List<SpellClass> SpellClasses = new(19);
    public int RaceMask;
    public short GoldFactor;
    public float ItemFactor;
    public float Atk;
    public float Def;
    public short MaxAtkDefIncreaseLevel;
    public float AtkDefIncreaseRate;
    public short Unused5;
    public short Unused6;

    public List<RaceMask> Races => Helpers.ParseEnum<RaceMask>(RaceMask);

    public override string ToString() => Name;
}
