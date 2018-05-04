using System;

namespace Sagitta.Exceptions
{
    /// <summary>
    ///     Sagitta 内部で例外が発生した場合に投げられます。
    /// </summary>
    public class PixivException : Exception
    {
        /// <summary>
        ///     コンストラクタ
        /// </summary>
        public PixivException() { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="message">例外メッセージ</param>
        public PixivException(string message) : base(message) { }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        /// <param name="message">例外メッセージ</param>
        /// <param name="innerException">内部例外</param>
        public PixivException(string message, Exception innerException) : base(message, innerException) { }
    }
}