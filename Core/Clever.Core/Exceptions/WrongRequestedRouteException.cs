namespace Clever.Core.Exceptions
{
	[Serializable]
	public class WrongRequestedRouteException : Exception
	{
		public WrongRequestedRouteException()
		{
		}

		public WrongRequestedRouteException(string message) : base(message)
		{
		}

		public WrongRequestedRouteException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}