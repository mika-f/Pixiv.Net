using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class UserPreview
    {
        [JsonProperty("user")]
        public UserWithComment User { get; set; }

        [JsonProperty("illusts")]
        public IEnumerable<Illust> Illusts { get; set; }

        [JsonProperty("novels")]
        public IEnumerable<Novel> Novels { get; set; }

        [JsonProperty("is_muted")]
        public bool IsMuted { get; set; }
    }
}