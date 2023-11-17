namespace MordorReader;

public class DungeonMap
{
    public short FloorCount;

    public short[] FloorOffsets = null!;

    public List<Floor> Floors = new();
}
