using System;
using System.Collections;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public interface IDbContextScope : IDisposable
{
	IDbContextCollection DbContexts { get; }

	int SaveChanges();

	void RefreshEntitiesInParentScope(IEnumerable entities);
}
