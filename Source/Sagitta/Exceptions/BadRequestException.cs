using System;
using System.Net;
using System.Net.Http;

namespace Sagitta.Exceptions
{
    public class BadRequestException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestException(HttpResponseMessage response) : base(response) {}

        public BadRequestException(HttpResponseMessage response, string message) : base(response, message) {}

        public BadRequestException(HttpResponseMessage response, string message, Exception innerException) : base(response, message, innerException) {}
    }
}