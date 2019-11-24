using System.Runtime.Serialization;

namespace Pixiv.Enums
{
    public enum ContentType
    {
        [EnumMember(Value = "illust")]
        Illust,

        [EnumMember(Value = "manga")]
        Manga
    }
}