using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Clients.V1.Illust;
using Pixiv.Enums;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class IllustClient : ApiClient
    {
        public BookmarkClient Bookmark { get; }

        internal IllustClient(PixivClient client) : base(client, "/v1/illust")
        {
            Bookmark = new BookmarkClient(client);
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<Models.Illust> DetailAsync(long illustId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("illust_id", illustId)
            };

            var response = await GetAsync("/detail", parameters).Stay();
            return response["illust"]!.ToObject<Models.Illust>()!;
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> NewAsync(ContentType contentType, long? maxIllustId = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("content_type", contentType.ToValue())
            };
            if (maxIllustId.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_illust_id", maxIllustId.Value));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustCollection>("/new", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> RankingAsync(RankingMode rankingMode, DateTime? date = null, long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("mode", rankingMode.ToValue())
            };
            if (date.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(date), date.Value.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture)));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustCollection>("/ranking", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> RecommendedAsync(bool includeRankingIllusts = true, bool includePrivacyPolicy = true, long? maxBookmarkIdForRecentIllust = null, long? minBookmarkIdForRecommend = null, long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("include_ranking_illusts", includeRankingIllusts),
                new KeyValuePair<string, object>("include_privacy_policy", includePrivacyPolicy)
            };
            if (maxBookmarkIdForRecentIllust.HasValue)
                parameters.Add(new KeyValuePair<string, object>("max_bookmark_id_for_recent_illust", maxBookmarkIdForRecentIllust.Value));
            if (minBookmarkIdForRecommend.HasValue)
                parameters.Add(new KeyValuePair<string, object>("min_bookmark_id_for_recommend", minBookmarkIdForRecommend));
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustCollection>("/recommended", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<SeriesDetail> Series(long illustSeriesId, long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("illust_series_id", illustSeriesId)
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset.Value));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<SeriesDetail>("series", parameters).Stay();
        }
    }
}