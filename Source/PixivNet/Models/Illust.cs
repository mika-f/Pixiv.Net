using System.Collections.Generic;

using Newtonsoft.Json;

using Pixiv.Enum;

namespace Pixiv.Models
{
    /// <summary>
    ///     イラスト
    /// </summary>
    public class Illust : Work
    {
        /// <summary>
        ///     イラストの種類
        /// </summary>
        [JsonProperty("type")]
        public IllustType Type { get; set; }

        /// <summary>
        ///     使用ツール
        /// </summary>
        [JsonProperty("tools")]
        public IEnumerable<string> Tools { get; set; }

        /// <summary>
        ///     横サイズ
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        ///     縦サイズ
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        ///     TODO
        /// </summary>
        [JsonProperty("sanity_level")]
        public int SanityLevel { get; set; }

        /// <summary>
        ///     1ページ目の画像 URL
        /// </summary>
        [JsonProperty("meta_single_page")]
        public MetaSinglePage MetaSinglePage { get; set; }

        /// <summary>
        ///     複数枚画像がある場合の画像 URL のコレクション
        /// </summary>
        [JsonProperty("meta_pages")]
        public IEnumerable<ImageUrls> MetaPages { get; set; }
    }
}