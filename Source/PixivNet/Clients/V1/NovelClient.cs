using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Clients.V1.Novel;
using Pixiv.Enums;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class NovelClient : ApiClient
    {
        public BookmarkClient Bookmark { get; }

        internal NovelClient(PixivClient client) : base(client, "/v1/novel")
        {
            Bookmark = new BookmarkClient(client);
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> FollowAsync(Restrict restrict, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<NovelCollection>("/follow", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> MypixivAsync(long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<NovelCollection>("/mypixiv", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> NewAsync(long? maxNovelId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (maxNovelId.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_novel_id", maxNovelId.Value));

            return await GetAsync<NovelCollection>("/new", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> RankingAsync(RankingMode mode, DateTime? date = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(mode), mode.ToValue())
            };
            if (date.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(date), date.Value.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture)));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<NovelCollection>("/ranking", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> RecommendedAsync(bool includeRankingNovels = true, bool includePrivacyPolicy = true, long? maxBookmarkIdForRecommend = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("include_ranking_novels", includeRankingNovels),
                new KeyValuePair<string, object>("include_privacy_policy", includePrivacyPolicy)
            };
            if (maxBookmarkIdForRecommend.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id_for_recommend", maxBookmarkIdForRecommend.Value));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));

            return await GetAsync<NovelCollection>("/recommended", parameters).Stay();
        }
    }
}