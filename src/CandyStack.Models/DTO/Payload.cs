using ServiceStack.ServiceHost;

namespace CandyStack.Models.DTO
{
	[Route("/cargo")]
	public class Payload : IReturn<bool>
	{
		public bool IsShopEmpty { get; set; }
	}
}