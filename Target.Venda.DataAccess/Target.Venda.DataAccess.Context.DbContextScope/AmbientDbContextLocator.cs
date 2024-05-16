using System.Data.Entity;

namespace Target.Venda.DataAccess.Context.DbContextScope;

public class AmbientDbContextLocator : IAmbientDbContextLocator
{
	public TDbContext Get<TDbContext>() where TDbContext : DbContext
	{
		DbContextScope ambientScope = DbContextScope.GetAmbientScope();
		return (ambientScope == null) ? null : ambientScope.DbContexts.Get<TDbContext>();
	}
}
