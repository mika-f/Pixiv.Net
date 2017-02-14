using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Sagitta.Enum;

namespace Sagitta.Models
{
    public class Illust
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IllustType Type { get; set; }

        [JsonProperty("image_urls")]
        public ImageUrls ImageUrls { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("restrict")]
        public int Restrict { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        [JsonProperty("tools")]
        public IEnumerable<string> Tools { get; set; }

        [JsonProperty("create_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("sanity_level")]
        public int SanityLevel { get; set; }

        [JsonProperty("meta_single_page")]
        public MetaSinglePage MetaSinglePage { get; set; }

        [JsonProperty("meta_pages")]
        public IEnumerable<MetaPage> MetaPages { get; set; }

        [JsonProperty("total_view")]
        public int TotalView { get; set; }

        [JsonProperty("total_bookmarks")]
        public int TotalBookmarks { get; set; }

        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonProperty("visible")]
        public bool IsVisible { get; set; }

        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}