using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Pixiv.Extensions;

namespace Pixiv.Clients
{
    public class ApiClient
    {
        private readonly string _base;
        protected PixivClient Client { get; }

        public ApiClient(PixivClient client, string @base)
        {
            Client = client;
            _base = @base;
        }

        public async Task<T> GetAsync<T>(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null)
        {
            return await Client.GetAsync<T>(_base + endpoint, parameters).Stay();
        }

        public async Task<JObject> GetAsync(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null)
        {
            return await Client.GetAsync(_base + endpoint, parameters).Stay();
        }
    }
}