using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Pixiv.Tests.Helpers
{
    internal class FakeHttpClientHandler : HttpClientHandler
    {
        public HttpRequestMessage? LastRequest { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequest = request;

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") });
        }
    }
}