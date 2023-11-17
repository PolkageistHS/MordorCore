namespace MordorReader;

public class HallRecord
{
    public long Value;
    public string Name = "";
    public int Date;
    public DateTime RecordSetDate => new DateTime(1900, 1, 1).AddDays(Date);

    /// <inheritdoc />
    public override string ToString() => $"{Name} with {Value:##,###} on {RecordSetDate:d}";
}
