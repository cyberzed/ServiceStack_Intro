using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyStack.Domain.Order
{
	public class Order
	{
		private readonly ISet<OrderItem> items;

		public Order()
		{
			items = new HashSet<OrderItem>();
			OrderStatus = OrderStatus.Created;
		}

		public uint OrderId { get; private set; }

		public IEnumerable<OrderItem> Items
		{
			get { return items; }
		}

		public DateTimeOffset Date { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public string CancelReason { get; private set; }

		public decimal TotalPrice
		{
			get { return Items.Sum(item => item.Quantity*item.UnitPrice); }
		}
	}
}