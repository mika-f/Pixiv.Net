using System.Collections.Generic;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class MuteList
    {
        [JsonProperty("muted_tags")]
        public IEnumerable<MuteTag> Tags { get; set; }

        // TODO: I don't use this feature. Help.
        [JsonProperty("muted_users")]
        public IEnumerable<object> Users { get; set; }
    }
}