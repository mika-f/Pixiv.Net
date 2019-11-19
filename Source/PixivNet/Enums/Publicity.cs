using System.Runtime.Serialization;

namespace Pixiv.Enums
{
    public enum Publicity
    {
        [EnumMember(Value = "public")]
        Public,

        [EnumMember(Value = "private")]
        Private
    }
}