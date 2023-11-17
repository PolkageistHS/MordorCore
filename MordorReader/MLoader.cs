using System.Diagnostics;

namespace MordorReader;

public static class MLoader
{
    public static GameData LoadGameData(string filename = "MDATA1.MDR", int bufferLength = 260)
    {
        using RecordReader reader = new(filename, bufferLength);
        GameData gameData = new();
        reader.Read();
        gameData.Version = reader.GetString();
        reader.Read();
        gameData.NumRaces = reader.GetShort();
        reader.Read();
        gameData.NumGuilds = reader.GetShort();
        reader.Read();
        gameData.NumItemSubtypes = reader.GetShort();
        reader.Read();
        gameData.NumItemTypes = reader.GetShort();
        reader.Read();
        gameData.NumMonsterSubtypes = reader.GetShort();
        reader.Read();
        gameData.NumMonsterTypes = reader.GetShort();
        for (int i = 0; i < gameData.NumRaces; i++)
        {
            RaceInfo race = new();
            reader.Read();
            race.Name = reader.GetString();
            for (int j = 0; j < race.MinStats.Length; j++)
                race.MinStats[j] = reader.GetShort();
            for (int j = 0; j < race.MaxStats.Length; j++)
                race.MaxStats[j] = reader.GetShort();
            for (int j = 0; j < race.Resistances.Length; j++)
                race.Resistances[j] = reader.GetShort();
            race._alignment = reader.GetInt();
            race._size = reader.GetShort();
            race.BonusPoints = reader.GetShort();
            race.MaxAge = reader.GetShort();
            race.ExpFactor = reader.GetFloat();
            gameData.Races.Add(race);
        }
        for (int i = 0; i < gameData.NumGuilds; i++)
        {
            GuildInfo guild = new();
            reader.Read();
            guild.Name = reader.GetString();
            guild.AverageHits = reader.GetShort();
            guild.MaxLevel = reader.GetShort();
            guild.MH = reader.GetShort();
            guild.ExpFactor = reader.GetFloat();
            guild.Unused1 = reader.GetShort();
            for (int j = 0; j < guild.ReqStats.Length; j++)
                guild.ReqStats[j] = reader.GetShort();
            guild.Alignment = reader.GetInt();
            for (int j = 0; j < guild.AbilityRates.Length; j++)
                guild.AbilityRates[j] = reader.GetFloat();
            guild.Quested = reader.GetShort();
            guild.Unused2 = reader.GetFloat();
            guild.QuestPercentage = reader.GetShort();
            for (int j = 0; j < guild.SpellClasses.Capacity; j++)
            {
                SpellClass spellClass = new();
                guild.SpellClasses.Add(spellClass);
                spellClass.Name = StaticValues.SpellClasses[j];
                spellClass.LevelScale = reader.GetFloat();
            }
            for (int j = 0; j < guild.SpellClasses.Capacity; j++)
                guild.SpellClasses[j].LevelMax = reader.GetFloat();
            guild.RaceMask = reader.GetInt();
            guild.GoldFactor = reader.GetShort();
            guild.LevelScale = reader.GetFloat();
            guild.Atk = reader.GetFloat();
            guild.Def = reader.GetFloat();
            guild.MaxAtkDefIncreaseLevel = reader.GetShort();
            guild.AtkDefIncreaseRate = reader.GetFloat();
            guild.Unused5 = reader.GetShort();
            guild.Unused6 = reader.GetShort();
            gameData.Guilds.Add(guild);
        }
        for (int i = 0; i < gameData.NumItemSubtypes; i++)
        {
            ItemSubtype subtype = new();
            reader.Read();
            subtype.Name = reader.GetString();
            subtype.Itemtype = reader.GetShort();
            gameData.ItemSubtypes.Add(subtype);
        }
        for (int i = 0; i < gameData.NumItemTypes; i++)
        {
            ItemType item = new();
            reader.Read();
            item.Name = reader.GetString();
            item.IsEquipable = reader.GetShort();
            gameData.ItemTypes.Add(item);
        }
        for (int i = 0; i < gameData.NumMonsterSubtypes; i++)
        {
            MonsterSubtype subtype = new();
            reader.Read();
            subtype.Name = reader.GetString();
            subtype.MonsterType = reader.GetShort();
            gameData.MonsterSubtypes.Add(subtype);
        }
        for (int i = 0; i < gameData.NumMonsterTypes; i++)
        {
            MonsterPrimaryType subtype = new();
            reader.Read();
            subtype.Name = reader.GetString();
            subtype.unused = reader.GetShort();
            gameData.MonsterTypes.Add(subtype);
        }
        return gameData;
    }

    public static Spells LoadSpells(string filename = "MDATA2.MDR")
    {
        using RecordReader reader = new(filename, 75);
        Spells spells = new();
        reader.Read();
        spells.Version = reader.GetString();
        if (spells.Version != "1.1")
            throw new Exception("Invalid version");
        reader.Read();
        spells.Count = reader.GetShort();
        for (int i = 0; i < spells.Count; i++)
        {
            Spell s = new();
            reader.Read();
            s.Name = reader.GetString();
            s.ID = reader.GetShort();
            s.Category = reader.GetShort();
            s.Level = reader.GetShort();
            s.Cost = reader.GetShort();
            reader.GetShort();
            s.KillEffect = reader.GetShort();
            s.AffectMonster = reader.GetShort();
            s.AffectGroup = reader.GetShort();
            s.Damage1 = reader.GetShort();
            s.Damage2 = reader.GetShort();
            s.SpecialEffect = reader.GetShort();
            for (int j = 0; j < 7; j++) 
                s.RequiredStats[j] = reader.GetShort();
            s.ResistedBy = reader.GetShort();
            spells.SpellList.Add(s);
        }
        return spells;
    }

    public static Items LoadItems(string filename = "MDATA3.MDR")
    {
        using RecordReader reader = new(filename, 125);
        Items items = new();
        reader.Read();
        items.Version = reader.GetString();
        if (items.Version != "1.1")
            throw new Exception("Invalid version");
        reader.Read();
        items.GeneralStoreCode = reader.GetShort();
        reader.Read();
        items.Count = reader.GetShort();
        for (int i = 0; i < items.Count; i++)
        {
            Item item = new();
            reader.Read();
            item.Name = reader.GetString();
            item.ID = reader.GetShort();
            item.Attack = reader.GetShort();
            item.Defense = reader.GetShort();
            item.Price = reader.GetInt();
            item.Floor = reader.GetShort();
            item.Rarity = reader.GetShort();
            item._abilities = reader.GetInt();
            item.Swings = reader.GetShort();
            item.SpecialType = reader.GetShort();
            item.SpellRowNum = reader.GetShort();
            item.SpellID = reader.GetShort();
            item.Charges = reader.GetShort();
            item.SubTypeID = reader.GetShort();
            item._guilds = reader.GetInt();
            item.LevelScale = reader.GetShort();
            item.DamageMod = reader.GetFloat();
            item._alignmentFlags = reader.GetInt();
            item.Hands = reader.GetShort();
            item.Type = reader.GetShort();
            item._resistanceFlags = reader.GetInt();
            for (int j = 0; j < item.Stats.Length; j++) 
                item.Stats[j] = reader.GetShort();
            for (int j = 0; j < item.StatsMod.Length; j++)
                item.StatsMod[j] = reader.GetShort();
            item.Cursed = reader.GetShort();
            item.SpellLvl = reader.GetShort();
            item.ClassRestricted = reader.GetShort();
            items.ItemList.Add(item);
        }
        return items;
    }

    public static Characters LoadCharacters(string filename = "MDATA4.MDR")
    {
        using RecordReader reader = new(filename, 2900);
        Characters chars = new();
        reader.Read();
        chars.Version = reader.GetString();
        reader.Read();
        chars.CharacterCount = reader.GetShort();
        while (true)
        {
            Character c = new();
            if (!reader.Read()) 
                break;
            c.Name = reader.GetString(30).Trim(); //0-29
            c.Race = reader.GetShort(); //30-31
            c.Alignment = reader.GetShort(); //32-33
            c.Sex = reader.GetShort(); //34-35
            c.DaysOld = reader.GetFloat(); //36-39
            c.CurrentMP = reader.GetShort(); //40-41
            c.DungeonLevel = reader.GetShort(); //42-43
            c.CurrentX = reader.GetShort(); //44-45
            c.CurrentY = reader.GetShort(); //46-47
            c.Atk = reader.GetFloat(); //48-51
            c.Def = reader.GetFloat(); //52-55
            c.BaseStats = new Stats
            {
                Str = reader.GetShort(), //56-57
                Int = reader.GetShort(), //58-59
                Wis = reader.GetShort(), //60-61
                Con = reader.GetShort(), //62-63
                Cha = reader.GetShort(), //64-65
                Dex = reader.GetShort(), //66-67
                Unused = reader.GetShort() //68-69
            };
            c.ModifiedStats = new Stats
            {
                Str = reader.GetShort(), //70-71
                Int = reader.GetShort(), //72-73
                Wis = reader.GetShort(), //74-75
                Con = reader.GetShort(), //76-77
                Cha = reader.GetShort(), //78-79
                Dex = reader.GetShort(), //80-81
                Unused = reader.GetShort() //82-83
            };
            for (int j = 0; j < c.InventoryItems.Length; j++) //84-821 (41*18)
            {
                HeldItem held = new();
                c.InventoryItems[j] = held;
                held.Atk = reader.GetShort();
                held.Def = reader.GetShort();
                held.ItemIndex = reader.GetShort();
                held.ItemId = reader.GetShort();
                held.Alignment = reader.GetShort();
                held.Charges = reader.GetShort();
                held.Equipped = reader.GetShort();
                held.IdentificationLevel = reader.GetShort();
                held.Cursed = reader.GetShort();
            }
            for (int j = 0; j < c.BankItems.Length; j++) //822-1559 (41*18)
            {
                HeldItem held = new();
                c.BankItems[j] = held;
                held.ItemIndex = reader.GetShort();
                held.Alignment = reader.GetShort();
                held.Charges = reader.GetShort();
                held.Equipped = reader.GetShort();
                held.IdentificationLevel = reader.GetShort();
                held.Cursed = reader.GetShort();
                held.Atk = reader.GetShort();
                held.Def = reader.GetShort();
                held.ItemId = reader.GetShort();
            }
            for (int j = 0; j < c.EquippedItems.Length; j++) //1560-1631 (36*2)
                c.EquippedItems[j] = reader.GetShort();
            c.UnusedDamageMod = reader.GetIntCurrency(); //1632-1639
            c.Unused1 = reader.GetShort(); //1640-1641
            c.Direction = reader.GetShort(); //1642-1643
            c.Unused2 = reader.GetShort(); //1644-1645
            c.TotalExperience = reader.GetIntCurrency(); //1646-1653
            c.GoldOnHand = reader.GetIntCurrency(); //1654-1661
            c.CurrentHp = reader.GetShort(); //1662-1663
            c.MaxHp = reader.GetShort(); //1664-1665
            c.GoldInBank = reader.GetIntCurrency(); //1666-1673
            c.ExtraSwings = reader.GetShort(); //1674-1675
            c.ActiveGuild = reader.GetShort(); //1676-1677
            for (int j = 0; j < c.GuildStatuses.Length; j++) //1678-2061 (16*32)
            {
                GuildStatus guild = new();
                c.GuildStatuses[j] = guild;
                guild.CurrentLevel = reader.GetShort();
                guild.CurrentExp = reader.GetIntCurrency();
                guild.IsQuested = reader.GetShort();
                guild.QuestedTargetID = reader.GetShort();
                guild.M57B2 = reader.GetShort();
                guild.Atk = reader.GetFloat();
                guild.Def = reader.GetFloat();
            }
            for (int j = 0; j < c.Companions.Length; j++) //2062-2226 (5x33)
            {
                Companion companion = new();
                c.Companions[j] = companion;
                companion.Name = reader.GetString(15);
                companion.MonsterID = reader.GetShort();
                companion.Slot = reader.GetShort();
                companion.CurrentHp = reader.GetShort(); 
                companion.MaxHp = reader.GetShort(); 
                companion.Alignment = reader.GetShort();
                companion.Atk = reader.GetShort(); 
                companion.Def = reader.GetShort(); 
                companion.BindLevel = reader.GetShort(); 
                companion.IDLevel = reader.GetShort();
            }
            c.HandsOccupied = reader.GetShort(); //2227-2228
            c.M58DC = reader.GetShort(); //2229-2230
            c.RezChance = reader.GetShort(); //2231-2232
            c.CharacterPerformingRez = reader.GetString(30); //2233-2262
            for (int j = 0; j < c.MiscCharacterInfo.Length; j++)
                c.MiscCharacterInfo[j] = reader.GetIntCurrency();
            //0: kills 2263-2270
            //1: deaths 2271-2278
            //2: comp kills 2279-2286
            //3: monster quests 2287-2294
            //4: item quests 2295-2302
            //5: time played? 2303-2310
            //6: creation date (days after 1/1/1900) 2311-2318
            //7: unused 2319-2326
            //8: unused 2327-2334
            for (int j = 0; j < c.CharacterOptions.Length; j++) // 2335-2346 (6*2), unknown flags of some sort
                c.CharacterOptions[j] = reader.GetShort();
            for (int j = 0; j < c.StatusEffects.Length; j++) //2347-2362(8*2)
                c.StatusEffects[j] = reader.GetShort();
            for (int j = 0; j < c.Resistances.Length; j++) //2363-2386 (12*2)
                c.Resistances[j] = reader.GetShort();
            c.TempBuffs = reader.GetInt(); //2387-2390
            for (int j = 0; j < c.TempResistances.Length; j++) //2391-2414 (12*2)
                c.TempResistances[j] = reader.GetShort();
            c.DeadType = reader.GetShort(); //2415-2416
            c.CarriedCorpseID = reader.GetShort(); //2417-2418
            c.Password = reader.GetString(10); //2419-2428
            for (int j = 0; j < c.SavedWindowStates.Length; j++) //2429-2806 (21*18)
            {
                SavedWindowState savedWindowState = new();
                c.SavedWindowStates[j] = savedWindowState;
                savedWindowState.Left = reader.GetInt();
                savedWindowState.Top = reader.GetInt();
                savedWindowState.Height = reader.GetInt();
                savedWindowState.Width = reader.GetInt();
                savedWindowState.WindowState = reader.GetShort();
            }
            c.RecordLineNumber = reader.GetShort(); //2807-2808
            c.XpNeededToPin = reader.GetInt(); //2809-2812
            c.AbilitiesFromEquippedItems = reader.GetInt(); //2813-2816
            for (int j = 0; j < c.ResistsFromItems.Length; j++) //2817-2840 (12*2)
                c.ResistsFromItems[j] = reader.GetShort();
            for (int j = 0; j < c.EquippedItemsInHands.Length; j++) //2841-2844 (2*2)
                c.EquippedItemsInHands[j] = reader.GetShort();
            c.SomeADPlaceholderMaybe = reader.GetShort(); //2845-2846
            for (int j = 0; j < c.BufferSlots.Length; j++) //2847-2868 
                c.BufferSlots[j] = reader.GetShort();
            c.CurrentAreaNum = reader.GetShort(); //2869-2870
            c.Unused3 = reader.GetShort(); //2871-2872
            c.Unused4 = reader.GetShort(); //2873-2874
            c.SanctuaryCoordinates.X = reader.GetShort(); //2875-2876
            c.SanctuaryCoordinates.Y = reader.GetShort(); //2877-2878
            c.SanctuaryCoordinates.Level = reader.GetShort(); //2879-2880
            for (int j = 0; j < c.LocationAwareness.Length; j++) //2881-2886 (3*2)
                c.LocationAwareness[j] = reader.GetShort();
            chars.CharacterList.Add(c);
        }
        return chars;
    }

    public static Monsters LoadMonsters(string filename = "MDATA5.MDR")
    {
        Monsters monsters = new();
        RecordReader reader = new(filename, 160);
        reader.Read();
        monsters.Version = reader.GetString();
        Debug.Assert(monsters.Version == "1.1");
        reader.Read();
        reader.Read();
        monsters.Count = reader.GetShort();
        for (int i = 0; i < monsters.Count; i++)
        {
            Monster m = new();
            reader.Read();
            m.Name = reader.GetString();
            m.Attack = reader.GetShort();
            m.Defense = reader.GetShort();
            m.ID = reader.GetShort();
            m.Hits = reader.GetShort();
            m.NumGroups = reader.GetShort();
            m.PicID = reader.GetShort();
            m.LockedChance = reader.GetShort();
            m.LevelFound = reader.GetShort();
            for (int j = 0; j < m.resistances.Length; j++) 
                m.resistances[j] = reader.GetShort();
            m._specialPropertyFlags = reader.GetInt();
            m._specialAttackFlags = reader.GetInt();
            m._spellFlags = reader.GetInt();
            for (int j = 0; j < m.boxChance.Length; j++) 
                m.boxChance[j] = reader.GetShort();
            reader.GetShort();
            m._alignment = reader.GetShort();
            m.GroupSize = reader.GetShort();
            m.GoldFactor = reader.GetInt();
            m.trapFlags = reader.GetInt();
            m.GuildLevel = reader.GetShort();
            for (int j = 0; j < m.stats.Length; j++) 
                m.stats[j] = reader.GetShort();
            m.MonsterType = reader.GetShort();
            m.DamageMod = reader.GetFloat();
            m.CompanionType = reader.GetShort();
            m.CompanionSpawnMode = reader.GetShort();
            m.CompanionID = reader.GetShort();
            for (int j = 0; j < m.items.Length; j++) 
                m.items[j] = reader.GetShort();
            m.SimilarityID = reader.GetShort();
            m.CompanionGrouping = reader.GetShort();
            m._size = reader.GetShort();
            m.ItemDropLevel = reader.GetShort();
            m.ItemChance = reader.GetShort();
            monsters.MonstersList.Add(m);
        }
        return monsters;
    }

    public static GeneralStore LoadGeneralStore(string filename = "MDATA6.MDR")
    {
        using RecordReader reader = new(filename, 16);
        GeneralStore store = new();
        reader.Read();
        store.Version = reader.GetString();
        reader.Read();
        store.Header1 = reader.GetShort();
        reader.Read();
        store.Count = reader.GetShort();
        while (true)
        {
            StoreItem item = new();
            if (!reader.Read()) 
                break;
            short num = reader.GetShort();
            if (num == 0) 
                continue;
            item.RowNumber = num;
            item.ItemID = reader.GetShort();
            item.UnalignedQty = reader.GetShort();
            item.GoodQty = reader.GetShort();
            item.NeutralQty = reader.GetShort();
            item.EvilQty = reader.GetShort();
            store.Items.Add(item);
        }
        return store;
    }

    public static Guildmasters LoadGuildmasters(string filename = "MDATA7.MDR")
    {
        using RecordReader reader = new(filename, 128);
        Guildmasters guildmasters = new();
        reader.Read();
        guildmasters.Version = reader.GetString();
        while (true)
        {
            Guildmaster guildmaster = new();
            if (!reader.Read()) 
                break;
            guildmaster.Name = reader.GetString();
            guildmaster.Level = reader.GetShort();
            guildmasters.GuildmasterList.Add(guildmaster);
        }
        return guildmasters;
    }

    public static Automap LoadAutomap(string filename = "MDATA8.MDR")
    {
        using RecordReader reader = new(filename, 10);
        Automap automap = new();
        reader.Read();
        automap.Version = reader.GetString();
        reader.Read();
        automap.DeepestLevel = reader.GetShort();
        short i = 1;
        bool cont = true;
        while (cont)
        {
            AutomapFloor floor = new()
            {
                FloorNumber = i++
            };
            for (short j = 1; j <= 30; j++)
            {
                for (short k = 1; k <= 30; k++)
                {
                    if (!reader.Read())
                        cont = false;
                    MapTile tile = new()
                    {
                        X = k,
                        Y = j,
                        Tile = reader.GetInt()
                    };
                    floor.Tiles.Add(tile);
                }
            }
            automap.Floors.Add(floor);
        }
        return automap;
    }

    public static GuildLog LoadGuildLogs(string filename = "MDATA9.MDR")
    {
        using RecordReader reader = new(filename);
        GuildLog logs = new();
        reader.Read();
        logs.Count = reader.GetShort();
        while (true)
        {
            GuildLogEntry log = new();
            short? temp = reader.GetShortIfItExists();
            if (temp == null) 
                break;
            log.GuildID = temp.Value;
            log.DayValue = reader.GetInt();
            log.Message = reader.GetString();
            logs.AddGuildLog(log);
        }
        return logs;
    }

    public static DungeonState LoadDungeonState(string filename = "MDATA10.MDR")
    {
        using RecordReader reader = new(filename, 28);
        DungeonState dungeon = new();
        reader.Read();
        dungeon.LevelCount = reader.GetShort();
        dungeon.SpawnCounts = new short[dungeon.LevelCount];
        for (int i = 0; i < dungeon.LevelCount; i++)
        {
            reader.Read();
            dungeon.SpawnCounts[i] = reader.GetShort();
        }
        while (true)
        {
            AreaSpawn spawn = new();
            if (!reader.Read())
                break;
            for (int i = 0; i < spawn.MonsterSpawns.Length; i++)
            {
                MonsterSpawn monsterSpawn = new();
                spawn.MonsterSpawns[i] = monsterSpawn;
                monsterSpawn.Atk = reader.GetShort();
                monsterSpawn.Def = reader.GetShort();
                monsterSpawn.CurrentHP = reader.GetShort();
                monsterSpawn.MaxHP = reader.GetShort();
                monsterSpawn.Alignment = reader.GetShort();
                monsterSpawn.Hostility = reader.GetShort();
                monsterSpawn.MonsterID = reader.GetShort();
                monsterSpawn.GroupSize = reader.GetShort();
                monsterSpawn.SpawnTime = reader.GetFloat();
                monsterSpawn.IdentificationLevel = reader.GetShort();
                monsterSpawn.GroupNumber = reader.GetShort();
                monsterSpawn.OtherMonsterID = reader.GetShort();
                reader.Read();
            }
            spawn.Treasure = new TreasureSpawn();
            dungeon.AreaSpawns.Add(spawn);
            spawn.Treasure.ChestType = reader.GetShort();
            spawn.Treasure.MonsterID = reader.GetShort();
            spawn.Treasure.Gold = reader.GetDoubleCurrency();
            spawn.Treasure.TrapID = reader.GetShort();
            spawn.Treasure.Locked = reader.GetShort();
        }
        return dungeon;
    }

    public static DungeonMap LoadDungeonMap(string filename = "MDATA11.MDR")
    {
        using RecordReader reader = new(filename, 20);
        DungeonMap dungeon = new();
        reader.Read();
        dungeon.FloorCount = reader.GetShort();
        dungeon.FloorOffsets = new short[dungeon.FloorCount];
        for (short i = 0; i < dungeon.FloorCount; i++)
        {
            reader.Read();
            dungeon.FloorOffsets[i] = reader.GetShort();
        }
        for (short i = 0; i < dungeon.FloorOffsets.Length; i++)
        {
            reader.Seek(dungeon.FloorOffsets[i]);
            reader.Read();
            Floor floor = new();
            dungeon.Floors.Add(floor);
            floor.Width = reader.GetShort();
            floor.Height = reader.GetShort();
            floor.LevelNum = reader.GetShort();
            floor.AreaCount = reader.GetShort();
            floor.ChuteCount = reader.GetShort();
            floor.TeleporterCount = reader.GetShort();
            for (short j = 1; j <= floor.Width; j++)
            {
                for (short k = 1; k <= floor.Height; k++)
                {
                    MapTile tile = new();
                    floor.Tiles.Add(tile);
                    tile.X = k;
                    tile.Y = j;
                    reader.Read();
                    tile.Area = reader.GetShort();
                    tile.Tile = (int)reader.GetIntCurrency();
                }
            }
            reader.Read();
            for (int j = 0; j < 201; j++)
            {
                Area area = new();
                floor.Areas.Add(area);
                reader.Read();
                area.SpawnMask = reader.GetInt();
                area.LairID = reader.GetShort();
            }
            reader.Read();
            for (int j = 0; j < floor.TeleporterCount; j++)
            {
                Teleporter teleporter = new();
                reader.Read();
                teleporter.x = reader.GetShort();
                teleporter.y = reader.GetShort();
                teleporter.x2 = reader.GetShort();
                teleporter.y2 = reader.GetShort();
                teleporter.z2 = reader.GetShort();
                if (teleporter is { x: > 0, y: > 0 })
                    floor.Teleporters.Add(teleporter);
            }
            reader.Read();
            for (int j = 0; j < floor.ChuteCount; j++)
            {
                Chute chute = new();
                reader.Read();
                chute.x = reader.GetShort();
                chute.y = reader.GetShort();
                chute.Depth = reader.GetShort();
                if (chute is { x: > 0, y: > 0 })
                    floor.Chutes.Add(chute);
            }
        }
        return dungeon;
    }

    public static PartyGroups LoadPartyGroups(string filename = "MDATA12.MDR")
    {
        using RecordReader reader = new(filename, 35);
        PartyGroups groups = new();
        reader.Read();
        groups.Count = reader.GetShort();
        for (int i = 0; i < groups.Count; i++)
        {
            string?[] group = new string[4];
            for (int j = 0; j < 4; j++)
            {
                if (!reader.Read()) 
                    break;
                group[j] = reader.GetString();
            }
            if (group.Any(x => x != null))
                groups.Groups.Add(group!);
        }
        return groups;
    }

    public static Library LoadLibrary(string filename = "MDATA13.MDR")
    {
        using RecordReader reader = new(filename, 100);
        Library library = new();
        reader.Read();
        library.Version = reader.GetString();
        reader.Read();
        library.TotalMonsters = reader.GetShort();
        reader.Read();
        library.TotalItems = reader.GetShort();
        reader.Read();
        library.MonstersFound = reader.GetShort();
        reader.Read();
        library.ItemsFound = reader.GetShort();
        for (int i = 0; i < library.TotalMonsters; i++)
        {
            LibraryRecord record = new();
            reader.Read();
            record.ID = reader.GetShort();
            record.Known = reader.GetShort();
            record.NumSeen = reader.GetIntCurrency();
            if (record.NumSeen == 0)
                continue;
            record.LastSeenBy = reader.GetString(30);
            record.MonsterID = reader.GetShort();
            record.LastSeenDay = reader.GetInt();
            record.Location = reader.GetString(8);
            record.Deaths = reader.GetShort();
            library.Monsters.Add(record);
        }
        for (int i = 0; i < library.TotalItems; i++)
        {
            LibraryRecord record = new();
            reader.Read();
            record.ID = reader.GetShort();
            record.Known = reader.GetShort();
            record.NumSeen = reader.GetIntCurrency();
            if (record.NumSeen == 0) 
                continue;
            record.LastSeenBy = reader.GetString(30);
            record.MonsterID = reader.GetShort();
            record.LastSeenDay = reader.GetInt();
            record.Location = reader.GetString(8);
            record.Deaths = reader.GetShort();
            library.Items.Add(record);
        }
        return library;
    }

    public static HallOfRecords LoadHallOfRecords(string filename = "MDATA14.MDR")
    {
        using RecordReader reader = new(filename, 45);
        HallOfRecords hall = new();
        while (reader.Read())
        {
            HallRecord rec = new()
            {
                Value = reader.GetIntCurrency(),
                Name = reader.GetString(30).Trim(),
                Date = reader.GetInt()
            };
            hall.Records.Add(rec);
        }
        return hall;
    }

    public static Confinement LoadConfinement(string filename = "MDATA15.MDR")
    {
        using RecordReader reader = new(filename, 16);
        Confinement conf = new();
        reader.Read();
        conf.Version = reader.GetString();
        reader.Read();
        conf.Count = reader.GetShort();
        reader.Read();
        conf.TotalRecords = reader.GetShort();
        for (int i = 0; i < conf.TotalRecords; i++)
        {
            ConfinementMonster monster = new();
            reader.Read();
            monster.RowNumber = reader.GetShort();
            if (monster.RowNumber == 0)
                continue;
            monster.MonsterID = reader.GetShort();
            monster.Good = reader.GetShort();
            monster.Neutral = reader.GetShort();
            monster.Evil = reader.GetShort();
            conf.Monsters.Add(monster);
        }
        return conf;
    }
}
