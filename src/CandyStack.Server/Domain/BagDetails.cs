using System;
using ServiceStack.DataAnnotations;

namespace CandyStack.Server.Domain
{
	public class BagDetails
	{
		[AutoIncrement]
		public uint Id { get; set; }

		[References(typeof (Candy))]
		public ushort CandyId { get; set; }

		[Ignore]
		public Candy Candy { get; set; }

		[References(typeof (BagOfCandy))]
		public uint BagId { get; set; }

		public float Weight { get; set; }

		public decimal Price
		{
			get { return Candy.Price*Convert.ToDecimal(Weight); }
		}
	}
}