using System;

using Pixiv.Enum;

namespace Pixiv.Extensions
{
    /// <summary>
    ///     <see cref="SearchTarget" /> 拡張
    /// </summary>
    public static class SearchTargetExtension
    {
        /// <summary>
        ///     <see cref="SearchTarget" /> を URL クエリパラメータに変換します。
        /// </summary>
        /// <param name="obj">
        ///     <see cref="SearchTarget" />
        /// </param>
        /// <returns>変換後文字列</returns>
        public static string ToParameter(this SearchTarget obj)
        {
            switch (obj)
            {
                case SearchTarget.TitleAndCaption:
                    return "title_and_caption";

                case SearchTarget.ExactMatchForTags:
                    return "exact_match_for_tags";

                case SearchTarget.PartialMatchForTags:
                    return "partial_match_for_tags";

                case SearchTarget.Text:
                    return "text";

                case SearchTarget.Keyword:
                    return "keyword";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}