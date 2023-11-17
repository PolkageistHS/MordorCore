using MordorReader;

namespace MordorConsole;

public class DungeonStateComparer
{
    private readonly DungeonState _first;
    private readonly DungeonState _second;

    public DungeonStateComparer(DungeonState first, DungeonState second)
    {
        _first = first;
        _second = second;
    }

    public void PrintDifferences()
    {
        if (_first.LevelCount != _second.LevelCount)
            Console.WriteLine($"LevelCount: {_first.LevelCount} != {_second.LevelCount}");
        if (_first.SpawnCounts.Length != _second.SpawnCounts.Length)
            Console.WriteLine($"SpawnCounts.Length: {_first.SpawnCounts.Length} != {_second.SpawnCounts.Length}");
        for (int i = 0; i < _first.SpawnCounts.Length; i++)
        {
            if (_first.SpawnCounts[i] != _second.SpawnCounts[i])
                Console.WriteLine($"SpawnCounts[{i}]: {_first.SpawnCounts[i]} != {_second.SpawnCounts[i]}");
        }
        if (_first.AreaSpawns.Count != _second.AreaSpawns.Count)
            Console.WriteLine($"AreaSpawns.Count: {_first.AreaSpawns.Count} != {_second.AreaSpawns.Count}");
        else
        {
            for (int i = 0; i < _first.AreaSpawns.Count; i++)
            {
                AreaSpawn area1 = _first.AreaSpawns[i];
                AreaSpawn area2 = _second.AreaSpawns[i];
                for (int j = 0; j < area1.MonsterSpawns.Length; j++)
                {
                    MonsterSpawn monster1 = area1.MonsterSpawns[j];
                    MonsterSpawn monster2 = area2.MonsterSpawns[j];
                    if (monster1.Atk != monster2.Atk)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u1: {monster1.Atk} != {monster2.Atk}");
                    if (monster1.Def != monster2.Def)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u2: {monster1.Def} != {monster2.Def}");
                    if (monster1.CurrentHP != monster2.CurrentHP)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u3: {monster1.CurrentHP} != {monster2.CurrentHP}");
                    if (monster1.MaxHP != monster2.MaxHP)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u4: {monster1.MaxHP} != {monster2.MaxHP}");
                    if (monster1.Alignment != monster2.Alignment)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u5: {monster1.Alignment} != {monster2.Alignment}");
                    if (monster1.Hostility != monster2.Hostility)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u6: {monster1.Hostility} != {monster2.Hostility}");
                    if (monster1.MonsterID != monster2.MonsterID)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u7: {monster1.MonsterID} != {monster2.MonsterID}");
                    if (monster1.GroupSize != monster2.GroupSize)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].GroupSize: {monster1.GroupSize} != {monster2.GroupSize}");
                    if (Math.Abs(monster1.SpawnTime - monster2.SpawnTime) > 0.01)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].SpawnTime: {monster1.SpawnTime} != {monster2.SpawnTime}");
                    if (monster1.IdentificationLevel != monster2.IdentificationLevel)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u10: {monster1.IdentificationLevel} != {monster2.IdentificationLevel}");
                    if (monster1.GroupNumber != monster2.GroupNumber)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u11: {monster1.GroupNumber} != {monster2.GroupNumber}");
                    if (monster1.OtherMonsterID != monster2.OtherMonsterID)
                        Console.WriteLine($"AreaSpawns[{i}].MonsterSpawns[{j}].u12: {monster1.OtherMonsterID} != {monster2.OtherMonsterID}");
                }
                if (area1.Treasure.ChestType != area2.Treasure.ChestType)
                    Console.WriteLine($"AreaSpawns[{i}].Treasure.ChestType: {area1.Treasure.ChestType} != {area2.Treasure.ChestType}");
                if (area1.Treasure.MonsterID != area2.Treasure.MonsterID)
                    Console.WriteLine($"AreaSpawns[{i}].Treasure.MonsterID: {area1.Treasure.MonsterID} != {area2.Treasure.MonsterID}");
                if (Math.Abs(area1.Treasure.Gold - area2.Treasure.Gold) > 0.1)
                    Console.WriteLine($"AreaSpawns[{i}].Treasure.Gold: {area1.Treasure.Gold} != {area2.Treasure.Gold}");
                if (area1.Treasure.TrapID != area2.Treasure.TrapID)
                    Console.WriteLine($"AreaSpawns[{i}].Treasure.TrapID: {area1.Treasure.TrapID} != {area2.Treasure.TrapID}");
                if (area1.Treasure.Locked != area2.Treasure.Locked)
                    Console.WriteLine($"AreaSpawns[{i}].Treasure.Locked: {area1.Treasure.Locked} != {area2.Treasure.Locked}");
            }
        }
    }
}
