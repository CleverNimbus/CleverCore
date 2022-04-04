namespace Clever.Core.Exceptions
{
	[Serializable]
	public class WrongNumberOfParametersException : Exception
	{
		public WrongNumberOfParametersException()
		{
		}

		public WrongNumberOfParametersException(string message) : base(message)
		{
		}

		public WrongNumberOfParametersException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}