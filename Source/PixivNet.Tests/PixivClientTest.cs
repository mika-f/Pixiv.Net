using System;
using System.Linq;
using System.Threading.Tasks;

using Moq;

using Pixiv.Shims;
using Pixiv.Tests.Helpers;

using Xunit;

namespace Pixiv.Tests
{
    public class PixivClientTest
    {
        [Fact]
        public async Task ApplyPixivHeaders_ValidClientHash1()
        {
            var handler = new FakeHttpClientHandler();
            var mock = new Mock<PixivClient>(() => new PixivClient("", "", PixivClientFactory.ClientHash, handler));
            mock.Setup(w => w.GetCurrentDate()).Returns(new DateTimeOffset(new DateTime(2019, 11, 4, 17, 12, 12)));

            await mock.Object.GetAsync("https://example.com", false); // no stuff

            var request = handler.LastRequest;

            Assert.Equal("b3c435f615d7dea97b8c1637d93e52ca", request!.Headers.GetValues("X-Client-Hash").First());
            Assert.Equal("2019-11-04T17:12:12+09:00", request!.Headers.GetValues("X-Client-Time").First());
        }

        [Fact]
        public async Task ApplyPixivHeaders_ValidClientHash2()
        {
            var handler = new FakeHttpClientHandler();
            var mock = new Mock<PixivClient>(() => new PixivClient("", "", PixivClientFactory.ClientHash, handler));
            mock.Setup(w => w.GetCurrentDate()).Returns(new DateTimeOffset(new DateTime(2019, 11, 4, 17, 11, 38)));

            await mock.Object.GetAsync("https://example.com", false); // no stuff

            var request = handler.LastRequest;

            Assert.Equal("0e1d9a577486aed197e5ceb5ab9e622c", request!.Headers.GetValues("X-Client-Hash").First());
            Assert.Equal("2019-11-04T17:11:38+09:00", request!.Headers.GetValues("X-Client-Time").First());
        }
    }
}