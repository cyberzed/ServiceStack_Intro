using System.Collections.Generic;
using CandyStack.Models.Domain;
using ServiceStack.ServiceHost;

namespace CandyStack.Models.DTO
{
	[Route("/orders", "GET")]
	[Route("/orders/status/{OrderStatus}", "GET")]
	public class OrdersRequest : IReturn<List<Order>>
	{
		public List<uint> Ids { get; set; }
		public OrderStatus OrderStatus { get; set; }
	}
}