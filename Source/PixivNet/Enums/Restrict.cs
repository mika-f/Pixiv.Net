using System.Runtime.Serialization;

namespace Pixiv.Enums
{
    public enum Restrict
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "public")]
        Public,

        [EnumMember(Value = "private")]
        Private
    }
}