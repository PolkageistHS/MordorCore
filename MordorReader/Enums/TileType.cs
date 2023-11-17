namespace MordorReader;

[Flags]
public enum TileType
{
    WallEast = 1, //0
    WallNorth = 2, //1
    DoorEast = 4, //2
    DoorNorth = 8, //3
    SecretDoorEast = 16, //4
    SecretDoorNorth = 32, //5
    FaceNorth = 64, //6
    FaceEast = 128, //7
    FaceSouth = 256, //8
    FaceWest = 512, //9
    Extinguisher = 1024, //10
    Pit = 2048, //11
    StairsUp = 4096, //12
    StairsDown = 8192, //13
    Teleporter = 16384, //14
    Water = 32768, //15
    Quicksand = 65536, //16
    Rotator = 131072, //17
    Antimagic = 262144, //18
    Rock = 524288, //19
    Fog = 1048576, //20
    Chute = 2097152, //21
    Stud = 4194304, //22
    Explored = 8388608
}
