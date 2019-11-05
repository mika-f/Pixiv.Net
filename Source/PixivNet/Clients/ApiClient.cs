using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Pixiv.Extensions;

namespace Pixiv.Clients
{
    public class ApiClient
    {
        private readonly string _base;
        private readonly string _host;
        protected PixivClient Client { get; }

        public ApiClient(PixivClient client, string @base, string host = "app-api.pixiv.net")
        {
            Client = client;
            _base = @base;
            _host = host;
        }

        public async Task<T> GetAsync<T>(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null)
        {
            return await Client.GetAsync<T>($"https://{_host}{_base}{endpoint}", parameters).Stay();
        }

        public async Task<JObject> GetAsync(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null)
        {
            return await Client.GetAsync($"https://{_host}{_base}{endpoint}", parameters).Stay();
        }
    }
}