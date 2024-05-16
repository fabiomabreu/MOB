using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class VersaoCargaBLL
{
	public static VersaoCargaTO Select(SqlConnection conexao, int id)
	{
		return VersaoCargaDAL.Select(conexao, id);
	}

	public static VersaoCargaTO SelectMax(SqlConnection conexao, int? major, int? minor)
	{
		return VersaoCargaDAL.SelectMax(conexao, major, minor);
	}
}
