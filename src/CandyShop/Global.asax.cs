using System;
using ServiceStack.MiniProfiler;

namespace CandyStack
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
		}

		protected void Session_Start(object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (Request.IsLocal)
			{
				Profiler.Start();
			}
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
			Profiler.Stop();
		}

		protected void Application_Error(object sender, EventArgs e)
		{
		}

		protected void Session_End(object sender, EventArgs e)
		{
		}

		protected void Application_End(object sender, EventArgs e)
		{
		}
	}
}