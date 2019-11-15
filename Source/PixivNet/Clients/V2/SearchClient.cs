using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V2
{
    public class SearchClient : ApiClient
    {
        internal SearchClient(PixivClient client) : base(client, "/v2/search") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IEnumerable<Tag>> AutoCompleteAsync(string word, bool mergePlainKeywordResults = true)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(word), word),
                new KeyValuePair<string, object>("merge_plain_keyword_results", mergePlainKeywordResults)
            };

            var response = await GetAsync("/autocomplete", parameters).Stay();
            return response["tags"].ToObject<IEnumerable<Tag>>();
        }
    }
}