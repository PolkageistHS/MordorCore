namespace MordorReader;

[Flags]
public enum SpecialAttack
{
	Poison = 1,
	Disease = 2,
	Paralyze = 4,
	FireBreath = 8,
	ColdBreath = 16,
	Acid = 32,
	Electrocute = 64,
	Drain = 128,
	Stone = 256,
	Age = 512,
	CriticalHit = 1024,
	Backstab = 2048,
	DestroyItem = 4096,
	Steal = 8192
}
