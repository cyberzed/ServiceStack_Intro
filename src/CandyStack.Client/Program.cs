using System;
using CandyStack.Models.DTO;
using ServiceStack.ServiceClient.Web;

namespace CandyStack.Client
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var serverUrl = "http://localhost:57441/";

			var client = new JsonServiceClient(serverUrl);

			var isDatabaseSetupForDemo = client.Get(new Payload());

			Console.WriteLine("IsDatabaseSetupForDemo: {0}", isDatabaseSetupForDemo);

			var candies = client.Get(new CandyRequest());
		}
	}
}