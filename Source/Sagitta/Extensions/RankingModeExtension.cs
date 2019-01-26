using System;

using Sagitta.Enum;

namespace Sagitta.Extensions
{
    /// <summary>
    ///     <see cref="RankingMode" /> 拡張
    /// </summary>
    public static class RankingModeExtension
    {
        /// <summary>
        ///     <see cref="RankingMode" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="RankingMode" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this RankingMode obj)
        {
            switch (obj)
            {
                case RankingMode.Daily:
                    return "day";

                case RankingMode.DailyMale:
                    return "day_make";

                case RankingMode.DailyFemale:
                    return "day_female";

                case RankingMode.DailyManga:
                    return "day_manga";

                case RankingMode.Weekly:
                    return "week";

                case RankingMode.WeeklyOriginal:
                    return "week_original";

                case RankingMode.WeeklyRookie:
                    return "week_rookie";

                case RankingMode.WeeklyManga:
                    return "week_manga";

                case RankingMode.Monthly:
                    return "month";

                case RankingMode.MonthlyManga:
                    return "month_manga";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}