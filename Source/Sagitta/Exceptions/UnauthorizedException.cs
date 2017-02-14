using System;
using System.Net;
using System.Net.Http;

namespace Sagitta.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException(HttpResponseMessage response) : base(response) {}

        public UnauthorizedException(HttpResponseMessage response, string message) : base(response, message) {}

        public UnauthorizedException(HttpResponseMessage response, string message, Exception innerException) : base(response, message, innerException) {}
    }
}