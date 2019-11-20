using System.Runtime.Serialization;

namespace Pixiv.Enums
{
    public enum Sort
    {
        [EnumMember(Value = "date_asc")]
        DateAsc,

        [EnumMember(Value = "date_desc")]
        DateDesc,

        [EnumMember(Value = "popular_desc")]
        PopularDesc,

        [EnumMember(Value = "popular_female_desc")]
        PopularFemaleDesc,

        [EnumMember(Value = "popular_male_desc")]
        PopularMaleDesc
    }
}