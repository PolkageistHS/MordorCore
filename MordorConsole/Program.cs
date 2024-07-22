namespace MordorConsole;

internal static class Program
{
    // ReSharper disable UnusedVariable
    private static void Main()
    {
        const string folder = @"C:\Users\John\Downloads\MordorShared";
        //string? weapon = new WeaponGen().TransformText();
        //string? armor = new ArmorGen().TransformText();
        //string? consumables = new ConsumableGen().TransformText();
        //string? accessories = new AccessoryGen().TransformText();
        //string? sigils = new SigilGen().TransformText();
        //string? ids = new OtherIdGen().TransformText();
        //string? mons = new MonsterGen().TransformText();
        //string? spelltext = new SpellGen().TransformText();
        ReflectionRecordReader reader = new(folder);
        DATA01GameData gamedata = reader.GetMordorRecord<DATA01GameData>();
        DATA02Spells spells = reader.GetMordorRecord<DATA02Spells>();
        DATA03Items items = reader.GetMordorRecord<DATA03Items>();
        DATA04Characters characters = reader.GetMordorRecord<DATA04Characters>();
        DATA05Monsters monsters = reader.GetMordorRecord<DATA05Monsters>();
        DATA06GeneralStore generalStore = reader.GetMordorRecord<DATA06GeneralStore>();
        DATA07Guildmasters guildmasters = reader.GetMordorRecord<DATA07Guildmasters>();
        DATA08Automap automap = reader.GetMordorRecord<DATA08Automap>();
        DATA09GuildLogs guildLogs = reader.GetMordorRecord<DATA09GuildLogs>();
        //DATA10DungeonState dungeonState = reader.GetMordorRecord<DATA10DungeonState>();
        //DATA11DungeonMap dungeonMap = reader.GetMordorRecord<DATA11DungeonMap>();
        //DATA12PartyGroups partyGroups = reader.GetMordorRecord<DATA12PartyGroups>();
        DATA13Library library = reader.GetMordorRecord<DATA13Library>();
        DATA14HallOfRecords hallOfRecords = reader.GetMordorRecord<DATA14HallOfRecords>();
        DATA15Confinement confinement = reader.GetMordorRecord<DATA15Confinement>();
    }
}
