using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class VendedorErpBLL
{
	public static VendedorErpTO[] Select(DbConnection connection, string CdVend, string Nome, bool? Ativo, bool? UtilizaPalmTop, byte[] RowId, int? CodigoEmpresa)
	{
		VendedorErpTO[] array = VendedorErpDAL.Select(connection, CdVend, Nome, Ativo, UtilizaPalmTop, RowId, CodigoEmpresa);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static string getCodigoPaisPorVendedor(DbConnection connTargetErp, string codigoVendedor)
	{
		string codigoPaisPorVendedor = VendedorErpDAL.getCodigoPaisPorVendedor(connTargetErp, codigoVendedor);
		if (codigoPaisPorVendedor == null)
		{
			return "BRA";
		}
		return codigoPaisPorVendedor;
	}

	public static void setCoordenadaResidencia(DbConnection connTargetErp, CoordenadaResidenciaTO cr)
	{
		VendedorErpDAL.setCoordenadaResidencia(connTargetErp, cr);
	}
}
