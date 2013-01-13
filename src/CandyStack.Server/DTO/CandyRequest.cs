using System.Collections.Generic;
using CandyStack.Server.Domain;
using ServiceStack.ServiceHost;

namespace CandyStack.Server.DTO
{
	[Route("/candies", "GET")]
	[Route("/candies/min/{MinPrice}", "GET")]
	[Route("/candies/max/{MaxPrice}", "GET")]
	public class CandyRequest : IReturn<List<Candy>>
	{
		public List<uint> Ids { get; set; }

		public decimal? MinPrice { get; set; }
		public decimal? MaxPrice { get; set; }
	}
}