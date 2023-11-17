namespace MordorReader;

public class Teleporter
{
    public short x;
    public short y;
    public short x2;
    public short y2;
    public short z2;

    public override string ToString()
    {
        if (x2 == 0 || y2 == 0 || z2 == 0)
            return $"({x}, {y}) => Random";
        return $"({x}, {y}) => ({x2}, {y2}, {z2})";
    }
}