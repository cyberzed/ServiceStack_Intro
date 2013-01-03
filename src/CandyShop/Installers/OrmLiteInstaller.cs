using System.Configuration;
using Funq;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace CandyStack.Installers
{
	public class OrmLiteInstaller : IFunqInstaller
	{
		public void Install(Container container)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

			var ormLiteConnectionFactory = new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance)
				{
					ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
				};

			container.Register<IDbConnectionFactory>(c => ormLiteConnectionFactory);
		}
	}
}