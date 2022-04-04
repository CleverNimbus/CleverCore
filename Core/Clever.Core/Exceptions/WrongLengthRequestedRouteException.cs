namespace Clever.Core.Exceptions
{
	[Serializable]
	public class WrongLengthRequestedRouteException : Exception
	{
		public WrongLengthRequestedRouteException()
		{
		}

		public WrongLengthRequestedRouteException(string message) : base(message)
		{
		}

		public WrongLengthRequestedRouteException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}