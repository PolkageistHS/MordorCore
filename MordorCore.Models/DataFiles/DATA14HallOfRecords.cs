namespace MordorCore.Models.DataFiles;

[DataRecordLength(100)]
public class DATA14HallOfRecords : IMordorDataFile
{
    public List<HallRecord> Records { get; set; } = new();
}
