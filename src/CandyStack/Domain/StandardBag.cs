using System.Collections.Generic;

namespace CandyStack.Domain
{
	public class StandardBag : IBagOfCandy
	{
		public string Name { get; set; }
		public IEnumerable<Candy> Candies { get; set; }

		public decimal Price
		{
			get { return 0; }
		}

		public float Weight
		{
			get { return 0; }
		}
	}
}