using Clever.Example.Models.Enums;

namespace Clever.Example.Models.ValueObjects
{
	public static class Genres
	{
		private static Dictionary<BookGenre, string> _genres;

		static Genres()
		{
			if (_genres != null)
				return;

			_genres = new Dictionary<BookGenre, string>
			{
				{ BookGenre.UnSpecified, string.Empty },
				{ BookGenre.Biography, "Biography" },
				{ BookGenre.SciFi, "SciFi" },
				{ BookGenre.Fantasy, "Fantasy" }
			};
		}

		public static string GetGenre(BookGenre genre)
		{
			return _genres[genre].ToString();
		}
	}
}