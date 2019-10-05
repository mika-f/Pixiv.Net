using System;
using System.Net;
using System.Net.Http;

namespace Pixiv.Exceptions
{
#pragma warning disable RCS1194 // Implement exception constructors.

    /// <summary>
    ///     Pixiv.Net での API コール時に例外が発生した場合、投げられる例外のベースクラスです。
    /// </summary>
    public abstract class ApiException : PixivException
#pragma warning restore RCS1194 // Implement exception constructors.
    {
        /// <summary>
        ///     例外発生時のレスポンス
        /// </summary>
        public HttpResponseMessage Response { get; }

        /// <summary>
        ///     例外発生時のステータスコード
        /// </summary>
        public abstract HttpStatusCode StatusCode { get; }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        /// <param name="message">例外メッセージ</param>
        protected ApiException(HttpResponseMessage response, string message = null) : this(response, message, null) { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="response">
        ///     <see cref="HttpResponseMessage" />
        /// </param>
        /// <param name="message">例外メッセージ</param>
        /// <param name="innerException">内部例外</param>
        protected ApiException(HttpResponseMessage response, string message, Exception innerException) : base(message, innerException)
        {
            Response = response;
        }
    }
}