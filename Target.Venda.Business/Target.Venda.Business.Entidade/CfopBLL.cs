using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class CfopBLL : EntidadeBaseBLL<CfopMO>
{
	protected override EntidadeBaseDAL<CfopMO> GetInstanceDAL()
	{
		return new CfopDAL();
	}

	public List<int> ObterCFOPs(CfopVO exemplo)
	{
		return (BaseDAL as CfopDAL).ObterCFOPs(exemplo);
	}

	public int BuscaCFOP(TipoPedidoVO tipoPedido, ClienteMO cliente, PedidoVendaMO pedidoVenda)
	{
		CfopVO cfopVO = new CfopVO();
		cfopVO.TIPO_PEDIDO = tipoPedido.CODIGO_TIPO_PEDIDO;
		cfopVO.AREA_LIVRE_COMERCIO = cliente.AREA_LIVRE_COMERCIO.ToBool();
		EnderecoClienteMO enderecoClienteMO = cliente.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "FA");
		if (cliente.ESTRANGEIRO.ToBool())
		{
			cfopVO.TIPO_DESTINO_CLIENTE = "EX";
		}
		else if (enderecoClienteMO.ESTADO == LoginERP.EMPRESA_LOGADA.ESTADO || tipoPedido.NFCE_SEM_IDENTIFICACAO_DESTINATARIO)
		{
			cfopVO.TIPO_DESTINO_CLIENTE = "ME";
		}
		else
		{
			cfopVO.TIPO_DESTINO_CLIENTE = "OE";
		}
		cfopVO.TIPO_PRODUTO = null;
		if (tipoPedido.AUTOMATICO_3_CASA)
		{
			bool flag = pedidoVenda.ITENS.Exists((ItemPedidoMO x) => x.PRODUZIDO);
			cfopVO.TIPO_PRODUTO = TipoProdutoCFOPEnum.NAO_PRODUZIDO;
			if (flag)
			{
				cfopVO.TIPO_PRODUTO = TipoProdutoCFOPEnum.PRODUZIDO;
			}
		}
		List<int> list = ObterCFOPs(cfopVO);
		if (list == null || list.Count != 1)
		{
			new MyException("Não foi possível definir um código fiscal de operação (CFOP) válida.").ThrowException();
		}
		return list.First();
	}

	public void CarregarCFOPSRPedido(PedidoVendaMO pedidoVenda)
	{
		if (!string.IsNullOrEmpty(pedidoVenda.TIPO_PEDIDO.TIPO_PEDIDO_SR.Trim()))
		{
			ClienteMO cliente = pedidoVenda.CLIENTE;
			if (pedidoVenda.CLIENTE_ENTREGA != null)
			{
				cliente = pedidoVenda.CLIENTE_ENTREGA;
			}
			TipoPedidoBLL tipoPedidoBLL = new TipoPedidoBLL();
			pedidoVenda.TIPO_PEDIDO_SR = tipoPedidoBLL.ObterTipoPedidoPeloCodigo(pedidoVenda.TIPO_PEDIDO.TIPO_PEDIDO_SR);
			int value = BuscaCFOP(pedidoVenda.TIPO_PEDIDO_SR, cliente, pedidoVenda);
			pedidoVenda.CFOP_SR = value;
		}
	}

	public void CarregarCFOPPedido(PedidoVendaMO pedidoVenda)
	{
		int value = BuscaCFOP(pedidoVenda.TIPO_PEDIDO, pedidoVenda.CLIENTE, pedidoVenda);
		pedidoVenda.CFOP = value;
	}

	public void ValidarCFOPdoPedido(PedidoVendaMO pedidoVenda)
	{
		CfopMO cfopMO = ObterPeloID(pedidoVenda.CFOP.ToInt());
		if (cfopMO == null)
		{
			throw new MyException("CFOP não encontrado");
		}
		if (pedidoVenda.ENTREGA_OUTRO_CLIENTE.ToBool() && pedidoVenda.CFOP_SR.ToInt() <= 0)
		{
			throw new MyException("CFOP simples remessa não informado");
		}
		EnderecoClienteMO enderecoClienteMO = pedidoVenda.CLIENTE.ENDERECOS.Find((EnderecoClienteMO e) => e.TIPO_ENDERECO == "FA");
		if (pedidoVenda.EMPRESA.ESTADO != enderecoClienteMO.ESTADO && cfopMO.CLIENTE_DESTINO == "ME" && !pedidoVenda.TIPO_PEDIDO.NFCE_SEM_IDENTIFICACAO_DESTINATARIO)
		{
			string menssage = $"A CFOP definida para a emissão da NF não é válida. ESTADO ORIGEM: {pedidoVenda.EMPRESA.ESTADO} ESTADO DESTINO: {enderecoClienteMO.ESTADO} CFOP:{cfopMO.CODIGO_OPERACAO}";
			throw new MyException(menssage);
		}
	}
}
