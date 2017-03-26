using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class IllustBookmarkClient : ApiClient
    {
        public IllustBookmarkClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task AddAsync(int illustId, Restrict restrict = Restrict.Public, string[] tags = null)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (tags != null)
                parameters.AddRange(tags.Select(tag => new KeyValuePair<string, string>("tags[]", tag)));

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/illust/bookmark/add", parameters).Stay();
        }

        public async Task DeleteAsync(int illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/illust/bookmark/delete", parameters).Stay();
        }

        public async Task<BookmarkDetail> DetailAsync(int illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            var response = await PixivClient.GetAsync<BookmarkDetailResponse>("https://app-api.pixiv.net/v2/illust/bookmark/detail", parameters).Stay();
            return response?.BookmarkDetail;
        }

        public async Task<BookmarkUsers> UsersAsync(int illustId, int offset = 0)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            return await PixivClient.GetAsync<BookmarkUsers>("https://app-api.pixiv.net/v1/illust/bookmark/users", parameters).Stay();
        }
    }
}