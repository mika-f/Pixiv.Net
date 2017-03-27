using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Sagitta.Models
{
    public class Cursorable
    {
        [JsonIgnore]
        internal PixivClient PixivClient { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
    }

    public class Cursorable<T> : Cursorable where T : new()
    {
        public Task<T> NextPageAsync() => PixivClient.GetAsync<T>(NextUrl, PixivClient.EmptyParameter);
    }
}