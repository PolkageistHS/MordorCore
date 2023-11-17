namespace MordorReader;

[Flags]
public enum MonsterTypeMask
{
	Humanoid = 1,
	Cleanup = 2,
	Demon = 4,
	Devil = 8,
	Elemental = 16,
	Reptile = 32,
	Dragon = 64,
	Animal = 128,
	Insect = 256,
	Undead = 512,
	Aquatic = 1024,
	Giant = 2048,
	Mythical = 4096,
	Lycanthrope = 8192,
	Thief = 16384,
	Mage = 32768,
	Warrior = 65536,
	Indigini = 131072,
	Numkinds = 262144
}
