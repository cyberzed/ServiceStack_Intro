using System;
using CandyStack.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Data
{
	public class BagOfCandyPersister
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		public BagOfCandyPersister(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public void Create(BagOfCandy bagOfCandy)
		{
			using (var dbConnnection = dbConnectionFactory.Open())
			{
				using (var transaction = dbConnnection.BeginTransaction())
				{
					dbConnnection.Insert(bagOfCandy);

					var bagId = dbConnnection.GetLastInsertId();
					bagOfCandy.Id = Convert.ToUInt32(bagId);

					foreach (var detail in bagOfCandy.Details)
					{
						dbConnnection.Insert(detail);

						var detailId = dbConnnection.GetLastInsertId();
						detail.Id = Convert.ToUInt32(detailId);
					}

					transaction.Commit();
				}
			}
		}
	}
}