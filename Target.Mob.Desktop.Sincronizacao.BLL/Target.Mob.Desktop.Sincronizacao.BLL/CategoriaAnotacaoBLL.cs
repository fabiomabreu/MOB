using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class CategoriaAnotacaoBLL
{
	public static byte[] selectMaxRowId(DbConnection connTargetErp)
	{
		return CategoriaAnotacaoDAL.selectMaxRowId(connTargetErp);
	}

	public static void Merge(DbConnection connTargetErp, CategoriaAnotacaoTO categAnot)
	{
		CategoriaAnotacaoTO categoriaAnotacaoTO = new CategoriaAnotacaoTO();
		categoriaAnotacaoTO.IdCategoriaAnotacao = categAnot.IdCategoriaAnotacao;
		CategoriaAnotacaoTO[] array = CategoriaAnotacaoDAL.Select(connTargetErp, categoriaAnotacaoTO);
		if (array != null && array.Count() > 0)
		{
			CategoriaAnotacaoDAL.Update(connTargetErp, categAnot);
		}
		else
		{
			CategoriaAnotacaoDAL.Insert(connTargetErp, categAnot);
		}
	}
}
