using System.Net.Http;

using Pixiv;

namespace PixivNet.Shims
{
    public static class PixivClientFactory
    {
        public const string ClientHash = "28c1fdd170a5204386cb1313c7077b34f83e4aaf4aa829ce78c231e05b0bae2c";

        public static PixivClient CreateWith(string version, HttpMessageHandler? handler = null)
        {
            switch (version)
            {
                default:
                    return new PixivClient("", "", ClientHash, handler);
            }
        }
    }
}