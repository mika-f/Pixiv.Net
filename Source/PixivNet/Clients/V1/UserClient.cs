using Pixiv.Clients.V1.User;

namespace Pixiv.Clients.V1
{
    public class UserClient : ApiClient
    {
        public BookmarksClient Bookmarks { get; }
        public BookmarkTagsClient BookmarkTags { get; }
        public BrowsingHistoryClient BrowsingHistory { get; }
        public MeClient Me { get; }
        public ProfileClient Profile { get; }

        internal UserClient(PixivClient client) : base(client, "/v1/user")
        {
            Bookmarks = new BookmarksClient(client);
            BookmarkTags = new BookmarkTagsClient(client);
            BrowsingHistory = new BrowsingHistoryClient(client);
            Me = new MeClient(client);
            Profile = new ProfileClient(client);
        }
    }
}