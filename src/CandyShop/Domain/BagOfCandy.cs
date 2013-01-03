using ServiceStack.DataAnnotations;

namespace CandyStack.Domain
{
	public class BagOfCandy
	{
		[AutoIncrement]
		public uint Id { get; private set; }

		public string Name { get; set; }
	}
}