using CandyStack.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Data
{
	public class CandyRepository
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		public CandyRepository(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public void Store(Candy candy)
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				dbConnection.Save(candy);
			}
		}
	}
}