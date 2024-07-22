namespace MordorReader;

public class LibraryRecord
{
    public short ID;
    public short Known;
    public long NumSeen;
    public string LastSeenBy = "";
    public short MonsterID; //ID of monster that dropped item, or 0 for monsters
    public int LastSeenDay;
    public string Location = "";
    public short Deaths; //0xFFFF for items

    public string LastSeenAt
    {
        get
        {
            string loc = Location.Trim();
            return loc.Length < 3 ? $"on level {loc}" : $"at {loc}";
        }
    }

    public string LastSeenDate
    {
        get
        {
            if (LastSeenDay == 0)
            {
                return "Never";
            }
            DateTime seenDate = new(1900, 1, 1);
            seenDate = seenDate.AddDays(LastSeenDay);
            TimeSpan diff = DateTime.Today - seenDate;
            return diff.Days switch
            {
                0 => "today",
                -1 => "yesterday",
                _ => $"{seenDate:d} ({Math.Abs(diff.Days)} days ago)"
            };
        }
    }

    public override string ToString()
    {
        if (MonsterID == 0)
        {
            return $"MonsterID {ID} seen {NumSeen} times, last {LastSeenAt} {LastSeenDate}";
        }
        return $"ItemID {ID} seen {NumSeen} times, last {LastSeenAt} {LastSeenDate} dropped by {(MonsterID == -1 ? "unknown" : MonsterID)}";
    }
}
