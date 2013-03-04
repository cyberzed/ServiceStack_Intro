using ServiceStack.ServiceHost;

namespace CandyStack.Models.DTO
{
	[Route("/candysign", "GET")]
	[Route("/candysign/{Id}", "GET")]
	[Route("/candysign/{Id}/{Width}/{Height}", "GET")]
	public class CandySignRequest
	{
		public uint Id { get; set; }

		public int? Width { get; set; }
		public int? Height { get; set; }
	}
}