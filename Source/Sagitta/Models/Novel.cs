using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Novel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("restrict")]
        public int Restrict { get; set; }

        [JsonProperty("image_urls")]
        public ImageUrls ImageUrls { get; set; }

        [JsonProperty("create_date")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("text_length")]
        public int TextLength { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonProperty("total_bookmarks")]
        public int TotalBookmarks { get; set; }

        [JsonProperty("total_view")]
        public int TotalView { get; set; }

        [JsonProperty("visible")]
        public bool IsVisible { get; set; }

        [JsonProperty("total_comments")]
        public int TotalComments { get; set; }

        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}