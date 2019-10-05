using System.Threading.Tasks;

using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients
{
    /// <summary>
    ///     アプリケーション情報関連 API
    /// </summary>
    // MARKED: 7.4.4
    public class ApplicationInfoClient : ApiClient
    {
        /// <inheritdoc />
        internal ApplicationInfoClient(PixivClient pixivClient) : base(pixivClient) { }

        // ReSharper disable once InconsistentNaming
        /// <summary>
        ///     Pixiv for iOS の情報を取得します。
        /// </summary>
        /// <returns><see cref="ApplicationInfo" /> モデル</returns>
        public async Task<ApplicationInfo> iOSAsync()
        {
            var response = await PixivClient.GetAsync("https://app-api.pixiv.net/v1/application-info/ios").Stay();
            return response["application-info"].ToObject<ApplicationInfo>();
        }
    }
}