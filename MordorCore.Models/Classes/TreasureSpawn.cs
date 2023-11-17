namespace MordorCore.Models.Classes;

public class TreasureSpawn
{
    [NewRecord]
    public short ChestType { get; set; }

    public short MonsterID { get; set; }
    
    public double Gold { get; set; }
    
    public short TrapID { get; set; }
    
    public short Locked { get; set; }
}
