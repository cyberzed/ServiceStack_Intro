using ServiceStack.DataAnnotations;

namespace CandyStack.Domain
{
	public class CandyCustomization
	{
		[AutoIncrement]
		public uint Id { get; set; }

		[References(typeof (Candy))]
		public ushort CandyId { get; set; }

		[References(typeof (BagOfCandy))]
		public uint BagId { get; set; }

		public float Weight { get; set; }
	}
}