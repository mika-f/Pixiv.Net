using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Extensions;
using Pixiv.Helpers;
using Pixiv.Models;

namespace Pixiv.Clients
{
    /// <summary>
    ///     ミュート関連 API
    /// </summary>
    public class MuteClient : ApiClient
    {
        /// <inheritdoc />
        internal MuteClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     指定したタグのミュートを解除します。
        /// </summary>
        /// <param name="tags">タグ名</param>
        public async Task DeleteAsync(string[] tags)
        {
            Ensure.ArraySizeNotZero(tags, nameof(tags));

            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("delete_tags[]", string.Join(",", tags)) };
            await PixivClient.PostAsync("https://app-api.pixiv.net/v1/mute/edit", parameters).Stay();
        }

        /// <summary>
        ///     ミュートリストを取得します。
        /// </summary>
        /// <returns>
        ///     <see cref="MuteList" />
        /// </returns>
        public async Task<MuteList> ListAsync()
        {
            return await PixivClient.GetAsync<MuteList>("https://app-api.pixiv.net/v1/mute/list").Stay();
        }
    }
}