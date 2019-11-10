using System.Runtime.Serialization;

namespace Pixiv.Enum
{
    public enum IllustType
    {
        [EnumMember(Value = "illust")]
        Illust,

        [EnumMember(Value = "manga")]
        Manga,

        [EnumMember(Value = "ugoira")]
        Ugoira
    }
}