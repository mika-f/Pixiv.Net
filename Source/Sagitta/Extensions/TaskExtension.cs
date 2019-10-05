using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pixiv.Extensions
{
    /// <summary>
    ///     <see cref="Task{TResult}" /> 拡張
    /// </summary>
    public static class TaskExtension
    {
        /// <summary>
        ///     `ConfigureAwait(false)` を行います。
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="obj">
        ///     <see cref="Task{TResult}" />
        /// </param>
        /// <returns></returns>
        public static ConfiguredTaskAwaitable<T> Stay<T>(this Task<T> obj)
        {
            return obj.ConfigureAwait(false);
        }
    }
}