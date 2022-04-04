using Clever.Core.Exceptions;
using Clever.Core.Persistence.DB;
using Clever.Example.Models.Enums;

namespace Clever.Example.Models.Entities
{
	public record Book : AggregateRoot
	{
		public string Title { get; set; } = string.Empty;
		public DateTime PublishDate { get; set; }
		public int NumberOfPages { get; set; }
		public Author Author { get; set; }
		public BookGenre Genre { get; set; }

		public Book()
		{

		}

		public Book(string title, BookGenre genre = BookGenre.UnSpecified)
		{
			Title = title;
			Genre = genre;
			CheckForBrokenLogic();
		}

		private void CheckForBrokenLogic()
		{
			if (string.IsNullOrWhiteSpace(Title))
				throw new BusinessLogicBrokenException("Book title is mandatory!");
		}
	}
}