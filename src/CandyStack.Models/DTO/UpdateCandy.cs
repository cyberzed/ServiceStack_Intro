using ServiceStack.ServiceHost;

namespace CandyStack.Models.DTO
{
	[Route("/candies", Verbs = "PATCH")]
	[Route("/candies/{Id}", Verbs = "PATCH")]
	public class UpdateCandy
	{
		public ushort Id { get; set; }
		public string Name { get; set; }
	}
}