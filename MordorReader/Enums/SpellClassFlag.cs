namespace MordorReader;

[Flags]
public enum SpellClassFlag
{
    Fire = 1,
    Cold = 2,
    Electric = 4,
    Mind = 8,
    Damage = 16,
    Element = 32,
    Kill = 64,
    Charm = 128,
    Bind = 256,
    Heal = 512,
    Movement = 1024,
    Banish = 2048,
    Dispell = 4096,
    Resistant = 8192,
    Visual = 16384,
    Magical = 32768,
    Location = 65536,
    Protection = 131072
}
