namespace MordorReader;

public class Spells
{
    public string Version = "";

    public short Count;

    public List<Spell> SpellList { get; } = new();

    public List<Spell> SpellsByName => SpellList.OrderBy(spell => spell.Name).ToList();

    public List<Spell> SpellsByID => SpellList.OrderBy(spell => spell.ID).ToList();

    public List<IGrouping<int, Spell>> SpellsBySpecialEffect => SpellList.GroupBy(spell => spell.SpecialEffect).OrderBy(grouping => grouping.Key).ToList();
}
