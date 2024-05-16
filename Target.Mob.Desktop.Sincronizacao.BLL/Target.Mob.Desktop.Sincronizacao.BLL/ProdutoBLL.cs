using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class ProdutoBLL
{
	public static ProdutoTO[] Select(DbConnection connection, int CdEmpPedido, int? CdProd, int? CdEmp, string CdGrupoPrd)
	{
		ProdutoTO[] array = ProdutoDAL.Select(connection, CdEmpPedido, CdProd, CdEmp, CdGrupoPrd);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static ProdutoTO[] Select(DbConnection connection, int? CdProd, int? CdEmp, string CdGrupoPrd, bool? Ativo, bool? BloqEnvioPalmTop, string Descricao, string DescResum, string CdFabric, string CdLinha, byte[] RowId)
	{
		ProdutoTO[] array = ProdutoDAL.Select(connection, CdProd, CdEmp, CdGrupoPrd, Ativo, BloqEnvioPalmTop, Descricao, DescResum, CdFabric, CdLinha, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static ProdutoTO Select(DbConnection connection, int CdEmpPedido, int? CdProd)
	{
		ProdutoTO[] array = ProdutoDAL.Select(connection, CdEmpPedido, CdProd, null, null);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array[0];
	}
}
