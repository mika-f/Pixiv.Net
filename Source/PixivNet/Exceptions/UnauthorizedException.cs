using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;

namespace Pixiv.Exceptions
{
    [SuppressMessage("Design", "CA1032:標準例外コンストラクターを実装します", Justification = "<保留中>")]
    public class UnauthorizedException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException(HttpResponseMessage response) : base(response) { }

        public UnauthorizedException(HttpResponseMessage response, string message) : base(response, message) { }

        public UnauthorizedException(HttpResponseMessage response, string message, Exception innerException) : base(response, message, innerException) { }
    }
}