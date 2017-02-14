namespace Sagitta.Clients
{
    public class IllustClient : ApiClient
    {
        public IllustBookmarkClient Bookmark { get; set; }

        public IllustClient(PixivClient pixivClient) : base(pixivClient)
        {
            Bookmark = new IllustBookmarkClient(pixivClient);
        }
    }
}