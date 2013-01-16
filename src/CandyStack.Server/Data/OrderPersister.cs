using System;
using System.Data;
using CandyStack.Models.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Server.Data
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
				dbConnection.Save(order);

				foreach (var orderItem in order.OrderItems)
				{
					if (orderItem.Id == default(uint))
					{
						dbConnection.Save(orderItem);
					}
					else
					{
						InsertOrderItem(dbConnection, orderItem);
					}
				}
			}
		}

		public void Create(Order order)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				dbConnection.InsertOnly(order, ev => ev.Insert(o => new {o.Date, o.OrderStatus, o.CancellationReason, o.Total}));

				var orderId = dbConnection.GetLastInsertId();
				order.Id = Convert.ToUInt32(orderId);

				foreach (var orderItem in order.OrderItems)
				{
					InsertOrderItem(dbConnection, orderItem);
				}
			}
		}

		private static void InsertOrderItem(IDbConnection dbConnection, OrderItem orderItem)
		{
			dbConnection.InsertOnly(orderItem, ev => ev.Insert(oi => new {oi.OrderId, oi.BagId, oi.Quantity, oi.UnitPrice}));

			var orderItemId = dbConnection.GetLastInsertId();
			orderItem.Id = Convert.ToUInt32(orderItemId);
		}
	}
}