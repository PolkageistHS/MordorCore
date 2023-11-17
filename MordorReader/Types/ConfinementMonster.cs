namespace MordorReader;

public class ConfinementMonster
{
    public short RowNumber;
    public short MonsterID;
    public short Good;
    public short Neutral;
    public short Evil;

    public override string ToString() => $"Monster row#: {RowNumber}, {Good}/{Neutral}/{Evil}";
}
