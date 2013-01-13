using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;

namespace CandyStack.Server.Domain
{
	[Route("/bagofcandy", "GET,POST")]
	[Route("/bagofcandy/{Id}", "GET")]
	public class BagOfCandy
	{
		private readonly List<BagDetails> details;
		private uint id;

		public BagOfCandy()
		{
			details = new List<BagDetails>();
		}

		[AutoIncrement]
		public uint Id
		{
			get { return id; }
			set
			{
				id = value;

				foreach (var detail in details)
				{
					detail.BagId = id;
				}
			}
		}

		public string Name { get; set; }

		public decimal Price { get; set; }

		[Ignore]
		public List<BagDetails> Details
		{
			get { return details; }
		}

		public void Add(Candy candy, float weight)
		{
			if (candy == null)
			{
				throw new ArgumentNullException("candy");
			}

			if (weight <= 0)
			{
				throw new ArgumentOutOfRangeException("weight");
			}

			var bagDetails = new BagDetails {BagId = Id, CandyId = candy.Id, Weight = weight};

			Price += bagDetails.Price;

			Details.Add(bagDetails);
		}
	}
}