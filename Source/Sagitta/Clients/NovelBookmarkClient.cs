using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

namespace Sagitta.Clients
{
    public class NovelBookmarkClient : ApiClient
    {
        public NovelBookmarkClient(PixivClient pixivClient) : base(pixivClient) {}

        public async Task AddAsync(int novelId, Restrict restrict = Restrict.Public, string[] tags = null)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString()),
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (tags != null)
                parameters.AddRange(tags.Select(tag => new KeyValuePair<string, string>("tags[]", tag)));

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v2/novel/bookmark/add", parameters).Stay();
        }

        public async Task DeleteAsync(int novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };

            await PixivClient.PostAsync<VoidClass>("https://app-api.pixiv.net/v1/novel/bookmark/delete", parameters).Stay();
        }

        public async Task<BookmarkDetail> DetailAsync(int novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };

            var response = await PixivClient.GetAsync<BookmarkDetailResponse>("https://app-api.pixiv.net/v2/novel/bookmark/detail", parameters).Stay();
            return response?.BookmarkDetail;
        }

        public Task<BookmarkUsers> UsersAsync(int novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };

            return PixivClient.GetAsync<BookmarkUsers>("https://app-api.pixiv.net/v1/novel/bookmark/users", parameters);
        }
    }
}