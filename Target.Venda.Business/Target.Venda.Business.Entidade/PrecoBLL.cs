using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class PrecoBLL : EntidadeBaseBLL<PrecoMO>
{
	protected override EntidadeBaseDAL<PrecoMO> GetInstanceDAL()
	{
		return new PrecoDAL();
	}

	public PrecoMO ObterPrecoItemPedido(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido)
	{
		bool dESC_COND_PAGTO_UTILIZAR_DESCONTO_AUTOMATICO = ConfigERP.PARAMETROS_TELA.VENDA.DESC_COND_PAGTO_UTILIZAR_DESCONTO_AUTOMATICO;
		return (BaseDAL as PrecoDAL).ObterPrecoItemPedido(pedidoVenda, itemPedido, dESC_COND_PAGTO_UTILIZAR_DESCONTO_AUTOMATICO);
	}

	public void CalcularPrecoItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		decimal? pERCDESCCAMPANHA;
		if (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC && (!ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && cLIENTE.PRECO_VENDA_4_DEC)))
		{
			itemPedido.TOTAL_ORIGINAL = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal() * itemPedido.QUANTIDADE, ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
			itemPedido.VALOR_DOS_DESCONTOS = Math.Round(itemPedido.DESCONTO_APLICADO.ToDecimal() * itemPedido.TOTAL_ORIGINAL, ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
			itemPedido.PRECO_UNITARIO = Math.Round(itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - itemPedido.DESCONTO_APLICADO.ToDecimal()), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
			pERCDESCCAMPANHA = itemPedido.PERCDESCCAMPANHA;
			if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
			{
				pERCDESCCAMPANHA = itemPedido.PERC_DESC_CAMPANHA_COMBO;
				if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
				{
					goto IL_01a9;
				}
			}
			itemPedido.PRECO_UNITARIO = Math.Round(itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - (itemPedido.PERCDESCCAMPANHA.ToDecimal() + itemPedido.PERC_DESC_CAMPANHA_COMBO.ToDecimal())), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
			goto IL_01a9;
		}
		itemPedido.TOTAL_ORIGINAL = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal() * itemPedido.QUANTIDADE, 4, MidpointRounding.AwayFromZero);
		itemPedido.VALOR_DOS_DESCONTOS = Math.Round(itemPedido.DESCONTO_APLICADO.ToDecimal() * itemPedido.TOTAL_ORIGINAL, 2, MidpointRounding.AwayFromZero);
		itemPedido.PRECO_UNITARIO = Math.Round(itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - itemPedido.DESCONTO_APLICADO.ToDecimal()), 2, MidpointRounding.AwayFromZero);
		pERCDESCCAMPANHA = itemPedido.PERCDESCCAMPANHA;
		if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
		{
			pERCDESCCAMPANHA = itemPedido.PERC_DESC_CAMPANHA_COMBO;
			if (!((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue))
			{
				goto IL_037c;
			}
		}
		itemPedido.PRECO_UNITARIO = Math.Round(itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - (itemPedido.PERCDESCCAMPANHA.ToDecimal() + itemPedido.PERC_DESC_CAMPANHA_COMBO.ToDecimal())), 2, MidpointRounding.AwayFromZero);
		goto IL_037c;
		IL_01a9:
		itemPedido.TOTAL = Math.Round(itemPedido.VALOR_UNITARIO_VENDA.ToDecimal() * itemPedido.QUANTIDADE_UNIDADE_VENDA.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
		if (ConfigERP.PAR_CFG.UNID_PEDIDA)
		{
			itemPedido.TOTAL_PEDIDA = Math.Round(itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal() * itemPedido.VALOR_UNITARIO_PEDIDA.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
		}
		goto IL_03f5;
		IL_037c:
		itemPedido.TOTAL = Math.Round(itemPedido.VALOR_UNITARIO_VENDA.ToDecimal() * itemPedido.QUANTIDADE_UNIDADE_VENDA.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		if (ConfigERP.PAR_CFG.UNID_PEDIDA)
		{
			itemPedido.TOTAL_PEDIDA = Math.Round(itemPedido.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal() * itemPedido.VALOR_UNITARIO_PEDIDA.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		}
		goto IL_03f5;
		IL_03f5:
		CalcularPrecoUnidadeVenda(itemPedido);
	}

	public void CalcularPrecoUnidadeVenda(ItemPedidoMO itemPedido)
	{
		if (ConfigERP.PAR_CFG.UNID_VDA_VAR)
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
			}
		}
		else
		{
			itemPedido.QUANTIDADE_UNIDADE_VENDA = itemPedido.QUANTIDADE;
			itemPedido.VALOR_UNITARIO_VENDA = itemPedido.PRECO_UNITARIO;
		}
	}

	public PrecoMO ObterPrecoProdutoPelaTabelaPreco(int codigoProduto, string codigoTabela)
	{
		return BaseDAL.ObterUnicoPeloExemplo(new PrecoMO
		{
			CODIGO_TABELA = codigoTabela,
			CODIGO_PRODUTO = codigoProduto
		});
	}

	public DescontosPedidoVO ObterDescontosItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		DescontosPedidoVO descontosPedidoVO = new DescontosPedidoVO();
		bool dESC_QTDE_COMO_DESC_PERM_EM_BONIFICACOES = ConfigERP.PARAMETROS_TELA.VENDA.DESC_QTDE_COMO_DESC_PERM_EM_BONIFICACOES;
		if ((itemPedido.BONIFICADO.ToBool() && !dESC_QTDE_COMO_DESC_PERM_EM_BONIFICACOES) || itemPedido.VERBA_VENDEDOR)
		{
			descontosPedidoVO.DESCONTO_PERMITIDO_PRODUTO = itemPedido.DESCONTO_PROMOCAO.ToDecimal();
		}
		else
		{
			descontosPedidoVO.DESCONTO_PERMITIDO_PRODUTO = itemPedido.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE.ToDecimal();
		}
		descontosPedidoVO.DESCONTO_CLIENTE = pedidoVenda.CLIENTE.DESCONTO.ToDecimal();
		descontosPedidoVO.DESCONTO_VENDEDOR = pedidoVenda.VENDEDOR.PERCENTUAL_DESCONTO.ToDecimal();
		decimal tOTAL_DESCONTO_PERMITIDO = Math.Round(descontosPedidoVO.DESCONTO_PERMITIDO_PRODUTO + descontosPedidoVO.DESCONTO_VENDEDOR + descontosPedidoVO.DESCONTO_CLIENTE, 4, MidpointRounding.AwayFromZero);
		descontosPedidoVO.TOTAL_DESCONTO_PERMITIDO = tOTAL_DESCONTO_PERMITIDO;
		return descontosPedidoVO;
	}

	public bool VerificarSeGeraVerbaNoItemPedido(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, DescontosPedidoVO descontosRO, PrecoMO precoMO)
	{
		TipoPedidoVO tIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO;
		bool pED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA = ConfigERP.PARAMETROS_TELA.VENDA.PED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA;
		bool uSAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA = ConfigERP.PARAMETROS_TELA.VENDA.USAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA;
		bool flag = !itemPedido.SEQ_KIT_PROMOCAO.HasValue && !precoMO.GERA_VERBA.ToBool();
		decimal? pERCENTUAL_DESCONTO_GERAL = pedidoVenda.PERCENTUAL_DESCONTO_GERAL;
		bool flag2 = (pERCENTUAL_DESCONTO_GERAL.GetValueOrDefault() == default(decimal)) & pERCENTUAL_DESCONTO_GERAL.HasValue;
		if (ConfigERP.PAR_CFG.DESCGERALPROD)
		{
			pERCENTUAL_DESCONTO_GERAL = itemPedido.PERCENTUAL_DESCONTO_GERAL;
			flag2 = (pERCENTUAL_DESCONTO_GERAL.GetValueOrDefault() == default(decimal)) & pERCENTUAL_DESCONTO_GERAL.HasValue;
		}
		bool flag3 = itemPedido.SEQ_KIT_PROMOCAO.HasValue && !itemPedido.VERBA_VENDEDOR && (flag2 || !uSAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA);
		bool flag4 = itemPedido.REQUISITO_BONIFICADO == "B" && !itemPedido.VERBA_VENDEDOR_BONIF;
		bool flag5 = itemPedido.ITEM_BONIFICADO_CONTRATO.ToBool();
		pERCENTUAL_DESCONTO_GERAL = itemPedido.DESCONTO_APLICADO;
		decimal tOTAL_DESCONTO_PERMITIDO = descontosRO.TOTAL_DESCONTO_PERMITIDO;
		bool flag6 = (pERCENTUAL_DESCONTO_GERAL.GetValueOrDefault() == tOTAL_DESCONTO_PERMITIDO) & pERCENTUAL_DESCONTO_GERAL.HasValue;
		bool flag7 = !(tIPO_PEDIDO.BONIFICACAO && pED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA);
		bool flag8 = flag6 && flag2 && flag7;
		bool flag9 = flag || flag3 || flag4 || flag5 || flag8;
		return !flag9;
	}

	public ValorBaseCalculoVerbaVO ObterValorBaseCalculoParaVerba(CalculoVerbaParamVO parametro)
	{
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		ConfiguracaoVO pAR_CFG = parametro.PAR_CFG;
		ClienteMO cLIENTE = parametro.CLIENTE;
		TipoPedidoVO tIPO_PEDIDO = parametro.TIPO_PEDIDO;
		DescontosPedidoVO dESCONTOS = parametro.DESCONTOS;
		bool uSAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA = parametro.PARAMETRO_TELA_VENDA.USAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA;
		bool pED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA = parametro.PARAMETRO_TELA_VENDA.PED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA;
		bool pED_BONIFICACAO_DESCONSIDERA_DESC_PERMITIDOS = parametro.PARAMETRO_TELA_VENDA.PED_BONIFICACAO_DESCONSIDERA_DESC_PERMITIDOS;
		ValorBaseCalculoVerbaVO valorBaseCalculoVerbaVO = new ValorBaseCalculoVerbaVO();
		valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_TABELA = iTEM_PEDIDO.PRECO_NOTA_FISCAL.ToDecimal();
		bool flag = pAR_CFG.PRECO_VENDA_4_DEC && (!pAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || (pAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && cLIENTE.PRECO_VENDA_4_DEC));
		if (!flag)
		{
			valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_TABELA = Math.Round(valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_TABELA, 2, MidpointRounding.AwayFromZero);
		}
		valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = 0m;
		if (tIPO_PEDIDO.BONIFICACAO)
		{
			valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = 0m;
			goto IL_0417;
		}
		if (iTEM_PEDIDO.PERCDESCCAMPANHA.HasValue)
		{
			decimal? pERCDESCCAMPANHA = iTEM_PEDIDO.PERCDESCCAMPANHA;
			if ((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue)
			{
				goto IL_0172;
			}
		}
		if (iTEM_PEDIDO.PERC_DESC_CAMPANHA_COMBO.HasValue)
		{
			decimal? pERCDESCCAMPANHA = iTEM_PEDIDO.PERC_DESC_CAMPANHA_COMBO;
			if ((pERCDESCCAMPANHA.GetValueOrDefault() > default(decimal)) & pERCDESCCAMPANHA.HasValue)
			{
				goto IL_0172;
			}
		}
		decimal num = iTEM_PEDIDO.PRECO_UNITARIO.ToDecimal();
		goto IL_0380;
		IL_0380:
		decimal num2 = num;
		if (iTEM_PEDIDO.VERBA_VENDEDOR)
		{
			valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = iTEM_PEDIDO.QUANTIDADE * num2 - iTEM_PEDIDO.VALOR_DESCONTO_GERAL.ToDecimal();
		}
		else
		{
			valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = iTEM_PEDIDO.QUANTIDADE * num2 - iTEM_PEDIDO.VALOR_DESCONTO_GERAL.ToDecimal() * (decimal)Convert.ToInt32(uSAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA);
		}
		if (!flag)
		{
			valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = Math.Round(valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA, 2, MidpointRounding.AwayFromZero);
		}
		goto IL_0417;
		IL_0172:
		decimal vALOR_ITEM_PRECO_TABELA = valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_TABELA;
		decimal value = 1;
		decimal? dESCONTO_APLICADO = iTEM_PEDIDO.DESCONTO_APLICADO;
		decimal value2 = 1;
		decimal value3 = 1;
		decimal? dESCONTO_ = iTEM_PEDIDO.DESCONTO_01;
		decimal? num3 = (decimal?)value3 - dESCONTO_;
		value3 = 1;
		decimal? num4 = iTEM_PEDIDO.PERCDESCCAMPANHA + iTEM_PEDIDO.PERC_DESC_CAMPANHA_COMBO;
		decimal? num5 = num3 * ((decimal?)value3 - num4);
		decimal? num6 = dESCONTO_APLICADO - ((decimal?)value2 - num5 - iTEM_PEDIDO.DESCONTO_01);
		decimal? num7 = (decimal?)value - num6;
		num = Math.Round(((decimal?)vALOR_ITEM_PRECO_TABELA * num7).ToDecimal(), 4, MidpointRounding.AwayFromZero);
		goto IL_0380;
		IL_0417:
		valorBaseCalculoVerbaVO.VALOR_TOTAL_DESCONTO = 0m;
		decimal num8 = Math.Round(dESCONTOS.TOTAL_DESCONTO_PERMITIDO, 5, MidpointRounding.AwayFromZero);
		decimal d = iTEM_PEDIDO.PRECO_NOTA_FISCAL.ToDecimal() * (1m - num8);
		d = (flag ? Math.Round(d, 4, MidpointRounding.AwayFromZero) : Math.Round(d, 2, MidpointRounding.AwayFromZero));
		d *= iTEM_PEDIDO.QUANTIDADE.ToDecimal();
		d = Math.Round(d, 2, MidpointRounding.AwayFromZero);
		valorBaseCalculoVerbaVO.VALOR_TOTAL_DESCONTO = iTEM_PEDIDO.PRECO_NOTA_FISCAL.ToDecimal() * iTEM_PEDIDO.QUANTIDADE.ToDecimal() - d;
		if (tIPO_PEDIDO.BONIFICACAO && pED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA && pED_BONIFICACAO_DESCONSIDERA_DESC_PERMITIDOS)
		{
			valorBaseCalculoVerbaVO.VALOR_TOTAL_DESCONTO = 0m;
		}
		if (tIPO_PEDIDO.BONIFICACAO && !pED_BONIFICACAO_DEBITAR_VL_PEDIDO_DA_VERBA)
		{
			valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = iTEM_PEDIDO.QUANTIDADE * valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_TABELA - valorBaseCalculoVerbaVO.VALOR_TOTAL_DESCONTO;
		}
		valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA = Math.Round(valorBaseCalculoVerbaVO.VALOR_ITEM_PRECO_VENDA.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		return valorBaseCalculoVerbaVO;
	}

	public void TratarArredondamentoPreco(PedidoVendaMO pedidoVenda)
	{
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		if (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC && (!ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && cLIENTE.PRECO_VENDA_4_DEC)))
		{
			foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
			{
				iTEN.PRECO_BASICO = Math.Round(iTEN.PRECO_BASICO.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
				iTEN.PRECO_NOTA_FISCAL = Math.Round(iTEN.PRECO_NOTA_FISCAL.ToDecimal(), ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE, MidpointRounding.AwayFromZero);
			}
			return;
		}
		foreach (ItemPedidoMO iTEN2 in pedidoVenda.ITENS)
		{
			iTEN2.PRECO_BASICO = Math.Round(iTEN2.PRECO_BASICO.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			iTEN2.PRECO_NOTA_FISCAL = Math.Round(iTEN2.PRECO_NOTA_FISCAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		}
	}

	public void CalcularVerbaItemPedido(CalcularVerbaItemPedidoParamVO parametro)
	{
		ValorBaseCalculoVerbaVO vALORES_BASE = parametro.VALORES_BASE;
		ItemPedidoMO iTEM_PEDIDO = parametro.ITEM_PEDIDO;
		PrecoMO pRECO = parametro.PRECO;
		ConfiguracaoVO pARCFG = parametro.PARCFG;
		VendedorMO vENDEDOR = parametro.VENDEDOR;
		EquipeMO eQUIPE_VENDEDOR = parametro.EQUIPE_VENDEDOR;
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.LimparValoresVerbasDoItemPedido(iTEM_PEDIDO);
		decimal num = vALORES_BASE.VALOR_ITEM_PRECO_TABELA * iTEM_PEDIDO.QUANTIDADE;
		bool uSAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA = ConfigERP.PARAMETROS_TELA.VENDA.USAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA;
		int num2;
		if (iTEM_PEDIDO.SEQ_KIT_PROMOCAO.HasValue && !iTEM_PEDIDO.VERBA_VENDEDOR)
		{
			decimal? vALOR_DESCONTO_GERAL = iTEM_PEDIDO.VALOR_DESCONTO_GERAL;
			num2 = (((vALOR_DESCONTO_GERAL.GetValueOrDefault() > default(decimal)) & vALOR_DESCONTO_GERAL.HasValue) ? 1 : 0);
		}
		else
		{
			num2 = 0;
		}
		decimal num3 = ((((uint)num2 & (uSAR_DESCONTO_GERAL_NO_CALCULO_DA_VERBA ? 1u : 0u)) == 0) ? (vALORES_BASE.VALOR_ITEM_PRECO_VENDA + vALORES_BASE.VALOR_TOTAL_DESCONTO - num) : (-iTEM_PEDIDO.VALOR_DESCONTO_GERAL.ToDecimal()));
		if (pRECO.VALOR_VERBA_UNITARIO.HasValue && pRECO.VALOR_VERBA_UNITARIO.ToDecimal() != 0m)
		{
			num3 += pRECO.VALOR_VERBA_UNITARIO.ToDecimal() * iTEM_PEDIDO.QUANTIDADE;
		}
		if (!(num3 > 0m))
		{
			iTEM_PEDIDO.VALOR_VERBA = num3;
			return;
		}
		iTEM_PEDIDO.VALOR_VERBA = Math.Round(num3 * pARCFG.VERBA_PERC_CRED, 2, MidpointRounding.AwayFromZero);
		iTEM_PEDIDO.VALOR_VERBA_EMPRESA = Math.Round(num3 * pARCFG.VERBA_PERC_CRED_EMP, 2, MidpointRounding.AwayFromZero);
		if (string.IsNullOrEmpty(eQUIPE_VENDEDOR.CODIGO_VENDEDOR_SUPERVISOR) || pARCFG.VERBA_PERC_CRED_EQUIP == 0m)
		{
			iTEM_PEDIDO.VALOR_VERBA = num3 - iTEM_PEDIDO.VALOR_VERBA_EMPRESA.ToDecimal();
		}
		else
		{
			iTEM_PEDIDO.VALOR_VERBA_EQUIPE = num3 - iTEM_PEDIDO.VALOR_VERBA.ToDecimal() - iTEM_PEDIDO.VALOR_VERBA_EMPRESA.ToDecimal();
		}
	}

	public VerbaVO ObterVerbaDoCliente(VendedorMO vendedor, ClienteMO cliente)
	{
		return (BaseDAL as PrecoDAL).ObterVerbaDoCliente(vendedor, cliente);
	}

	public VerbaVO ObterVerbaVendedor(VendedorMO vendedor)
	{
		return (BaseDAL as PrecoDAL).ObterVerbaVendedor(vendedor);
	}

	public void CalcularCustoVenda(PedidoVendaMO pedidoVenda)
	{
		EnderecoClienteMO enderecoClienteMO = pedidoVenda.CLIENTE.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "EN");
		EstadoBLL estadoBLL = new EstadoBLL();
		EstadoMO estadoDestino = estadoBLL.ObterPeloID(enderecoClienteMO.ESTADO);
		EmpresaMO eMPRESA_LOGADA = LoginERP.EMPRESA_LOGADA;
		ProdutoCustoBLL produtoCustoBLL = new ProdutoCustoBLL();
		List<ProdutoCustoVO> list = produtoCustoBLL.CalcularCustoProdutoPedido(eMPRESA_LOGADA, estadoDestino, pedidoVenda.PEDIDO_ELETRONICO);
		ProdutoBLL produtoBLL = new ProdutoBLL();
		foreach (ItemPedidoMO itemPedido in pedidoVenda.ITENS)
		{
			List<ProdutoCustoVO> list2 = list.FindAll((ProdutoCustoVO x) => x.CODIGO_PRODUTO == itemPedido.CODIGO_PRODUTO);
			ProdutoCustoVO? custoProduto = list2.Find((ProdutoCustoVO x) => x.TIPO_CUSTO == "CRP");
			CalcularCustoVenda_CRP(pedidoVenda, itemPedido, estadoDestino, custoProduto);
			ProdutoCustoVO? custoProduto2 = list2.Find((ProdutoCustoVO x) => x.TIPO_CUSTO == "CUE");
			CalcularCustoVenda_CUE(pedidoVenda, itemPedido, estadoDestino, custoProduto2);
			ProdutoCustoVO? custoProduto3 = list2.Find((ProdutoCustoVO x) => x.TIPO_CUSTO == "CMP");
			CalcularCustoVenda_CMP(pedidoVenda, itemPedido, estadoDestino, custoProduto3);
			itemPedido.VENDA_AV = itemPedido.PRECO_UNITARIO * (decimal?)itemPedido.QUANTIDADE * (decimal?)(1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal());
			itemPedido.VENDA_LIQUIDA = Math.Round(itemPedido.VENDA_AV.ToDecimal() - itemPedido.CUSTO_AV.ToDecimal(), 2);
			itemPedido.VENDA_AV = Math.Round(itemPedido.VENDA_AV.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			itemPedido.CUSTO_AV = Math.Round(itemPedido.CUSTO_AV.Value, 2, MidpointRounding.AwayFromZero);
			itemPedido.CUSTO_CMP = Math.Round(itemPedido.CUSTO_CMP.Value, 2, MidpointRounding.AwayFromZero);
			itemPedido.CUSTO_CUE = Math.Round(itemPedido.CUSTO_CUE.Value, 2, MidpointRounding.AwayFromZero);
		}
	}

	private void CalcularCustoVenda_CMP(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, EstadoMO estadoDestino, ProdutoCustoVO? _custoProduto)
	{
		decimal num = default(decimal);
		if (!_custoProduto.HasValue)
		{
			itemPedido.SEQ_CUSTO_CMP = 0;
			itemPedido.CUSTO_CMP = default(decimal);
			itemPedido.CUSTO_CMP_CAPADO = default(decimal);
			return;
		}
		ProdutoCustoVO value = _custoProduto.Value;
		itemPedido.VALOR_CREDITO_ICMS_CMP = Math.Round((value.VALOR_ICMS_COMPRA * (decimal?)itemPedido.QUANTIDADE).ToDecimal(), 4, MidpointRounding.AwayFromZero);
		itemPedido.SEQ_CUSTO_CMP = value.SEQ;
		itemPedido.CUSTO_CMP = value.VALOR_CUSTO * itemPedido.QUANTIDADE;
		if (!estadoDestino.GRAVA_CUSTO_SEM_SUBSTITUICAO.ToBool())
		{
			value.VALOR_ICMS_SUBST = default(decimal);
			if (!value.CUSTO_CAPADO_CRED_ICMS)
			{
				value.VALOR_ICMS_COMPRA = default(decimal);
			}
		}
		num = ((!(value.CRED_ICMS_PRESUMIDO.ToDecimal() != 0m)) ? value.VALOR_ICMS_COMPRA.ToDecimal() : (itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) * value.CRED_ICMS_PRESUMIDO.ToDecimal()));
		itemPedido.CUSTO_CMP_CAPADO = (value.VALOR_CUSTO - num - value.VALOR_PIS.ToDecimal() - value.VALOR_CONFINS.ToDecimal() - value.VALOR_ICMS_SUBST.ToDecimal()) * itemPedido.QUANTIDADE;
		itemPedido.CUSTO_CMP_CAPADO = Math.Round(itemPedido.CUSTO_CMP_CAPADO.ToDecimal(), 4, MidpointRounding.AwayFromZero);
	}

	private void CalcularCustoVenda_CUE(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, EstadoMO estadoDestino, ProdutoCustoVO? _custoProduto)
	{
		decimal num = default(decimal);
		if (!_custoProduto.HasValue)
		{
			itemPedido.SEQ_CUSTO_CUE = 0;
			itemPedido.CUSTO_CUE = default(decimal);
			itemPedido.CUSTO_CUE_CAPADO = default(decimal);
			itemPedido.CUSTO_CUE_SEM_IMPOSTO = null;
			return;
		}
		ProdutoCustoVO value = _custoProduto.Value;
		itemPedido.VALOR_CREDITO_ICMS_CUE = Math.Round((value.VALOR_ICMS_COMPRA * (decimal?)itemPedido.QUANTIDADE).ToDecimal(), 4, MidpointRounding.AwayFromZero);
		itemPedido.SEQ_CUSTO_CUE = value.SEQ;
		itemPedido.CUSTO_CUE = value.VALOR_CUSTO * itemPedido.QUANTIDADE;
		itemPedido.CUSTO_CUE_SEM_IMPOSTO = value.VALOR_CUSTO_SEM_IMPOSTOS * (decimal?)itemPedido.QUANTIDADE;
		if (!estadoDestino.GRAVA_CUSTO_SEM_SUBSTITUICAO.ToBool())
		{
			value.VALOR_ICMS_SUBST = default(decimal);
			if (!value.CUSTO_CAPADO_CRED_ICMS)
			{
				value.VALOR_ICMS_COMPRA = default(decimal);
			}
		}
		num = ((!(value.CRED_ICMS_PRESUMIDO.ToDecimal() != 0m)) ? value.VALOR_ICMS_COMPRA.ToDecimal() : (itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) * value.CRED_ICMS_PRESUMIDO.ToDecimal()));
		itemPedido.CUSTO_CUE_CAPADO = (value.VALOR_CUSTO - num - value.VALOR_PIS.ToDecimal() - value.VALOR_CONFINS.ToDecimal() - value.VALOR_ICMS_SUBST.ToDecimal()) * itemPedido.QUANTIDADE;
		itemPedido.CUSTO_CUE_CAPADO = Math.Round(itemPedido.CUSTO_CUE_CAPADO.ToDecimal(), 4, MidpointRounding.AwayFromZero);
	}

	private void CalcularCustoVenda_CRP(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, EstadoMO estadoDestino, ProdutoCustoVO? _custoProduto)
	{
		decimal num = default(decimal);
		if (!_custoProduto.HasValue)
		{
			itemPedido.SEQ_CUSTO_CRP = 0;
			itemPedido.CUSTO_AV = default(decimal);
			itemPedido.CUSTO_AV_CAPADO = default(decimal);
			return;
		}
		ProdutoCustoVO value = _custoProduto.Value;
		itemPedido.VALOR_CREDITO_ICMS_CRP = Math.Round((value.VALOR_ICMS_COMPRA * (decimal?)itemPedido.QUANTIDADE).ToDecimal(), 4, MidpointRounding.AwayFromZero);
		itemPedido.SEQ_CUSTO_CRP = value.SEQ;
		itemPedido.CUSTO_AV = value.VALOR_CUSTO * itemPedido.QUANTIDADE;
		if (!estadoDestino.GRAVA_CUSTO_SEM_SUBSTITUICAO.ToBool())
		{
			value.VALOR_ICMS_SUBST = default(decimal);
			if (!value.CUSTO_CAPADO_CRED_ICMS)
			{
				value.VALOR_ICMS_COMPRA = default(decimal);
			}
		}
		num = ((!(value.CRED_ICMS_PRESUMIDO.ToDecimal() != 0m)) ? value.VALOR_ICMS_COMPRA.ToDecimal() : (itemPedido.PRECO_UNITARIO.ToDecimal() * (1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal()) * value.CRED_ICMS_PRESUMIDO.ToDecimal()));
		itemPedido.CUSTO_AV_CAPADO = (value.VALOR_CUSTO - num - value.VALOR_PIS.ToDecimal() - value.VALOR_CONFINS.ToDecimal() - value.VALOR_ICMS_SUBST.ToDecimal()) * itemPedido.QUANTIDADE;
		itemPedido.CUSTO_AV_CAPADO = Math.Round(itemPedido.CUSTO_AV_CAPADO.ToDecimal(), 4, MidpointRounding.AwayFromZero);
	}

	public void AtualizarPrecoProdutoPelaTabela(int codigoProduto, decimal valorPrecoAtualizado, string codigoTabela)
	{
		(BaseDAL as PrecoDAL).AtualizarPrecoProdutoPelaTabela(codigoProduto, valorPrecoAtualizado, codigoTabela);
	}

	public void CalcularDescontoFinanceiroPedido(PedidoVendaMO pedidoVenda)
	{
		DescontoFinanceiroVO descontoFinanceiro = ObterDescontoFinanceiroPedido(pedidoVenda);
		CalcularDescontoFinanceiroItensPedido(pedidoVenda, descontoFinanceiro);
		CalcularDescontoFinanceiroCabecalhoPedido(pedidoVenda, descontoFinanceiro);
	}

	private void CalcularDescontoFinanceiroCabecalhoPedido(PedidoVendaMO pedidoVenda, DescontoFinanceiroVO descontoFinanceiro)
	{
		decimal? vALOR_TOTAL_NOTA_FISCAL;
		if (ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO != "PRPD" && ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO != "FACL")
		{
			pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO = descontoFinanceiro.PERCENTUAL_DECONTO_FINANCEIRO;
			if (ConfigERP.PAR_CFG.DESC_FIN_TOT_NF)
			{
				decimal value = pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO.ToDecimal();
				vALOR_TOTAL_NOTA_FISCAL = pedidoVenda.VALOR_TOTAL_NOTA_FISCAL;
				pedidoVenda.VALOR_DESCONTO_FINANCEIRO = (decimal?)value * vALOR_TOTAL_NOTA_FISCAL;
			}
			else
			{
				decimal value = pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO.ToDecimal();
				vALOR_TOTAL_NOTA_FISCAL = pedidoVenda.VALOR_TOTAL;
				pedidoVenda.VALOR_DESCONTO_FINANCEIRO = (decimal?)value * vALOR_TOTAL_NOTA_FISCAL;
			}
		}
		else
		{
			pedidoVenda.VALOR_DESCONTO_FINANCEIRO = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VALOR_DESCONTO_FINANCEIRO);
			if (ConfigERP.PAR_CFG.DESC_FIN_TOT_NF)
			{
				decimal value = pedidoVenda.VALOR_DESCONTO_FINANCEIRO.ToDecimal();
				vALOR_TOTAL_NOTA_FISCAL = pedidoVenda.VALOR_TOTAL_NOTA_FISCAL;
				pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO = (decimal?)value / vALOR_TOTAL_NOTA_FISCAL;
			}
			else
			{
				decimal value = pedidoVenda.VALOR_DESCONTO_FINANCEIRO.ToDecimal();
				vALOR_TOTAL_NOTA_FISCAL = pedidoVenda.VALOR_TOTAL;
				pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO = (decimal?)value / vALOR_TOTAL_NOTA_FISCAL;
			}
		}
		vALOR_TOTAL_NOTA_FISCAL = pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO;
		if ((vALOR_TOTAL_NOTA_FISCAL.GetValueOrDefault() > default(decimal)) & vALOR_TOTAL_NOTA_FISCAL.HasValue)
		{
			pedidoVenda.NUMERO_DIAS_DESCONTO_FINANCEIRO = descontoFinanceiro.DIAS_DECONTO_FINANCEIRO;
		}
	}

	private void CalcularDescontoFinanceiroItensPedido(PedidoVendaMO pedidoVenda, DescontoFinanceiroVO descontoFinanceiro)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			iTEN.PERCENTUAL_DESCONTO_FINANCEIRO = descontoFinanceiro.PERCENTUAL_DECONTO_FINANCEIRO;
			if (ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO == "PRPD" || ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO == "FACL")
			{
				iTEN.PERCENTUAL_DESCONTO_FINANCEIRO = iTEN.PERCENTUAL_DESCONTO_FINANCEIRO_AUTO.ToDecimal();
			}
			if (ConfigERP.PAR_CFG.DESC_FIN_TOT_NF)
			{
				iTEN.VALOR_DESCONTO_FINANCEIRO = iTEN.PERCENTUAL_DESCONTO_FINANCEIRO * (decimal?)iTEN.VALOR_TOTAL_COM_IMPOSTOS;
			}
			else
			{
				iTEN.VALOR_DESCONTO_FINANCEIRO = iTEN.PERCENTUAL_DESCONTO_FINANCEIRO * (decimal?)(iTEN.TOTAL * (1m - pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal()));
			}
			iTEN.VALOR_DESCONTO_FINANCEIRO = Math.Round(iTEN.VALOR_DESCONTO_FINANCEIRO.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		}
	}

	private DescontoFinanceiroVO ObterDescontoFinanceiroPedido(PedidoVendaMO pedidoVenda)
	{
		DescontoFinanceiroVO descontoFinanceiroVO = new DescontoFinanceiroVO();
		if (ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO != "PRPD" && ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO != "FACL")
		{
			pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO i)
			{
				i.PERCENTUAL_DESCONTO_FINANCEIRO_AUTO = default(decimal);
			});
		}
		else
		{
			descontoFinanceiroVO.DIAS_DECONTO_FINANCEIRO = ConfigERP.PAR_CFG.NU_DIAS_DESC_FIN_AUTO;
		}
		decimal? pERCENTUAL_DESCONTO_FINANCEIRO = pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO;
		if ((pERCENTUAL_DESCONTO_FINANCEIRO.GetValueOrDefault() > default(decimal)) & pERCENTUAL_DESCONTO_FINANCEIRO.HasValue)
		{
			descontoFinanceiroVO.PERCENTUAL_DECONTO_FINANCEIRO = pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO.ToDecimal();
			descontoFinanceiroVO.DIAS_DECONTO_FINANCEIRO = (pedidoVenda.NUMERO_DIAS_DESCONTO_FINANCEIRO.HasValue ? pedidoVenda.NUMERO_DIAS_DESCONTO_FINANCEIRO : new short?(0)).Value;
		}
		else if (ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO == "CLIE")
		{
			descontoFinanceiroVO.PERCENTUAL_DECONTO_FINANCEIRO = pedidoVenda.CLIENTE.PERCENTUAL_DESCONTO_FINANCEIRO_AUTO.ToDecimal();
			descontoFinanceiroVO.DIAS_DECONTO_FINANCEIRO = ConfigERP.PAR_CFG.NU_DIAS_DESC_FIN_AUTO;
		}
		else if (ConfigERP.PAR_CFG.TP_DESC_FIN_AUTO == "COPG")
		{
			PromocaoEmpresaMO promocaoEmpresaMO = pedidoVenda.PROMOCAO.PROMOCAO_EMPRESA.Find((PromocaoEmpresaMO e) => e.CODIGO_EMPRESA == pedidoVenda.CODIGO_EMPRESA);
			descontoFinanceiroVO.PERCENTUAL_DECONTO_FINANCEIRO = promocaoEmpresaMO.PERCDESCFINAUTO.ToDecimal();
			descontoFinanceiroVO.DIAS_DECONTO_FINANCEIRO = (short)promocaoEmpresaMO.DIASDESCFINANC.ToInt();
		}
		return descontoFinanceiroVO;
	}

	public void CalcularPrecoItemPedidoPelaCondPagto(PrecoMO preco, ItemPedidoMO itemPedido, bool UtilizaPrecoCusto)
	{
		if (preco == null)
		{
			MyException ex = new MyException("Preço do produto não encontrado");
			ex.ThrowException();
		}
		itemPedido.DESCONTO_PROMOCAO_LANC_PRODUTO = BoolEnum.False;
		if (preco.DESCONTO_PROMOCAO_LANCAMENTO_PRODUTO.HasValue && preco.DESCONTO_PROMOCAO_LANCAMENTO_PRODUTO.ToBool())
		{
			itemPedido.DESCONTO_PROMOCAO_LANC_PRODUTO = BoolEnum.True;
		}
		itemPedido.DESCONTO_PROMOCAO = preco.DESCONTO_PROMOCAO.Value;
		itemPedido.DESCONTO_PROMOCAO_REDUZ_COMISSAO = preco.DESCONTO_PROMOCAO_REDUZ_COMISSAO;
		if (itemPedido.SEQ_KIT_PROMOCAO > 0)
		{
			itemPedido.DESCONTO_PROMOCAO = itemPedido.PERCENTUAL_DESCONTO_AUX;
		}
		bool flag = ConfigERP.PARAMETROS_TELA.VENDA.MANTER_DESCONTO_APLICADO_1_E_2_NOS_PEDIDOS_ELETRONICOS;
		if (itemPedido.CONSIDERA_PRECO_PROMOCAO)
		{
			flag = false;
		}
		if (!flag && !UtilizaPrecoCusto)
		{
			itemPedido.PRECO_BASICO = Math.Round(itemPedido.PRECO_BASICO.ToDecimal() * itemPedido.FATOR_PRECO.ToDecimal(), 4, MidpointRounding.AwayFromZero);
		}
		else
		{
			itemPedido.PRECO_BASICO = Math.Round(itemPedido.PRECO_BASICO.ToDecimal(), 4, MidpointRounding.AwayFromZero);
		}
		itemPedido.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE = itemPedido.DESCONTO_PROMOCAO;
	}

	public void ValidarDescontoMaximoPermitidoItemPedido(ItemPedidoMO itemPedido, string codigoTabela)
	{
		PrecoMO precoMO = ObterPeloID(codigoTabela, itemPedido.CODIGO_PRODUTO);
		if (precoMO.DESCONTO_MAXIMO_PRODUTO.HasValue)
		{
			itemPedido.PERCENTUAL_MAX_PRODUTO = precoMO.DESCONTO_MAXIMO_PRODUTO.ToDecimal();
			bool flag = itemPedido.SEQ_KIT_PROMOCAO == 0 || !itemPedido.SEQ_KIT_PROMOCAO.HasValue;
			decimal? dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
			decimal pERCENTUAL_MAX_PRODUTO = itemPedido.PERCENTUAL_MAX_PRODUTO;
			bool flag2 = (dESCONTO_APLICADO.GetValueOrDefault() > pERCENTUAL_MAX_PRODUTO) & dESCONTO_APLICADO.HasValue;
			if (flag && flag2)
			{
				new MyException("Desconto maior que o maximo permitido para o produto").ThrowException();
			}
		}
	}

	public void ObterValorVendaItemBonificadoPeloItemNaoBonificado(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PAR_CFG.NF_ITEM_BONIF_VALOR_VDA)
		{
			return;
		}
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => x.BONIFICADO.ToBool());
		foreach (ItemPedidoMO itemBonificado in list)
		{
			ItemPedidoMO itemPedidoMO = pedidoVenda.ITENS.Find((ItemPedidoMO x) => x.CODIGO_PRODUTO == itemBonificado.CODIGO_PRODUTO && !x.BONIFICADO.ToBool());
			if (itemPedidoMO != null)
			{
				itemBonificado.PRECO_BASICO = itemPedidoMO.PRECO_UNITARIO;
				itemBonificado.PRECO_NOTA_FISCAL = itemPedidoMO.PRECO_UNITARIO;
				itemBonificado.PRECO_TABELA = ((!itemPedidoMO.PRECO_UNITARIO.HasValue) ? itemBonificado.PRECO_TABELA : itemPedidoMO.PRECO_UNITARIO.Value);
			}
		}
	}

	public void CalcularValorVendaItemBonificado(PedidoVendaMO pedidoVenda)
	{
		if (!pedidoVenda.TIPO_PEDIDO.UTILIZA_PRECO_CUSTO_BONIFICADO)
		{
			return;
		}
		ProdutoBLL produtoBLL = new ProdutoBLL();
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => x.BONIFICADO.ToBool());
		foreach (ItemPedidoMO item in list)
		{
			decimal num = produtoBLL.BuscaCustoProdutoCalculo(item, pedidoVenda);
			if (!(num > 0m))
			{
				throw new MyException("Tipo de pedido com bonificação com preço de custo, existem produtos sem custo cadastrado");
			}
			item.PRECO_BASICO = num;
			item.PRECO_NOTA_FISCAL = num;
			item.PRECO_TABELA = num;
		}
	}

	public void CalcularValorVendaTpPedBonificado(PedidoVendaMO pedidoVenda)
	{
		ProdutoBLL produtoBLL = new ProdutoBLL();
		List<ItemPedidoMO> iTENS = pedidoVenda.ITENS;
		foreach (ItemPedidoMO item in iTENS)
		{
			decimal num = produtoBLL.BuscaCustoProdutoCalculo(item, pedidoVenda);
			if (!(num > 0m))
			{
				throw new MyException("Tipo de pedido com bonificação com preço de custo, existem produtos sem custo cadastrado");
			}
			item.PRECO_BASICO = num;
			item.PRECO_NOTA_FISCAL = num;
			item.PRECO_TABELA = num;
			decimal pRECO_TABELA = item.PRECO_TABELA;
			decimal value = 1;
			decimal? dESCONTO_APLICADO_REAL = item.DESCONTO_APLICADO_REAL;
			decimal? num2 = (decimal?)value - dESCONTO_APLICADO_REAL;
			item.PRECO_UNITARIO = (decimal?)pRECO_TABELA * num2;
			pRECO_TABELA = item.PRECO_TABELA * item.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			value = 1;
			dESCONTO_APLICADO_REAL = item.DESCONTO_APLICADO_REAL;
			decimal? num3 = (decimal?)value - dESCONTO_APLICADO_REAL;
			item.VALOR_UNITARIO_PEDIDA = (decimal?)pRECO_TABELA * num3;
			pRECO_TABELA = item.PRECO_TABELA * item.FATOR_ESTOQUE_VENDA.ToDecimal();
			value = 1;
			dESCONTO_APLICADO_REAL = item.DESCONTO_APLICADO_REAL;
			decimal? num4 = (decimal?)value - dESCONTO_APLICADO_REAL;
			item.VALOR_UNITARIO_VENDA = (decimal?)pRECO_TABELA * num4;
			value = item.PRECO_TABELA;
			decimal value2 = 1;
			decimal? dESCONTO_APLICADO_REAL2 = item.DESCONTO_APLICADO_REAL;
			decimal? num5 = (decimal?)value2 - dESCONTO_APLICADO_REAL2;
			item.VENDA_AV = (decimal?)value * num5 * (decimal?)item.QUANTIDADE;
		}
	}

	public void CalcularJurosRateioCartaoCredito(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.FORMA_PAGAMENTO != "CC")
		{
			return;
		}
		if (pedidoVenda.PROMOCAO.CC_CARTAO_CREDITO.HasValue)
		{
			if (pedidoVenda.PROMOCAO.CC_CARTAO_CREDITO == false)
			{
				new MyException("Condição de pagamento não está configurada corretamente para pagamento em cartão de crédito ").ThrowException();
			}
			if (!pedidoVenda.PROMOCAO.CC_CONTRATO_OPERADORA_ID.HasValue || !pedidoVenda.PROMOCAO.CONTRATO.ATIVO)
			{
				new MyException("Contrato de cartão de crédito inativo ou não encontrado na condição de pagamento").ThrowException();
			}
			if (!pedidoVenda.QTDE_PARCELAS_CARTAO_CREDITO.HasValue)
			{
				new MyException("A quantidade de parcelas do do pedido não foi informada").ThrowException();
			}
			if (pedidoVenda.QTDE_PARCELAS_CARTAO_CREDITO > pedidoVenda.PROMOCAO.CC_QTDE_MAX_PARCELAS)
			{
				new MyException("A quantidade máxima de parcelas do Contrato de cartão de crédito foi ultrapassada").ThrowException();
			}
			if (pedidoVenda.QTDE_PARCELAS_CARTAO_CREDITO == 0)
			{
				new MyException("A quantidade de parcelas do pedido esta zerada").ThrowException();
			}
		}
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		bool flag = ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC && (!ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && cLIENTE.PRECO_VENDA_4_DEC));
		int qtdeCasasDecimais = 2;
		if (flag)
		{
			qtdeCasasDecimais = ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE;
		}
		decimal tOTAL;
		if (pedidoVenda.QTDE_PARCELAS_CARTAO_CREDITO > pedidoVenda.PROMOCAO.CC_NUMERO_PARCELAS_SEM_JUROS)
		{
			decimal? num = default(decimal);
			decimal? num2 = default(decimal);
			decimal? num3 = default(decimal);
			decimal? num4 = pedidoVenda.PROMOCAO.CC_TAXA_JUROS_PARCELAS * (decimal?)pedidoVenda.QTDE_PARCELAS_CARTAO_CREDITO;
			num2 = Math.Round((pedidoVenda.VALOR_TOTAL / ((decimal?)1 - num4)).Value, 2, MidpointRounding.AwayFromZero);
			num3 = num2 - pedidoVenda.VALOR_TOTAL;
			foreach (ItemPedidoMO item in pedidoVenda.ITENS.OrderBy((ItemPedidoMO x) => x.SEQ))
			{
				tOTAL = item.TOTAL;
				decimal? vALOR_TOTAL = pedidoVenda.VALOR_TOTAL;
				item.VALOR_JUROS_ITEM = Math.Round(((decimal?)tOTAL / vALOR_TOTAL * num3).Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
			}
			pedidoVenda.VALOR_JUROS = num3;
			decimal num5 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => Math.Round(x.VALOR_JUROS_ITEM.ToDecimal(), qtdeCasasDecimais, MidpointRounding.AwayFromZero));
			decimal value = Math.Round(pedidoVenda.VALOR_JUROS.Value - num5, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
			ItemPedidoMO itemPedidoMO = pedidoVenda.ITENS.First();
			itemPedidoMO.VALOR_JUROS_ITEM += (decimal?)value;
		}
		decimal? num6 = default(decimal);
		tOTAL = Math.Round((pedidoVenda.VALOR_TOTAL / (decimal?)(1m - pedidoVenda.PROMOCAO.CONTRATO.PERC_TAXA_CONTRATO)).Value, 2, MidpointRounding.AwayFromZero);
		decimal? vALOR_TOTAL2 = pedidoVenda.VALOR_TOTAL;
		num6 = (decimal?)tOTAL - vALOR_TOTAL2;
		foreach (ItemPedidoMO item2 in pedidoVenda.ITENS.OrderBy((ItemPedidoMO x) => x.SEQ))
		{
			decimal tOTAL2 = item2.TOTAL;
			decimal? vALOR_TOTAL = pedidoVenda.VALOR_TOTAL;
			item2.VALOR_TAXA_CONTRATO = Math.Round(((decimal?)tOTAL2 / vALOR_TOTAL * num6).Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
			if (pedidoVenda.PROMOCAO.CONTRATO.RATEIO_TAXA_ITENS_PEDIDO == true)
			{
				item2.PRECO_UNITARIO += (decimal?)Math.Round(item2.VALOR_TAXA_CONTRATO.Value / item2.QUANTIDADE, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				if (item2.INDICE_RELACAO == "MENOR")
				{
					item2.VALOR_UNITARIO_PEDIDA = Math.Round(item2.PRECO_UNITARIO.Value / (decimal)item2.FATOR_ESTOQUE_PEDIDA.Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				}
				else
				{
					item2.VALOR_UNITARIO_PEDIDA = Math.Round(item2.PRECO_UNITARIO.Value * (decimal)item2.FATOR_ESTOQUE_PEDIDA.Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				}
				CalcularPrecoUnidadeVenda(item2);
				item2.TOTAL = Math.Round(item2.VALOR_UNITARIO_VENDA.ToDecimal() * item2.QUANTIDADE_UNIDADE_VENDA.ToDecimal(), qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				item2.TOTAL_PEDIDA = Math.Round(item2.VALOR_UNITARIO_PEDIDA.ToDecimal() * item2.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal(), qtdeCasasDecimais, MidpointRounding.AwayFromZero);
			}
		}
		if (pedidoVenda.PROMOCAO.CONTRATO.RATEIO_TAXA_ITENS_PEDIDO == true)
		{
			pedidoVenda.VALOR_TOTAL = Math.Round(pedidoVenda.VALOR_TOTAL.ToDecimal() + num6.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			decimal num7 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => Math.Round(x.TOTAL, qtdeCasasDecimais, MidpointRounding.AwayFromZero));
			decimal num8 = Math.Round(pedidoVenda.VALOR_TOTAL.Value - num7, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
			ItemPedidoMO itemPedidoMO2 = pedidoVenda.ITENS.First();
			itemPedidoMO2.TOTAL += num8;
			itemPedidoMO2.TOTAL_PEDIDA += num8;
			if (itemPedidoMO2.INDICE_RELACAO_VENDA == "MENOR")
			{
				itemPedidoMO2.VALOR_UNITARIO_VENDA = Math.Round(itemPedidoMO2.TOTAL / itemPedidoMO2.QUANTIDADE_UNIDADE_VENDA.Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				itemPedidoMO2.VALOR_UNITARIO_PEDIDA = Math.Round(itemPedidoMO2.TOTAL_PEDIDA / itemPedidoMO2.QUANTIDADE_UNIDADE_PEDIDA.Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				itemPedidoMO2.PRECO_UNITARIO = itemPedidoMO2.VALOR_UNITARIO_VENDA.Value * itemPedidoMO2.FATOR_ESTOQUE_VENDA.Value;
			}
			else
			{
				itemPedidoMO2.VALOR_UNITARIO_VENDA = Math.Round(itemPedidoMO2.TOTAL / itemPedidoMO2.QUANTIDADE_UNIDADE_VENDA.Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				itemPedidoMO2.VALOR_UNITARIO_PEDIDA = Math.Round(itemPedidoMO2.TOTAL_PEDIDA / itemPedidoMO2.QUANTIDADE_UNIDADE_PEDIDA.Value, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
				itemPedidoMO2.PRECO_UNITARIO = itemPedidoMO2.VALOR_UNITARIO_VENDA.Value / itemPedidoMO2.FATOR_ESTOQUE_VENDA.Value;
			}
			itemPedidoMO2.TOTAL = Math.Round(itemPedidoMO2.VALOR_UNITARIO_VENDA.ToDecimal() * itemPedidoMO2.QUANTIDADE_UNIDADE_VENDA.ToDecimal(), qtdeCasasDecimais, MidpointRounding.AwayFromZero);
			itemPedidoMO2.TOTAL_PEDIDA = Math.Round(itemPedidoMO2.VALOR_UNITARIO_PEDIDA.ToDecimal() * itemPedidoMO2.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal(), qtdeCasasDecimais, MidpointRounding.AwayFromZero);
		}
		pedidoVenda.VALOR_TAXA_CONTRATO = num6;
		decimal num9 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => Math.Round(x.VALOR_TAXA_CONTRATO.ToDecimal(), qtdeCasasDecimais, MidpointRounding.AwayFromZero));
		decimal value2 = Math.Round(pedidoVenda.VALOR_TAXA_CONTRATO.Value - num9, qtdeCasasDecimais, MidpointRounding.AwayFromZero);
		ItemPedidoMO itemPedidoMO3 = pedidoVenda.ITENS.First();
		itemPedidoMO3.VALOR_TAXA_CONTRATO += (decimal?)value2;
	}
}
