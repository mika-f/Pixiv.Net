namespace Pixiv.Clients.V2.User
{
    public class BrowsingHistoryClient : ApiClient
    {
        public BrowsingHistory.IllustClient Illust { get; }

        internal BrowsingHistoryClient(PixivClient client) : base(client, "/v2/user/browsing-history")
        {
            Illust = new BrowsingHistory.IllustClient(client);
        }
    }
}