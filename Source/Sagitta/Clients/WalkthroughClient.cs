using System.Threading.Tasks;

using Sagitta.Extensions;
using Sagitta.Models;

namespace Sagitta.Clients
{
    /// <summary>
    ///     デモンストレーション関連 API へのアクセスを提供します。
    /// </summary>
    public class WalkthroughClient : ApiClient
    {
        /// <inheritdoc />
        internal WalkthroughClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     未ログイン時トップ画面用のイラスト集を取得します。
        /// </summary>
        /// <returns>
        ///     <see cref="IllustCollection" /> (※ページング不可)
        /// </returns>
        public async Task<IllustCollection> IllustsAsync()
        {
            return await PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/walkthrough/illusts").Stay();
        }
    }
}