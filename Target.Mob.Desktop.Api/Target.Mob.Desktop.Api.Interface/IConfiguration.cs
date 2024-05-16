namespace Target.Mob.Desktop.Api.Interface;

public interface IConfiguration
{
	string GetSecretKey();

	string GetConnectionString();

	string GetIssuer();

	string GetAudience();

	double GetExpiresMinutes();
}
