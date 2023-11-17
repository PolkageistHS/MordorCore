namespace MordorCore.Models.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class FixedLengthStringAttribute : Attribute
{
    public ushort Length { get; init; }
}
