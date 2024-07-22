namespace MordorReader;

public class SpellClass
{
    public string Name = "";

    public float LevelScale;

    public float LevelMax;

    public override string ToString()
    {
        if (LevelMax == 0 || LevelScale == 0)
        {
            return $"{Name}: (never)";
        }
        return $"{Name}: {LevelScale}/{LevelMax}";
    }
}
