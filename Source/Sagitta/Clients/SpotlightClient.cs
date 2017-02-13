using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class SpotlightClient : ApiClient
    {
        public SpotlightClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task<SpotlightArticles> ArticlesAsync(string category, int offset = 0, string filter = "")
        {
            Ensure.NotNullOrWhitespace(category, nameof(category));

            var parameters = new Dictionary<string, string>
            {
                {"category", category},
                {"offset", offset.ToString()}
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add("filter", filter);

            return await PixivClient.GetAsync<SpotlightArticles>("https://app-api.pixiv.net/v1/spotlight/articles", parameters);
        }
    }
}