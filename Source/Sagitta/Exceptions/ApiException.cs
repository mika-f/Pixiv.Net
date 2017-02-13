using System;
using System.Net;
using System.Net.Http;

namespace Sagitta.Exceptions
{
    internal abstract class ApiException : PixivException
    {
        public HttpResponseMessage Response { get; }
        public abstract HttpStatusCode StatusCode { get; }

        protected ApiException(HttpResponseMessage response) : this(response, null) {}

        protected ApiException(HttpResponseMessage response, string message) : this(response, message, null) {}

        protected ApiException(HttpResponseMessage response, string message, Exception innerException) : base(message, innerException)
        {
            Response = response;
        }
    }
}