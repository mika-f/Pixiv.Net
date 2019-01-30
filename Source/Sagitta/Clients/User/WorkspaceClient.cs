using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Extensions;

namespace Sagitta.Clients.User
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
        public async Task EditAsync(string printer = "", string desk = "", string scanner = "", string monitor = "", string tool = "", string desktop = "",
                                    string tablet = "", string music = "", string chair = "", string comment = "", string pc = "", string mouse = "")
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("printer", printer),
                new KeyValuePair<string, string>("desk", desk),
                new KeyValuePair<string, string>("scanner", scanner),
                new KeyValuePair<string, string>("monitor", monitor),
                new KeyValuePair<string, string>("tool", tool),
                new KeyValuePair<string, string>("desktop", desktop),
                new KeyValuePair<string, string>("tablet", tablet),
                new KeyValuePair<string, string>("music", music),
                new KeyValuePair<string, string>("chair", chair),
                new KeyValuePair<string, string>("comment", comment),
                new KeyValuePair<string, string>("pc", pc),
                new KeyValuePair<string, string>("mouse", mouse)
            };
            await PixivClient.PostAsync("https://app-api.pixiv.net/v1/user/workspace/edit", parameters).Stay();
        }
    }
}