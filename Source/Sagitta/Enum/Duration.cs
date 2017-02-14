using System;

namespace Sagitta.Enum
{
    public enum Duration
    {
        LastDay,

        LastWeek,

        LastMonth
    }

    public static class DurationExt
    {
        internal static string ToParameterStr(this Duration obj)
        {
            switch (obj)
            {
                case Duration.LastDay:
                    return "within_last_day";

                case Duration.LastWeek:
                    return "within_last_week";

                case Duration.LastMonth:
                    return "within_last_month";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}