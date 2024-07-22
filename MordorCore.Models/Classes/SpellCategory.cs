namespace MordorCore.Models.Classes;

public class SpellCategory
{
    public float LevelScale { get; set; }

    public float LevelMax { get; set; }

    public override string ToString()
    {
        if (LevelMax == 0 && LevelScale == 0)
        {
            return "Never learned";
        }
        return $"Max: {LevelMax}, Scale: {LevelScale}";
    }
}
