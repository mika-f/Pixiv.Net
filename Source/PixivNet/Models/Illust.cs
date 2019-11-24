using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Pixiv.Attributes;
using Pixiv.Enums;

namespace Pixiv.Models
{
    public class Illust : ApiResponse
    {
#pragma warning disable CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("create_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreateDate { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("height")]
        public long Height { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("image_urls")]
        public ImageUrls ImageUrls { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("meta_single_page")]
        public MetaSinglePage MetaSinglePage { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("meta_pages")]
        public IEnumerable<MetaPage> MetaPages { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("page_count")]
        public long PageCount { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("restrict")]
        public int Restrict { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("sanity_level")]
        public int SanityLevel { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("series")]
        public Series? Series { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_comments")]
        public long? TotalComments { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_bookmarks")]
        public long TotalBookmarks { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("total_view")]
        public long TotalView { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("tools")]
        public IEnumerable<string> Tools { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IllustType Type { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("user")]
        public MinifiedUser User { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("visible")]
        public bool IsVisible { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("width")]
        public long Width { get; set; }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [JsonProperty("x_restrict")]
        public int XRestrict { get; set; }

#pragma warning restore CS8618 // Null 非許容フィールドは初期化されていません。null 許容として宣言することを検討してください。
    }
}