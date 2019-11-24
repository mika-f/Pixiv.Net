using System;

namespace Pixiv.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property)]
    internal class MarkedAsAttribute : Attribute
    {
        public string MarkedAs { get; }

        public MarkedAsAttribute(string markedAs)
        {
            MarkedAs = markedAs;
        }
    }
}