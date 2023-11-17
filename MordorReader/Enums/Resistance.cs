namespace MordorReader;

[Flags]
public enum Resistance
{
	Fire = 1,
	Cold = 2,
	Electric = 4,
	Mind = 8,
	Disease = 16,
	Poison = 32,
	Magic = 64,
	Stone = 128,
	Paralysis = 256,
	Drain = 512,
	Acid = 1024
}
