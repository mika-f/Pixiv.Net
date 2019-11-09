using System.Runtime.Serialization;

namespace Pixiv.Enum
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