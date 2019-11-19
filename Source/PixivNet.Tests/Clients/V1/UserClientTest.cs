using System.Threading.Tasks;

using Pixiv.Enums;

using Xunit;

namespace Pixiv.Tests.Clients.V1
{
    public class UserClientTest : PixivTestAPiClient
    {
        public UserClientTest() : base("**REDACTED**") { }

        [Fact]
        public async Task Detail_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.DetailAsync(3623925));
        }

        [Fact]
        public void Detail_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.DetailAsync(3623925, null));
        }

        [Fact]
        public async Task Follower_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.FollowerAsync(3623925));
        }

        [Fact]
        public void Follower_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.FollowerAsync(3623925, null));
        }

        [Fact]
        public async Task Following_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.FollowingAsync(3623925, Restrict.Public));
        }

        [Fact]
        public void Following_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.FollowingAsync(3623925, Restrict.Public, null));
        }

        [Fact]
        public async Task Illusts_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.IllustsAsync(1023317, ContentType.Illust));
        }

        [Fact]
        public void Illusts_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.IllustsAsync(1023317, ContentType.Illust, null, null));
        }

        [Fact]
        public async Task IllustSeries_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.IllustSeriesAsync(14499092));
        }

        [Fact]
        public void IllustSeries_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.IllustSeriesAsync(14499092, null, null));
        }

        [Fact]
        public async Task Mypixiv_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.MypixivAsync(8986503));
        }

        [Fact]
        public void Mypixiv_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.MypixivAsync(8986503, null));
        }

        [Fact]
        public async Task Novel_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.NovelsAsync(8986503));
        }

        [Fact]
        public void Novel_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.NovelsAsync(8986503, null));
        }

        [Fact(Skip = "Unimplemented")]
        public async Task NovelDraftPreviews_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.NovelDraftPreviewsAsync());
        }

        [Fact(Skip = "Unimplemented")]
        public void NovelDraftPreviews_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.NovelDraftPreviewsAsync());
        }

        [Fact]
        public async Task Recommended_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.RecommendedAsync());
        }

        [Fact]
        public void Recommended_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.RecommendedAsync(null, null));
        }

        [Fact]
        public async Task Related_ShouldExtendsIsNullObject()
        {
            await ShouldExtendsIsNullObject(w => w.UserV1.RelatedAsync(11970396));
        }

        [Fact]
        public void Related_ShouldHaveAttributes()
        {
            ShouldHaveAttributes(w => w.UserV1.RelatedAsync(11970396, null));
        }
    }
}