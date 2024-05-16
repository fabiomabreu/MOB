using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class EndCliBLL
{
	public static EndCliTO[] Select(DbConnection connection, int? CdClien)
	{
		EndCliTO[] array = EndCliDAL.Select(connection, CdClien);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static EndCliTO[] Select(DbConnection connection, int? CdClien, string TpEnd)
	{
		EndCliTO[] array = EndCliDAL.Select(connection, CdClien, TpEnd);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static EndCliTO[] SelecionarCoordenadas(DbConnection connection)
	{
		EndCliTO[] array = EndCliDAL.SelecionarCoordenadas(connection);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, EndCliTO EndCli)
	{
		EndCliDAL.Insert(connection, EndCli);
	}

	public static void Update(DbConnection connection, EndCliTO EndCli)
	{
		EndCliDAL.Update(connection, EndCli);
	}

	public static void AtualizarEndereco(DbConnection connection, EndCliTO endereco, decimal latitude, decimal longitude)
	{
		EndCliDAL.AtualizarEndereco(connection, endereco, latitude, longitude);
	}
}
