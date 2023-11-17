namespace MordorReader;

public class Monsters
{
	public string Version = "";

	public short Count;

	public List<Monster> MonstersList { get; } = new();

	public List<Monster> MonstersByName => MonstersList.OrderBy(monster => monster.Name).ToList();

	public List<Monster> MonstersByID => MonstersList.OrderBy(monster => monster.ID).ToList();

	public List<IGrouping<short, Monster>> MonstersBySimilarityID => MonstersList.GroupBy(monster => monster.SimilarityID).OrderBy(x => x.Key).ToList();
}
