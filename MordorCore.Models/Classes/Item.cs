﻿namespace MordorCore.Models.Classes;

public class Item
{
    [NewRecord]
    public string Name { get; set; } = null!;

    public short ID { get; set; }
    
    public short Attack { get; set; }
    
    public short Defense { get; set; }
    
    public int Price { get; set; }
    
    public short Floor { get; set; }
    
    public short Rarity { get; set; }
    
    public int Abilities { get; set; }
    
    public short Swings { get; set; }
    
    public short SpecialType { get; set; }
    
    public short SpellRowNum { get; set; }
    
    public short SpellID { get; set; }
    
    public short Charges { get; set; }
    
    public short TypeID { get; set; }
    
    public int Guilds { get; set; }
    
    public short LevelScale { get; set; }
    
    public float DamageMod { get; set; }
    
    public int AlignmentFlags { get; set; }
    
    public short Hands { get; set; }
    
    public short SubtypeID { get; set; }
    
    public int ResistanceFlags { get; set; }

    public short[] MinimumStats { get; set; } = new short[7];

    public short[] StatsMod { get; set; } = new short[7];
    
    public short Cursed { get; set; }
    
    public short SpellLvl { get; set; }
    
    public short ClassRestricted { get; set; }

    public override string ToString() => $"{Name} : {ID}";
}
