using System.Runtime.Serialization;

namespace Pixiv.Enums
{
    public enum RankingMode
    {
        [EnumMember(Value = "day")]
        Daily,

        [EnumMember(Value = "day_female")]
        DailyFemale,

        [EnumMember(Value = "day_male")]
        DailyMale,

        [EnumMember(Value = "daily_manga")]
        DailyManga,

        [EnumMember(Value = "month")]
        Monthly,

        [EnumMember(Value = "month_manga")]
        MonthlyManga,

        [EnumMember(Value = "week")]
        Weekly,

        [EnumMember(Value = "week_original")]
        WeeklyOriginal,

        [EnumMember(Value = "week_rookie")]
        WeeklyRookie,

        [EnumMember(Value = "week_rookie_manga")]
        WeeklyRookieManga,

        [EnumMember(Value = "week_manga")]
        WeeklyManga
    }
}