using ServiceStack.DataAnnotations;

namespace CandyStack.Model
{
	public class BagDetails
	{
		[AutoIncrement]
		public uint Id { get; set; }

		[References(typeof (Candy))]
		public ushort CandyId { get; set; }

		[Ignore]
		public Candy Candy { get; set; }

		[References(typeof (BagOfCandy))]
		public uint BagId { get; set; }

		public float Weight { get; set; }
	}
}