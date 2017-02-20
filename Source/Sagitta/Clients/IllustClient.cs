using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Helpers;
using Sagitta.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Sagitta.Clients
{
    public class IllustClient : ApiClient
    {
        public IllustBookmarkClient Bookmark { get; private set; }

        public IllustClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmark = new IllustBookmarkClient(pixivClient);
        }

        public async Task<CommentsRoot> CommentAsync(int illustId, bool includeTotalComments = true, int offset = 0)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString()),
                new KeyValuePair<string, string>("include_total_comments", includeTotalComments.ToString().ToLower())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<CommentsRoot>("https://app-api.pixiv.net/v1/illust/comments", parameters);
        }

        public async Task<Illust> DetailAsync(int illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };

            return (await PixivClient.GetAsync<IllustRoot>("https://app-api.pixiv.net/v1/illust/detail", parameters)).Illust;
        }

        public async Task<IllustsRoot> FollowAsync(Restrict restrict = Restrict.Public, string filter = "", int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v2/illust/follow", parameters);
        }

        public async Task<IllustsRoot> MypixivAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v2/illust/mypixiv", parameters);
        }

        public async Task<IllustsRoot> NewAsync(IllustType contentType, string filter = "", int maxIllustId = 0)
        {
            Ensure.InvalidEnumValue(contentType == IllustType.Ugoira, nameof(contentType));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("content_type", contentType.ToParameterStr())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (maxIllustId > 0)
                parameters.Add(new KeyValuePair<string, string>("max_illust_id", maxIllustId.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/illust/new", parameters);
        }

        public async Task<IllustsRoot> RankingAsync(RankingMode mode, DateTime? date = null, string filter = "", int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("mode", mode.ToParameterStr())
            };
            if (date.HasValue)
                parameters.Add(new KeyValuePair<string, string>("date", date.Value.ToString("yyyy-MM-dd")));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("max_illust_id", offset.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/illust/ranking", parameters);
        }

        public async Task<IllustsRoot> RecommendedAsync(bool includeRankingIllusts = true, string filter = "", int maxBookmarkIdForRecommend = 0,
                                                        int minBookmarkIdForRecentIllust = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("include_ranking_illusts", includeRankingIllusts.ToString().ToLower())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (maxBookmarkIdForRecommend > 0)
                parameters.Add(new KeyValuePair<string, string>("max_bookmark_id_for_recommend", maxBookmarkIdForRecommend.ToString()));
            if (minBookmarkIdForRecentIllust > 0)
                parameters.Add(new KeyValuePair<string, string>("min_bookmark_id_for_recent_illust", minBookmarkIdForRecentIllust.ToString()));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v1/illust/recommended", parameters);
        }

        public async Task<IllustsRoot> RelatedAsync(int illustId, string filter = "", int[] seedIllustIds = null)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (seedIllustIds != null)
                parameters.AddRange(seedIllustIds.Select(w => new KeyValuePair<string, string>("seed_illust_ids[]", w.ToString())));

            return await PixivClient.GetAsync<IllustsRoot>("https://app-api.pixiv.net/v2/illust/related", parameters);
        }
    }
}