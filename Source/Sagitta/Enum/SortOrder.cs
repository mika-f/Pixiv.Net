using System;

namespace Sagitta.Enum
{
    public enum SortOrder
    {
        DateAsc,

        DateDesc,

        PopularDesc
    }

    public static class SortOrderExt
    {
        public static string ToParameterString(this SortOrder obj)
        {
            switch (obj)
            {
                case SortOrder.DateAsc:
                    return "date_asc";

                case SortOrder.DateDesc:
                    return "date_desc";

                case SortOrder.PopularDesc:
                    return "popular_desc";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}