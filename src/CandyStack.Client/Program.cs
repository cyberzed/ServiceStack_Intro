using System;
using System.Linq;
using CandyStack.Models.DTO;
using CandyStack.Models.Domain;
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

			var bagOfCandy = new BagOfCandy {Name = "Mix bag"};

			bagOfCandy.Add(candies.Skip(1).Take(1).Single(), 10.1f);
			bagOfCandy.Add(candies.Skip(2).Take(1).Single(), 5.1f);

			client.Post(bagOfCandy);
		}
	}
}