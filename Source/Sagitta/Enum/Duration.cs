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
        public static string ToParameterStr(this Duration obj)
        {
            switch (obj)
            {
                case Duration.LastDay:
                    return "last_day";

                case Duration.LastWeek:
                    return "last_week";

                case Duration.LastMonth:
                    return "last_month";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}