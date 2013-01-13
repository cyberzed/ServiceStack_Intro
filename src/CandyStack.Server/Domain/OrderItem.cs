using ServiceStack.DataAnnotations;

namespace CandyStack.Server.Domain
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
		public decimal UnitPrice { get; private set; }

		[Ignore]
		public decimal Total
		{
			get { return Quantity*UnitPrice; }
		}
	}
}