using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Sagitta.Clients
{
    public class IllustClient : ApiClient
    {
        public IllustBookmarkClient Bookmark { get; }

        public IllustClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmark = new IllustBookmarkClient(pixivClient);
        }

        public Task<CommentCollection> CommentAsync(int illustId, bool includeTotalComments = true, int offset = 0)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString()),
                new KeyValuePair<string, string>("include_total_comments", includeTotalComments.ToString().ToLower())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<CommentCollection>("https://app-api.pixiv.net/v1/illust/comments", parameters);
        }

        public async Task<Illust> DetailAsync(int illustId)
        {
            Ensure.GreaterThanZero(illustId, nameof(illustId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };

            var response = await PixivClient.GetAsync<IllustResponse>("https://app-api.pixiv.net/v1/illust/detail", parameters).Stay();
            return response?.Illust;
        }

        public Task<IllustCollection> FollowAsync(Restrict restrict = Restrict.Public, string filter = "", int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v2/illust/follow", parameters);
        }

        public Task<IllustCollection> MypixivAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v2/illust/mypixiv", parameters);
        }

        public Task<IllustCollection> NewAsync(IllustType contentType, string filter = "", int maxIllustId = 0)
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

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/new", parameters);
        }

        public Task<IllustCollection> RankingAsync(RankingMode mode, DateTime? date = null, string filter = "", int offset = 0)
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

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/ranking", parameters);
        }

        public Task<IllustCollection> RecommendedAsync(bool includeRankingIllusts = true, string filter = "", int maxBookmarkIdForRecommend = 0,
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

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v1/illust/recommended", parameters);
        }

        public Task<IllustCollection> RelatedAsync(int illustId, string filter = "", int[] seedIllustIds = null)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("illust_id", illustId.ToString())
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));
            if (seedIllustIds != null)
                parameters.AddRange(seedIllustIds.Select(w => new KeyValuePair<string, string>("seed_illust_ids[]", w.ToString())));

            return PixivClient.GetAsync<IllustCollection>("https://app-api.pixiv.net/v2/illust/related", parameters);
        }
    }
}