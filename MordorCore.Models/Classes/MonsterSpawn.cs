﻿namespace MordorCore.Models.Classes;

public class MonsterSpawn
{
    [NewRecord]
    public short Atk { get; set; }
 
    public short Def { get; set; }
    
    public short CurrentHP { get; set; }
    
    public short MaxHP { get; set; }
    
    public short Alignment { get; set; }
    
    public short Hostility { get; set; }
    
    public short MonsterID { get; set; }
    
    public short GroupSize { get; set; }
    
    public float SpawnTime { get; set; }
    
    public short IdentificationLevel { get; set; }
    
    public short GroupNumber { get; set; }
    
    public short OtherMonsterID { get; set; }
}
