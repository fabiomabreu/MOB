using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TipoExtensaoArquivoBLL
{
	public static TipoExtensaoArquivoTO[] Select(DbConnection connection, int? IDTipoExtensaoArquivo)
	{
		TipoExtensaoArquivoTO[] array = TipoExtensaoArquivoDAL.Select(connection, IDTipoExtensaoArquivo);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, TipoExtensaoArquivoTO IDTipoExtensaoArquivo)
	{
		TipoExtensaoArquivoDAL.Insert(connection, IDTipoExtensaoArquivo);
	}

	internal static void Update(DbConnection connection, TipoExtensaoArquivoTO IDTipoExtensaoArquivo)
	{
		TipoExtensaoArquivoDAL.Update(connection, IDTipoExtensaoArquivo);
	}
}
