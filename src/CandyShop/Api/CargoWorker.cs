using CandyStack.DTO;
using CandyStack.Services;
using ServiceStack.ServiceInterface;

namespace CandyStack.Api
{
	public class CargoWorker : Service
	{
		private readonly CargoService cargoService;

		public CargoWorker(CargoService cargoService)
		{
			this.cargoService = cargoService;
		}

		public object Get(Payload payload)
		{
			return cargoService.IsFoundationBuilt();
		}

		public object Post(Payload payload)
		{
			return cargoService.Build();
		}

		public object Delete(Payload payload)
		{
			return cargoService.Clean();
		}
	}
}