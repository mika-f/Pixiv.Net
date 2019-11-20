using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;

namespace Pixiv.Exceptions
{
    [SuppressMessage("Design", "CA1032:標準例外コンストラクターを実装します", Justification = "<保留中>")]
    [SuppressMessage("Design", "RCS1194:Implement exception constructors.", Justification = "<保留中>")]
    public abstract class ApiException : PixivException
    {
        public HttpResponseMessage Response { get; }

        public abstract HttpStatusCode StatusCode { get; }

        protected ApiException(HttpResponseMessage response, string? message = null) : this(response, message, null) { }

        protected ApiException(HttpResponseMessage response, string? message, Exception? innerException) : base(message, innerException)
        {
            Response = response;
        }
    }
}