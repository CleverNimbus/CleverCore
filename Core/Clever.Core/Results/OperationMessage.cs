namespace Clever.Core.Results
{
	public class OperationMessage
	{
		public OperationMessage(string message)
		{
			Message = message;
		}

		public OperationMessage(Exception innerException) : this(innerException.Message)
		{
			InnerException = innerException;
		}

		public OperationMessage(string message, Exception innerException) : this(message)
		{
			InnerException = innerException;
		}

		public string Message { get; set; }
		public Exception? InnerException { get; set; }
	}
}