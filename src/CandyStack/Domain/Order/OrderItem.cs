namespace CandyStack.Domain.Order
{
	public class OrderItem
	{
		public IBagOfCandy BagOfCandy { get; set; }
		public ushort Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}