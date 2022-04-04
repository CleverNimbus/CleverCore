using Clever.Core.Exceptions;
using Clever.Core.Persistence.DB;

namespace Clever.Example.Models.Entities
{
	public record Author : AggregateRoot
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Author()
		{

		}

		public Author (string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			CheckForBrokenLogic();
		}

		private void CheckForBrokenLogic()
		{
			if (string.IsNullOrWhiteSpace(FirstName))
				throw new BusinessLogicBrokenException("First author name is mandatory!");

			if (string.IsNullOrWhiteSpace(LastName))
				throw new BusinessLogicBrokenException("Last author name is mandatory!");
		}
	}
}