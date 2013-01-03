using CandyStack.Services;
using Funq;

namespace CandyStack.Installers
{
	public class InfrastructureInstaller:IFunqInstaller
	{
		public void Install(Container container)
		{
			container.RegisterAutoWired<CargoService>();
		}
	}
}