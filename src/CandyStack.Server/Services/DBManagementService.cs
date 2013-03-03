using System;
using System.Linq;
using CandyStack.Models.Domain;
using ServiceStack.MiniProfiler;
using ServiceStack.OrmLite;

namespace CandyStack.Server.Services
{
	public class DbManagementService
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		private readonly Type[] dbTypes;

		public DbManagementService(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;

			dbTypes = new[]
				{
					typeof (Candy),
					typeof (BagOfCandy),
					typeof (BagDetails),
					typeof (Order),
					typeof (OrderItem),
				};
		}

		public bool Clean()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				dbConnection.DropTables(dbTypes.Reverse().ToArray());
			}

			return true;
		}

		public bool Build()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				dbConnection.CreateTableIfNotExists(dbTypes);
			}

			return true;
		}

		public bool IsFoundationBuilt()
		{
			var currentProfiler = Profiler.Current;

			using (currentProfiler.Step("Checking if all tables are created"))
			{
				using (var dbConnection = dbConnectionFactory.OpenDbConnection())
				{
					if (dbTypes.Any(dbType => !dbConnection.TableExists(dbType.Name)))
						return false;
				}
			}

			return true;
		}
	}
}