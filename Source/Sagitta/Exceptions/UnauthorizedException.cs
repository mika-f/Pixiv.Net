using System;
using System.Net;
using System.Net.Http;

namespace Sagitta.Exceptions
{
    /// <summary>
    ///     Pixiv に対して、認証エラー (HTTP 401 Unauthorized) が発生した場合に投げられます。
    /// </summary>
    public class UnauthorizedException : ApiException
    {
        /// <summary>
        ///     ステータスコード
        /// </summary>
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        public UnauthorizedException(HttpResponseMessage response) : base(response) { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        /// <param name="message">例外メッセージ</param>
        public UnauthorizedException(HttpResponseMessage response, string message) : base(response, message) { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        /// <param name="message">例外メッセージ</param>
        /// <param name="innerException">内部例外</param>
        public UnauthorizedException(HttpResponseMessage response, string message, Exception innerException) : base(response, message, innerException) { }
    }
}