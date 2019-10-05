using System;

using Pixiv.Enum;

namespace Pixiv.Extensions
{
    /// <summary>
    ///     <see cref="ListType" /> 拡張
    /// </summary>
    public static class ListTypeExtension
    {
        /// <summary>
        ///     <see cref="ListType" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="ListType" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this ListType obj)
        {
            switch (obj)
            {
                case ListType.Following:
                    return "following";

                case ListType.Popular:
                    return "popular";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}