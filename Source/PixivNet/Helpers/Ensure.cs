using System;

namespace Pixiv.Helpers
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

        public static void GreaterThanZero(long obj, string name)
        {
            if (obj < 0)
                throw new ArgumentException("Int64 cannot less than zero.", name);
        }

        public static void InvalidEnumValue(bool cond, string name)
        {
            if (cond)
                throw new NotSupportedException($"{name}: Not supported value");
        }

        public static void ArraySizeNotZero<T>(T[] obj, string name)
        {
            if (obj.Length == 0)
                throw new ArgumentException("Array is empty", name);
        }
    }
}