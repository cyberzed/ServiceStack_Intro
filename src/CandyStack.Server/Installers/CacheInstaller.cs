using Funq;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Redis;

namespace CandyStack.Server.Installers
{
	public class CacheInstaller : IFunqInstaller
	{
		public void Install(Container container)
		{
			container.Register<ICacheClient>(new MemoryCacheClient());

			//container.Register<IRedisClientsManager>(c => new PooledRedisClientManager("localhost:6379"));

			//container.Register(c => c.Resolve<IRedisClientsManager>().GetCacheClient());
		}
	}
}