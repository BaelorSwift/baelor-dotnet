using BaelorNet.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BaelorNet.Tests
{
	public class AlbumTests
	{
		[Fact]
		public async Task ReturnsOneOrMoreAlbum()
		{
			var apiKey = Environment.GetEnvironmentVariable("baelor-test-apikey");
			var baelorClient = new BaelorClient(apiKey);
			var albums = await baelorClient.Albums();
			Assert.NotEmpty(albums);
		}

		[Theory]
		[InlineData("1989")]
		[InlineData("taylor-swift")]
		public async Task ReturnsAlbumFromSlug(string slug)
		{
			var apiKey = Environment.GetEnvironmentVariable("baelor-test-apikey");
			var baelorClient = new BaelorClient(apiKey);
			var album = await baelorClient.Album(slug);
			Assert.NotNull(album);
		}

		[Fact]
		public async Task ThrowsAuthenticationException()
		{
			var baelorClient = new BaelorClient();
			var ex = await Assert.ThrowsAsync<AuthenticationRequiredException>(
				async () => await baelorClient.Albums());

			Assert.Equal("This endpoint requires an Api Key to authenticate.", ex.Message);
		}
	}
}
