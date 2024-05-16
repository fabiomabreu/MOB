using System.Runtime.Remoting.Messaging;

namespace Target.Venda.Helpers.Geral;

public static class SessionHelper
{
	public static object GetData(string key)
	{
		return CallContext.LogicalGetData(key);
	}

	public static void SetData(string key, object value)
	{
		CallContext.LogicalSetData(key, value);
	}

	public static void Destroy(string key)
	{
		CallContext.FreeNamedDataSlot(key);
	}

	public static bool Initialized(string key)
	{
		return CallContext.LogicalGetData(key) != null;
	}
}
