namespace Target.Venda.DataAccess.Context.DbContextScope;

public static class AmbientLocatorSingleton
{
	private static IAmbientDbContextLocator instance;

	public static IAmbientDbContextLocator AmbientDbContext()
	{
		if (instance == null)
		{
			instance = new AmbientDbContextLocator();
		}
		return instance;
	}
}
