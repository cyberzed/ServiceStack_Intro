using ServiceStack.ServiceHost;

namespace CandyStack.DTO
{
	[Route("/orders", "GET,POST,PUT")]
	[Route("/orders/{Id}", "GET,PUT,DELETE")]
	[Route("/orders/status/{OrderStatus}")]
	public class Order
	{
	}
}