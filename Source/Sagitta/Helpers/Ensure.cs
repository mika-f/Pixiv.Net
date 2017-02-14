using System;

namespace Sagitta.Helpers
{
    internal static class Ensure
    {
        public static void NotNull(object obj, string name)
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }

        public static void NotNullOrWhitespace(string str, string name)
        {
            NotNull(str, name);
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException("String cannot be empty", name);
        }

        public static void GreaterThanZero(int obj, string name)
        {
            if (obj < 0)
                throw new ArgumentException("Int cannot less than zero.", name);
        }
    }
}