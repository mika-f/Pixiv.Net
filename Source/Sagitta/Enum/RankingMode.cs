using System;

namespace Sagitta.Enum
{
    public enum RankingMode
    {
        Day,

        DayManga,

        DayMale,

        DayFemale,

        Week,

        WeekOriginal,

        WeekRookie,

        WeekRookieManga,

        Month,

        MonthManga
    }

    public static class RankingModeExt
    {
        internal static string ToParameterStr(this RankingMode obj)
        {
            switch (obj)
            {
                case RankingMode.Day:
                    return "day";

                case RankingMode.DayManga:
                    return "day_manga";

                case RankingMode.DayMale:
                    return "day_male";

                case RankingMode.DayFemale:
                    return "day_female";

                case RankingMode.Week:
                    return "week";

                case RankingMode.WeekOriginal:
                    return "week_original";

                case RankingMode.WeekRookie:
                    return "week_rookie";

                case RankingMode.WeekRookieManga:
                    return "week_rookie_manga";

                case RankingMode.Month:
                    return "month";

                case RankingMode.MonthManga:
                    return "month_manga";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}