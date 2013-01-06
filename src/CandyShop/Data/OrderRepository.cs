using System.Collections.Generic;
using CandyStack.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Data
{
	public class OrderRepository
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		public OrderRepository(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public Order GetById(uint orderId)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				var order = dbConnection.GetById<Order>(orderId);

				return order;
			}
		}

		public IEnumerable<Order> GetAll()
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				var orders = dbConnection.Select<Order>();

				return orders;
			}
		}

		public void Store(Order order)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				dbConnection.Save(order);
				dbConnection.SaveAll(order.OrderItems);
			}
		}
	}
}