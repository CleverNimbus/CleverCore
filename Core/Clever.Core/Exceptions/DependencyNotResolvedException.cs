namespace Clever.Core.Exceptions
{
	[Serializable]
	public class DependencyNotResolvedException : Exception
	{
		public DependencyNotResolvedException()
		{
		}

		public DependencyNotResolvedException(string message) : base(message)
		{
		}

		public DependencyNotResolvedException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}