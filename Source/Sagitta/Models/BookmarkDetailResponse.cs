using Newtonsoft.Json;

namespace Sagitta.Models
{
    internal class BookmarkDetailResponse
    {
        [JsonProperty("bookmark_detail")]
        public BookmarkDetail BookmarkDetail { get; set; }
    }
}