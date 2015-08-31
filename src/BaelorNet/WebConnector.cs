using BaelorNet.Exceptions;
using BaelorNet.Extentions;
using BaelorNet.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaelorNet
{
	internal class WebConnector
	{
		/// <summary>
		/// The base url of the Api.
		/// </summary>
		private string _apiBase = "https://baelor.io/api";

		/// <summary>
		/// The version of the Api we're using.
		/// </summary>
		private string _apiVersion = "0";

		/// <summary>
		/// The format of the Api url.
		/// </summary>
		private string _apiFormat = "{0}/v{1}/{2}";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpMethod"></param>
		/// <param name="apiEndpoint"></param>
		/// <param name="data"></param>
		internal async Task<T> PerformRequest<T>(Enums.HttpMethod httpMethod, string apiEndpoint, object data)
			where T : class
		{
			return await PerformRequest<T>(httpMethod, apiEndpoint, null, data);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpMethod"></param>
		/// <param name="apiEndpoint"></param>
		/// <param name="apiKey"></param>
		internal async Task<T> PerformRequest<T>(Enums.HttpMethod httpMethod, string apiEndpoint, string apiKey)
			where T : class
		{
			return await PerformRequest<T>(httpMethod, apiEndpoint, apiKey, null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpMethod"></param>
		/// <param name="apiEndpoint"></param>
		/// <param name="apiKey"></param>
		/// <param name="data"></param>
		internal async Task<T> PerformRequest<T>(Enums.HttpMethod httpMethod, string apiEndpoint, string apiKey, object data)
			where T : class
		{
			if (apiEndpoint == null)
				throw new ArgumentNullException("apiEndpoint");
			if ((httpMethod == Enums.HttpMethod.POST || httpMethod == Enums.HttpMethod.PATCH) && data == null)
				throw new ArgumentNullException("data");

			var uri = BuildApiUri(apiEndpoint);

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("User-Agent", string.Format("Baelor.Net/{0} (yolo)", "0.69"));
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				if (apiKey != null)
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", apiKey);

				if (data != null)
					httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

				HttpResponseMessage response = null;
				switch (httpMethod)
				{
					case Enums.HttpMethod.POST:
						response = await httpClient.PostAsync(uri,
							new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
						break;

					case Enums.HttpMethod.PATCH:
						response = await httpClient.PatchAsync(uri,
							new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
						break;

					case Enums.HttpMethod.GET:
						response = await httpClient.GetAsync(uri);
						break;

					case Enums.HttpMethod.DELETE:
						response = await httpClient.DeleteAsync(uri);
						break;

					default:
						throw new NotSupportedException("Only POST, PATCH, GET, and DELETE methods are supported.");
				}

				try
				{
					var content = await response.Content.ReadAsStringAsync();
					var parsed = JsonConvert.DeserializeObject<ResponseBase<T>>(content);
					if (parsed.Success)
						return parsed.Result;

					throw new BaelorException(parsed.Error.Description, parsed.Error.StatusCode, parsed.Error.Details);
				}
				catch (JsonReaderException)
				{
					throw new BaelorException("json_parsing_excpetion", 0x00);
				}
			}
		}

		/// <summary>
		/// Builds a <see cref="Uri"/> that specifies where to make the request to.
		/// </summary>
		/// <param name="apiEndpoint">The requested endpoint of the Api to access.</param>
		private Uri BuildApiUri(string apiEndpoint)
		{
			return new Uri(string.Format(_apiFormat, _apiBase, _apiVersion, apiEndpoint));
		}
	}
}
