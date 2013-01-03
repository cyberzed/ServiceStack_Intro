using System.Collections.Generic;

namespace CandyStack.Domain
{
	public class CustomBag : IBagOfCandy
	{
		public List<CandyCustomization> Candies { get; set; }

		public decimal Price { get; private set; }
		public float Weight { get; private set; }
	}
}