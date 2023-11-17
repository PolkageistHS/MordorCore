namespace MordorCore.Models.DataFiles;

[DataRecordLength(10)]
public class DATA08Automap : IMordorDataFile
{
    [NewRecord]
    public string Version { get; set; } = null!;

    [NewRecord]
    public short DeepestLevel { get; set; }
    
    public AutomapFloor[] Floors { get; set; } = new AutomapFloor[15];
}
