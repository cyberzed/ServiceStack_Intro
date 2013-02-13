using CandyStack.Models.DTO;
using CandyStack.Server.Services;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace CandyStack.Server.Api
{
	[Restrict(LocalhostOnly = true)]
	public class CargoService : Service
	{
		private readonly DbManagementService dbManagementService;

		public CargoService(DbManagementService dbManagementService)
		{
			this.dbManagementService = dbManagementService;
		}

		public object Get(Payload payload)
		{
			return dbManagementService.IsFoundationBuilt();
		}

		public object Post(Payload payload)
		{
			return dbManagementService.Build();
		}

		public object Delete(Payload payload)
		{
			return dbManagementService.Clean();
		}
	}
}