using System.Runtime.Serialization;

namespace be.MbDevelompent.Greenmaster.Statics.Object.Organic;

public enum PlantType
{
    [EnumMember(Value = "HEDGE")]Hedge,
    [EnumMember(Value = "TREE")]Tree,
    [EnumMember(Value = "GROUNDCOVER")]GroundCover,
    [EnumMember(Value = "CLIMBING")]Climbing,
    [EnumMember(Value = "BUSH")]Bush,
    [EnumMember(Value = "GRASS")]Grass,
    [EnumMember(Value = "OTHER")]Other
}