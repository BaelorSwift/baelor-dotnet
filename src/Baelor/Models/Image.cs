using Newtonsoft.Json;
using System;

namespace Baelor.Models
{
	public class Image
	{
		[JsonProperty("image_id")]
		public Guid ImageId { get; set; }
	}
}