using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Sagitta.Enum;
using Sagitta.Extensions;
using Sagitta.Helpers;
using Sagitta.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Sagitta.Clients
{
    public class NovelClient : ApiClient
    {
        public NovelBookmarkClient Bookmark { get; }
        public NovelMarkerClient Marker { get; }

        public NovelClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmark = new NovelBookmarkClient(pixivClient);
            Marker = new NovelMarkerClient(pixivClient);
        }

        public Task<CommentCollection> CommentsAsync(int novelId, int offset = 0)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            return PixivClient.GetAsync<CommentCollection>("https://app-api.pixiv.net/v1/novel/comments", parameters);
        }

        public async Task<Novel> DetailAsync(int novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };

            var response = await PixivClient.GetAsync<NovelResponse>("https://app-api.pixiv.net/v2/novel/detail", parameters).Stay();
            return response?.Novel;
        }

        public Task<NovelCollection> FollowAsync(Restrict restrict = Restrict.Public, int offset = 0, string filter = "")
        {
            Ensure.InvalidEnumValue(restrict == Restrict.All, nameof(restrict));
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("restrict", restrict.ToParameterStr())
            };
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            if (string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, string>("filter", filter));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/follow", parameters);
        }

        public Task<Markers> MarkersAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            return PixivClient.GetAsync<Markers>("https://app-api.pixiv.net/v2/novel/markers", parameters);
        }

        public Task<NovelCollection> MypixivAsync(int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/mypixiv", parameters);
        }

        public Task<NovelCollection> NewAsync(int maxNovelId = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (maxNovelId > 0)
                parameters.Add(new KeyValuePair<string, string>("max_novel_id", maxNovelId.ToString()));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/new", parameters);
        }

        public Task<NovelCollection> RankingAsync(RankingMode mode, DateTime? date = null, int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("mode", mode.ToParameterStr())
            };
            if (date.HasValue)
                parameters.Add(new KeyValuePair<string, string>("date", date.Value.ToString("yyyy-MM-dd")));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/ranking", parameters);
        }

        public Task<NovelCollection> RecommendedAsync(bool includeRankingIllusts = true, int maxBookmarkIdForRecommend = 0, int offset = 0)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("include_ranking_illusts", includeRankingIllusts.ToString().ToLower())
            };
            if (maxBookmarkIdForRecommend > 0)
                parameters.Add(new KeyValuePair<string, string>("max_bookmark_id_for_recommend", maxBookmarkIdForRecommend.ToString()));
            if (offset > 0)
                parameters.Add(new KeyValuePair<string, string>("offset", offset.ToString()));

            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/recommended", parameters);
        }

        public Task<NovelCollection> SeriesAsync(int seriesId)
        {
            Ensure.GreaterThanZero(seriesId, nameof(seriesId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("series_id", seriesId.ToString())
            };
            return PixivClient.GetAsync<NovelCollection>("https://app-api.pixiv.net/v1/novel/series", parameters);
        }

        public Task<Text> TextAsync(int novelId)
        {
            Ensure.GreaterThanZero(novelId, nameof(novelId));

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("novel_id", novelId.ToString())
            };
            return PixivClient.GetAsync<Text>("https://app-api.pixiv.net/v1/novel/text", parameters);
        }
    }
}