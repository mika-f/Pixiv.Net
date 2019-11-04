using System;

namespace Pixiv.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property)]
    internal class ApiVersionAttribute : Attribute
    {
        public string MinVersion { get; }
        public string MaxVersion { get; }

        public ApiVersionAttribute(string? minVersion = null, string? maxVersion = null)
        {
            MinVersion = minVersion ?? "unspecified";
            MaxVersion = maxVersion ?? "unspecified";
        }
    }
}