using System;
using System.Data.Entity;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public interface IDbContextCollection : IDisposable
{
	TDbContext Get<TDbContext>() where TDbContext : DbContext;
}
