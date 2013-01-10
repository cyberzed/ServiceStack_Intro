using System.Linq;
using System.Net;
using CandyStack.DTO;
using CandyStack.Data;
using CandyStack.Domain;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace CandyStack.Api
{
	public class OrderService : Service
	{
		private readonly OrderPersister orderPersister;

		public OrderService(OrderPersister orderPersister)
		{
			this.orderPersister = orderPersister;
		}

		public object Get(Order request)
		{
			if (request.Id != default(uint))
			{
				var order = Db.GetById<Order>(request.Id);

				return order;
			}

			return new HttpResult(HttpStatusCode.BadRequest);
		}

		public object Get(OrdersRequest request)
		{
			if (request.Ids != null && request.Ids.Any())
			{
				var orders = Db.GetByIds<Order>(request.Ids);

				return orders;
			}

			if (request.OrderStatus != OrderStatus.None)
			{
				var orders = Db.Where<Order>(new {request.OrderStatus});

				return orders;
			}

			return Db.Select<Order>();
		}

		public object Post(Order request)
		{
			if (request.Id != default(uint))
			{
				return new HttpResult(HttpStatusCode.Conflict);
			}

			orderPersister.Store(request);

			return request;
		}

		public object Put(Order request)
		{
			if (request.Id == default(uint))
			{
				return new HttpResult(HttpStatusCode.BadRequest);
			}

			orderPersister.Store(request);

			return request;
		}

		public object Delete(Order request)
		{
			if (request.Id == default(uint))
			{
				return new HttpResult(HttpStatusCode.BadRequest);
			}

			Db.DeleteById<Order>(request.Id);

			return new HttpResult(HttpStatusCode.OK);
		}
	}
}