using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CandyStack.Domain;
using ServiceStack.DataAnnotations;

namespace CandyStack.Model
{
	public class Order
	{
		private readonly List<OrderItem> orderItems;

		public Order()
		{
			OrderStatus = OrderStatus.Unpaid;
			orderItems = new List<OrderItem>();
		}

		[AutoIncrement]
		public uint Id { get; set; }

		public DateTime Date { get; set; }
		public OrderStatus OrderStatus { get; set; }

		[StringLength(255)]
		public string CancellationReason { get; set; }

		public decimal Total
		{
			get { return orderItems.Sum(oi => oi.Total); }
		}

		[Ignore]
		public ReadOnlyCollection<OrderItem> OrderItems
		{
			get { return orderItems.AsReadOnly(); }
		}

		public void Add(OrderItem orderItem)
		{
			if (orderItem == null)
			{
				throw new ArgumentNullException("orderItem");
			}

			orderItem.OrderId = Id;

			orderItems.Add(orderItem);
		}

		public void Remove(OrderItem orderItem)
		{
			if (orderItem == null)
			{
				throw new ArgumentNullException("orderItem");
			}

			orderItems.Remove(orderItem);
		}

		public void Pay()
		{
			OrderStatus = OrderStatus.Paid;
		}

		public void Cancel(string reason)
		{
			if (string.IsNullOrWhiteSpace(reason))
			{
				throw new ArgumentException("Reason can not be null or empty", "reason");
			}

			OrderStatus = OrderStatus.Cancelled;
			CancellationReason = reason;
		}

		public void Pack()
		{
			OrderStatus = OrderStatus.Packing;
		}

		public void CompletePacking()
		{
			OrderStatus = OrderStatus.Ready;
		}

		public void Pickup()
		{
			OrderStatus = OrderStatus.Delivered;
		}
	}
}