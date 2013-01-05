using System.Collections.Generic;
using CandyStack.Model;
using ServiceStack.OrmLite;

namespace CandyStack.Data
{
	public class BagOfCandyRepository
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		public BagOfCandyRepository(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public BagOfCandy GetById(uint bagOfCandyId)
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				var bagOfCandy = dbConnection.GetById<BagOfCandy>(bagOfCandyId);

				if (bagOfCandy == null)
				{
					return null;
				}

				var details = dbConnection.Where<BagDetails>(new {BagId = bagOfCandy.Id});

				bagOfCandy.Details.AddRange(details);

				return bagOfCandy;
			}
		}

		public IEnumerable<BagOfCandy> GetAll()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				var bagsOfCandy = dbConnection.Select<BagOfCandy>();

				return bagsOfCandy;
			}
		}

		public void Store(BagOfCandy bagOfCandy)
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				using (var transaction = dbConnection.BeginTransaction())
				{
					dbConnection.Save(bagOfCandy);
					dbConnection.SaveAll(bagOfCandy.Details);

					transaction.Commit();
				}
			}
		}
	}
}