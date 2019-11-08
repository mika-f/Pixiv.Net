using Pixiv.Clients.V2.Illust;

namespace Pixiv.Clients.V2
{
    public class IllustClient : ApiClient
    {
        public BookmarkClient Bookmark { get; }
        
        internal IllustClient(PixivClient client) : base(client, "/v2/illust")
        {
            Bookmark = new BookmarkClient(client);
        }
    }
}