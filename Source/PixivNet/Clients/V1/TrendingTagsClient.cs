using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class TrendingTagsClient : ApiClient
    {
        public TrendingTagsClient(PixivClient client) : base(client, "/v1/trending-tags") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        public async Task<IEnumerable<TrendTag>> IllustAsync(string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            var obj = await GetAsync("/illust", parameters).Stay();
            return obj["trend_tags"].ToObject<IEnumerable<TrendTag>>();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        public async Task<IEnumerable<TrendTag>> NovelAsync(string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            var obj = await GetAsync("/novel", parameters).Stay();
            return obj["trend_tags"].ToObject<IEnumerable<TrendTag>>();
        }
    }
}