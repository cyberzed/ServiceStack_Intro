using ServiceStack.DataAnnotations;

namespace CandyStack.Model
{
	public class Candy
	{
		[AutoIncrement]
		public ushort Id { get; set; }

		[Index(Unique = true)]
		public string Name { get; set; }
	}
}