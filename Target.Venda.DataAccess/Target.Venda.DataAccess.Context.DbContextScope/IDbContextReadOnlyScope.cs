using System;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public interface IDbContextReadOnlyScope : IDisposable
{
	IDbContextCollection DbContexts { get; }
}
