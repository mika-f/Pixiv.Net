using System;

using Sagitta.Enum;

namespace Sagitta.Extensions
{
    /// <summary>
    ///     <see cref="Restrict" /> 拡張
    /// </summary>
    public static class RestrictExtension
    {
        /// <summary>
        ///     <see cref="Restrict" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="Restrict" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this Restrict obj)
        {
            switch (obj)
            {
                case Restrict.All:
                    return "all";

                case Restrict.Public:
                    return "public";

                case Restrict.Private:
                    return "private";

                case Restrict.Mypixiv:
                    return "mypixiv";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}