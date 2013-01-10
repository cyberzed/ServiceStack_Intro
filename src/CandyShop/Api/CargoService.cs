using CandyStack.DTO;
using CandyStack.Services;
using ServiceStack.ServiceInterface;

namespace CandyStack.Api
{
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