using ServiceStack.ServiceHost;

namespace CandyStack.DTO
{
	[Route("/cargo")]
	public class Payload
	{
		public bool IsShopEmpty { get; set; }
	}
}