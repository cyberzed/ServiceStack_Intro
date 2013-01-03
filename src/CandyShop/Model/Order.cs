using System;
using System.ComponentModel.DataAnnotations;
using CandyStack.Domain;
using ServiceStack.DataAnnotations;

namespace CandyStack.Model
{
	public class Order
	{
		public Order()
		{
			OrderStatus = OrderStatus.Created;
		}

		[AutoIncrement]
		public uint Id { get; set; }

		public DateTime Date { get; set; }
		public OrderStatus OrderStatus { get; set; }

		[StringLength(255)]
		public string CancellationReason { get; set; }

		public decimal Total { get; set; }
	}
}