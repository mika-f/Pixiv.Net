using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class SpotlightClient : ApiClient
    {
        public SpotlightClient(PixivClient pixivClient) : base(pixivClient) {}

        public Task<SpotlightArticles> ArticlesAsync(string category, int offset = 0, string filter = "")
        {
            Ensure.NotNullOrWhitespace(category, nameof(category));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("category", category)
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));

            return PixivClient.GetAsync<SpotlightArticles>("https://app-api.pixiv.net/v1/spotlight/articles", parameters);
        }
    }
}