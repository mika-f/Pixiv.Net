using System;

using Pixiv.Enum;

namespace Pixiv.Extensions
{
    /// <summary>
    ///     <see cref="IllustType" /> 拡張
    /// </summary>
    public static class IllustTypeExtension
    {
        /// <summary>
        ///     <see cref="IllustType" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="IllustType" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this IllustType obj)
        {
            switch (obj)
            {
                case IllustType.Illust:
                    return "illust";

                case IllustType.Manga:
                    return "manga";

                case IllustType.Ugoira:
                    return "ugoira";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}