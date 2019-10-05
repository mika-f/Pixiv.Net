using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Helpers;

namespace Sagitta.Clients.User.BrowsingHistory
{
    /// <summary>
    ///     閲覧履歴 (イラスト) 関連 API
    /// </summary>
    public class IllustClient : ApiClient
    {
        /// <inheritdoc />
        internal IllustClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したイラスト ID を閲覧履歴へと追加します。
        /// </summary>
        /// <param name="illustIds">イラスト ID</param>
        public async Task AddAsync(long[] illustIds)
        {
            Ensure.ArraySizeNotZero(illustIds, nameof(illustIds));

            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddRange(parameters.Select(w => new KeyValuePair<string, object>("illust_ids[]", w)));

            await PixivClient.PostAsync("https://app-api.pixiv.net/v2/user/browsing-history/illust/add", parameters).Stay();
        }
    }
}