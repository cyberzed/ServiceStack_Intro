using System;

namespace CandyStack.Domain
{
	public class Candy
	{
		public Candy(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			Name = name;
		}

		public string Name { get; private set; }
	}
}