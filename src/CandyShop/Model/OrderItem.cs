using ServiceStack.DataAnnotations;

namespace CandyStack.Model
{
	public class OrderItem
	{
		[AutoIncrement]
		public uint Id { get; set; }

		[References(typeof (Order))]
		public uint OrderId { get; set; }

		[References(typeof (BagOfCandy))]
		public uint BagId { get; set; }

		public ushort Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}