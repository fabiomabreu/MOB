using System.Data.Entity;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public interface IAmbientDbContextLocator
{
	TDbContext Get<TDbContext>() where TDbContext : DbContext;
}
