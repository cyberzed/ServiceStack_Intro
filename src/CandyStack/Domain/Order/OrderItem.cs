using ServiceStack.DataAnnotations;

namespace CandyStack.Domain.Order
{
	public class OrderItem
	{
		[References(typeof (Order))]
		public uint OrderId { get; set; }

		public IBagOfCandy BagOfCandy { get; set; }
		public ushort Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}