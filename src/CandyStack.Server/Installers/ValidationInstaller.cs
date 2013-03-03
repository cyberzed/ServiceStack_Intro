using CandyStack.Server.Validators;
using Funq;
using ServiceStack.ServiceInterface.Validation;

namespace CandyStack.Server.Installers
{
	public class ValidationInstaller : IFunqInstaller
	{
		public void Install(Container container)
		{
			container.RegisterValidators(typeof (CandyValidator).Assembly);
		}
	}
}