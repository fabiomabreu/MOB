using System;
using Target.Venda.Helpers.Log;

namespace Target.Venda.DataAccess.Context;

public static class ContextFactory
{
	public static ERPContext CreateContext()
	{
		try
		{
			return ObterAppContext();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	private static ERPContext ObterAppContext()
	{
		return new ERPContext();
	}
}
