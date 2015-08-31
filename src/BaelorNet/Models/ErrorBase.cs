using Newtonsoft.Json;

namespace BaelorNet.Models
{
	public class ErrorBase
	{
		[JsonProperty("status_code")]
		public int StatusCode { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("details")]
		public object Details { get; set; }
	}
}
