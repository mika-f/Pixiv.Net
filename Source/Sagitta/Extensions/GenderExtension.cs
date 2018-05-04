using System;

using Sagitta.Enum;

namespace Sagitta.Extensions
{
    /// <summary>
    ///     <see cref="Gender" /> 拡張
    /// </summary>
    public static class GenderExtension
    {
        /// <summary>
        ///     <see cref="Gender" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="Gender" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this Gender obj)
        {
            switch (obj)
            {
                case Gender.Male:
                    return "male";

                case Gender.Female:
                    return "female";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}