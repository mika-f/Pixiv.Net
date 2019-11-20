using System;
using System.Collections.Generic;
using System.Linq;

using Pixiv.Models;

using Xunit;

namespace Pixiv.Tests.Helpers
{
    internal static class ObjectAssertion
    {
        public static void CheckRecursivelyExtendsIsNull(this ApiResponse obj, params string[] ignores)
        {
            foreach (var property in obj.GetType().GetProperties().Where(w => w.GetValue(obj) != null))
                if (property.PropertyType.IsSubclassOf(typeof(ApiResponse)))
                    (property.GetValue(obj) as ApiResponse)?.CheckRecursivelyExtendsIsNull();
                else if (property.PropertyType.IsGenericType && property.PropertyType.GenericTypeArguments.Any(w => w.IsSubclassOf(typeof(ApiResponse))))
                    if (property.PropertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(IEnumerable<>)))
                    {
                        var items = property.GetValue(obj) as IEnumerable<ApiResponse> ?? throw new InvalidOperationException();
                        foreach (var item in items)
                            item.CheckRecursivelyExtendsIsNull();
                    }

            if (ignores.Length == 0)
            {
                Assert.Null(obj.Extends);
            }
            else
            {
                ignores.ToList().ForEach(w => obj.Extends?.Remove(w));
                Assert.Equal(0, obj.Extends?.Count);
            }
        }
    }
}