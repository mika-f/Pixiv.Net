using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sagitta.Handlers
{
    internal class OAuth2HttpClientHandler : HttpClientHandler
    {
        private readonly PixivClient _client;

        public OAuth2HttpClientHandler(PixivClient client)
        {
            this._client = client;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(!string.IsNullOrWhiteSpace(this._client.AccessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this._client.AccessToken);
            return base.SendAsync(request, cancellationToken);
        }
    }
}