using ServiceStack.ServiceHost;

namespace CandyStack.Domain
{
	[Route("/cargotruck")]
	public class Payload
	{
		public bool IsShopEmpty { get; set; }
	}
}