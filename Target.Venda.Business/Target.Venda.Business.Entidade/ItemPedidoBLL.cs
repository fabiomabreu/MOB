using System;
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

public class ItemPedidoBLL : EntidadeBaseBLL<ItemPedidoMO>
{
	protected override EntidadeBaseDAL<ItemPedidoMO> GetInstanceDAL()
	{
		return new ItemPedidoDAL();
	}

	public void TratarItemPromocionalSemEstoque(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		bool cORTE_AUTO_INSUF_ESTOQUE_NAO_LIBERA_PEDIDO = ConfigERP.PARAMETROS_TELA.VENDA.CORTE_AUTO_INSUF_ESTOQUE_NAO_LIBERA_PEDIDO;
		bool flag = itemPedido.ESTOQUE_INSUFICIENTE.ToBool() || itemPedido.ESTOQUE_ZERADO.ToBool();
		bool flag2 = itemPedido.SEQ_KIT_PROMOCAO > 0;
		if (flag2 && cORTE_AUTO_INSUF_ESTOQUE_NAO_LIBERA_PEDIDO && flag)
		{
			MyException ex = new MyException("Existe uma promoção nesse item e o estoque é insuficiente.");
			ex.ThrowException();
		}
	}

	public List<ItemPedidoMO> ObterItensPedido(PedidoVendaMO pedidoVenda)
	{
		List<ItemPedidoMO> list = ObterItensPedidoNovo(pedidoVenda);
		ValidarItensAtendidos(pedidoVenda, list);
		foreach (ItemPedidoMO item in list)
		{
			item.PARCFG_MARGEM_BRUTA_DESCONTO_FINANCEIRO = ConfigERP.PAR_CFG.MG_BRUTA_DESC_FIN;
			item.SEQ_ORIGEM = (item.SEQ_ORIGEM.HasValue ? item.SEQ_ORIGEM : new int?(item.SEQ));
			item.TP_PED_BONIFICACAO_VALOR_ZERO = ConfigERP.PAR_CFG.TPPEDBONIFICACAOVALORZERO && pedidoVenda.TIPO_PEDIDO.BONIFICACAO;
			if (ConfigERP.PARAMETROS_TELA.VENDA.CORTE_AUTO_PRODUTO_COM_RESTR_VENDA && item.RESTRICAO_VENDA.ToBool())
			{
				item.STATUS_ENTIDADE = StatusModelEnum.DELETADO;
			}
		}
		return list;
	}

	private List<ItemPedidoMO> ObterItensPedidoNovo(PedidoVendaMO pedidoVenda)
	{
		FiltroItemPedidoVO filtroItemPedidoVO = new FiltroItemPedidoVO();
		filtroItemPedidoVO.CODIGO_EMPRESA_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO.CODIGO_EMPRESA_ELETRONICO;
		filtroItemPedidoVO.NUMERO_PEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO.NUMERO_PEDIDO_ELETRONICO;
		filtroItemPedidoVO.SEQ_PEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO.SEQ_PEDIDO_ELETRONICO;
		filtroItemPedidoVO.CODIGO_TABELA = pedidoVenda.CODIGO_TABELA;
		filtroItemPedidoVO.CODIGO_GRUPO_COMISSAO = pedidoVenda.VENDEDOR.CODIGO_GRUPO;
		filtroItemPedidoVO.ESTADO_ORIGEM = LoginERP.EMPRESA_LOGADA.ESTADO;
		EnderecoClienteMO enderecoClienteMO = pedidoVenda.CLIENTE.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "EN");
		filtroItemPedidoVO.ESTADO_DESTINO = enderecoClienteMO.ESTADO;
		filtroItemPedidoVO.IMPRIME_NOTA_FISCAL = pedidoVenda.TIPO_PEDIDO.IMPRIME_NOTA_FISCAL;
		ConfiguracaoTelaVendaVO vENDA = ConfigERP.PARAMETROS_TELA.VENDA;
		filtroItemPedidoVO.MANTER_DESCONTO_APLICADO_PEDIDO_ELETRONICO = vENDA.MANTER_DESCONTO_APLICADO_1_E_2_NOS_PEDIDOS_ELETRONICOS;
		filtroItemPedidoVO.CODIGO_TRIBUTACAO_TIPO_SIT_TRIB = pedidoVenda.CLIENTE.TRIBUTACAO.CODIGO_TRIBUTACAO_TIPO_SIT_TRIB;
		filtroItemPedidoVO.DEVOLUCAO_FORNECEDOR = pedidoVenda.TIPO_PEDIDO.DEVOLUCAO_FORNECEDOR;
		filtroItemPedidoVO.UTILIZA_SIT_TRIB_ESP_TP_PED = ConfigERP.PAR_CFG.UTILIZA_SIT_TRIB_ESP_TP_PED;
		filtroItemPedidoVO.UTILIZA_SITUACAO_TRIBUTACAO_ESP = pedidoVenda.TIPO_PEDIDO.UTILIZA_SITUACAO_TRIBUTACAO_ESP;
		filtroItemPedidoVO.UTILIZA_PRECO_CUSTO = pedidoVenda.TIPO_PEDIDO.UTILIZA_PRECO_CUSTO;
		return (BaseDAL as ItemPedidoDAL).ObterItensPedido(filtroItemPedidoVO);
	}

	public void RemoverItens(List<ItemPedidoMO> itens, Predicate<ItemPedidoMO> condicao)
	{
		itens.RemoveAll(condicao);
	}

	private void ValidarItensAtendidos(PedidoVendaMO pedidoVenda, List<ItemPedidoMO> Itens)
	{
		int num = (BaseDAL as ItemPedidoDAL).QuantidadeItensAtendidosPedidoEletronico(pedidoVenda.PEDIDO_ELETRONICO);
		if (num == Itens.Count)
		{
			return;
		}
		MyException ex = new MyException();
		int num2 = ((pedidoVenda.PEDIDO_ELETRONICO != null) ? pedidoVenda.PEDIDO_ELETRONICO.NUMERO_PEDIDO_ELETRONICO : 0);
		if (pedidoVenda.TIPO_PEDIDO.INVENTARIO)
		{
			ex.AddErro("O Tipo Pedido informado é do tipo Inventario. Ped. Ele: {0}", num2);
		}
		else
		{
			ex.AddAviso("Foram cortados {0} produtos do Pedido Eletrônico: {1}", Itens.Count - num, num2);
		}
		foreach (ItemPedidoMO Iten in Itens)
		{
			if (Iten.QUANTIDADE <= 0m)
			{
				Iten.STATUS_ENTIDADE = StatusModelEnum.DELETADO;
			}
		}
		ex.ThrowException();
	}

	public void CalcularValorComImpostos(ItemPedidoMO itemPedido, TipoPedidoVO tipoPedido)
	{
		bool aCRESCIMO_DIF_ICM = ConfigERP.PAR_CFG.ACRESCIMO_DIF_ICM;
		if (itemPedido.PRECO_NOTA_FISCAL.ToDecimal() * itemPedido.QUANTIDADE != 0m && !tipoPedido.DEVOLUCAO_FORNECEDOR && !tipoPedido.INVENTARIO)
		{
			decimal num = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			itemPedido.DESCONTO_APLICADO_REAL = (itemPedido.PRECO_TABELA * itemPedido.QUANTIDADE - itemPedido.PRECO_UNITARIO.ToDecimal() * itemPedido.QUANTIDADE) / (itemPedido.PRECO_TABELA.ToDecimal() * itemPedido.QUANTIDADE);
			itemPedido.DESCONTO_APLICADO_REAL = Math.Round(itemPedido.DESCONTO_APLICADO_REAL.ToDecimal(), 4, MidpointRounding.AwayFromZero);
		}
		itemPedido.VALOR_ITEM_TABELA = itemPedido.QUANTIDADE * itemPedido.PRECO_BASICO.ToDecimal();
		itemPedido.VALOR_IPI = Math.Round((itemPedido.PRECO_UNITARIO * (decimal?)itemPedido.ALIQUOTA_IPI.ToDecimal()).ToDecimal(), 2, MidpointRounding.AwayFromZero);
		decimal? pERCDESCCAMPANHA = itemPedido.PERCDESCCAMPANHA;
		if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
		{
			pERCDESCCAMPANHA = itemPedido.PERC_DESC_CAMPANHA_COMBO;
			if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue) || !(itemPedido.UNIDADE_PEDIDA == itemPedido.UNIDADE_VENDA))
			{
				if (itemPedido.UNIDADE_PEDIDA == itemPedido.UNIDADE_VENDA)
				{
					itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal();
					itemPedido.VALOR_UNITARIO_VENDA = itemPedido.VALOR_UNITARIO_PEDIDA.ToDecimal();
				}
				else if (itemPedido.INDICE_RELACAO_VENDA == "MENOR")
				{
					itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE * itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
					itemPedido.VALOR_UNITARIO_VENDA = itemPedido.PRECO_UNITARIO / (decimal?)itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
				}
				else
				{
					itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE / itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
					itemPedido.VALOR_UNITARIO_VENDA = itemPedido.PRECO_UNITARIO * (decimal?)itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
					itemPedido.INDICE_RELACAO_VENDA = "MAIOR";
				}
				goto IL_04c4;
			}
		}
		if (itemPedido.INDICE_RELACAO_VENDA == "MENOR")
		{
			itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE * itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
			itemPedido.VALOR_UNITARIO_VENDA = itemPedido.PRECO_UNITARIO / (decimal?)itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
			itemPedido.VALOR_UNITARIO_PEDIDA = itemPedido.VALOR_UNITARIO_VENDA;
			itemPedido.TOTAL_PEDIDA = itemPedido.VALOR_UNITARIO_PEDIDA.ToDecimal() * itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal();
		}
		else
		{
			itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE / itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
			itemPedido.VALOR_UNITARIO_VENDA = itemPedido.PRECO_UNITARIO * (decimal?)itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
			itemPedido.INDICE_RELACAO_VENDA = "MAIOR";
			itemPedido.VALOR_UNITARIO_PEDIDA = itemPedido.VALOR_UNITARIO_VENDA;
			itemPedido.TOTAL_PEDIDA = itemPedido.VALOR_UNITARIO_PEDIDA.ToDecimal() * itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal();
		}
		goto IL_04c4;
		IL_04c4:
		if (itemPedido.QUANTIDADE > 0m)
		{
			itemPedido.TOTAL = itemPedido.VALOR_UNITARIO_VENDA.ToDecimal() * itemPedido.QUANTIDADE_UNIDADE_VENDA.ToDecimal();
		}
		if (aCRESCIMO_DIF_ICM)
		{
			itemPedido.VALOR_ACRESCIDO_DIF_ICMS = itemPedido.TOTAL * itemPedido.PERCENTUAL_ACRESCIDO_DIF_ICMS / (1m + itemPedido.PERCENTUAL_ACRESCIDO_DIF_ICMS);
		}
		if (!itemPedido.DESCONTO_APLICADO.HasValue)
		{
			itemPedido.DESCONTO_APLICADO = default(decimal);
		}
	}

	public void CalcularValorComDesconto(ItemPedidoMO itemPedido, TipoPedidoVO tipoPedido)
	{
		bool flag = ConfigERP.PARAMETROS_TELA.VENDA.MANTER_DESCONTO_APLICADO_1_E_2_NOS_PEDIDOS_ELETRONICOS;
		bool uNID_PEDIDA = ConfigERP.PAR_CFG.UNID_PEDIDA;
		bool pRECO_VENDA_4_DEC = ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC;
		decimal value = default(decimal);
		if (itemPedido.CONSIDERA_PRECO_PROMOCAO)
		{
			flag = false;
		}
		if (!uNID_PEDIDA)
		{
			itemPedido.INDICE_RELACAO = "MAIOR";
			itemPedido.FATOR_ESTOQUE_PEDIDA = 1.0;
			itemPedido.QUANTIDADE_UNIDADE_PEDIDA = itemPedido.QUANTIDADE;
			itemPedido.UNIDADE_PEDIDA = itemPedido.UNIDADE;
			itemPedido.VALOR_UNITARIO_PEDIDA = itemPedido.PRECO_UNITARIO;
			itemPedido.TOTAL_PEDIDA = itemPedido.TOTAL;
		}
		decimal value2;
		decimal qUANTIDADE;
		if (tipoPedido.DEVOLUCAO_FORNECEDOR || tipoPedido.INVENTARIO)
		{
			itemPedido.PRECO_NOTA_FISCAL = itemPedido.PRECO_UNITARIO;
			itemPedido.PRECO_TABELA = itemPedido.PRECO_UNITARIO.Value;
			itemPedido.PRECO_BASICO = itemPedido.PRECO_UNITARIO;
			itemPedido.DESCONTO_APLICADO_REAL = default(decimal);
			if (!flag)
			{
				itemPedido.DESCONTO_APLICADO = default(decimal);
			}
		}
		else
		{
			decimal? num = itemPedido.PRECO_NOTA_FISCAL * (decimal?)itemPedido.QUANTIDADE;
			if (!((num.GetValueOrDefault() == default(decimal)) & num.HasValue) && !flag)
			{
				if (uNID_PEDIDA)
				{
					if (pRECO_VENDA_4_DEC)
					{
						if (itemPedido.INDICE_RELACAO == "MAIOR")
						{
							value = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal() * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
						}
						else if (itemPedido.INDICE_RELACAO == "MENOR")
						{
							value = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal() / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
						}
					}
					else if (itemPedido.INDICE_RELACAO == "MAIOR")
					{
						value = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal() * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal(), 2, MidpointRounding.AwayFromZero);
					}
					else if (itemPedido.INDICE_RELACAO == "MENOR")
					{
						value = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal() / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal(), 2, MidpointRounding.AwayFromZero);
					}
					value2 = 1;
					decimal? num2 = itemPedido.VALOR_UNITARIO_PEDIDA / (decimal?)value;
					itemPedido.DESCONTO_APLICADO = Math.Round(((decimal?)value2 - num2).ToDecimal(), 4, MidpointRounding.AwayFromZero).ToDecimal();
				}
				else
				{
					value = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
					value2 = value * itemPedido.QUANTIDADE;
					qUANTIDADE = itemPedido.QUANTIDADE;
					decimal? pRECO_UNITARIO = itemPedido.PRECO_UNITARIO;
					decimal? num3 = (decimal?)qUANTIDADE * pRECO_UNITARIO;
					itemPedido.DESCONTO_APLICADO = Math.Round((((decimal?)value2 - num3) / (itemPedido.PRECO_NOTA_FISCAL * (decimal?)itemPedido.QUANTIDADE)).ToDecimal(), 4, MidpointRounding.AwayFromZero).ToDecimal();
				}
			}
		}
		itemPedido.PERCDESCCAMPANHA = (itemPedido.PERCDESCCAMPANHA.Equals(null) ? new decimal?(default(decimal)) : itemPedido.PERCDESCCAMPANHA);
		itemPedido.PERC_DESC_CAMPANHA_COMBO = (itemPedido.PERC_DESC_CAMPANHA_COMBO.Equals(null) ? new decimal?(default(decimal)) : itemPedido.PERC_DESC_CAMPANHA_COMBO);
		decimal? pERCDESCCAMPANHA = itemPedido.PERCDESCCAMPANHA;
		if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
		{
			pERCDESCCAMPANHA = itemPedido.PERC_DESC_CAMPANHA_COMBO;
			if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
			{
				goto IL_06c7;
			}
		}
		itemPedido.DESCONTO_02 = itemPedido.DESCONTO_02 + itemPedido.PERCDESCCAMPANHA + itemPedido.PERC_DESC_CAMPANHA_COMBO;
		decimal num4 = itemPedido.DESCONTO_APLICADO.ToDecimal();
		value2 = 1;
		qUANTIDADE = 1;
		decimal? dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
		pERCDESCCAMPANHA = (decimal?)qUANTIDADE - dESCONTO_APLICADO;
		qUANTIDADE = 1;
		dESCONTO_APLICADO = itemPedido.DESCONTO_02;
		decimal? num5 = pERCDESCCAMPANHA * ((decimal?)qUANTIDADE - dESCONTO_APLICADO);
		itemPedido.DESCONTO_APLICADO = (decimal?)value2 - num5;
		goto IL_06c7;
		IL_06c7:
		if (!flag)
		{
			decimal? num = itemPedido.PERCDESCCAMPANHA;
			if ((num.GetValueOrDefault() == default(decimal)) & num.HasValue)
			{
				num = itemPedido.PERC_DESC_CAMPANHA_COMBO;
				if ((num.GetValueOrDefault() == default(decimal)) & num.HasValue)
				{
					itemPedido.DESCONTO_01 = itemPedido.DESCONTO_APLICADO.ToDecimal();
					itemPedido.DESCONTO_02 = default(decimal);
				}
			}
		}
		if (pRECO_VENDA_4_DEC)
		{
			itemPedido.PRECO_TABELA = Math.Round(itemPedido.PRECO_TABELA.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
		}
		else
		{
			itemPedido.PRECO_TABELA = Math.Round(itemPedido.PRECO_TABELA.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		}
		itemPedido.TOTAL_ORIGINAL = itemPedido.QUANTIDADE * itemPedido.PRECO_NOTA_FISCAL.ToDecimal();
		itemPedido.TOTAL_PEDIDA = itemPedido.VALOR_UNITARIO_PEDIDA.ToDecimal() * itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal();
		itemPedido.VALOR_DOS_DESCONTOS = (itemPedido.DESCONTO_APLICADO.ToDecimal() - itemPedido.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.ToDecimal()) * itemPedido.TOTAL_ORIGINAL;
		itemPedido.VALOR_COM_DESCONTO_PERMITIDO = itemPedido.TOTAL_ORIGINAL;
	}

	public List<ItemPedidoMO> ObterItensNaoBonificados(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda != null && pedidoVenda.ITENS != null)
		{
			return pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => !x.BONIFICADO.ToBool());
		}
		return new List<ItemPedidoMO>();
	}

	public void RatearDiferencaValorDescontoNoItens(List<ItemPedidoMO> itensPedidoRateio, decimal descGeralPedido, decimal totalSomaDescontoItens)
	{
		ProdutoBLL produtoBLL = new ProdutoBLL();
		if (itensPedidoRateio.Count() == 1)
		{
			ItemPedidoMO itemPedidoMO = itensPedidoRateio.First();
			itemPedidoMO.VALOR_DESCONTO_GERAL += (decimal?)(descGeralPedido - totalSomaDescontoItens);
			return;
		}
		while (totalSomaDescontoItens < descGeralPedido)
		{
			foreach (ItemPedidoMO item in itensPedidoRateio)
			{
				decimal? vALOR_DESCONTO_GERAL = item.VALOR_DESCONTO_GERAL;
				if (!((vALOR_DESCONTO_GERAL.GetValueOrDefault() > default(decimal)) & vALOR_DESCONTO_GERAL.HasValue))
				{
					break;
				}
				if (totalSomaDescontoItens > descGeralPedido)
				{
					totalSomaDescontoItens -= 0.01m;
					item.VALOR_DESCONTO_GERAL -= (decimal?)0.01m;
					continue;
				}
				if (totalSomaDescontoItens < descGeralPedido)
				{
					totalSomaDescontoItens += 0.01m;
					item.VALOR_DESCONTO_GERAL += (decimal?)0.01m;
					continue;
				}
				break;
			}
		}
	}

	public void LimparValoresVerbasDeTodosItensPedido(PedidoVendaMO pedidoVenda)
	{
		pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO x)
		{
			LimparValoresVerbasDoItemPedido(x);
		});
	}

	public void LimparValoresVerbasDoItemPedido(ItemPedidoMO itemPedido)
	{
		itemPedido.VALOR_VERBA = default(decimal);
		itemPedido.VALOR_VERBA_EMPRESA = default(decimal);
		itemPedido.VALOR_VERBA_EQUIPE = default(decimal);
	}

	public void LimparValoresComissaoDeTodosItensPedido(PedidoVendaMO pedidoVenda)
	{
		pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO x)
		{
			x.PERCENTUAL_COMISSAO = 0m;
			x.REDUCAO_COMISSAO = 0m;
			x.VALOR_COMISSAO = 0m;
			x.VALOR_COMISSAO_VENDEDOR = 0m;
			x.VALOR_COMISSAO_LANCADOR = 0m;
		});
	}

	public void CalcularTotaisPedidoVenda(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		ProdutoBLL produtoBLL = new ProdutoBLL();
		TotalPedidoVendaVO totalPedidoVendaVO = new TotalPedidoVendaVO();
		totalPedidoVendaVO.VALOR_TOTAL = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => Math.Round(x.TOTAL, 2, MidpointRounding.AwayFromZero));
		totalPedidoVendaVO.VALOR_ORIGINAL = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.TOTAL_ORIGINAL);
		totalPedidoVendaVO.VALOR_TOTAL_PEDIDO = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => Math.Round(x.TOTAL_PEDIDA, 2, MidpointRounding.AwayFromZero));
		totalPedidoVendaVO.VALOR_TOTAL_DESCONTO = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_DOS_DESCONTOS);
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		decimal num4 = default(decimal);
		decimal num5 = default(decimal);
		decimal num6 = default(decimal);
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			num2 += Math.Round(iTEN.PRECO_BASICO.ToDecimal() * iTEN.QUANTIDADE * (iTEN.DESCONTO_APLICADO.ToDecimal() + iTEN.PERCDESCCAMPANHA.ToDecimal() + iTEN.PERC_DESC_CAMPANHA_COMBO.ToDecimal() - iTEN.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.ToDecimal()), 4, MidpointRounding.AwayFromZero);
			num4 += iTEN.TOTAL_ORIGINAL * iTEN.DESCONTO_APLICADO.ToDecimal() * iTEN.QUANTIDADE;
			num5 += Math.Round(iTEN.TOTAL_ORIGINAL * iTEN.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.ToDecimal(), 4, MidpointRounding.AwayFromZero) * iTEN.QUANTIDADE;
			if (produtoBLL.VerificaDescGeralProd(iTEN))
			{
				num6 += iTEN.TOTAL;
			}
		}
		if (totalPedidoVendaVO.VALOR_ORIGINAL != 0m)
		{
			num = num2 / totalPedidoVendaVO.VALOR_ORIGINAL;
			num3 = num4 / totalPedidoVendaVO.VALOR_ORIGINAL;
		}
		num2 = totalPedidoVendaVO.VALOR_ORIGINAL * num;
		pedidoVenda.VALOR_DESCONTO_GERAL = (totalPedidoVendaVO.VALOR_ORIGINAL - num2) * pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		decimal num7 = num2 + pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal();
		pedidoVenda.VALOR_TOTAL = Math.Round(totalPedidoVendaVO.VALOR_ORIGINAL - num7, 2, MidpointRounding.AwayFromZero);
		if (pedidoVenda.TIPO_DESCONTO_GERAL == "PE" && !ConfigERP.PAR_CFG.DESCGERALNAORECALCULACORTE)
		{
			pedidoVenda.VALOR_DESCONTO_GERAL = Math.Round(totalPedidoVendaVO.VALOR_TOTAL * pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		}
		else
		{
			if (pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal() != 0m)
			{
				if (totalPedidoVendaVO.VALOR_TOTAL != 0m)
				{
					pedidoVenda.PERCENTUAL_DESCONTO_GERAL = Math.Round(pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal() / totalPedidoVendaVO.VALOR_TOTAL, 2, MidpointRounding.AwayFromZero);
				}
			}
			else
			{
				pedidoVenda.PERCENTUAL_DESCONTO_GERAL = default(decimal);
			}
			if (ConfigERP.PAR_CFG.DESCGERALNAORECALCULACORTE)
			{
				pedidoVenda.TIPO_DESCONTO_GERAL = "VA";
				pedidoVenda.VALOR_DESCONTO_GERAL = pedidoEletronico.VALOR_DESCONTO_GERAL;
				if (pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal() != 0m)
				{
					pedidoVenda.PERCENTUAL_DESCONTO_GERAL = Math.Round(pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal() / totalPedidoVendaVO.VALOR_TOTAL, 4, MidpointRounding.AwayFromZero);
					decimal? pERCENTUAL_DESCONTO_GERAL = pedidoVenda.PERCENTUAL_DESCONTO_GERAL;
					decimal num8 = 1;
					if ((pERCENTUAL_DESCONTO_GERAL.GetValueOrDefault() > num8) & pERCENTUAL_DESCONTO_GERAL.HasValue)
					{
						pedidoVenda.VALOR_DESCONTO_GERAL = default(decimal);
						pedidoVenda.PERCENTUAL_DESCONTO_GERAL = default(decimal);
					}
				}
				else
				{
					pedidoVenda.PERCENTUAL_DESCONTO_GERAL = default(decimal);
				}
			}
			if (ConfigERP.PAR_CFG.DESCGERALPROD)
			{
				if (num6 != 0m)
				{
					if (pedidoVenda.TIPO_DESCONTO_GERAL == "PE")
					{
						pedidoVenda.VALOR_DESCONTO_GERAL = Math.Round(num6 * pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
					}
					else
					{
						decimal? pERCENTUAL_DESCONTO_GERAL = pedidoVenda.VALOR_DESCONTO_GERAL;
						if (((pERCENTUAL_DESCONTO_GERAL.GetValueOrDefault() > default(decimal)) & pERCENTUAL_DESCONTO_GERAL.HasValue) && pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal() != 0m)
						{
							pedidoVenda.PERCENTUAL_DESCONTO_GERAL = Math.Round(pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal() / num6, 4, MidpointRounding.AwayFromZero);
							pERCENTUAL_DESCONTO_GERAL = pedidoVenda.PERCENTUAL_DESCONTO_GERAL;
							decimal num8 = 1;
							if ((pERCENTUAL_DESCONTO_GERAL.GetValueOrDefault() > num8) & pERCENTUAL_DESCONTO_GERAL.HasValue)
							{
								pedidoVenda.VALOR_DESCONTO_GERAL = default(decimal);
								pedidoVenda.PERCENTUAL_DESCONTO_GERAL = default(decimal);
							}
						}
						else
						{
							pedidoVenda.PERCENTUAL_DESCONTO_GERAL = default(decimal);
						}
					}
				}
				else
				{
					pedidoVenda.VALOR_DESCONTO_GERAL = default(decimal);
					pedidoVenda.PERCENTUAL_DESCONTO_GERAL = default(decimal);
				}
			}
		}
		num7 = Math.Round(num2 + pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal(), 4, MidpointRounding.AwayFromZero);
		pedidoVenda.VALOR_TOTAL = Math.Round(totalPedidoVendaVO.VALOR_TOTAL_PEDIDO.ToDecimal() - pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		TargetServicosBLL targetServicosBLL = new TargetServicosBLL();
		TargetServicosMO targetServicosMO = new TargetServicosMO();
		string webServiceUrl = "";
		targetServicosMO = targetServicosBLL.ObterTargetServicosPeloId(10);
		if (!string.IsNullOrEmpty(targetServicosMO.EnderecoServidor) && targetServicosMO.PortaAPI >= 0)
		{
			webServiceUrl = $"http://{targetServicosMO.EnderecoServidor}:{targetServicosMO.PortaAPI}/api/imposto";
		}
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		foreach (ItemPedidoMO iTEN2 in pedidoVenda.ITENS)
		{
			if (ConfigERP.PAR_CFG.DESCGERALPROD)
			{
				if (produtoBLL.VerificaDescGeralProd(iTEN2))
				{
					iTEN2.PERCENTUAL_DESCONTO_GERAL = pedidoVenda.PERCENTUAL_DESCONTO_GERAL;
					iTEN2.VALOR_DESCONTO_GERAL = iTEN2.PRECO_UNITARIO.ToDecimal() * iTEN2.QUANTIDADE * pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
				}
				else
				{
					iTEN2.PERCENTUAL_DESCONTO_GERAL = default(decimal);
					iTEN2.VALOR_DESCONTO_GERAL = default(decimal);
				}
				pedidoVendaBLL.CalcularImposto(pedidoVenda, iTEN2, ConfigERP.PARAMETROS_TELA.VENDA.PED_ELE_UTILIZA_API_IMPOSTO, webServiceUrl);
				iTEN2.VALOR_TOTAL_COM_IMPOSTOS = iTEN2.TOTAL * (1m - iTEN2.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) + iTEN2.VALOR_IMPOSTOS;
				iTEN2.VALOR_TOTAL_ORIGINAL_COM_IMPOSTOS = iTEN2.TOTAL_ORIGINAL * (1m - iTEN2.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) + iTEN2.VALOR_IMPOSTOS;
			}
			else
			{
				iTEN2.PERCENTUAL_DESCONTO_GERAL = pedidoVenda.PERCENTUAL_DESCONTO_GERAL;
				iTEN2.VALOR_DESCONTO_GERAL = iTEN2.PRECO_UNITARIO.ToDecimal() * iTEN2.QUANTIDADE * pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
				bool flag = iTEN2.INCIDE_ICMS_SUBST.Value || iTEN2.ST_ADICIONAL_ITEM;
				pedidoVendaBLL.CalcularImposto(pedidoVenda, iTEN2, ConfigERP.PARAMETROS_TELA.VENDA.PED_ELE_UTILIZA_API_IMPOSTO, webServiceUrl);
				iTEN2.VALOR_TOTAL_COM_IMPOSTOS = iTEN2.TOTAL * (1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) + iTEN2.VALOR_IMPOSTOS;
				iTEN2.VALOR_TOTAL_ORIGINAL_COM_IMPOSTOS = iTEN2.TOTAL_ORIGINAL * (1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) + iTEN2.VALOR_IMPOSTOS;
			}
		}
		decimal num9 = default(decimal);
		bool flag2 = pedidoVenda.TIPO_FRETE == "C" && ConfigERP.PARAMETROS_TELA.EMISSAO_NOTA_FISCAL.SOMA_FRETE_TIPO_CIF_NO_VALOR_DA_NOTA;
		bool flag3 = pedidoVenda.TIPO_FRETE == "F" && ConfigERP.PARAMETROS_TELA.EMISSAO_NOTA_FISCAL.SOMA_FRETE_TIPO_FOB_NO_VALOR_DA_NOTA;
		if (flag2 || flag3)
		{
			num9 = pedidoVenda.VALOR_FRETE.ToDecimal();
		}
		decimal num10 = default(decimal);
		if (pedidoVenda.TROCA != null && pedidoVenda.TROCA.TIPO_ABATIMENTO == "PN")
		{
			num10 = pedidoVenda.TROCA.VALOR_TOTAL;
		}
		TabelaPrecoBLL tabelaPrecoBLL = new TabelaPrecoBLL();
		TabelaPrecoMO tabelaPrecoMO = tabelaPrecoBLL.ObterPeloID(pedidoVenda.CODIGO_TABELA);
		if (tabelaPrecoMO.NF_PRECO_CHEIO_DESC_BOL.ToBool())
		{
			pedidoVenda.VALOR_TOTAL_NOTA_FISCAL = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_TOTAL_ORIGINAL_COM_IMPOSTOS) - num10 + num9;
		}
		else
		{
			pedidoVenda.VALOR_TOTAL_NOTA_FISCAL = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_TOTAL_COM_IMPOSTOS) - num10 + num9;
		}
		if (ConfigERP.PARAMETROS_TELA.VENDA.SOMA_NO_VALOR_TOTAL_DO_PRODUTO)
		{
			pedidoVenda.VALOR_TOTAL += pedidoVenda.VALOR_FRETE;
		}
	}

	public void ValidarLiberacaoFiscalItensPedido(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.ITENS.Exists((ItemPedidoMO i) => !i.LIBERACAO_FISCAL))
		{
			string menssage = $"Existem produtos não liberados pela area fiscal";
			throw new MyException(menssage);
		}
	}

	public void TratarQuantidadeItemPedido(ItemPedidoMO itemPedido)
	{
		if (itemPedido.UNIDADE_PEDIDA == itemPedido.UNIDADE && itemPedido.FATOR_ESTOQUE_PEDIDA == 1.0)
		{
			itemPedido.QUANTIDADE = itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal();
		}
		if (itemPedido.UNIDADE_PEDIDA == itemPedido.UNIDADE_VENDA && itemPedido.INDICE_RELACAO == itemPedido.INDICE_RELACAO_VENDA && itemPedido.FATOR_ESTOQUE_PEDIDA == itemPedido.FATOR_ESTOQUE_VENDA.ToDouble())
		{
			itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE_UNIDADE_PEDIDA;
		}
		else if (itemPedido.INDICE_RELACAO_VENDA == "MENOR")
		{
			itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE * itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
		}
		else
		{
			itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE / itemPedido.FATOR_ESTOQUE_VENDA.ToDecimal();
		}
	}

	public void CarregarVolumeItensPedido(PedidoVendaMO pedidoVenda)
	{
		if ((ConfigERP.PAR_CFG.VOL_PEDVDA_TIPO != TipoVolumePedidoEnum.INFORMACAO_MANUAL || ConfigERP.PAR_CFG.VOL_PEDVDA_ORIGEM != OrigemVolumePedidoEnum.FILA_FATURAMENTO || !ConfigERP.PAR_CFG.VOLPEDVDAOBRIGARINFORMACAO) && !ConfigERP.PAR_CFG.FILA_SEPARACAO)
		{
			pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO i)
			{
				i.QUANTIDADE_VOLUMES = i.QUANTIDADE_UNIDADE_VENDA.ToDecimal();
			});
		}
	}

	public void CarregarVolumeItensPedidoSemInfoVolumes(PedidoVendaMO pedidoVenda)
	{
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => !x.INFO_VOLUMES);
		foreach (ItemPedidoMO item in list)
		{
			item.QUANTIDADE_VOLUMES = item.QUANTIDADE;
		}
	}

	public void ValidarLimiteDescontoItemPedido(ItemPedidoMO item)
	{
		bool flag = !item.BONIFICADO.ToBool();
		bool flag2 = !(item.SEQ_KIT_PROMOCAO > 0);
		decimal? dESCONTO_PERMITIDO_PRODUTO_QUANTIDADE = item.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE;
		bool flag3 = (dESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.GetValueOrDefault() > default(decimal)) & dESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.HasValue;
		if (flag && flag2 && flag3 && item.DESCONTO_APLICADO > item.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE)
		{
			new MyException("Desconto permitido para o item foi extrapolado").ThrowException();
		}
	}

	public void ValidarDescontoItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		decimal? dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
		decimal num = 99.9999m;
		if (!((dESCONTO_APLICADO.GetValueOrDefault() > num) & dESCONTO_APLICADO.HasValue))
		{
			dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
			num = -99.999m;
			if (!((dESCONTO_APLICADO.GetValueOrDefault() < num) & dESCONTO_APLICADO.HasValue))
			{
				PrecoBLL precoBLL = new PrecoBLL();
				PrecoMO precoMO = precoBLL.ObterPrecoProdutoPelaTabelaPreco(itemPedido.CODIGO_PRODUTO, pedidoVenda.CODIGO_TABELA);
				itemPedido.LIMITE_ACRESCIMO = precoMO.LIMITE_ACRESCIMO;
				decimal num2 = default(decimal);
				if (itemPedido.TOTAL_ORIGINAL != 0m)
				{
					num2 = itemPedido.TOTAL_ORIGINAL * (itemPedido.DESCONTO_APLICADO.ToDecimal() * -1m) / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal() / (itemPedido.TOTAL_ORIGINAL / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal());
					num2 = Math.Round(num2, 4, MidpointRounding.AwayFromZero);
					dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
					num = 1;
					bool flag = (dESCONTO_APLICADO.GetValueOrDefault() > num) & dESCONTO_APLICADO.HasValue;
					int num3;
					if (itemPedido.LIMITE_ACRESCIMO.HasValue)
					{
						dESCONTO_APLICADO = itemPedido.LIMITE_ACRESCIMO;
						num = num2;
						num3 = (((dESCONTO_APLICADO.GetValueOrDefault() < num) & dESCONTO_APLICADO.HasValue) ? 1 : 0);
					}
					else
					{
						num3 = 0;
					}
					bool flag2 = (byte)num3 != 0;
					if (flag || flag2)
					{
						string mensagem = $"Desconto inválido para o produto: {itemPedido.CODIGO_PRODUTO}";
						MyException ex = new MyException();
						ex.AddAviso(mensagem);
						ex.ThrowException();
					}
				}
				return;
			}
		}
		throw new MyException("Desconto alem dos limites permitidos");
	}

	public bool ValidarValorZeroItemPedido(ItemPedidoMO item)
	{
		bool result = true;
		bool flag = !item.BONIFICADO.ToBool();
		decimal? pRECO_UNITARIO = item.PRECO_UNITARIO;
		bool flag2 = !((pRECO_UNITARIO.GetValueOrDefault() > default(decimal)) & pRECO_UNITARIO.HasValue);
		if (flag && flag2)
		{
			result = false;
		}
		return result;
	}

	public void ValidarPapelCortado(PedidoVendaMO pedidoVenda)
	{
		bool flag = pedidoVenda.ITENS.First().PAPEL_CORTADO.ToBool();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			if (flag != iTEN.PAPEL_CORTADO.ToBool())
			{
				throw new MyException("Não é permitido conter itens do tipo papel cortado com não cortado");
			}
		}
	}
}
