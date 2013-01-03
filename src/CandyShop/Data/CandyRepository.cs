using System.Collections.Generic;
using CandyStack.Model;
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

		public IEnumerable<Candy> GetAll()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				return dbConnection.Select<Candy>();
			}
		}

		public Candy GetById(uint candyId)
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				return dbConnection.GetById<Candy>(candyId);
			}
		}
	}
}