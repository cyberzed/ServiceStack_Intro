using CandyStack.Installers;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

[assembly: WebActivator.PreApplicationStartMethod(typeof (CandyStack.App_Start.AppHost), "Start")]

namespace CandyStack.App_Start
{
	public class AppHost : AppHostBase
	{
		public AppHost() : base("CandyStack", typeof (AppHost).Assembly)
		{
		}

		public override void Configure(Funq.Container container)
		{
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			SetConfig(new EndpointHostConfig
				{
					EnableFeatures = Feature.All.Remove(Feature.Xml).Remove(Feature.Soap)
				});

			var installers = new IFunqInstaller[] {new OrmLiteInstaller(), new InfrastructureInstaller()};

			container.Install(installers);
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}