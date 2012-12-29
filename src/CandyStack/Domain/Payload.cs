using ServiceStack.ServiceHost;

namespace CandyStack.Domain
{
	[Route("/constructionworkers")]
	public class Payload
	{
		public bool HasFoundation { get; set; }
	}
}