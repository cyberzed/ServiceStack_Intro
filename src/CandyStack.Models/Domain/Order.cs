using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace CandyStack.Models.Domain
{
	[Route("/orders", "POST,PUT,DELETE")]
	[Route("/orders/{Id}", "GET,PUT,DELETE")]
	public class Order
	{
		private readonly List<OrderItem> orderItems;
		private uint id;

		public Order()
		{
			OrderStatus = OrderStatus.Unpaid;
			orderItems = new List<OrderItem>();
		}

		[AutoIncrement]
		public uint Id
		{
			get { return id; }
			set
			{
				id = value;

				foreach (var orderItem in orderItems)
				{
					orderItem.OrderId = id;
				}
			}
		}

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
			if (OrderStatus != OrderStatus.Unpaid)
			{
				throw new InvalidOperationException("Unable to add lines to an order after it have been paid");
			}

			if (orderItem == null)
			{
				throw new ArgumentNullException("orderItem");
			}

			if (id > 0)
			{
				orderItem.OrderId = Id;
			}

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