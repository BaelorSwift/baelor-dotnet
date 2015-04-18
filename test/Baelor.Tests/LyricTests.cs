using Baelor.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Baelor.Tests
{
	public class LyricTests
	{
		[Theory]
		[InlineData("style")]
		[InlineData("22")]
		public async Task ReturnsLyricFromSongSlug(string slug)
		{
			var apiKey = Environment.GetEnvironmentVariable("baelor-test-apikey");
			var baelorClient = new BaelorClient(apiKey);
			var lyric = await baelorClient.Lyrics(slug);
			Assert.NotNull(lyric);
		}

		[Theory]
		[InlineData("style")]
		public async Task ThrowsAuthenticationException(string slug)
		{
			var baelorClient = new BaelorClient();
			var ex = await Assert.ThrowsAsync<AuthenticationRequiredException>(
				async () => await baelorClient.Lyrics(slug));

			Assert.Equal("This endpoint requires an Api Key to authenticate.", ex.Message);
		}
	}
}