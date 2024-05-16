using System.Threading;

namespace Target.Venda.Helpers.Geral;

public class ThreadHelper
{
	public static int GetThreadID()
	{
		return Thread.CurrentThread.ManagedThreadId;
	}
}
