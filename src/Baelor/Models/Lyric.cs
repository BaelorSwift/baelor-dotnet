using Newtonsoft.Json;
using System;

namespace Baelor.Models
{
	public class Lyric
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("time_code")]
		public TimeSpan TimeCode { get; set; }
	}
}
