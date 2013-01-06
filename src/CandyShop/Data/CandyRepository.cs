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

		public Candy GetById(uint candyId)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				var candy = dbConnection.GetById<Candy>(candyId);

				return candy;
			}
		}

		public IEnumerable<Candy> GetAll()
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				var candies = dbConnection.Select<Candy>();

				return candies;
			}
		}

		public void Store(Candy candy)
		{
			using (var dbConnection = dbConnectionFactory.Open())
			{
				dbConnection.Save(candy);
			}
		}
	}
}