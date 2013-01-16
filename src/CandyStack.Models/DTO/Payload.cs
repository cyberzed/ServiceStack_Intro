using ServiceStack.ServiceHost;

namespace CandyStack.Models.DTO
{
	[Route("/cargo")]
	public class Payload
	{
		public bool IsShopEmpty { get; set; }
	}
}