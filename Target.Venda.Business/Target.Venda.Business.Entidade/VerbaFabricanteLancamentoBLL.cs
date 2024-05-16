using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;

namespace Target.Venda.Business.Entidade;

public class VerbaFabricanteLancamentoBLL : EntidadeBaseBLL<VerbaFabricanteLancamentoMO>
{
	protected override EntidadeBaseDAL<VerbaFabricanteLancamentoMO> GetInstanceDAL()
	{
		return new VerbaFabricanteLancamentoDAL();
	}

	public void GerarLancamentoVerbaFabricante(PedidoVendaMO pedidoVenda, string codigoTipoLancAjuste, decimal valorLancAjuste, AcaoComercialMO acaoComercial)
	{
		try
		{
			VerbaFabricanteTipoLancamentoBLL verbaFabricanteTipoLancamentoBLL = new VerbaFabricanteTipoLancamentoBLL();
			VerbaFabricanteTipoLancamentoMO verbaFabricanteTipoLancamentoMO = verbaFabricanteTipoLancamentoBLL.ObterPeloID(codigoTipoLancAjuste);
			decimal vALOR = valorLancAjuste;
			if (verbaFabricanteTipoLancamentoMO.TIPO == "D")
			{
				vALOR = valorLancAjuste * -1m;
			}
			DateTime dATA_CRIACAO = DateTimeHelper.ObterDataHoraAtualBancoDados();
			DateTime dATA_LANCAMENTO = DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.Data);
			VerbaFabricanteLancamentoMO verbaFabricanteLancamentoMO = new VerbaFabricanteLancamentoMO();
			verbaFabricanteLancamentoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
			verbaFabricanteLancamentoMO.VALOR = vALOR;
			verbaFabricanteLancamentoMO.CODIGO_FABRICANTE = acaoComercial.CODIGO_FABRICANTE;
			verbaFabricanteLancamentoMO.CODIGO_USUARIO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
			verbaFabricanteLancamentoMO.DATA_LANCAMENTO = dATA_LANCAMENTO;
			verbaFabricanteLancamentoMO.DATA_CRIACAO = dATA_CRIACAO;
			verbaFabricanteLancamentoMO.CODIGO_VERBA_FABRICANTE_TIPO_LANCAMENTO = verbaFabricanteTipoLancamentoMO.CODIGO_VERBA_FABRICANTE_TIPO_LANCAMENTO;
			verbaFabricanteLancamentoMO.SEQ_ACAO_COMERCIAL = ((acaoComercial.SEQ_ACAO_COMERCIAL != 0) ? new int?(acaoComercial.SEQ_ACAO_COMERCIAL) : verbaFabricanteLancamentoMO.SEQ_ACAO_COMERCIAL);
			verbaFabricanteLancamentoMO.SITUACAO = "VL";
			verbaFabricanteLancamentoMO.PERMITE_CONSOLIDACAO = verbaFabricanteTipoLancamentoMO.PERMITE_CONSOLIDACAO;
			verbaFabricanteLancamentoMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			verbaFabricanteLancamentoMO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
			verbaFabricanteLancamentoMO.SEQ_ITEM_PEDIDO_VENDA = null;
			verbaFabricanteLancamentoMO.NUMERO_TITULO = null;
			verbaFabricanteLancamentoMO.SERIE = null;
			verbaFabricanteLancamentoMO.CODIGO_FORNECEDOR_COMPRA = null;
			verbaFabricanteLancamentoMO.NUMERO_NOTA_FISCAL_COMPRA = null;
			verbaFabricanteLancamentoMO.CD_TEXTO = null;
			verbaFabricanteLancamentoMO.REFERENCIA = null;
			verbaFabricanteLancamentoMO.CODIGO_PRODUTO = null;
			verbaFabricanteLancamentoMO.NUMERO_PEDIDO_COMPRA = null;
			Salvar(verbaFabricanteLancamentoMO);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
