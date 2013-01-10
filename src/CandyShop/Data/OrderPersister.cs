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

		public void Store(Order order)
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
	}
}