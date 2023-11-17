namespace MordorReader;

public class Item
{
    public string Name = "";
    public short ID;
    public short Attack;
    public short Defense;
    public int Price;
    public short Floor;
    public short Rarity;
    public int _abilities;
    public short Swings;
    public short SpecialType;
    public short SpellRowNum;
    public short SpellID;
    public short Charges;
    public short SubTypeID;
    public int _guilds;
    public short LevelScale;
    public float DamageMod;
    public int _alignmentFlags;
    public short Hands;
    public short Type;
    public int _resistanceFlags;
    public readonly short[] Stats = new short[7];
    public readonly short[] StatsMod = new short[7];
    public short Cursed;
    public short SpellLvl;
    public short ClassRestricted;

    public List<GuildMask> Guilds => Helpers.ParseEnum<GuildMask>(_guilds);

    public List<Resistance> Resists => Helpers.ParseEnum<Resistance>(_resistanceFlags);

    public List<ItemAlignment> Alignments => Helpers.ParseEnum<ItemAlignment>(_alignmentFlags);

    public List<ItemAbility> Abilities => Helpers.ParseEnum<ItemAbility>(_abilities);

    public override string ToString() => $"{Name}: ID {ID}";
}
