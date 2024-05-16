using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class RelatorioTrabalhoVendedorBLL
{
	public static byte[] selectMaxRowId(DbConnection connTargetErp)
	{
		return RelatorioTrabalhoVendedorDAL.selectMaxRowId(connTargetErp);
	}

	public static void Merge(DbConnection connTargetErp, RelatorioTrabalhoVendedorTO relatorioTrabalhoVendedor)
	{
		RelatorioTrabalhoVendedorTO relatorioTrabalhoVendedorTO = new RelatorioTrabalhoVendedorTO();
		relatorioTrabalhoVendedorTO.IdVendedor = relatorioTrabalhoVendedor.IdVendedor;
		relatorioTrabalhoVendedorTO.Data = relatorioTrabalhoVendedor.Data;
		RelatorioTrabalhoVendedorTO[] array = RelatorioTrabalhoVendedorDAL.Select(connTargetErp, relatorioTrabalhoVendedorTO);
		if (array != null && array.Count() > 0)
		{
			RelatorioTrabalhoVendedorTO[] array2 = array;
			foreach (RelatorioTrabalhoVendedorTO rtv in array2)
			{
				RelatorioTrabalhoVendedorDAL.Delete(connTargetErp, rtv);
			}
		}
		RelatorioTrabalhoVendedorDAL.Insert(connTargetErp, relatorioTrabalhoVendedor);
	}
}
