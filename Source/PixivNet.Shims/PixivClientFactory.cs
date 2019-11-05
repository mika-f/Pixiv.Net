using System;
using System.Net.Http;

using Pixiv;

namespace PixivNet.Shims
{
    public static class PixivClientFactory
    {
        public static PixivClient CreateWith(string version, HttpMessageHandler? handler = null)
        {
            switch (version)
            {
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}