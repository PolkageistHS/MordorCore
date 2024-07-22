using System.Text;

namespace MordorConsole;

public static class ItemGenHelpers
{
    public static string RemoveBadCharacters(string val) => val.Replace(" ", "")
                                                               .Replace("+", "")
                                                               .Replace("'", "")
                                                               .Replace("-", "");

    public static string ConvertToBool(int val) => (val != 0).ToString().ToLower();

    private static bool IsMask(int val, int bitVal) => (val & (1 << bitVal)) != 0;

    public static string GetStringFromInt(Dictionary<int, string> dict, int val) => dict[val];

    public static string GetResistsFromArray(short[] resists)
    {
        StringBuilder sb = new();
        sb.AppendLine("{");
        foreach (KeyValuePair<int, string> pair in ItemGenCollections.Resists.Where(pair => resists[pair.Key] > 0))
        {
            sb.AppendLine($"    {pair.Value} = {resists[pair.Key]},");
        }
        sb.AppendLine("},");
        return sb.ToString();
    }
    
    public static string GetJoinedEnums(Dictionary<int, string> dict, int val)
    {
        List<string> strs = dict.Where(pair => pair.Key >= 0 && IsMask(val, pair.Key))
                                .Select(pair => pair.Value).ToList();
        return strs.Count > 0 ? string.Join(" | ", [.. strs]) : dict[-1];
    }

    public static string GetMultiValues(Dictionary<int, string> dict, int val)
    {
        StringBuilder sb = new();
        foreach (KeyValuePair<int, string> pair in dict.Where(pair => IsMask(val, pair.Key)))
        {
            sb.AppendLine($"{pair.Value},");
        }
        return sb.ToString();
    }

    public static string GetStatsFromArray(short[] stats)
    {
        StringBuilder sb = new();
        if (stats[0] > 0)
        {
            sb.AppendLine($"Strength = {stats[0]},");
        }
        if (stats[1] > 0)
        {
            sb.AppendLine($"Intelligence = {stats[1]},");
        }
        if (stats[2] > 0)
        {
            sb.AppendLine($"Wisdom = {stats[2]},");
        }
        if (stats[3] > 0)
        {
            sb.AppendLine($"Constitution = {stats[3]},");
        }
        if (stats[4] > 0)
        {
            sb.AppendLine($"Charisma = {stats[4]},");
        }
        if (stats[5] > 0)
        {
            sb.AppendLine($"Dexterity = {stats[5]},");
        }
        return sb.ToString();
    }
}
