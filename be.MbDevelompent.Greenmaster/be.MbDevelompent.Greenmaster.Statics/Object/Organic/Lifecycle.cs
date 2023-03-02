using System.Runtime.Serialization;

namespace be.MbDevelompent.Greenmaster.Statics.Object.Organic;

public enum Lifecycle
{
    [EnumMember(Value = "ANNUAL")]Annual,
    [EnumMember(Value = "PERENNIAL")]Perennial,
    [EnumMember(Value = "BIENNIAL")]Biennial
}