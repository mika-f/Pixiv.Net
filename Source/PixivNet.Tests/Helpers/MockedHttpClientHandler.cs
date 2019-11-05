using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Pixiv.Tests.Helpers
{
    internal class MockedHttpClientHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}