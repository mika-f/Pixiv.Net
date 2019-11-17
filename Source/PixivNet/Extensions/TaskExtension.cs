using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pixiv.Extensions
{
    public static class TaskExtension
    {
        public static ConfiguredTaskAwaitable<T> Stay<T>(this Task<T> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            return task.ConfigureAwait(false);
        }
    }
}