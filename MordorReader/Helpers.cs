namespace MordorReader;

public static class Helpers
{
    public static List<T> ParseEnum<T>(int flags) where T : struct, Enum
    {
        return flags == 0 ? 
            new List<T>() : 
            Enum.GetValues<T>()
                .Where(t => (flags & (int)(object)t) == (int)(object)t).ToList();
    }
}
