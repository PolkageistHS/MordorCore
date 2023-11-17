namespace MordorReader;

public class Spell
{
	public string Name = "";
	public short ID;
	public short Category;
	public short Level;
	public short Cost;
	public short unused;
	public short KillEffect;
	public short AffectMonster;
	public short AffectGroup;
	public short Damage1;
	public short Damage2;
	public int SpecialEffect;
	public short[] RequiredStats = new short[7];
	public short ResistedBy;

	public override string ToString() => $"{Name}: ID {ID}, Category {Category}";
}
