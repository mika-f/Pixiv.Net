using System;

namespace Sagitta.Enum
{
    public enum SearchTarget
    {
        /// <summary>
        ///     Search title and caption body.
        /// </summary>
        TitleAndCaption,

        /// <summary>
        ///     Search tags exactly
        /// </summary>
        ExactMatchForTags,

        /// <summary>
        ///     Search tags partiality
        /// </summary>
        PartialMatchForTags,

        /// <summary>
        ///     Search novel's text
        /// </summary>
        Text,

        /// <summary>
        ///     Search novel's body
        /// </summary>
        Keyword
    }

    public static class SearchTargetExt
    {
        public static string ToParameterStr(this SearchTarget obj)
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