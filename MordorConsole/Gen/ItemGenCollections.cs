namespace MordorConsole;

public static class ItemGenCollections
{
    public static readonly Dictionary<int, string> Alignments = new()
    {
        { 0, "Alignments.Unaligned" },
        { 1, "Alignments.Good" },
        { 2, "Alignments.Neutral" },
        { 3, "Alignments.Evil" }
    };

    public static readonly Dictionary<int, string> MonsterAlignments = new()
    {
        { 0, "Alignments.Good" },
        { 1, "Alignments.Neutral" },
        { 2, "Alignments.Evil" }
    };

    public static readonly Dictionary<int, string> EquippedEffects = new()
    {
        { -1, "EquippedEffects.None" },
        { 0, "EquippedEffects.Levitate" },
        { 1, "EquippedEffects.Invisible" },
        { 2, "EquippedEffects.Protection" },
        { 3, "EquippedEffects.SeeInvisible" },
        { 4, "EquippedEffects.CriticalHit" },
        { 5, "EquippedEffects.Backstab" }
    };

    public static readonly Dictionary<int, string> Guilds = new()
    {
        { 0, "GuildIds.Nomad" },
        { 1, "GuildIds.Warrior" },
        { 2, "GuildIds.Paladin" },
        { 3, "GuildIds.Ninja" },
        { 4, "GuildIds.Villain" },
        { 5, "GuildIds.Seeker" },
        { 6, "GuildIds.Thief" },
        { 7, "GuildIds.Scavenger" },
        { 8, "GuildIds.Mage" },
        { 9, "GuildIds.Sorcerer" },
        { 10, "GuildIds.Wizard" },
        { 11, "GuildIds.Healer" }
    };

    public static readonly Dictionary<int, string> EquippedResists = new()
    {
        { -1, "EquippedResists.None" },
        { 0, "EquippedResists.Fire" },
        { 1, "EquippedResists.Cold" },
        { 2, "EquippedResists.Electric" },
        { 3, "EquippedResists.Psychic" },
        { 4, "EquippedResists.Disease" },
        { 5, "EquippedResists.Poison" },
        { 6, "EquippedResists.Magic" },
        { 7, "EquippedResists.Stone" },
        { 8, "EquippedResists.Paralysis" },
        { 9, "EquippedResists.Drain" },
        { 10, "EquippedResists.Acid" }
    };

    public static readonly Dictionary<int, string> Cursed = new()
    {
        { 0, "CursedLevels.NotCursed" },
        { 1, "CursedLevels.Cursed" },
        { 2, "CursedLevels.AutoAttach" }
    };

    public static readonly Dictionary<int, string> Resists = new()
    {
        { 1, "Fire" },
        { 2, "Cold" },
        { 3, "Electric" },
        { 4, "Psychic" },
        { 5, "Disease" },
        { 6, "Poison" },
        { 7, "Kinetic" },
        { 8, "Stone" },
        { 9, "Paralysis" },
        { 10, "Drain" },
        { 11, "Acid" }
    };
}
