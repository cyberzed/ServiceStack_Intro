using ServiceStack.DataAnnotations;

namespace CandyStack.Model
{
	public class BagOfCandy
	{
		[AutoIncrement]
		public uint Id { get; set; }

		public string Name { get; set; }
	}
}