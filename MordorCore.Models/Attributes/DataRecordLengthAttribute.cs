using System.Diagnostics;

namespace MordorCore.Models.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DataRecordLengthAttribute : Attribute
{
    public int? Length { get; }

    [DebuggerStepThrough]
    public DataRecordLengthAttribute(int length) => Length = length;
}
