namespace Clever.Core.Exceptions
{
	[Serializable]
	public class BusinessLogicBrokenException : Exception
	{
		public BusinessLogicBrokenException()
		{
		}

		public BusinessLogicBrokenException(string message) : base(message)
		{
		}

		public BusinessLogicBrokenException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}