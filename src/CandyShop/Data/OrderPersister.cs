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
					dbConnection.SaveAll(order.OrderItems);

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

					var id = dbConnection.GetLastInsertId();
					order.Id = Convert.ToUInt32(id);

					dbConnection.InsertAll(order.OrderItems);

					transaction.Commit();
				}
			}
		}
	}
}