using ServiceStack.DataAnnotations;

namespace CandyStack.Models.Domain
{
	public class OrderItem
	{
		public OrderItem()
		{
		}

		public OrderItem(BagOfCandy bagOfCandy, ushort quantity)
		{
			BagOfCandy = bagOfCandy;

			BagId = bagOfCandy.Id;
			Quantity = quantity;

			UnitPrice = bagOfCandy.Price;

			Total = quantity*UnitPrice;
		}

		[AutoIncrement]
		public uint Id { get; set; }

		[References(typeof (Order))]
		public uint OrderId { get; set; }

		[References(typeof (BagOfCandy))]
		public uint BagId { get; set; }

		[Ignore]
		public BagOfCandy BagOfCandy { get; set; }

		public ushort Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		public decimal Total { get; set; }
	}
}