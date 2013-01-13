using System.Collections.Generic;

namespace CandyStack.Server.Installers
{
	public static class FunqExtensions
	{
		public static void Install(this Funq.Container container, IEnumerable<IFunqInstaller> installers)
		{
			foreach (var installer in installers)
			{
				installer.Install(container);
			}
		}
	}
}