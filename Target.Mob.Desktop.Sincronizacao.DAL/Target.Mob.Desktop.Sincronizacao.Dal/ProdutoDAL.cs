using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class ProdutoDAL
{
	private const string SELECT = "uspProdutoSelect";

	public static ProdutoTO[] Select(DbConnection connection, int CdEmpPedido, int? CdProd, int? CdEmp, string CdGrupoPrd)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_grupo_prd", CdGrupoPrd);
		connection.AddParameters("@ativo", null);
		connection.AddParameters("@bloq_envio_palmtop", null);
		connection.AddParameters("@descricao", null);
		connection.AddParameters("@desc_resum", null);
		connection.AddParameters("@rowid", null);
		connection.AddParameters("@cd_emp_pedido", CdEmpPedido);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspProdutoSelect"));
	}

	public static ProdutoTO[] Select(DbConnection connection, int? CdProd, int? CdEmp, string CdGrupoPrd, bool? Ativo, bool? BloqEnvioPalmTop, string Descricao, string DescResum, string CdFabric, string CdLinha, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_grupo_prd", CdGrupoPrd);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@bloq_envio_palmtop", BloqEnvioPalmTop);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@desc_resum", DescResum);
		connection.AddParameters("@cd_fabric", CdFabric);
		connection.AddParameters("@cd_linha", CdLinha);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspProdutoSelect"));
	}

	private static ProdutoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ProdutoTO produtoTO = new ProdutoTO();
				produtoTO.CdProd = rs.GetNullableInteger("cd_prod");
				produtoTO.CdProdFabric = rs.GetString("cd_prod_fabric");
				produtoTO.CdEmp = rs.GetNullableInteger("cd_emp");
				produtoTO.CdGrupoPrd = rs.GetString("cd_grupo_prd");
				produtoTO.Ativo = rs.GetNullableBoolean("ativo");
				produtoTO.BloqEnvioPalmTop = rs.GetNullableBoolean("bloq_envio_palm_top");
				produtoTO.Descricao = rs.GetString("descricao");
				produtoTO.DescResum = rs.GetString("desc_resum");
				produtoTO.RowId = rs.GetArrayByte("rowid");
				produtoTO.CdFabric = rs.GetString("cd_fabric");
				produtoTO.CdLinha = rs.GetString("cd_linha");
				produtoTO.TpCdBarra = rs.GetString("tp_cd_barra");
				produtoTO.CdBarra = rs.GetString("cd_barra");
				produtoTO.TpCdBarraCompra = rs.GetString("tp_cd_barra_compra");
				produtoTO.CdBarraCompra = rs.GetString("cd_barra_compra");
				arrayList.Add(produtoTO);
			}
		}
		return (ProdutoTO[])arrayList.ToArray(typeof(ProdutoTO));
	}
}
