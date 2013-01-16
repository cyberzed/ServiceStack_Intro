using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace CandyStack.Models.Domain
{
	[Route("/candies", "POST,PUT,DELETE")]
	[Route("/candies/{Id}", "GET,PUT,DELETE")]
	public class Candy
	{
		[AutoIncrement]
		public ushort Id { get; set; }

		[Index(Unique = true)]
		public string Name { get; set; }

		public decimal Price { get; set; }
	}
}