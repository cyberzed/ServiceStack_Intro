using CandyStack.Data;
using ServiceStack.ServiceInterface;

namespace CandyStack.Api
{
	public class OrderService : Service
	{
		private readonly OrderRepository orderRepository;

		public OrderService(OrderRepository orderRepository)
		{
			this.orderRepository = orderRepository;
		}


	}
}