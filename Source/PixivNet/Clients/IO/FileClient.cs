using System;
using System.IO;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;

namespace Pixiv.Clients.IO
{
    public class FileClient : ApiClient
    {
        internal FileClient(PixivClient client) : base(client, "") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        [RequiredReferrer]
        public async Task<Stream> GetAsync(Uri uri)
        {
            return await GetAsyncAsStream(uri).Stay();
        }
    }
}