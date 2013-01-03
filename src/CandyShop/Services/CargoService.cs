using System;
using System.Linq;
using CandyStack.Domain;
using CandyStack.Domain.Order;
using ServiceStack.OrmLite;

namespace CandyStack.Services
{
	public class CargoService
	{
		private readonly IDbConnectionFactory dbConnectionFactory;

		private readonly Type[] dbTypes = new[]
			{
				typeof (Candy),
				typeof (BagOfCandy),
				typeof (CandyCustomization),
				typeof (Order),
				typeof (OrderItem),
			};

		public CargoService(IDbConnectionFactory dbConnectionFactory)
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