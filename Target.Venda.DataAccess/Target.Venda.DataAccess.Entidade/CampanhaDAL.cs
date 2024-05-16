using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class CampanhaDAL : EntidadeBaseDAL<CampanhaMO>
{
	protected override Expression<Func<CampanhaMO, bool>> GetWhere(Expression<Func<CampanhaMO, bool>> whereClause, CampanhaMO exemplo)
	{
		if (exemplo.CAMPANHAID > 0)
		{
			whereClause = whereClause.And((CampanhaMO x) => x.CAMPANHAID == exemplo.CAMPANHAID);
		}
		return whereClause;
	}

	public int BuscaCampanhaAtiva(PedidoVendaMO pedidoVenda)
	{
		string select = "SELECT TOP 1\r\n\t\t\t\t\t\t\t\tISNULL(c.CampanhaID,0)\r\n\t\t\t\t\t\t\tFROM \r\n\t\t\t\t\t\t\t\tCampanha c WITH (NOLOCK)\r\n\t\t\t\t\t\t\t\tJOIN CampanhaCli cc WITH (NOLOCK)\r\n\t\t\t\t\t\t\t\t\tON c.CampanhaID = cc.CampanhaID\r\n\t\t\t\t\t\t\t\tJOIN CampanhaTpPed ct WITH (NOLOCK)\r\n\t\t\t\t\t\t\t\t\tON c.CampanhaID = ct.CampanhaID\r\n\t\t\t\t\t\t\t\tJOIN CampanhaEmp ce WITH (NOLOCK)\r\n\t\t\t\t\t\t\t\t\tON c.CampanhaID = ce.CampanhaID\r\n                                JOIN CampanhaVendedor cv WITH (NOLOCK)\r\n                                    ON c.CampanhaID = cv.CampanhaID\r\n\t\t\t\t\t\t\tWHERE\r\n\t\t\t\t\t\t\t\tc.Ativo = 1\r\n\t\t\t\t\t\t\tAND\tc.DtInicio <= {0}\r\n\t\t\t\t\t\t\tAND\tc.DtFim >= {0}\r\n\t\t\t\t\t\t\tAND\tce.CdEmp = {1}\r\n\t\t\t\t\t\t\tAND\tcc.CdClien = {2}\r\n\t\t\t\t\t\t\tAND\tct.TpPed = {3}\r\n                            AND cv.CdVend = {4}   ";
		return ExecutarScalarSQL<int>(select, new object[5]
		{
			pedidoVenda.DATA_PEDIDO,
			pedidoVenda.CODIGO_EMPRESA,
			pedidoVenda.CODIGO_CLIENTE,
			pedidoVenda.TIPO_PEDIDO.CODIGO_TIPO_PEDIDO,
			pedidoVenda.CODIGO_VENDEDOR
		});
	}

	public void InsereItPedvCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		string comando = "\r\n\t\t\t\t\t\t\t\tINSERT INTO ItPedvCampanha\r\n\t\t\t\t\t\t\t\t(\r\n\t\t\t\t\t\t\t\t\tCdEmpEle,\r\n\t\t\t\t\t\t\t\t\tNuPedEle,\r\n                                    CdClien,\r\n\t\t\t\t\t\t\t\t\tSeqItPedv,\r\n\t\t\t\t\t\t\t\t\tCdProd,\r\n\t\t\t\t\t\t\t\t\tQtde,\r\n                                    VlUnit,\r\n                                    TpPed,\r\n                                    CdVend,\r\n                                    SeqKit,\r\n                                    Bonificado\r\n\t\t\t\t\t\t\t\t)\r\n                                VALUES\r\n\t\t\t\t\t\t\t\t(\r\n\t\t\t\t\t\t\t\t\t{0},\r\n\t\t\t\t\t\t\t\t\t{1},\r\n\t\t\t\t\t\t\t\t\t{2},\r\n\t\t\t\t\t\t\t\t\t{3},\r\n\t\t\t\t\t\t\t\t\t{4},\r\n\t\t\t\t\t\t\t\t\t{5},\r\n                                    {6},\r\n                                    {7},\r\n                                    {8},\r\n                                    {9},\r\n                                    {10}\r\n\t\t\t\t\t\t\t\t)\t";
		foreach (ItemPedidoEletronicoMO iTEN in pedidoEletronico.ITENS)
		{
			ExecutarSqlCommand(comando, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.CODIGO_CLIENTE, iTEN.SEQ, iTEN.CODIGO_PRODUTO, iTEN.QUANTIDADE, iTEN.PRECO_UNITARIO, pedidoEletronico.CODIGO_TIPO_PEDIDO, pedidoEletronico.CODIGO_VENDEDOR, iTEN.SEQ_KIT, iTEN.BONIFICADO);
		}
	}

	public int? AplicaDescontosCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		string procedure = "uspCampanhaDescAplicar";
		string empty = string.Empty;
		List<SqlParameter> list = new List<SqlParameter>();
		list.Add(new SqlParameter("@parNuCdEmp", pedidoEletronico.CODIGO_EMPRESA_ELETRONICO));
		list.Add(new SqlParameter("@parNuCdClien", pedidoEletronico.CODIGO_CLIENTE));
		list.Add(new SqlParameter("@rparStrMsgErro", empty));
		return ExecutarStoredProcedureScalar<int?>(procedure, list);
	}

	public void DeletaItPedvCampanha(PedidoEletronicoMO pedidoEletronico)
	{
		string comando = " DELETE FROM ItPedvCampanha\r\n                            WHERE ItPedvCampanhaID IN(\tSELECT DISTINCT it.ItPedvCampanhaID\r\n                                                        FROM ItPedvCampanha it WITH (NOLOCK)\r\n                                                        WHERE it.CdClien = {0}\t);";
		ExecutarSqlCommand(comando, pedidoEletronico.CODIGO_CLIENTE);
	}

	public int? CampanhaItPedvDescontosGera(int cdEmp, int nuPed)
	{
		string procedure = "uspCampanhaItPedvDescontosGera";
		string empty = string.Empty;
		List<SqlParameter> list = new List<SqlParameter>();
		list.Add(new SqlParameter("@parNuCdEmp", cdEmp));
		list.Add(new SqlParameter("@parNuNuPed", nuPed));
		list.Add(new SqlParameter("@rparStrMsgErro", empty));
		return ExecutarStoredProcedureScalar<int?>(procedure, list);
	}

	public DescontoCampanhaVO VerificarDescontoCampanhaItem(ItemPedidoMO item, PedidoEletronicoMO pedidoEletronico)
	{
		try
		{
			string select = "\r\n        \t\t\tSELECT DISTINCT\r\n                        ISNULL( it.PercDescCampanha, 0 ) AS PERC_DESC_CAMPANHA,\r\n\t\t                ISNULL( it.PercDescCampanhaCombo, 0 ) AS PERC_DESC_CAMPANHA_COMBO,\r\n\t\t                ISNULL( it.CalcularVerbaFabricante, 0 ) AS CALCULAR_VERBA_FABRICANTE,\r\n                        ISNULL( it.ConsideraProdutosEmPromocao, 0 ) AS CONSIDERA_PRODUTOS_PROMOCAO,\r\n                        ISNULL( it.ConsideraProdutosBonificados, 0 ) AS CONSIDERA_PRODUTOS_BONIFICADOS,\r\n                        ISNULL( it.VerbaFabrDebitaPisCofins, 0 ) AS VERBA_FABR_DEBITA_PIS_COFINS\r\n        \t\t\tFROM\r\n        \t\t\t\tItPedvCampanha it WITH (NOLOCK)\r\n        \t\t\tWHERE\r\n        \t\t\t\tit.CdEmpEle = {0}\r\n        \t\t\tAND\tit.NuPedEle = {1}\r\n        \t\t\tAND\tit.SeqItPedv = {2}\t";
			return ExecutarScalarSQL<DescontoCampanhaVO>(select, new object[3] { pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, item.SEQ });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AtualizaItPedvCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		string comando = "\r\n\t\t\t\t\t\t\t\tUPDATE ItPedvCampanha\r\n\t\t\t\t\t\t\t\tSET CdEmp = {0},\r\n\t\t\t\t\t\t\t\t\tNuPed = {1}\r\n\t\t\t\t\t\t\t\tWHERE\r\n                                    CdEmpEle = {2}\r\n                                AND NuPedEle = {3}";
		ExecutarSqlCommand(comando, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO);
	}
}
