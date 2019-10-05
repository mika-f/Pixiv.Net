using System;

namespace Pixiv.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property)]
    internal class ApiVersionAttribute : Attribute
    {
        public string Version { get; }

        public ApiVersionAttribute(string version)
        {
            Version = version;
        }
    }
}