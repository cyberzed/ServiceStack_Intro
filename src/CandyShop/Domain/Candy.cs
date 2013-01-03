using System;
using ServiceStack.DataAnnotations;

namespace CandyStack.Domain
{
	public class Candy
	{
		public Candy()
		{
		}

		public Candy(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			Name = name;
		}

		[AutoIncrement]
		public ushort Id { get; private set; }

		[Index(Unique = true)]
		public string Name { get; private set; }
	}
}