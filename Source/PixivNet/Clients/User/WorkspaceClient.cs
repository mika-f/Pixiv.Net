using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Extensions;

namespace Pixiv.Clients.User
{
    /// <summary>
    ///     作業環境関連 API
    /// </summary>
    public class WorkspaceClient : ApiClient
    {
        /// <inheritdoc />
        internal WorkspaceClient(PixivClient pixivClient) : base(pixivClient) { }

        /// <summary>
        ///     作業環境を更新します。
        /// </summary>
        /// <param name="printer">プリンター</param>
        /// <param name="desk">机</param>
        /// <param name="scanner">スキャナー</param>
        /// <param name="monitor">モニター</param>
        /// <param name="tool">ソフト</param>
        /// <param name="desktop">机の上にあるもの</param>
        /// <param name="tablet">タブレット</param>
        /// <param name="music">絵を描く時に聞く音楽</param>
        /// <param name="chair">椅子</param>
        /// <param name="comment">その他</param>
        /// <param name="pc">コンピュータ</param>
        /// <param name="mouse">マウス</param>
        public async Task EditAsync(string printer = "", string desk = "", string scanner = "", string monitor = "", string tool = "", string desktop = "", string tablet = "", string music = "", string chair = "", string comment = "", string pc = "", string mouse = "")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("printer", printer),
                new KeyValuePair<string, object>("desk", desk),
                new KeyValuePair<string, object>("scanner", scanner),
                new KeyValuePair<string, object>("monitor", monitor),
                new KeyValuePair<string, object>("tool", tool),
                new KeyValuePair<string, object>("desktop", desktop),
                new KeyValuePair<string, object>("tablet", tablet),
                new KeyValuePair<string, object>("music", music),
                new KeyValuePair<string, object>("chair", chair),
                new KeyValuePair<string, object>("comment", comment),
                new KeyValuePair<string, object>("pc", pc),
                new KeyValuePair<string, object>("mouse", mouse)
            };
            await PixivClient.PostAsync("https://app-api.pixiv.net/v1/user/workspace/edit", parameters).Stay();
        }
    }
}