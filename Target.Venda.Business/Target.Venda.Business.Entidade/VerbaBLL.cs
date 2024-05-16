using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class VerbaBLL
{
	public void CalcularVerbaPedido(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		if (!pedidoVenda.TIPO_PEDIDO.GERA_VERBA)
		{
			itemPedidoBLL.LimparValoresVerbasDeTodosItensPedido(pedidoVenda);
			{
				foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
				{
					iTEN.CALCULA_REDUCAO_COMISSAO = true;
				}
				return;
			}
		}
		PrecoBLL precoBLL = new PrecoBLL();
		decimal num2;
		decimal? num;
		using (List<ItemPedidoMO>.Enumerator enumerator2 = pedidoVenda.ITENS.GetEnumerator())
		{
			ItemPedidoMO current2;
			for (; enumerator2.MoveNext(); CalcularVerbaFabricanteAdicCampanha(current2))
			{
				current2 = enumerator2.Current;
				PrecoMO precoMO = precoBLL.ObterPrecoProdutoPelaTabelaPreco(current2.CODIGO_PRODUTO, pedidoVenda.CODIGO_TABELA);
				DescontosPedidoVO descontosPedidoVO = precoBLL.ObterDescontosItemPedido(current2, pedidoVenda);
				bool flag = precoBLL.VerificarSeGeraVerbaNoItemPedido(pedidoVenda, current2, descontosPedidoVO, precoMO);
				decimal? dESCONTO_APLICADO = current2.DESCONTO_APLICADO;
				if (flag)
				{
					if (current2.SEQ_ACAO_COMERCIAL > 0)
					{
						num = dESCONTO_APLICADO;
						num2 = 1;
						if ((num.GetValueOrDefault() == num2) & num.HasValue)
						{
							goto IL_01d0;
						}
					}
					ValorBaseCalculoVerbaVO vALORES_BASE = precoBLL.ObterValorBaseCalculoParaVerba(new CalculoVerbaParamVO
					{
						ITEM_PEDIDO = current2,
						PRECO = precoMO,
						DESCONTOS = descontosPedidoVO,
						CLIENTE = pedidoVenda.CLIENTE,
						PAR_CFG = ConfigERP.PAR_CFG,
						PARAMETRO_TELA_VENDA = ConfigERP.PARAMETROS_TELA.VENDA,
						TIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO
					});
					precoBLL.CalcularVerbaItemPedido(new CalcularVerbaItemPedidoParamVO
					{
						VALORES_BASE = vALORES_BASE,
						ITEM_PEDIDO = current2,
						PARCFG = ConfigERP.PAR_CFG,
						VENDEDOR = pedidoVenda.VENDEDOR,
						EQUIPE_VENDEDOR = pedidoVenda.VENDEDOR.EQUIPE,
						PRECO = precoMO
					});
					continue;
				}
				goto IL_01d0;
				IL_01d0:
				itemPedidoBLL.LimparValoresVerbasDoItemPedido(current2);
				current2.CALCULA_REDUCAO_COMISSAO = true;
			}
		}
		VerbaVO verbaVO = ((!(ConfigERP.PAR_CFG.VERBA_TP_LANC == "CL")) ? precoBLL.ObterVerbaVendedor(pedidoVenda.VENDEDOR) : precoBLL.ObterVerbaDoCliente(pedidoVenda.VENDEDOR, pedidoVenda.CLIENTE));
		decimal? num3 = pedidoVenda.ITENS.Sum((ItemPedidoMO s) => s.VALOR_VERBA);
		num = num3;
		int bUSCA_RED_COMISSAO_VENDEDOR;
		if (!((num.GetValueOrDefault() >= default(decimal)) & num.HasValue))
		{
			num = num3;
			if (((num.GetValueOrDefault() < default(decimal)) & num.HasValue) && verbaVO.VALOR_ATUAL >= 0m)
			{
				num = num3 + (decimal?)verbaVO.VALOR_ATUAL;
				num2 = verbaVO.VALOR_LIMITE_VERBA;
				bUSCA_RED_COMISSAO_VENDEDOR = ((!((num.GetValueOrDefault() >= num2) & num.HasValue)) ? 1 : 0);
			}
			else
			{
				bUSCA_RED_COMISSAO_VENDEDOR = 1;
			}
		}
		else
		{
			bUSCA_RED_COMISSAO_VENDEDOR = 0;
		}
		pedidoVenda.BUSCA_RED_COMISSAO_VENDEDOR = (byte)bUSCA_RED_COMISSAO_VENDEDOR != 0;
		num = num3;
		if ((num.GetValueOrDefault() >= default(decimal)) & num.HasValue)
		{
			pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO i)
			{
				i.VALOR_VERBA_FABRICANTE_ADIC = (i.CAMPANHA_CALCULAR_VERBA_FABRICANTE ? i.VALOR_VERBA_FABRICANTE_ADIC : new decimal?(default(decimal)));
			});
		}
		num = (decimal?)verbaVO.VALOR_ATUAL + num3;
		num2 = verbaVO.VALOR_LIMITE_VERBA;
		bool flag2 = (num.GetValueOrDefault() < num2) & num.HasValue;
		bool flag3 = !ConfigERP.PARAMETROS_TELA.VENDA.CALCULA_AO_PASSAR_LIMITE_VENDEDOR;
		num = num3;
		bool flag4 = (num.GetValueOrDefault() < default(decimal)) & num.HasValue;
		if (flag2 && flag3 && flag4)
		{
			itemPedidoBLL.LimparValoresVerbasDeTodosItensPedido(pedidoVenda);
		}
	}

	public void TratarVerbaFabricante(PedidoVendaMO pedidoVenda)
	{
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll(delegate(ItemPedidoMO x)
		{
			decimal? vALOR_VERBA_FABRICANTE_ADIC = x.VALOR_VERBA_FABRICANTE_ADIC;
			return (vALOR_VERBA_FABRICANTE_ADIC.GetValueOrDefault() > default(decimal)) & vALOR_VERBA_FABRICANTE_ADIC.HasValue;
		});
		foreach (ItemPedidoMO item in list)
		{
			VerbaFabricanteLancamentoContaIncluir(pedidoVenda, item);
		}
	}

	private void VerbaFabricanteLancamentoContaIncluir(PedidoVendaMO pedidoVenda, ItemPedidoMO item)
	{
		ProdutoBLL produtoBLL = new ProdutoBLL();
		ProdutoMO produtoMO = produtoBLL.ObterPeloID(item.CODIGO_PRODUTO);
		if (string.IsNullOrEmpty(produtoMO.CODIGO_FABRIC))
		{
			throw new Exception("Erro: parâmetro com valor inválido (vazio) - código do fabricante");
		}
		if (string.IsNullOrEmpty(LoginERP.USUARIO_LOGADO.CODIGO_USUARIO))
		{
			throw new Exception("Erro: parâmetro com valor inválido (vazio) - código do usuário ");
		}
		string codigoTipoLancAjuste = "VDNI";
		DateTime dateTime = DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.Data);
		AcaoComercialMO acaoComercialMO = new AcaoComercialMO();
		acaoComercialMO.SEQ_ACAO_COMERCIAL = (item.SEQ_ACAO_COMERCIAL.HasValue ? item.SEQ_ACAO_COMERCIAL.Value : 0);
		acaoComercialMO.CODIGO_FABRICANTE = produtoMO.CODIGO_FABRIC;
		VerbaFabricanteLancamentoBLL verbaFabricanteLancamentoBLL = new VerbaFabricanteLancamentoBLL();
		verbaFabricanteLancamentoBLL.GerarLancamentoVerbaFabricante(pedidoVenda, codigoTipoLancAjuste, item.VALOR_VERBA_FABRICANTE_ADIC.ToDecimal(), acaoComercialMO);
	}

	public void CalcularVerbaFabricanteItensPedido(PedidoVendaMO pedidoVenda)
	{
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => x.SEQ_ACAO_COMERCIAL > 0);
		if (list.Count == 0)
		{
			return;
		}
		ProdutoCustoBLL produtoCustoBLL = new ProdutoCustoBLL();
		AcaoComercialPromocaoBLL acaoComercialPromocaoBLL = new AcaoComercialPromocaoBLL();
		AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
		AcaoComercialProdutoBLL acaoComercialProdutoBLL = new AcaoComercialProdutoBLL();
		EmpresaMO eMPRESA_LOGADA = LoginERP.EMPRESA_LOGADA;
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		string vERBA_FABR_TP_CUSTO_BONIF = pAR_CFG.VERBA_FABR_TP_CUSTO_BONIF;
		foreach (ItemPedidoMO item in list)
		{
			decimal num = default(decimal);
			bool flag = item.SEQ_KIT_PROMOCAO > 0;
			if (flag)
			{
				num = ((!item.BONIFICADO.ToBool()) ? acaoComercialPromocaoBLL.ObterValorVerbaFabricantePromocao(item) : produtoCustoBLL.ObterValorVerbaFabricanteBonificado(item, eMPRESA_LOGADA, vERBA_FABR_TP_CUSTO_BONIF));
			}
			if ((!flag && !item.BONIFICADO.ToBool()) || (flag && num == 0m && !item.BONIFICADO.ToBool()))
			{
				num = acaoComercialProdutoBLL.ObterValorVerbaFabricanteProduto(item);
			}
			item.VALOR_VERBA_FABRICANTE = Math.Round(num * item.QUANTIDADE, 2, MidpointRounding.AwayFromZero);
		}
	}

	private void CalcularVerbaFabricanteAdicCampanha(ItemPedidoMO itemPedido)
	{
		if (itemPedido.CAMPANHA_CALCULAR_VERBA_FABRICANTE)
		{
			itemPedido.VALOR_VERBA_FABRICANTE_ADIC = ((!itemPedido.VALOR_VERBA_FABRICANTE_ADIC.HasValue) ? new decimal?(default(decimal)) : itemPedido.VALOR_VERBA_FABRICANTE_ADIC);
			itemPedido.DESCONTO_01 = ((!itemPedido.DESCONTO_01.HasValue) ? new decimal?(default(decimal)) : itemPedido.DESCONTO_01);
			itemPedido.PERCENTUAL_DESCONTO_GERAL = ((!itemPedido.PERCENTUAL_DESCONTO_GERAL.HasValue) ? new decimal?(default(decimal)) : itemPedido.PERCENTUAL_DESCONTO_GERAL);
			itemPedido.PERCDESCCAMPANHA = ((!itemPedido.PERCDESCCAMPANHA.HasValue) ? new decimal?(default(decimal)) : itemPedido.PERCDESCCAMPANHA);
			itemPedido.PERC_DESC_CAMPANHA_COMBO = ((!itemPedido.PERC_DESC_CAMPANHA_COMBO.HasValue) ? new decimal?(default(decimal)) : itemPedido.PERC_DESC_CAMPANHA_COMBO);
			itemPedido.VALOR_DEBITO_PIS = ((!itemPedido.VALOR_DEBITO_PIS.HasValue) ? new decimal?(default(decimal)) : itemPedido.VALOR_DEBITO_PIS);
			itemPedido.VALOR_DEBITO_COFINS = ((!itemPedido.VALOR_DEBITO_COFINS.HasValue) ? new decimal?(default(decimal)) : itemPedido.VALOR_DEBITO_COFINS);
			decimal? num = ((!itemPedido.CAMPANHA_VERBA_FABR_DEBITA_PIS_COFINS) ? new decimal?(default(decimal)) : (itemPedido.VALOR_DEBITO_PIS + itemPedido.VALOR_DEBITO_COFINS));
			decimal? vALOR_VERBA_FABRICANTE_ADIC = itemPedido.VALOR_VERBA_FABRICANTE_ADIC;
			decimal? num2 = (decimal?)(itemPedido.QUANTIDADE * itemPedido.PRECO_TABELA) - num;
			decimal value = 1;
			decimal? num3 = itemPedido.DESCONTO_01 + itemPedido.PERCENTUAL_DESCONTO_GERAL;
			itemPedido.VALOR_VERBA_FABRICANTE_ADIC = vALOR_VERBA_FABRICANTE_ADIC + num2 * ((decimal?)value - num3) * (itemPedido.PERCDESCCAMPANHA + itemPedido.PERC_DESC_CAMPANHA_COMBO);
		}
	}
}
