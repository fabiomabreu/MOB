using System.Data.Entity;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public interface IDbContextFactory
{
	TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext;
}
