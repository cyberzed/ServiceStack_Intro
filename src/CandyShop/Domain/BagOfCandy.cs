using System;
using System.Collections.Generic;
using System.Linq;
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

		[Ignore]
		public decimal Price
		{
			get { return details.Sum(d => d.Candy.Price*Convert.ToDecimal(d.Weight)); }
		}

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

			var customization = new BagDetails {BagId = Id, CandyId = candy.Id, Weight = weight};

			Details.Add(customization);
		}
	}
}