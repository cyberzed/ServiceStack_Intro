using ServiceStack.ServiceHost;

namespace CandyStack.DTO
{
	[Route("/cargotruck")]
	public class Payload
	{
		public bool IsShopEmpty { get; set; }
	}
}