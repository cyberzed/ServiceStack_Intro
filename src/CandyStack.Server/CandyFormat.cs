using System;
using System.IO;
using CandyStack.Models.Domain;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace CandyStack.Server
{
	public class CandyFormat
	{
		private const string CandyFormatContentType = "text/x-candy";

		public static void Register(IAppHost appHost)
		{
			appHost.ContentTypeFilters.Register(CandyFormatContentType, SerializeToStream, (t, s) => { throw new NotImplementedException(); });
		}

		private static void SerializeToStream(IRequestContext requestcontext, object dto, Stream outputstream)
		{
			var candyResponse = dto as Candy;

			if (candyResponse != null)
			{
				using (var writer = new StreamWriter(outputstream))
				{
					writer.WriteLine("Id: {0}", candyResponse.Id);
					writer.WriteLine("Name: {0}", candyResponse.Name);
					writer.WriteLine("Price: {0}", candyResponse.Price);
				}
			}
		}
	}
}