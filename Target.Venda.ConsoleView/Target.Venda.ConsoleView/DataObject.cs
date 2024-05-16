using System.Runtime.Remoting.Messaging;

namespace Target.Venda.ConsoleView;

public class DataObject : ILogicalThreadAffinative
{
	public string Message { get; set; }

	public string Status { get; set; }
}
