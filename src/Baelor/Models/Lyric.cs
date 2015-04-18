using Newtonsoft.Json;

namespace Baelor.Models
{
	public class Lyric
	{
		[JsonProperty("lyrics")]
		public string Lyrics { get; set; }

		[JsonProperty("song")]
		public Song Song { get; set; }
	}
}