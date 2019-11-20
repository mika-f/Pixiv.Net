using System.Runtime.Serialization;

namespace Pixiv.Enums
{
    public enum SearchTarget
    {
        [EnumMember(Value = "exact_match_for_tags")]
        ExactMatchForTags,

        [EnumMember(Value = "keyword")]
        Keyword,

        [EnumMember(Value = "partial_match_for_tags")]
        PartialMatchForTags,

        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "title_and_caption")]
        TitleAndCaption
    }
}