namespace CandyStack.Domain
{
	public enum OrderStatus
	{
		None = 0,
		Unpaid,
		Paid,
		Packing,
		Ready,
		Delivered,
		Cancelled
	}
}