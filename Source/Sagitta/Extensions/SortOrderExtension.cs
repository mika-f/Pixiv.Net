using System;

using Sagitta.Enum;

namespace Sagitta.Extensions
{
    /// <summary>
    ///     <see cref="SortOrder" /> 拡張
    /// </summary>
    public static class SortOrderExtension
    {
        /// <summary>
        ///     <see cref="SortOrder" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="SortOrder" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this SortOrder obj)
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