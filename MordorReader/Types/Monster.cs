namespace MordorReader;

public class Monster
{
	public string Name = "";
	public short Attack;
	public short Defense;
	public short ID;
	public short Hits;
	public short NumGroups;
	public short PicID;
	public short LockedChance;
	public short LevelFound;
	public readonly short[] resistances = new short[12]; //only first 11 used
	public int _specialPropertyFlags;
	public int _specialAttackFlags;
	public int _spellFlags;
	public short EncounterChance;
	public readonly short[] boxChance = new short[4]; //only first 3 used
	public short _alignment; // 0 Good - 2 Evil
	public short GroupSize;
	public int GoldFactor; //wabbit's u11
	public int trapFlags; //wabbit's u12
	public int GuildLevel;
	public readonly short[] stats = new short[7]; //only first 6 used
	public short MonsterType; //0 Humanoid - 17 indigini
	public float DamageMod;
	public short CompanionType; //0 Humanoid - 17 indigini
	public short CompanionSpawnMode; //wabbit's u18
	public short CompanionID; //id of specific monster
	public readonly short[] items = new short[11]; //only first 10 used
	public short SimilarityID; //wabbit's u21
	public short CompanionGrouping; //wabbit's u22
	public short _size;
	public short ItemDropLevel;
	public short ItemChance;

	public Size Size => (Size)_size;

	public List<SpellClassFlag> Spells => Helpers.ParseEnum<SpellClassFlag>(_spellFlags);

	public List<SpecialAttack> SpecialAttacks => Helpers.ParseEnum<SpecialAttack>(_specialAttackFlags);

	public List<SpecialProperty> SpecialProperties => Helpers.ParseEnum<SpecialProperty>(_specialPropertyFlags);

	public MonsterAlignment Alignment => (MonsterAlignment)_alignment;

	public override string ToString() => $"{Name} : {ID}";
}
