using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class SpotlightClient : ApiClient
    {
        internal SpotlightClient(PixivClient client) : base(client, "/v1/spotlight") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<SpotlightArticleCollection> ArticlesAsync(string category, string filter = "for_ios", int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(category), category)
            };
            
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));

            return await GetAsync<SpotlightArticleCollection>("/articles", parameters).Stay();
        }
    }
}