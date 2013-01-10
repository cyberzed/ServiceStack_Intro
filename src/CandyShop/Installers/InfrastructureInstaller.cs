using CandyStack.Data;
using CandyStack.Services;
using Funq;

namespace CandyStack.Installers
{
	public class InfrastructureInstaller:IFunqInstaller
	{
		public void Install(Container container)
		{
			container.RegisterAutoWired<DbManagementService>();
			container.RegisterAutoWired<OrderPersister>();
		}
	}
}