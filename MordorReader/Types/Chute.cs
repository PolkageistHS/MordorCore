namespace MordorReader;

public class Chute
{
    public short x;
    public short y;
    public short Depth;

    public override string ToString() => $"({x}, {y}) => {Depth}";
}