using System;
using CandyStack.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Data
{
	public class OrderPersister
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		public OrderPersister(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public void Update(Order order)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				using (var transaction = dbConnection.BeginTransaction())
				{
					dbConnection.Save(order);

					foreach (var orderItem in order.OrderItems)
					{
						if (orderItem.Id == default(uint))
						{
							dbConnection.Save(orderItem);
						}
						else
						{
							dbConnection.Insert(orderItem);

							var orderItemId = dbConnection.GetLastInsertId();
							orderItem.Id = Convert.ToUInt32(orderItemId);
						}
					}

					transaction.Commit();
				}
			}
		}

		public void Create(Order order)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				using (var transaction = dbConnection.BeginTransaction())
				{
					dbConnection.Insert(order);

					var orderId = dbConnection.GetLastInsertId();
					order.Id = Convert.ToUInt32(orderId);

					foreach (var orderItem in order.OrderItems)
					{
						dbConnection.Insert(orderItem);

						var orderItemId = dbConnection.GetLastInsertId();
						orderItem.Id = Convert.ToUInt32(orderItemId);
					}

					transaction.Commit();
				}
			}
		}
	}
}