namespace MordorReader;

public class RaceInfo
{
    public string Name = "";
    public short[] MinStats = new short[7];
    public short[] MaxStats = new short[7];
    public short[] Resistances = new short[12];
    public int _alignment;
    public short _size;
    public short BonusPoints;
    public short MaxAge;
    public float ExpFactor;

    public List<MonsterAlignment> Alignments => Helpers.ParseEnum<MonsterAlignment>(_alignment);

    public Size Size => (Size)_size;
    public override string ToString() => Name;
}
