using Pixiv.Clients.V1.Illust;

namespace Pixiv.Clients.V1
{
    public class IllustClient : ApiClient
    {
        public BookmarkClient Bookmark { get; }

        internal IllustClient(PixivClient client) : base(client, "/v1/illust")
        {
            Bookmark = new BookmarkClient(client);
        }
    }
}