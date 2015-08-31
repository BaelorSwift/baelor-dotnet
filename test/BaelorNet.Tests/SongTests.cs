using BaelorNet.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BaelorNet.Tests
{
	public class SongTests
	{
		[Fact]
		public async Task ReturnsOneOrMoreSong()
		{
			var apiKey = Environment.GetEnvironmentVariable("baelor-test-apikey");
			var baelorClient = new BaelorClient(apiKey);
			var songs = await baelorClient.Songs();
			Assert.NotEmpty(songs);
		}

		[Theory]
		[InlineData("style")]
		[InlineData("22")]
		public async Task ReturnsSongFromSlug(string slug)
		{
			var apiKey = Environment.GetEnvironmentVariable("baelor-test-apikey");
			var baelorClient = new BaelorClient(apiKey);
			var song = await baelorClient.Song(slug);
			Assert.NotNull(song);
		}

		[Fact]
		public async Task ThrowsAuthenticationException()
		{
			var baelorClient = new BaelorClient();
			var ex = await Assert.ThrowsAsync<AuthenticationRequiredException>(
				async () => await baelorClient.Songs());

			Assert.Equal("This endpoint requires an Api Key to authenticate.", ex.Message);
		}
	}

}
