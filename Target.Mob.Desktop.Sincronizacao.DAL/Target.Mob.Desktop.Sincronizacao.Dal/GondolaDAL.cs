using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class GondolaDAL
{
	private const string INSERT_OR_REPLACE = "uspGondolaInsertOrReplace";

	public static void InsertOrReplace(DbConnection connection, GondolaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo", instance.Codigo);
		connection.AddParameters("@CodigoCliente", instance.CodigoCliente);
		connection.AddParameters("@CodigoProduto", instance.CodigoProduto);
		connection.AddParameters("@Data", instance.Data);
		connection.AddParameters("@QtdeEstoqueCliente", instance.QtdeEstoqueCliente);
		connection.AddParameters("@PrecoGondola", instance.PrecoGondola);
		connection.AddParameters("@QtdeGiro", instance.QtdeGiro);
		connection.AddParameters("@QtdeVendaMedia", instance.QtdeVendaMedia);
		connection.AddParameters("@QtdeSugerida", instance.QtdeSugerida);
		connection.AddParameters("@QtdeSeguranca", instance.QtdeSeguranca);
		connection.AddParameters("@QtdeVendida", instance.QtdeVendida);
		connection.AddParameters("@QtdeSaldo", instance.QtdeSaldo);
		connection.AddParameters("@CodigoEmpresa", instance.CodigoEmpresa);
		connection.AddParameters("@NumeroPedido", instance.NumeroPedido);
		connection.AddParameters("@Markup", instance.Markup);
		connection.AddParameters("@IdVendedor", instance.IdVendedor);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspGondolaInsertOrReplace");
	}

	private static GondolaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				GondolaTO gondolaTO = new GondolaTO();
				gondolaTO.Codigo = rs.GetInteger("Codigo");
				gondolaTO.CodigoCliente = rs.GetInteger("CodigoCliente");
				gondolaTO.CodigoProduto = rs.GetInteger("CodigoProduto");
				gondolaTO.Data = rs.GetDateTime("Data");
				gondolaTO.QtdeEstoqueCliente = rs.GetInteger("QtdeEstoqueCliente");
				gondolaTO.PrecoGondola = rs.GetDecimal("PrecoGondola");
				gondolaTO.QtdeGiro = rs.GetInteger("QtdeGiro");
				gondolaTO.QtdeVendaMedia = rs.GetDecimal("QtdeVendaMedia");
				gondolaTO.QtdeSugerida = rs.GetInteger("QtdeSugerida");
				gondolaTO.QtdeSeguranca = rs.GetInteger("QtdeSeguranca");
				gondolaTO.QtdeVendida = rs.GetInteger("QtdeVendida");
				gondolaTO.QtdeSaldo = rs.GetInteger("QtdeSaldo");
				gondolaTO.CodigoEmpresa = rs.GetInteger("CodigoEmpresa");
				gondolaTO.NumeroPedido = rs.GetInteger("NumeroPedido");
				gondolaTO.Markup = rs.GetDecimal("Markup");
				gondolaTO.IdVendedor = rs.GetInteger("IdVendedor");
				arrayList.Add(gondolaTO);
			}
		}
		return (GondolaTO[])arrayList.ToArray(typeof(GondolaTO));
	}
}
