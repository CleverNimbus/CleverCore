using Clever.Core.Service.Factories;

namespace Clever.Core.Service.Infraestructure
{
	public class CallEntry
	{
		public EntryPointItem EntryPointItem { get; set; }
		public object[] Parameters { get; private set; }

		public CallEntry(EntryPointItem entryPointItem, object[] parameters)
		{
			EntryPointItem = entryPointItem;

			Parameters = parameters;
		}
	}
}