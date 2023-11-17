namespace MordorReader;

public class Confinement
{
    public string Version = "";
    public int Count;
    public int TotalRecords;
    public List<ConfinementMonster> Monsters = new();
    public List<ConfinementMonster> MonstersByID => Monsters.OrderBy(monster => monster.MonsterID).ToList();
    public List<ConfinementMonster> MonstersByID2 => Monsters.OrderBy(monster => monster.RowNumber).ToList();
}
