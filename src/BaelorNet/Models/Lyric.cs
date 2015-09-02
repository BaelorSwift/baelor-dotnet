using Newtonsoft.Json;
using System;

namespace BaelorNet.Models
{
	public class Lyric
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("time_code")]
		public TimeSpan TimeCode { get; set; }
	}
}
