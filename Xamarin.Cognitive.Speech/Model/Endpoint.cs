using System;

namespace Xamarin.Cognitive.Speech
{
	/// <summary>
	/// Endpoint details.
	/// </summary>
	public class Endpoint
	{
		/// <summary>
		/// Gets the protocol.
		/// </summary>
		public string Protocol { get; private set; } = "https";

		/// <summary>
		/// Gets the host.
		/// </summary>
		public string Host { get; private set; }

		/// <summary>
		/// Gets the port.
		/// </summary>
		public int Port { get; private set; } = 443;

		/// <summary>
		/// Gets the path.
		/// </summary>
		public string Path { get; private set; }

		/// <summary>
		/// Gets the query.
		/// </summary>
		public string Query { get; private set; }
		
		/// <summary>
		/// Gets a value indicating if this endpoint should use the speech region as a prefix to the endpoint
		/// </summary>
		/// <remarks>Defaults to True. If enabled, the speech region will prefix this endpoint, e.g. [Protocol]://centralus.[Host]:[Port]/[Path]?[Query]</remarks>
		public bool PrefixWithRegion { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Xamarin.Cognitive.Speech.Endpoint"/> class.
		/// </summary>
		/// <param name="protocol">Protocol.</param>
		/// <param name="host">Host.</param>
		/// <param name="port">Port.</param>
		/// <param name="path">Path, including the leading '/'</param>
		/// <param name="prefixWithRegion">If set to True, the speech region will prefix this endpoint, e.g. [Protocol]://centralus.[Host]:[Port]/[Path]?[Query]</param>
		public Endpoint (string protocol, string host, int port, string path, bool prefixWithRegion = true)
		{
			Protocol = protocol;
			Host = host;
			Port = port;
			Path = path;
			PrefixWithRegion = prefixWithRegion;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Xamarin.Cognitive.Speech.Endpoint"/> class. 
		/// Assumes Https protocol.
		/// </summary>
		/// <param name="host">Host.</param>
		/// <param name="port">Port.</param>
		/// <param name="path">Path, including the leading '/'</param>
		/// <param name="prefixWithRegion">If set to True, the speech region will prefix this endpoint, e.g. [Protocol]://centralus.[Host]:[Port]/[Path]?[Query]</param>
		public Endpoint (string host, int port, string path, bool prefixWithRegion = true)
		{
			Host = host;
			Port = port;
			Path = path;
			PrefixWithRegion = prefixWithRegion;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Xamarin.Cognitive.Speech.Endpoint"/> class. 
		/// Assumes Https protocol and port 443.
		/// </summary>
		/// <param name="host">Host.</param>
		/// <param name="path">Path, including the leading '/'</param>
		/// <param name="prefixWithRegion">If set to True, the speech region will prefix this endpoint, e.g. [Protocol]://centralus.[Host]:[Port]/[Path]?[Query]</param>
		public Endpoint (string host, string path, bool prefixWithRegion = true)
		{
			Host = host;
			Path = path;
			PrefixWithRegion = prefixWithRegion;
		}
		
				/// <summary>
		/// Initializes a new instance of the <see cref="T:Xamarin.Cognitive.Speech.Endpoint"/> class. 
		/// Assumes Https protocol and port 443.
		/// </summary>
		/// <param name="host">Host.</param>
		/// <param name="path">Path, including the leading '/'</param>
		/// <param name="prefixWithRegion">If set to True, the speech region will prefix this endpoint, e.g. [Protocol]://centralus.[Host]:[Port]/[Path]?[Query]</param>
		public Endpoint (string host, string path, string query, bool prefixWithRegion = true)
		{
			Host = host;
			Path = path;
			Query = query;
			PrefixWithRegion = prefixWithRegion;
		}

		public UriBuilder ToUriBuilder (SpeechRegion speechRegion)
		{
			var uriBuilder = new UriBuilder
			{
			    Scheme = this.Protocol,
			    Port = this.Port,
			    Path = this.Path,
			    Query = this.Query,
			};

			if (PrefixWithRegion)
			{
				uriBuilder.Host = $"{speechRegion.ToString ().ToLower ()}.{this.Host}";
			}
			else
			{
				uriBuilder.Host = this.Host;
			}

			return uriBuilder;
		}
	}
}
