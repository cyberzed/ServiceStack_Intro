using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace CandyStack.Domain
{
	public class BagOfCandy
	{
		private readonly List<BagDetails> details;

		public BagOfCandy()
		{
			details = new List<BagDetails>();
		}

		[AutoIncrement]
		public uint Id { get; set; }

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