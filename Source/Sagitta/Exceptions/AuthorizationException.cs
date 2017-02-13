using System;
using System.Net;
using System.Net.Http;

namespace Sagitta.Exceptions
{
    internal class AuthorizationException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public AuthorizationException(HttpResponseMessage response) : base(response) {}

        public AuthorizationException(HttpResponseMessage response, string message) : base(response, message) {}

        public AuthorizationException(HttpResponseMessage response, string message, Exception innerException) : base(response, message, innerException) {}
    }
}