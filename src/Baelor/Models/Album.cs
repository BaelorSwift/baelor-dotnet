using Newtonsoft.Json;
using System;

namespace Baelor.Models
{
	public class Album
	{
		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("released_at")]
		public DateTime ReleasedAt { get; set; }

		[JsonProperty("length")]
		public TimeSpan Length { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("genres")]
		public string[] Genres { get; set; }

		[JsonProperty("producers")]
		public string[] Producers { get; set; }

		[JsonProperty("songs", NullValueHandling = NullValueHandling.Ignore)]
		public Song[] Songs { get; set; }

		[JsonProperty("album_cover")]
		public Image AlbumCover { get; set; }
	}
}
