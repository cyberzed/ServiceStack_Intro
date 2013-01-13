using ServiceStack.ServiceHost;

namespace CandyStack.Server.DTO
{
	[Route("/cargo")]
	public class Payload
	{
		public bool IsShopEmpty { get; set; }
	}
}