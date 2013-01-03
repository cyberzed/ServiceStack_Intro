using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace CandyStack.Domain.Order
{
	public class Order
	{
		public Order()
		{
			OrderStatus = OrderStatus.Created;
		}

		[AutoIncrement]
		public uint Id { get; private set; }

		public DateTime Date { get; set; }
		public OrderStatus OrderStatus { get; set; }

		[StringLength(255)]
		public string CancellationReason { get; private set; }

		public decimal Total { get; set; }
	}
}