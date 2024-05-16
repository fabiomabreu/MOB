using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Modulo;

public class ModuloFinanceiroBLL : ModuloBaseBLL, IModuloFinanceiroBLL, IModuloBaseBLL
{
	public void CalcularDescontoFinanceiro(PedidoVendaMO pedidoVenda)
	{
		PrecoBLL precoBLL = new PrecoBLL();
		precoBLL.CalcularDescontoFinanceiroPedido(pedidoVenda);
	}

	public void GerarParcelasPedido(PedidoVendaMO pedidoVenda)
	{
		ParcelaPedidoBLL parcelaPedidoBLL = new ParcelaPedidoBLL();
		DateTime dataPrimeiroVencimento = parcelaPedidoBLL.ObterDataPrimeiroVencimento(pedidoVenda);
		ParcelaPrazoDiferenciadoVO parcelaPrazoDiferenciadoVO = parcelaPedidoBLL.ObterPrazoDiferenciado(pedidoVenda);
		List<ParcelaPedidoMO> parcelas = parcelaPedidoBLL.GerarParcelasPelaCondicaoPagamento(pedidoVenda, parcelaPrazoDiferenciadoVO.VALOR_TOTAL_PRAZO_PADRAO, dataPrimeiroVencimento);
		parcelaPedidoBLL.GerarParcelasPrazoDiferenciado(pedidoVenda, parcelas, parcelaPrazoDiferenciadoVO, dataPrimeiroVencimento);
		parcelas = CalculaVencimentoFixoCliente(pedidoVenda.CLIENTE, parcelas);
		parcelaPedidoBLL.ValidarParcelasPedido(pedidoVenda, parcelas);
	}

	public List<ParcelaPedidoMO> CalculaVencimentoFixoCliente(ClienteMO cliente, List<ParcelaPedidoMO> parcelas)
	{
		if (cliente.CLIENTE_DIA_VENCIMENTO != null && cliente.CLIENTE_DIA_VENCIMENTO.Count() == 0)
		{
			return parcelas;
		}
		foreach (ParcelaPedidoMO parcela2 in parcelas)
		{
			bool flag = false;
			for (int i = 0; i < cliente.CLIENTE_DIA_VENCIMENTO.Count(); i++)
			{
				if (cliente.CLIENTE_DIA_VENCIMENTO[i].DIA_VENCIMENTO >= parcela2.DATA_PARCELA.Day)
				{
					parcela2.DATA_PARCELA = new DateTime(parcela2.DATA_PARCELA.Year, parcela2.DATA_PARCELA.Month, cliente.CLIENTE_DIA_VENCIMENTO[i].DIA_VENCIMENTO);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				parcela2.DATA_PARCELA = new DateTime(parcela2.DATA_PARCELA.AddMonths(1).Year, parcela2.DATA_PARCELA.AddMonths(1).Month, cliente.CLIENTE_DIA_VENCIMENTO[0].DIA_VENCIMENTO);
			}
		}
		short num = 1;
		List<ParcelaPedidoMO> list = new List<ParcelaPedidoMO>();
		foreach (ParcelaPedidoMO parcela in parcelas)
		{
			if (list.FindAll((ParcelaPedidoMO x) => x.DATA_PARCELA == parcela.DATA_PARCELA).Count() != 0)
			{
				continue;
			}
			List<ParcelaPedidoMO> source = parcelas.FindAll((ParcelaPedidoMO x) => x.DATA_PARCELA == parcela.DATA_PARCELA);
			ParcelaPedidoMO parcelaPedidoMO = parcela;
			if (source.Count() > 1)
			{
				parcelaPedidoMO.SEQ_PARCELA_PEDIDO = num;
				parcelaPedidoMO.VALOR_PARCELA = source.Sum((ParcelaPedidoMO x) => x.VALOR_PARCELA);
			}
			else
			{
				parcelaPedidoMO = parcela;
				parcelaPedidoMO.SEQ_PARCELA_PEDIDO = num;
			}
			list.Add(parcelaPedidoMO);
			num++;
		}
		return list;
	}

	public void AtualizaPrazoMedioPedido(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.AtualizaPrazoMedioPedido(pedidoVenda);
	}

	public void ValidarFormaPagamento(PedidoVendaMO pedidoVenda)
	{
		try
		{
			FormaPagamentoPromocaoBLL formaPagamentoPromocaoBLL = new FormaPagamentoPromocaoBLL();
			formaPagamentoPromocaoBLL.ValidarFormaPagamentoPedido(pedidoVenda);
		}
		catch (MyException)
		{
			throw;
		}
	}

	public void ValidarCondicaoPagamento(PedidoVendaMO pedidoVenda)
	{
		PromocaoBLL promocaoBLL = new PromocaoBLL();
		promocaoBLL.ValidarCondicaoPagamentoPedidoEletronico(pedidoVenda);
	}

	public bool PedidoAtingiuValorMinimo(PedidoVendaMO pedidoVenda, ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle)
	{
		PromocaoBLL promocaoBLL = new PromocaoBLL();
		bool flag = promocaoBLL.PedidoAtingiuValorMinimo(pedidoVenda);
		if (flag)
		{
			return flag;
		}
		return false;
	}
}
