using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class ProdutoComissaoBLL : EntidadeBaseBLL<ProdutoComissaoMO>
{
	protected override EntidadeBaseDAL<ProdutoComissaoMO> GetInstanceDAL()
	{
		return new ProdutoComissaoDAL();
	}

	public void CalcularRedutorComissao(ItemPedidoMO itemPedido, DescontosPedidoVO descontosPedido, PedidoVendaMO pedidoVenda)
	{
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		if (pAR_CFG.TP_REDUTOR_COMISSAO == "CHEI")
		{
			if (descontosPedido.PERCENTUAL_DESCONTO > 0m)
			{
				if (descontosPedido.PERCENTUAL_DESCONTO - descontosPedido.DESCONTO_PERMITIDO_CLIENTE <= 0m)
				{
					descontosPedido.PERCENTUAL_DESCONTO = 0m;
				}
				else
				{
					descontosPedido.PERCENTUAL_DESCONTO -= descontosPedido.DESCONTO_PERMITIDO_CLIENTE;
				}
			}
		}
		else if (pAR_CFG.TP_REDUTOR_COMISSAO == "LIQU" && descontosPedido.PERCENTUAL_DESCONTO > 0m)
		{
			if (descontosPedido.PERCENTUAL_DESCONTO - descontosPedido.DESCONTO_PERMITIDO_CLIENTE <= 0m)
			{
				descontosPedido.PERCENTUAL_DESCONTO = 0m;
			}
			else if (itemPedido.VALOR_ITEM_TABELA > 0m)
			{
				decimal num = itemPedido.VALOR_ITEM_TABELA * descontosPedido.DESCONTO_PERMITIDO_CLIENTE;
				decimal num2 = itemPedido.VALOR_ITEM_TABELA * descontosPedido.PERCENTUAL_DESCONTO;
				decimal num3 = num2 - num;
				descontosPedido.PERCENTUAL_DESCONTO = num3 / (itemPedido.VALOR_ITEM_TABELA * (1m - descontosPedido.DESCONTO_PERMITIDO_CLIENTE));
			}
		}
		decimal value = ObterRedutorComissao(pedidoVenda, itemPedido, descontosPedido.PERCENTUAL_DESCONTO, pedidoVenda.VENDEDOR);
		itemPedido.REDUCAO_COMISSAO = value;
	}

	private decimal ObterRedutorComissao(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, decimal percentualDesconto, VendedorMO vendedor)
	{
		return (BaseDAL as ProdutoComissaoDAL).ObterRedutorComissao(pedidoVenda, itemPedido, percentualDesconto, vendedor);
	}

	private void CalcularValorBaseComissaoPeloTipo(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		int qTDE_CASAS_DECIMAIS = 4;
		if (!pAR_CFG.PRECO_VENDA_4_DEC || (pAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && (!pAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || !cLIENTE.PRECO_VENDA_4_DEC)))
		{
			qTDE_CASAS_DECIMAIS = 2;
		}
		CalcularComissaoParamVO calcularComissaoParamVO = new CalcularComissaoParamVO();
		calcularComissaoParamVO.CLIENTE = pedidoVenda.CLIENTE;
		calcularComissaoParamVO.ITEM_PEDIDO = itemPedido;
		calcularComissaoParamVO.PARCFG = ConfigERP.PAR_CFG;
		calcularComissaoParamVO.PEDIDO_VENDA = pedidoVenda;
		calcularComissaoParamVO.QTDE_CASAS_DECIMAIS = qTDE_CASAS_DECIMAIS;
		string tP_VL_BASE_COMISSAO = pAR_CFG.TP_VL_BASE_COMISSAO;
		string text = tP_VL_BASE_COMISSAO;
		if (text == null)
		{
			return;
		}
		int length = text.Length;
		if (length != 4)
		{
			return;
		}
		switch (text[1])
		{
		case 'D':
			if (!(text == "VDCH"))
			{
				if (text == "VDST")
				{
					CalcularValorBaseComissaoVDST(calcularComissaoParamVO);
				}
			}
			else
			{
				CalcularValorBaseComissaoVDCH(calcularComissaoParamVO);
			}
			break;
		case 'T':
			if (text == "CTFI")
			{
				CalcularValorBaseComissaoCTFI(calcularComissaoParamVO);
			}
			break;
		case 'G':
			if (text == "MGBR")
			{
				CalcularValorBaseComissaoMGBR(calcularComissaoParamVO);
			}
			break;
		case 'C':
			if (text == "VCDF")
			{
				CalcularValorBaseComissaoVCDF(calcularComissaoParamVO);
			}
			break;
		case 'F':
			if (text == "DFST")
			{
				CalcularValorBaseComissaoDFST(calcularComissaoParamVO);
			}
			break;
		case 'E':
			if (text == "DESO")
			{
				CalcularValorBaseComissaoDESO(calcularComissaoParamVO);
			}
			break;
		}
	}

	private void CalcularValorBaseComissaoVCDF(CalcularComissaoParamVO parametro)
	{
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal num = pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		decimal? num2 = iTEM_PEDIDO.PRECO_UNITARIO * (decimal?)(1m - num);
		decimal value = 1;
		decimal? pERCENTUAL_DESCONTO_FINANCEIRO = iTEM_PEDIDO.PERCENTUAL_DESCONTO_FINANCEIRO;
		iTEM_PEDIDO.VALOR_BASE_COMISSAO = num2 * ((decimal?)value - pERCENTUAL_DESCONTO_FINANCEIRO);
	}

	private void CalcularValorBaseComissaoMGBR(CalcularComissaoParamVO parametro)
	{
		ConfiguracaoVO pARCFG = parametro.PARCFG;
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal num = pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		iTEM_PEDIDO.VALOR_BASE_COMISSAO = default(decimal);
		if (!(iTEM_PEDIDO.QUANTIDADE == 0m))
		{
			decimal num2 = default(decimal);
			switch (pARCFG.TP_CUSTO_COMIS_MG)
			{
			case "CUE":
				num2 = iTEM_PEDIDO.CUSTO_CUE.ToDecimal();
				break;
			case "CMP":
				num2 = iTEM_PEDIDO.CUSTO_CMP.ToDecimal();
				break;
			case "CRP":
				num2 = iTEM_PEDIDO.CUSTO_AV.ToDecimal();
				break;
			}
			iTEM_PEDIDO.VALOR_BASE_COMISSAO = iTEM_PEDIDO.PRECO_BASICO * (decimal?)(1m - iTEM_PEDIDO.DESCONTO_APLICADO.ToDecimal()) * (decimal?)(1m - num) - (decimal?)(num2 / iTEM_PEDIDO.QUANTIDADE);
		}
	}

	private void CalcularValorBaseComissaoCTFI(CalcularComissaoParamVO parametro)
	{
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal? pRECO_BASICO = iTEM_PEDIDO.PRECO_BASICO;
		decimal value = 1;
		decimal? pERCENTUAL_DESCONTO_FINANCEIRO = iTEM_PEDIDO.PERCENTUAL_DESCONTO_FINANCEIRO;
		iTEM_PEDIDO.VALOR_BASE_COMISSAO = pRECO_BASICO * ((decimal?)value - pERCENTUAL_DESCONTO_FINANCEIRO) * (decimal?)(1m - pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) * (decimal?)(1m - iTEM_PEDIDO.DESCONTO_APLICADO.ToDecimal());
	}

	private void CalcularValorBaseComissaoVDCH(CalcularComissaoParamVO parametro)
	{
		ConfiguracaoVO pARCFG = parametro.PARCFG;
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal num = pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		int qTDE_CASAS_DECIMAIS = parametro.QTDE_CASAS_DECIMAIS;
		if (pARCFG.UNID_VDA_VAR)
		{
			if (iTEM_PEDIDO.INDICE_RELACAO_VENDA == "MENOR")
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) * iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
				return;
			}
			decimal num2 = iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
			iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) / ((num2 == 0m) ? 1m : num2);
		}
		else
		{
			iTEM_PEDIDO.VALOR_BASE_COMISSAO = parametro.ITEM_PEDIDO.PRECO_UNITARIO * (decimal?)(1m - num);
		}
	}

	private void CalcularValorBaseComissaoVDST(CalcularComissaoParamVO parametro)
	{
		ConfiguracaoVO pARCFG = parametro.PARCFG;
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal num = pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		int qTDE_CASAS_DECIMAIS = parametro.QTDE_CASAS_DECIMAIS;
		if (pARCFG.UNID_VDA_VAR)
		{
			if (iTEM_PEDIDO.INDICE_RELACAO_VENDA == "MENOR")
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) * iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
			}
			else
			{
				decimal num2 = iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) / ((num2 == 0m) ? 1m : num2);
			}
		}
		else
		{
			iTEM_PEDIDO.VALOR_BASE_COMISSAO = parametro.ITEM_PEDIDO.PRECO_UNITARIO * (decimal?)(1m - num);
		}
		if (iTEM_PEDIDO.QUANTIDADE > 0m)
		{
			decimal? vALOR_ICMS_SUBST = iTEM_PEDIDO.VALOR_ICMS_SUBST;
			if ((vALOR_ICMS_SUBST.GetValueOrDefault() > default(decimal)) & vALOR_ICMS_SUBST.HasValue)
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO += (decimal?)decimal.Divide(iTEM_PEDIDO.VALOR_ICMS_SUBST.ToDecimal(), iTEM_PEDIDO.QUANTIDADE.ToDecimal());
			}
		}
	}

	private void CalcularValorBaseComissaoDFST(CalcularComissaoParamVO parametro)
	{
		ConfiguracaoVO pARCFG = parametro.PARCFG;
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal num = pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		int qTDE_CASAS_DECIMAIS = parametro.QTDE_CASAS_DECIMAIS;
		if (pARCFG.UNID_VDA_VAR)
		{
			if (iTEM_PEDIDO.INDICE_RELACAO_VENDA == "MENOR")
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) * iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
			}
			else
			{
				decimal num2 = iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) / ((num2 == 0m) ? 1m : num2);
			}
		}
		else
		{
			iTEM_PEDIDO.VALOR_BASE_COMISSAO = parametro.ITEM_PEDIDO.PRECO_UNITARIO * (decimal?)(1m - num);
		}
		if (iTEM_PEDIDO.QUANTIDADE > 0m)
		{
			decimal? vALOR_ICMS_SUBST = iTEM_PEDIDO.VALOR_ICMS_SUBST;
			if ((vALOR_ICMS_SUBST.GetValueOrDefault() > default(decimal)) & vALOR_ICMS_SUBST.HasValue)
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO += (decimal?)decimal.Divide(iTEM_PEDIDO.VALOR_ICMS_SUBST.ToDecimal(), iTEM_PEDIDO.QUANTIDADE.ToDecimal());
			}
		}
		if (iTEM_PEDIDO.QUANTIDADE > 0m)
		{
			decimal? vALOR_ICMS_SUBST = iTEM_PEDIDO.VALOR_DESCONTO_FINANCEIRO;
			if ((vALOR_ICMS_SUBST.GetValueOrDefault() > default(decimal)) & vALOR_ICMS_SUBST.HasValue)
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO -= (decimal?)decimal.Divide(iTEM_PEDIDO.VALOR_DESCONTO_FINANCEIRO.ToDecimal(), iTEM_PEDIDO.QUANTIDADE.ToDecimal());
			}
		}
	}

	private void CalcularValorBaseComissaoDESO(CalcularComissaoParamVO parametro)
	{
		ConfiguracaoVO pARCFG = parametro.PARCFG;
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PedidoVendaMO pEDIDO_VENDA = parametro.PEDIDO_VENDA;
		decimal num = pEDIDO_VENDA.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		int qTDE_CASAS_DECIMAIS = parametro.QTDE_CASAS_DECIMAIS;
		if (pARCFG.UNID_VDA_VAR)
		{
			if (iTEM_PEDIDO.INDICE_RELACAO_VENDA == "MENOR")
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) * iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
			}
			else
			{
				decimal num2 = iTEM_PEDIDO.FATOR_ESTOQUE_VENDA.ToDecimal();
				iTEM_PEDIDO.VALOR_BASE_COMISSAO = Math.Round(parametro.ITEM_PEDIDO.VALOR_UNITARIO_VENDA.ToDecimal() * (1m - num), qTDE_CASAS_DECIMAIS, MidpointRounding.AwayFromZero) / ((num2 == 0m) ? 1m : num2);
			}
		}
		else
		{
			iTEM_PEDIDO.VALOR_BASE_COMISSAO = parametro.ITEM_PEDIDO.PRECO_UNITARIO * (decimal?)(1m - num);
		}
		if (iTEM_PEDIDO.QUANTIDADE > 0m)
		{
			decimal? vALOR_ICMS_DESONERADO = iTEM_PEDIDO.VALOR_ICMS_DESONERADO;
			if ((vALOR_ICMS_DESONERADO.GetValueOrDefault() > default(decimal)) & vALOR_ICMS_DESONERADO.HasValue)
			{
				iTEM_PEDIDO.VALOR_BASE_COMISSAO -= (decimal?)decimal.Divide(iTEM_PEDIDO.VALOR_ICMS_DESONERADO.ToDecimal(), iTEM_PEDIDO.QUANTIDADE.ToDecimal());
			}
		}
	}

	public void CalcularComisssaoItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		decimal? pERCENTUAL_COMISSAO = cLIENTE.PERCENTUAL_COMISSAO;
		if (((pERCENTUAL_COMISSAO.GetValueOrDefault() > default(decimal)) & pERCENTUAL_COMISSAO.HasValue) && pAR_CFG.COMIS_CLIEN)
		{
			pERCENTUAL_COMISSAO = itemPedido.COMISSAO_PROMOCAO;
			if ((pERCENTUAL_COMISSAO.GetValueOrDefault() == default(decimal)) & pERCENTUAL_COMISSAO.HasValue)
			{
				itemPedido.COMISSAO_PADRAO = cLIENTE.PERCENTUAL_COMISSAO.ToDecimal();
			}
		}
		itemPedido.REDUCAO_COMISSAO = default(decimal);
		bool flag = pedidoVenda.BUSCA_RED_COMISSAO_VENDEDOR || itemPedido.CALCULA_REDUCAO_COMISSAO;
		bool flag2 = !(itemPedido.SEQ_KIT_PROMOCAO > 0) || itemPedido.PROMOCAO_CONSIDERA_REDUCAO_COMISSAO;
		pERCENTUAL_COMISSAO = cLIENTE.PERCENTUAL_COMISSAO;
		bool flag3 = !((pERCENTUAL_COMISSAO.GetValueOrDefault() > default(decimal)) & pERCENTUAL_COMISSAO.HasValue);
		if (flag && flag2 && flag3)
		{
			DescontosPedidoVO descontosPedidoVO = new DescontosPedidoVO();
			descontosPedidoVO.PERCENTUAL_DESCONTO = itemPedido.DESCONTO_APLICADO.ToDecimal();
			if (pAR_CFG.DESC_GERAL_RED_COMIS)
			{
				descontosPedidoVO.PERCENTUAL_DESCONTO += pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
			}
			if (!itemPedido.DESCONTO_PROMOCAO_REDUZ_COMISSAO.ToBool())
			{
				descontosPedidoVO.DESCONTO_PERMITIDO_PRODUTO = itemPedido.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.ToDecimal();
			}
			descontosPedidoVO.DESCONTO_PERMITIDO_CLIENTE = descontosPedidoVO.DESCONTO_PERMITIDO_PRODUTO + cLIENTE.DESCONTO.ToDecimal();
			CalcularRedutorComissao(itemPedido, descontosPedidoVO, pedidoVenda);
		}
		itemPedido.PERCENTUAL_COMISSAO = itemPedido.COMISSAO_PADRAO.ToDecimal() * (1m - itemPedido.REDUCAO_COMISSAO.ToDecimal());
		CalcularValorBaseComissaoPeloTipo(itemPedido, pedidoVenda);
		decimal qUANTIDADE = itemPedido.QUANTIDADE;
		decimal? vALOR_BASE_COMISSAO = itemPedido.VALOR_BASE_COMISSAO;
		itemPedido.VALOR_COMISSAO = (decimal?)qUANTIDADE * vALOR_BASE_COMISSAO * itemPedido.PERCENTUAL_COMISSAO;
		itemPedido.VALOR_BASE_COMISSAO = Math.Round(itemPedido.VALOR_BASE_COMISSAO.ToDecimal(), 4, MidpointRounding.AwayFromZero);
		itemPedido.VALOR_COMISSAO = Math.Round(itemPedido.VALOR_COMISSAO.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		itemPedido.VALOR_COMISSAO_VENDEDOR = itemPedido.VALOR_COMISSAO;
		itemPedido.VALOR_COMISSAO_LANCADOR = default(decimal);
		if (pAR_CFG.UTILIZA_COMIS_RT)
		{
			decimal? vALOR_TOTAL = pedidoVenda.VALOR_TOTAL;
			if ((vALOR_TOTAL.GetValueOrDefault() > default(decimal)) & vALOR_TOTAL.HasValue)
			{
				itemPedido.VALOR_COMISSAO_RT = pedidoVenda.VALOR_COMISSAO_RT.ToDecimal() * (itemPedido.TOTAL / pedidoVenda.VALOR_TOTAL.ToDecimal());
				itemPedido.VALOR_COMISSAO = Math.Round(itemPedido.VALOR_COMISSAO.ToDecimal() + itemPedido.VALOR_COMISSAO_RT.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			}
		}
		itemPedido.PERCENTUAL_COMISSAO = Math.Round(itemPedido.COMISSAO_PADRAO.ToDecimal() * (1m - itemPedido.REDUCAO_COMISSAO.ToDecimal()), 4, MidpointRounding.AwayFromZero);
	}

	public void RatearComisssaoRT(PedidoVendaMO pedidoVenda)
	{
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		decimal? num = pedidoVenda.ITENS.Sum((ItemPedidoMO s) => s.VALOR_COMISSAO_RT);
		if (!pAR_CFG.UTILIZA_COMIS_RT)
		{
			return;
		}
		decimal? vALOR_COMISSAO_RT = pedidoVenda.VALOR_COMISSAO_RT;
		if (!((vALOR_COMISSAO_RT.GetValueOrDefault() > default(decimal)) & vALOR_COMISSAO_RT.HasValue) || pedidoVenda.VALOR_COMISSAO_RT == num)
		{
			return;
		}
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			if (iTEN.TOTAL > 0m)
			{
				decimal? num2 = (decimal?)pedidoVenda.VALOR_COMISSAO_RT.ToDecimal() - num;
				iTEN.VALOR_COMISSAO += (decimal?)Math.Round(num2.ToDecimal(), 2, MidpointRounding.AwayFromZero);
				iTEN.VALOR_COMISSAO_RT += num2;
				break;
			}
		}
	}

	public List<ItemPedidoComissaoVO> ObterComissaoItemPedido(PedidoVendaMO pedidoVenda)
	{
		return (BaseDAL as ProdutoComissaoDAL).ObterComissaoItemPedido(pedidoVenda, pedidoVenda.PEDIDO_ELETRONICO, pedidoVenda.VENDEDOR);
	}
}
