using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Pixiv.Extensions
{
    public static class EnumExtensions
    {
        public static string ToValue<T>(this T @enum) where T : Enum
        {
            var name = Enum.GetName(typeof(T), @enum);
            var attribute = typeof(T).GetField(name)?.GetCustomAttribute<EnumMemberAttribute>() ?? throw new InvalidOperationException();
            return attribute.Value;
        }
    }
}