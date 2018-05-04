namespace Sagitta.Clients
{
    /// <summary>
    ///     API Client ベースクラス
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        ///     <see cref="PixivClient" /> インスタンス
        /// </summary>
        protected PixivClient PixivClient { get; }

        protected ApiClient(PixivClient pixivClient)
        {
            PixivClient = pixivClient;
        }
    }
}