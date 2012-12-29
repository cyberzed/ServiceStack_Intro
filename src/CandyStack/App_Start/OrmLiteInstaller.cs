using System.Configuration;
using Funq;
using ServiceStack.OrmLite;

namespace CandyStack.App_Start
{
	public class OrmLiteInstaller
	{
		public static void Install(Container container)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

			container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(connectionString));
		}
	}
}