namespace MordorReader;

public class MapTile
{
    public short X;

    public short Y;

    public short Area;

    public int Tile;

    public List<TileType> TileFlags => Helpers.ParseEnum<TileType>(Tile);
    
    /// <inheritdoc />
    public override string ToString() => $"{X}, {Y} - {string.Join(", ", TileFlags)}";
}
