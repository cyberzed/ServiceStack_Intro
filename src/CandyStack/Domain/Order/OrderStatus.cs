namespace CandyStack.Domain.Order
{
	public enum OrderStatus
	{
		Created,
		Unpaid,
		Paid,
		Packing,
		Ready,
		Cancelled,
		Delivered
	}
}