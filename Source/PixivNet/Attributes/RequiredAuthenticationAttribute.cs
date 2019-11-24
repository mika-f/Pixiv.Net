using System;

namespace Pixiv.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class RequiredAuthenticationAttribute : Attribute { }
}