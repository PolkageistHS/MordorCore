namespace MordorReader;

public class Companion
{
    public string Name = "";
    public short MonsterID;
    public short Slot;
    public short CurrentHp;
    public short MaxHp;
    public short Alignment;
    public short Atk;
    public short Def;
    public short BindLevel;
    public short IDLevel;

    public override string ToString() => Name;
}
