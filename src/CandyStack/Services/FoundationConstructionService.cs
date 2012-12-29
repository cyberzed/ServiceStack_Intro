using System;
using CandyStack.Domain;
using CandyStack.Domain.Order;
using ServiceStack.OrmLite;

namespace CandyStack.Services
{
	public class FoundationConstructionService
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		private readonly Type[] dbTypes = new[] {typeof (Order), typeof (Candy), typeof (StandardBag), typeof (CustomBag)};

		public FoundationConstructionService(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public void Clean()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				dbConnection.DropTables(dbTypes);
			}
		}

		public void Build()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				dbConnection.CreateTableIfNotExists(dbTypes);
			}
		}
	}
}