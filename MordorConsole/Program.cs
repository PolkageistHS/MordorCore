using MordorCore.DAL;
using MordorCore.Models.DataFiles;

namespace MordorConsole;

internal static class Program
{
    // ReSharper disable UnusedVariable
    private static void Main()
    {
        const string folder = @"C:\Users\John\Downloads\MordorShared";
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
