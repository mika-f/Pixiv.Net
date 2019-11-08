using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Enum;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V2.Illust
{
    public class BookmarkClient : ApiClient
    {
        internal BookmarkClient(PixivClient client) : base(client, "/v2/illust/bookmark") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task AddAsync(long illustId, Restrict restrict = Restrict.Public)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("illust_id", illustId),
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };

            await PostAsync("/add", parameters).Stay();
        }
        
        // TODO: Remove

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<BookmarkDetail> DetailAsync(long illustId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("illust_id", illustId)
            };

            var response = await GetAsync("/detail", parameters).Stay();
            return response["bookmark_detail"].ToObject<BookmarkDetail>();
        }
    }
}