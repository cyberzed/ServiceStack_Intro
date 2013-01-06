using ServiceStack.DataAnnotations;

namespace CandyStack.Domain
{
	public class Candy
	{
		[AutoIncrement]
		public ushort Id { get; set; }

		[Index(Unique = true)]
		public string Name { get; set; }

		public decimal Price { get; set; }
	}
}