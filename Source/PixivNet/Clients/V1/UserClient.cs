using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Clients.V1.User;
using Pixiv.Enums;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.V1
{
    public class UserClient : ApiClient
    {
        public BookmarksClient Bookmarks { get; }
        public BookmarkTagsClient BookmarkTags { get; }
        public BrowsingHistoryClient BrowsingHistory { get; }
        public FollowClient Follow { get; }
        public MeClient Me { get; }
        public ProfileClient Profile { get; }
        public WorkspaceClient Workspace { get; }

        internal UserClient(PixivClient client) : base(client, "/v1/user")
        {
            Bookmarks = new BookmarksClient(client);
            BookmarkTags = new BookmarkTagsClient(client);
            BrowsingHistory = new BrowsingHistoryClient(client);
            Follow = new FollowClient(client);
            Me = new MeClient(client);
            Profile = new ProfileClient(client);
            Workspace = new WorkspaceClient(client);
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserDetail> DetailAsync(long userId, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<UserDetail>("/detail", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserPreviewCollection> FollowerAsync(long userId, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));

            return await GetAsync<UserPreviewCollection>("/follower", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserPreviewCollection> FollowingAsync(long userId, Restrict restrict, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>(nameof(restrict), restrict.ToValue())
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));

            return await GetAsync<UserPreviewCollection>("/following", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustCollection> IllustsAsync(long userId, ContentType type, long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId),
                new KeyValuePair<string, object>(nameof(type), type.ToValue())
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustCollection>("/illusts", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<IllustSeriesCollection> IllustSeriesAsync(long userId, long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<IllustSeriesCollection>("/illust-series", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserPreviewCollection> MypixivAsync(long userId, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));

            return await GetAsync<UserPreviewCollection>("/mypixiv", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public Task<ApiResponse> NovelDraftPreviewsAsync()
        {
            // novel-draft-previews
            throw new NotImplementedException();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<NovelCollection> NovelsAsync(long userId, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("user_id", userId)
            };
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));

            return await GetAsync<NovelCollection>("/novels", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserPreviewCollection> RecommendedAsync(long? offset = null, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (offset.HasValue)
                parameters.Add(new KeyValuePair<string, object>(nameof(offset), offset));
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<UserPreviewCollection>("/recommended", parameters).Stay();
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredAuthentication]
        public async Task<UserPreviewCollection> RelatedAsync(long seedUserId, string? filter = "for_ios")
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("seed_user_id", seedUserId)
            };
            if (!string.IsNullOrWhiteSpace(filter))
                parameters.Add(new KeyValuePair<string, object>(nameof(filter), filter));

            return await GetAsync<UserPreviewCollection>("/related", parameters).Stay();
        }
    }
}