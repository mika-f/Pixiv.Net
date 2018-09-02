using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Models
{
    /// <summary>
    ///     投稿作品のベースクラス
    /// </summary>
    public class Work
    {
        /// <summary>
        ///     ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        ///     タイトル
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     キャプション
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        ///     制限レベル
        /// </summary>
        [JsonProperty("restrict")]
        public int Restrict { get; set; }

        /// <summary>
        ///     画像 URL
        /// </summary>
        [JsonProperty("image_urls")]
        public ImageUrls ImageUrls { get; set; }

        /// <summary>
        ///     投稿日時
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("create_date")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     タグ
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        /// <summary>
        ///     ページ数
        /// </summary>
        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        /// <summary>
        ///     ユーザー
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        ///     シリーズ
        /// </summary>
        [JsonProperty("series")]
        public Series Series { get; set; }

        /// <summary>
        ///     閲覧数
        /// </summary>
        [JsonProperty("total_view")]
        public int TotalView { get; set; }

        /// <summary>
        ///     コメント数
        /// </summary>
        [JsonProperty("total_comments")]
        public int TotalComments { get; set; }

        /// <summary>
        ///     ブックマーク数
        /// </summary>
        [JsonProperty("total_bookmarks")]
        public int TotalBookmarks { get; set; }

        /// <summary>
        ///     ブックマーク済みか否か
        /// </summary>
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        /// <summary>
        ///     表示可能であるか否か (年齢制限、 R18G 制限などに引っかかっていないか)
        /// </summary>
        [JsonProperty("visible")]
        public bool IsVisible { get; set; }

        /// <summary>
        ///     ミュートしているか否か
        /// </summary>
        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}