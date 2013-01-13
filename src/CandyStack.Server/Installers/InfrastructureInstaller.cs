using CandyStack.Server.Data;
using CandyStack.Server.Services;
using Funq;

namespace CandyStack.Server.Installers
{
	public class InfrastructureInstaller : IFunqInstaller
	{
		public void Install(Container container)
		{
			container.RegisterAutoWired<DbManagementService>();
			container.RegisterAutoWired<OrderPersister>();
			container.RegisterAutoWired<BagOfCandyPersister>();
		}
	}
}