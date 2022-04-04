namespace Clever.Core.Results
{
	public class BackEndOperationResult
	{
		public BackEndOperationResult()
		{
		}

		public BackEndOperationResult(IEnumerable<object> operationResultData) :
			this(operationResultData, new List<OperationMessage>())
		{
		}

		public BackEndOperationResult(object operationResultData) :
			this(new List<object> { operationResultData }, new List<OperationMessage>())
		{
		}

		public BackEndOperationResult(string message)
			: this(new List<object>(), new List<OperationMessage> { new OperationMessage(message) })
		{
		}

		public BackEndOperationResult(OperationMessage operationMessage)
			: this(new List<object>(), new List<OperationMessage> { operationMessage })
		{
		}

		public BackEndOperationResult(List<OperationMessage> messages)
			: this(new List<object>(), messages)
		{
		}

		public BackEndOperationResult(IEnumerable<object> operationResultData, List<OperationMessage> messages)
		{
			OperationResultData = operationResultData;
			Messages = messages;
		}

		public BackEndOperationResult(Exception exception)
		{
			Messages = new List<OperationMessage> { new OperationMessage(exception.Message, exception) };
			OperationResultData = null;
		}

		public IEnumerable<object> OperationResultData { get; set; } = new List<object>();

		public IEnumerable<OperationMessage> Messages { get; set; } = new List<OperationMessage>();

		public bool OperationResultSuccess { get; set; } = false;
	}
}