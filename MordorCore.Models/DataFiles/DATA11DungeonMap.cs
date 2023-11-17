namespace MordorCore.Models.DataFiles;

[DataRecordLength(20)]
public class DATA11DungeonMap : IMordorDataFile
{
    public short FloorCount { get; set; }

    public short[] FloorOffsets { get; set; } = new short[15];

    public Floor[] Floors { get; set; } = new Floor[15];
}
