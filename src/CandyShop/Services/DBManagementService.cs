using System;
using System.Linq;
using CandyStack.Domain;
using ServiceStack.OrmLite;

namespace CandyStack.Services
{
	public class DBManagementService
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		private readonly Type[] dbTypes = new[]
			{
				typeof (Candy),
				typeof (BagOfCandy),
				typeof (Order),
				typeof (OrderItem),
			};

		public DBManagementService(IDbConnectionFactory dbConnectionFactory)
		{
			this.dbConnectionFactory = dbConnectionFactory;
		}

		public bool Clean()
		{
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				dbConnection.DropTables(dbTypes);
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
			using (var dbConnection = dbConnectionFactory.OpenDbConnection())
			{
				if (dbTypes.Any(dbType => !dbConnection.TableExists(dbType.Name)))
				{
					return false;
				}
			}

			return true;
		}
	}
}