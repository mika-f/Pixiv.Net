using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Models;
using Pixiv.Tests.Helpers;

using PixivNet.Shims;

using Xunit;

namespace Pixiv.Tests
{
    public class PixivTestAPiClient
    {
        private readonly PixivClient _pixivClient;

        protected PixivTestAPiClient()
        {
            _pixivClient = PixivClientFactory.CreateWith("v2", new MockedHttpClientHandler());
        }

        protected void ShouldHaveAttributes<T>(Expression<Func<PixivClient, Task<T>>> expression)
        {
            var lambda = expression as LambdaExpression;
            var method = ((MethodCallExpression) lambda.Body).Method;

            // test 1
            {
                var attribute = method.GetCustomAttribute<MarkedAsAttribute>();

                Assert.NotNull(attribute); //Method should have `MarkedAs` attribute
                Assert.Equal(PixivClient.AppVersion, attribute!.MarkedAs); // `MarkedAs` value should equals to application version
            }

            // test 2
            {
                var attribute = method.GetCustomAttribute<ApiVersionAttribute>();

                Assert.NotNull(attribute); // Method should have `ApiVersion` attribute.

                var appVersion = new Version($"{PixivClient.AppVersion}.0");
                var minVersion = new Version(attribute!.MinVersion);
                var maxVersion = new Version(attribute!.MaxVersion);

                if (minVersion >= appVersion)
                    Assert.Null(method.GetCustomAttributes<ObsoleteAttribute>()); // if app >= min, method should not have obsolete attribute
                else if (maxVersion <= appVersion)
                    Assert.NotNull(method.GetCustomAttribute<ObsoleteAttribute>()); // if app >= max, method should have obsolete attribute
            }
        }

        protected async Task ShouldExtendsIsNullObject<T>(Func<PixivClient, Task<T>> func) where T : ApiResponse
        {
            var response = await func.Invoke(_pixivClient);
            response.CheckRecursivelyExtendsIsNull();
        }
    }
}