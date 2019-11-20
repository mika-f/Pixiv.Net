using Pixiv.Clients.V1.Novel;

namespace Pixiv.Clients.V1
{
    public class NovelClient : ApiClient
    {
        public BookmarkClient Bookmark { get; }

        internal NovelClient(PixivClient client) : base(client, "/v1/novel")
        {
            Bookmark = new BookmarkClient(client);
        }
    }
}