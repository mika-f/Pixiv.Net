namespace Sagitta.Clients
{
    public class ApiClient
    {
        protected PixivClient PixivClient { get; }

        protected ApiClient(PixivClient pixivClient)
        {
            PixivClient = pixivClient;
        }
    }
}