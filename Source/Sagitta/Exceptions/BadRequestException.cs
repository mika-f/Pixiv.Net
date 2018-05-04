using System;
using System.Net;
using System.Net.Http;

namespace Sagitta.Exceptions
{
    /// <summary>
    ///     Sagitta 内部で、 HTTP 400 Bad Request が返された場合に発生する例外です。
    /// </summary>
    public class BadRequestException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        public BadRequestException(HttpResponseMessage response) : base(response) { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        /// <param name="message">例外メッセージ</param>
        public BadRequestException(HttpResponseMessage response, string message) : base(response, message) { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        /// <param name="message">例外メッセージ</param>
        /// <param name="innerException">内部例外</param>
        public BadRequestException(HttpResponseMessage response, string message, Exception innerException) : base(response, message, innerException) { }
    }
}