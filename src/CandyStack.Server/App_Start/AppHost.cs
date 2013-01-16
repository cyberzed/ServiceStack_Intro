using CandyStack.Server.App_Start;
using CandyStack.Server.Installers;
using ServiceStack.Logging.NLogger;
using ServiceStack.WebHost.Endpoints;

[assembly: WebActivator.PreApplicationStartMethod(typeof (AppHost), "Start")]

namespace CandyStack.Server.App_Start
{
	public class AppHost : AppHostBase
	{
		public AppHost() : base("CandyStack", typeof (AppHost).Assembly)
		{
			Config.LogFactory = new NLogFactory();
		}

		public override void Configure(Funq.Container container)
		{
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			SetConfig(new EndpointHostConfig
				{
					//EnableFeatures = Feature.All.Remove(Feature.Xml).Remove(Feature.Soap)
				});

			//RequestFilters.Add((req, res, obj) => { Debug.WriteLine(req.AbsoluteUri); });

			//CandyFormat.Register(this);

			var installers = new IFunqInstaller[] {new OrmLiteInstaller(), new InfrastructureInstaller()};

			container.Install(installers);
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}