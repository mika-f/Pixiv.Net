using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sagitta.Extensions
{
    public static class TaskExt
    {
        public static ConfiguredTaskAwaitable<T> Stay<T>(this Task<T> obj) => obj.ConfigureAwait(false);
    }
}