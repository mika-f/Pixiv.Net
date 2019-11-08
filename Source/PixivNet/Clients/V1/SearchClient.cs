using Pixiv.Clients.V1.Search;

namespace Pixiv.Clients.V1
{
    public class SearchClient : ApiClient
    {
        public BookmarkRangesClient BookmarkRanges { get; }

        internal SearchClient(PixivClient client) : base(client, "/v1/search")
        {
            BookmarkRanges = new BookmarkRangesClient(client);
        }
    }
}