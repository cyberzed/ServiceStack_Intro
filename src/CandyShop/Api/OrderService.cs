using System.Linq;
using System.Net;
using CandyStack.DTO;
using CandyStack.Data;
using CandyStack.Domain;
using ServiceStack.Common.Web;
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

		public object Get(Order request)
		{
			if (request.Id != default(uint))
			{
				var order = orderRepository.GetById(request.Id);

				return order;
			}

			return new HttpResult(HttpStatusCode.BadRequest);
		}

		public object Get(OrdersRequest request)
		{
			if (request.Ids != null && request.Ids.Any())
			{
				var orders = orderRepository.GetByIds(request.Ids);

				return orders;
			}

			if (request.OrderStatus != OrderStatus.None)
			{
				var orders = orderRepository.GetByOrderStatus(request.OrderStatus);

				return orders;
			}

			return orderRepository.GetAll();
		}
	}
}