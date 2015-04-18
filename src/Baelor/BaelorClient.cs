﻿using Baelor.Enums;
using Baelor.Exceptions;
using Baelor.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Baelor
{
	public class BaelorClient
	{
		/// <summary>
		/// 
		/// </summary>
		internal readonly WebConnector _webConnector;

		/// <summary>
		/// 
		/// </summary>
		private string _apiKey = null;

		/// <summary>
		/// 
		/// </summary>
		private string _authenticationRequiredMessage = "This endpoint requires an Api Key to authenticate.";

		public BaelorClient()
		{
			_webConnector = new WebConnector();
		}

		public BaelorClient(string apiKey)
			: this()
		{
			_apiKey = apiKey;
		}

		public async Task<IEnumerable<Song>> Songs()
		{
			if (_apiKey == null)
				throw new AuthenticationRequiredException(_authenticationRequiredMessage);

			return await _webConnector.PerformRequest<IEnumerable<Song>>(HttpMethod.GET, "songs", _apiKey);
		}

		public async Task<Song> Song(string slug)
		{
			if (_apiKey == null)
				throw new AuthenticationRequiredException(_authenticationRequiredMessage);

			return await _webConnector.PerformRequest<Song>(HttpMethod.GET, "songs/" + slug, _apiKey);
		}

		public async Task<IEnumerable<Album>> Albums()
		{
			if (_apiKey == null)
				throw new AuthenticationRequiredException(_authenticationRequiredMessage);

			return await _webConnector.PerformRequest<IEnumerable<Album>>(HttpMethod.GET, "albums", _apiKey);
		}

		public async Task<Album> Album(string slug)
		{
			if (_apiKey == null)
				throw new AuthenticationRequiredException(_authenticationRequiredMessage);

			return await _webConnector.PerformRequest<Album>(HttpMethod.GET, "albums/" + slug, _apiKey);
		}

		public async Task<Lyric> Lyrics(string songSlug)
		{
			if (_apiKey == null)
				throw new AuthenticationRequiredException(_authenticationRequiredMessage);

			return await _webConnector.PerformRequest<Lyric>(HttpMethod.GET, "songs/" + songSlug + "/lyrics", _apiKey);
		}
	}
}
