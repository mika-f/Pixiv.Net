namespace Pixiv.Enum
{
    /// <summary>
    ///     検索対象
    /// </summary>
    public enum SearchTarget
    {
        /// <summary>
        ///     タイトルとキャプション
        /// </summary>
        TitleAndCaption,

        /// <summary>
        ///     厳密なタグ一致
        /// </summary>
        ExactMatchForTags,

        /// <summary>
        ///     部分的なタグ一致
        /// </summary>
        PartialMatchForTags,

        /// <summary>
        ///     小説本文
        /// </summary>
        Text,

        /// <summary>
        ///     小説本文
        /// </summary>
        Keyword
    }
}