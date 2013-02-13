using System.Diagnostics;
using CandyStack.Server.App_Start;
using CandyStack.Server.Installers;
using ServiceStack.Common;
using ServiceStack.Logging.NLogger;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
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
					EnableFeatures = Feature.All.Remove(Feature.Csv).Remove(Feature.Soap)
				});

			RequestFilters.Add((req, res, obj) => Debug.WriteLine(req.AbsoluteUri));

			CandyFormat.Register(this);

			var installers = new IFunqInstaller[]
				{
					new OrmLiteInstaller(),
					new CacheInstaller(),
					new AuthInstaller(),
					new InfrastructureInstaller()
				};

			container.Install(installers);

			Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] {new BasicAuthProvider()}));
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}