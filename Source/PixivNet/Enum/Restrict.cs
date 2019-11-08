using System.Runtime.Serialization;

namespace Pixiv.Enum
{
    public enum Restrict
    {
        [EnumMember(Value = "public")]
        Public,
        
        [EnumMember(Value = "private")]
        Private
    }
}