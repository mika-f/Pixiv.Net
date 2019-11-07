using Newtonsoft.Json;

namespace Pixiv.Tests.Models
{
    internal class Cassette
    {
        [JsonProperty("request")]
        public CassetteRequest Request { get; set; }

        [JsonProperty("response")]
        public CassetteResponse Response { get; set; }
    }
}