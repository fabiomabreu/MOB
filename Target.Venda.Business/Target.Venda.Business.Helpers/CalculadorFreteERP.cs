using System;
using System.Linq;
using Target.Venda.Business.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Helpers;

public class CalculadorFreteERP
{
	public void CalcularFrete(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		if (pedidoVenda.TIPO_ENTREGA == "RE")
		{
			pedidoVenda.TIPO_FRETE = "F";
			ZerarFrete(pedidoVenda, null);
			return;
		}
		RetornoCalcularValorFreteVO retornoCalcularValorFreteVO = null;
		bool flag = pedidoEletronico.MANTEM_VALOR_FRETE_PEDIDO_ELETRONICO.ToBool();
		if (pedidoEletronico.CODICO_INT_PEDIDO_ELETRONICO != "EZCOMMERCE" || !flag)
		{
			if (ConfigERP.PAR_CFG.UTILIZA_FRETE_ESTADO)
			{
				retornoCalcularValorFreteVO = CalcularValorFretePorEstado(pedidoVenda);
			}
			else
			{
				if (!ValidarCalculoFrete(pedidoVenda) || (pedidoVenda.CODIGO_FORNECEDOR <= 0 && pedidoVenda.TIPO_ENTREGA != "EN"))
				{
					ZerarFrete(pedidoVenda, retornoCalcularValorFreteVO);
					return;
				}
				retornoCalcularValorFreteVO = CalcularValorFrete(pedidoVenda);
			}
		}
		int num;
		if (retornoCalcularValorFreteVO != null)
		{
			decimal? vALOR_FRETE = pedidoVenda.VALOR_FRETE;
			num = (((vALOR_FRETE.GetValueOrDefault() > default(decimal)) & vALOR_FRETE.HasValue) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag2 = (byte)num != 0;
		if (flag2 && ((pedidoVenda.TIPO_FRETE == "C" && !retornoCalcularValorFreteVO.CALCULA_FRETE_CIF) || (pedidoVenda.TIPO_FRETE == "F" && !retornoCalcularValorFreteVO.CALCULA_FRETE_FOB)))
		{
			flag2 = false;
		}
		if (pedidoEletronico.CODICO_INT_PEDIDO_ELETRONICO == "EZCOMMERCE")
		{
			goto IL_019c;
		}
		if (flag)
		{
			decimal? vALOR_FRETE = pedidoVenda.VALOR_FRETE;
			if ((vALOR_FRETE.GetValueOrDefault() > default(decimal)) & vALOR_FRETE.HasValue)
			{
				goto IL_019c;
			}
		}
		if (flag2)
		{
			RatearValorFreteItensPedido(pedidoVenda, retornoCalcularValorFreteVO);
		}
		else
		{
			ZerarFrete(pedidoVenda, retornoCalcularValorFreteVO);
		}
		goto IL_01c7;
		IL_01c7:
		if (pedidoVenda.TIPO_ENTREGA == "EN" && !ConfigERP.PARAMETROS_TELA.VENDA.COBRA_FRETE_QUANDO_FOR_ENTREGA)
		{
			pedidoVenda.TIPO_FRETE = "C";
		}
		return;
		IL_019c:
		RatearManterValorFreteItensPedido(pedidoVenda);
		goto IL_01c7;
	}

	private void ZerarFrete(PedidoVendaMO pedidoVenda, RetornoCalcularValorFreteVO retornoCalculoFrete)
	{
		pedidoVenda.VALOR_FRETE = default(decimal);
		if (retornoCalculoFrete != null && ConfigERP.PARAMETROS_TELA.VENDA.ESCOLHA_AUTOMATICA_SE_CIF_OU_FOB_TRANSPORTADORA && (!retornoCalculoFrete.CALCULA_FRETE_CIF || !retornoCalculoFrete.CALCULA_FRETE_FOB))
		{
			if (retornoCalculoFrete.CALCULA_FRETE_CIF)
			{
				pedidoVenda.TIPO_FRETE = "F";
			}
			else if (retornoCalculoFrete.CALCULA_FRETE_FOB)
			{
				pedidoVenda.TIPO_FRETE = "C";
			}
		}
		pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO i)
		{
			i.VALOR_FRETE_ITEM = default(decimal);
			if (retornoCalculoFrete != null)
			{
				i.PERCENTUAL_ACRESCIMO_FRETE = retornoCalculoFrete.PERCENTUAL_FRETE;
			}
			else
			{
				i.PERCENTUAL_ACRESCIMO_FRETE = default(decimal);
			}
		});
	}

	private void RatearValorFreteItensPedido(PedidoVendaMO pedidoVenda, RetornoCalcularValorFreteVO retornoCalculoFrete)
	{
		decimal value = pedidoVenda.VALOR_FRETE.Value;
		decimal num = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VOLUME.ToDecimal() * x.QUANTIDADE);
		decimal valorTotalItens = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.TOTAL);
		RegiaoBLL regiaoBLL = new RegiaoBLL();
		RegiaoMO regiao = regiaoBLL.ObterPeloID(ConfigERP.PAR_CFG.QTDE_DEF_REGIAO);
		foreach (ItemPedidoMO item in pedidoVenda.ITENS.OrderBy((ItemPedidoMO x) => x.SEQ))
		{
			item.PERCENTUAL_ACRESCIMO_FRETE = retornoCalculoFrete.PERCENTUAL_FRETE;
			if (item.TOTAL == 0m)
			{
				item.VALOR_FRETE_ITEM = default(decimal);
				continue;
			}
			FretePorEntrega(pedidoVenda, regiao, item, valorTotalItens);
			FretePorTransportadora(pedidoVenda, retornoCalculoFrete, item, valorTotalItens);
			value -= item.VALOR_FRETE_ITEM.ToDecimal();
		}
		if (!(value != 0m))
		{
			return;
		}
		decimal? maiorFrete = pedidoVenda.ITENS.Max((ItemPedidoMO x) => x.VALOR_FRETE_ITEM);
		decimal? num2 = maiorFrete;
		if ((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue)
		{
			ItemPedidoMO itemPedidoMO = pedidoVenda.ITENS.Find((ItemPedidoMO x) => x.VALOR_FRETE_ITEM == maiorFrete);
			itemPedidoMO.VALOR_FRETE_ITEM += (decimal?)value;
		}
		else
		{
			ItemPedidoMO itemPedidoMO2 = pedidoVenda.ITENS.Last();
			itemPedidoMO2.VALOR_FRETE_ITEM = value;
		}
	}

	private void RatearManterValorFreteItensPedido(PedidoVendaMO pedidoVenda)
	{
		decimal value = pedidoVenda.VALOR_FRETE.Value;
		decimal num = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.VOLUME.ToDecimal() * x.QUANTIDADE);
		decimal valorTotalItens = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.TOTAL);
		foreach (ItemPedidoMO item in pedidoVenda.ITENS.OrderBy((ItemPedidoMO x) => x.SEQ))
		{
			item.PERCENTUAL_ACRESCIMO_FRETE = 1;
			if (item.TOTAL == 0m)
			{
				item.VALOR_FRETE_ITEM = default(decimal);
				continue;
			}
			FreteManterEletronico(pedidoVenda, item, valorTotalItens);
			value -= item.VALOR_FRETE_ITEM.ToDecimal();
		}
		if (!(value != 0m))
		{
			return;
		}
		decimal? maiorFrete = pedidoVenda.ITENS.Max((ItemPedidoMO x) => x.VALOR_FRETE_ITEM);
		decimal? num2 = maiorFrete;
		if ((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue)
		{
			ItemPedidoMO itemPedidoMO = pedidoVenda.ITENS.Find((ItemPedidoMO x) => x.VALOR_FRETE_ITEM == maiorFrete);
			itemPedidoMO.VALOR_FRETE_ITEM += (decimal?)value;
		}
		else
		{
			ItemPedidoMO itemPedidoMO2 = pedidoVenda.ITENS.Last();
			itemPedidoMO2.VALOR_FRETE_ITEM = value;
		}
	}

	private void FretePorEntrega(PedidoVendaMO pedidoVenda, RegiaoMO regiao, ItemPedidoMO itemPedido, decimal valorTotalItens)
	{
		if (pedidoVenda.TIPO_ENTREGA != "EN")
		{
			return;
		}
		if (regiao != null)
		{
			if (regiao.TIPO_COBRANCA_FRETE == "TF" || regiao.TIPO_COBRANCA_FRETE == "PE")
			{
				decimal d = itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value;
				itemPedido.VALOR_FRETE_ITEM = Math.Round(d, 2, MidpointRounding.AwayFromZero);
			}
			else if (regiao.TIPO_COBRANCA_FRETE == "KG")
			{
				decimal d2 = itemPedido.PESO_BRUTO.ToDecimal() / pedidoVenda.PESO_TOTAL.ToDecimal() * pedidoVenda.VALOR_FRETE.Value;
				itemPedido.VALOR_FRETE_ITEM = Math.Round(d2, 2, MidpointRounding.AwayFromZero);
			}
			else if (regiao.TIPO_COBRANCA_FRETE == "CU")
			{
				decimal? qUANTIDADE_VOLUMES = pedidoVenda.QUANTIDADE_VOLUMES;
				if (!((qUANTIDADE_VOLUMES.GetValueOrDefault() == default(decimal)) & qUANTIDADE_VOLUMES.HasValue) && pedidoVenda.QUANTIDADE_VOLUMES.HasValue)
				{
					decimal d3 = itemPedido.QUANTIDADE_VOLUMES.ToDecimal() * itemPedido.QUANTIDADE / pedidoVenda.QUANTIDADE_VOLUMES.ToDecimal() * pedidoVenda.VALOR_FRETE.ToDecimal();
					itemPedido.VALOR_FRETE_ITEM = Math.Round(d3, 2, MidpointRounding.AwayFromZero);
				}
				else
				{
					itemPedido.VALOR_FRETE_ITEM = default(decimal);
				}
			}
			else
			{
				decimal d4 = itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value;
				itemPedido.VALOR_FRETE_ITEM = Math.Round(d4, 2, MidpointRounding.AwayFromZero);
			}
		}
		else if (ConfigERP.PAR_CFG.TIPO_RATEIO_FRETE == "VA")
		{
			decimal d5 = itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value;
			itemPedido.VALOR_FRETE_ITEM = Math.Round(d5, 2, MidpointRounding.AwayFromZero);
		}
		else if (ConfigERP.PAR_CFG.TIPO_RATEIO_FRETE == "PE")
		{
			decimal d6 = itemPedido.PESO_BRUTO.ToDecimal() / pedidoVenda.PESO_TOTAL.ToDecimal() * pedidoVenda.VALOR_FRETE.ToDecimal();
			itemPedido.VALOR_FRETE_ITEM = Math.Round(d6, 2, MidpointRounding.AwayFromZero);
		}
	}

	private void FreteManterEletronico(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, decimal valorTotalItens)
	{
		if (ConfigERP.PAR_CFG.TIPO_RATEIO_FRETE == "VA")
		{
			decimal d = itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value;
			itemPedido.VALOR_FRETE_ITEM = Math.Round(d, 2, MidpointRounding.AwayFromZero);
		}
		else if (ConfigERP.PAR_CFG.TIPO_RATEIO_FRETE == "PE")
		{
			decimal d2 = itemPedido.PESO_BRUTO.ToDecimal() / pedidoVenda.PESO_TOTAL.ToDecimal() * pedidoVenda.VALOR_FRETE.ToDecimal();
			itemPedido.VALOR_FRETE_ITEM = Math.Round(d2, 2, MidpointRounding.AwayFromZero);
		}
	}

	private void FretePorTransportadora(PedidoVendaMO pedidoVenda, RetornoCalcularValorFreteVO retornoCalculoFrete, ItemPedidoMO itemPedido, decimal valorTotalItens)
	{
		if (pedidoVenda.TIPO_ENTREGA != "TR")
		{
			return;
		}
		decimal num = default(decimal);
		if (retornoCalculoFrete.TIPO_COBRANCA_FRETE == "TF" || retornoCalculoFrete.TIPO_COBRANCA_FRETE == "PE")
		{
			num = itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value;
		}
		else if (retornoCalculoFrete.TIPO_COBRANCA_FRETE == "KG" || retornoCalculoFrete.TIPO_COBRANCA_FRETE == "TP")
		{
			num = itemPedido.PESO_BRUTO.ToDecimal() / pedidoVenda.PESO_TOTAL.ToDecimal() * pedidoVenda.VALOR_FRETE.Value;
		}
		else if (!(retornoCalculoFrete.TIPO_COBRANCA_FRETE == "CU"))
		{
			num = ((ConfigERP.PAR_CFG.TIPO_RATEIO_FRETE == "VA") ? (itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value) : ((!(ConfigERP.PAR_CFG.TIPO_RATEIO_FRETE == "PE")) ? (itemPedido.TOTAL / valorTotalItens * pedidoVenda.VALOR_FRETE.Value) : (itemPedido.PESO_BRUTO.ToDecimal() / pedidoVenda.PESO_TOTAL.ToDecimal() * pedidoVenda.VALOR_FRETE.Value)));
		}
		else
		{
			decimal? qUANTIDADE_VOLUMES = pedidoVenda.QUANTIDADE_VOLUMES;
			if (!((qUANTIDADE_VOLUMES.GetValueOrDefault() == default(decimal)) & qUANTIDADE_VOLUMES.HasValue))
			{
				num = itemPedido.QUANTIDADE_VOLUMES.ToDecimal() * itemPedido.QUANTIDADE / pedidoVenda.QUANTIDADE_VOLUMES.ToDecimal() * pedidoVenda.VALOR_FRETE.Value;
			}
			else
			{
				itemPedido.VALOR_FRETE_ITEM = default(decimal);
			}
		}
		itemPedido.VALOR_FRETE_ITEM = Math.Truncate(num * 100m) / 100m;
	}

	private bool ValidarCalculoFrete(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.TIPO_ENTREGA == "RE")
		{
			return false;
		}
		bool flag = pedidoVenda.TIPO_ENTREGA == "TR" && !ConfigERP.PAR_CFG.ACRESCIMO_FRETE && pedidoVenda.CODIGO_FORNECEDOR > 0;
		bool flag2 = pedidoVenda.TIPO_ENTREGA == "EN";
		bool flag3 = flag || flag2;
		if (flag3)
		{
			bool flag4 = pedidoVenda.TIPO_FRETE == "C" || pedidoVenda.TIPO_FRETE == "F";
			flag3 = ConfigERP.PARAMETROS_TELA.VENDA.ESCOLHA_AUTOMATICA_SE_CIF_OU_FOB_TRANSPORTADORA || flag4;
		}
		bool flag5 = pedidoVenda.TIPO_ENTREGA == "TR" && ConfigERP.PAR_CFG.ACRESCIMO_FRETE;
		return flag3 || flag5;
	}

	private RetornoCalcularValorFreteVO CalcularValorFrete(PedidoVendaMO pedidoVenda)
	{
		RetornoCalcularValorFreteVO retornoCalcularValorFreteVO = null;
		retornoCalcularValorFreteVO = ((!(pedidoVenda.TIPO_ENTREGA == "TR") || ConfigERP.PAR_CFG.FRETE_UTILIZA_REGTRANS) ? CalculaValorFreteRegiao(pedidoVenda) : CalculaValorFreteTransportadora(pedidoVenda));
		if (retornoCalcularValorFreteVO != null)
		{
			pedidoVenda.VALOR_FRETE = Math.Round(retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE, 2, MidpointRounding.AwayFromZero);
		}
		return retornoCalcularValorFreteVO;
	}

	private RetornoCalcularValorFreteVO CalculaValorFreteTransportadora(PedidoVendaMO pedidoVenda)
	{
		FreteBLL freteBLL = new FreteBLL();
		FreteVO freteVO = freteBLL.ObterConfiguracaoFrete(pedidoVenda);
		if (freteVO == null)
		{
			MyException ex = new MyException();
			ex.AddAviso("Não existe frete cadastrado nessa faixa de CEP para essa transportadora.");
			return null;
		}
		CalculoFreteVO calculoFrete = CarregaParametroCalcularValorFreteTransportadora(pedidoVenda, freteVO);
		RetornoCalcularValorFreteVO retornoCalcularValorFreteVO = CalculaFreteMenorCalculo(freteVO, calculoFrete);
		CalcularCustoFinanceiro(pedidoVenda, retornoCalcularValorFreteVO);
		VerificarFreteMinimoIsencaoFreteTransportadora(freteVO, calculoFrete, retornoCalcularValorFreteVO);
		MontaRetornoFreteTransportadora(freteVO, calculoFrete, retornoCalcularValorFreteVO);
		return retornoCalcularValorFreteVO;
	}

	private CalculoFreteVO CarregaParametroCalcularValorFreteTransportadora(PedidoVendaMO pedidoVenda, FreteVO configFrete)
	{
		CalculoFreteVO calculoFreteVO = new CalculoFreteVO();
		calculoFreteVO.VALOR_TOTAL_ITENS = pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
		{
			decimal qUANTIDADE2 = x.QUANTIDADE;
			decimal? pRECO_UNITARIO = x.PRECO_UNITARIO;
			return Math.Round(((decimal?)qUANTIDADE2 * pRECO_UNITARIO).ToDecimal(), 4, MidpointRounding.AwayFromZero);
		}).ToDecimal();
		decimal num = SomarPesoItens(pedidoVenda, configFrete.VALOR_FRETE_UNIDADE);
		if (configFrete.TIPO_COBRANCA_CUBAGEM)
		{
			decimal num2 = pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
			{
				decimal qUANTIDADE = x.QUANTIDADE;
				decimal? vOLUME = x.VOLUME;
				return Math.Round(((decimal?)qUANTIDADE * vOLUME).ToDecimal(), 3, MidpointRounding.AwayFromZero);
			}).ToDecimal();
			calculoFreteVO.VALOR_FRETE_CUBAGEM = num2 * configFrete.TIPO_COBRANCA_CUBAGEM_VALOR.ToDecimal();
		}
		if (configFrete.TIPO_COBRANCA_PESAGEM)
		{
			calculoFreteVO.VALOR_FRETE_PESAGEM = num * configFrete.TIPO_COBRANCA_PESAGEM_VALOR.ToDecimal();
		}
		if (configFrete.TIPO_COBRANCA_PERCENTUAL)
		{
			calculoFreteVO.VALOR_FRETE_PERCENTUAL = calculoFreteVO.VALOR_TOTAL_ITENS * configFrete.TIPO_COBRANCA_PERCENTUAL_VALOR.ToDecimal();
		}
		FreteBLL freteBLL = new FreteBLL();
		if (configFrete.TIPO_COBRANCA_FIXO_PESO)
		{
			calculoFreteVO.VALOR_FRETE_FIXA_PESO = freteBLL.ObterValorFretePeloFatorPeso(configFrete, num);
		}
		if (configFrete.TIPO_COBRANCA_FIXO_VALOR)
		{
			calculoFreteVO.VALOR_FRETE_FIXA_VALOR = freteBLL.ObterValorFretePeloFatorValor(configFrete, calculoFreteVO.VALOR_TOTAL_ITENS);
		}
		return calculoFreteVO;
	}

	private RetornoCalcularValorFreteVO CalculaFreteMenorCalculo(FreteVO configFrete, CalculoFreteVO calculoFrete)
	{
		RetornoCalcularValorFreteVO retornoCalcularValorFreteVO = new RetornoCalcularValorFreteVO();
		if (configFrete.MELHOR_CALCULO)
		{
			if (retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE < calculoFrete.VALOR_FRETE_CUBAGEM)
			{
				retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "CU";
				retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_CUBAGEM;
			}
			if (retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE < calculoFrete.VALOR_FRETE_PESAGEM)
			{
				retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "KG";
				retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_PESAGEM;
			}
			if (retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE < calculoFrete.VALOR_FRETE_PERCENTUAL)
			{
				retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "PE";
				retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_PERCENTUAL;
			}
			if (retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE < calculoFrete.VALOR_FRETE_FIXA_PESO)
			{
				retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "TP";
				retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_FIXA_PESO;
			}
			if (retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE < calculoFrete.VALOR_FRETE_FIXA_VALOR)
			{
				retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "TF";
				retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_FIXA_VALOR;
			}
		}
		else if (configFrete.TIPO_COBRANCA_CUBAGEM)
		{
			retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "CU";
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_CUBAGEM;
		}
		else if (configFrete.TIPO_COBRANCA_PESAGEM)
		{
			retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "KG";
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_PESAGEM;
		}
		else if (configFrete.TIPO_COBRANCA_PERCENTUAL)
		{
			retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "PE";
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_PERCENTUAL;
		}
		else if (configFrete.TIPO_COBRANCA_FIXO_PESO)
		{
			retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "TP";
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_FIXA_PESO;
		}
		else if (configFrete.TIPO_COBRANCA_FIXO_VALOR)
		{
			retornoCalcularValorFreteVO.TIPO_COBRANCA_FRETE = "TF";
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = calculoFrete.VALOR_FRETE_FIXA_VALOR;
		}
		return retornoCalcularValorFreteVO;
	}

	private void VerificarFreteMinimoIsencaoFreteTransportadora(FreteVO configFrete, CalculoFreteVO calculoFrete, RetornoCalcularValorFreteVO retorno)
	{
		if (retorno.VALOR_TOTAL_FRETE < configFrete.VALOR_FRETE_MINIMO)
		{
			retorno.VALOR_TOTAL_FRETE = configFrete.VALOR_FRETE_MINIMO;
		}
		if (configFrete.ISENCAO)
		{
			decimal vALOR_TOTAL_ITENS = calculoFrete.VALOR_TOTAL_ITENS;
			decimal? iSENCAO_VALOR_MINIMO_PEDIDO = configFrete.ISENCAO_VALOR_MINIMO_PEDIDO;
			if ((vALOR_TOTAL_ITENS >= iSENCAO_VALOR_MINIMO_PEDIDO.GetValueOrDefault()) & iSENCAO_VALOR_MINIMO_PEDIDO.HasValue)
			{
				retorno.VALOR_TOTAL_FRETE = 0m;
			}
		}
	}

	private void MontaRetornoFreteTransportadora(FreteVO configFrete, CalculoFreteVO calculoFrete, RetornoCalcularValorFreteVO retorno)
	{
		retorno.VALOR_FRETE_MINIMO = configFrete.VALOR_FRETE_MINIMO;
		retorno.ISENCAO_FRETE = configFrete.ISENCAO;
		retorno.ISENCAO_VALOR_MINIMO_PEDIDO = configFrete.ISENCAO_VALOR_MINIMO_PEDIDO.ToDecimal();
		retorno.CALCULA_FRETE_CIF = configFrete.CALCULAR_FRETE_CIF;
		retorno.CALCULA_FRETE_FOB = configFrete.CALCULAR_FRETE_FOB;
		if (retorno.TIPO_COBRANCA_FRETE == "CU")
		{
			retorno.VALOR_FRETE_UNIDADE = configFrete.TIPO_COBRANCA_CUBAGEM_VALOR.ToDecimal();
		}
		else if (retorno.TIPO_COBRANCA_FRETE == "KG")
		{
			retorno.VALOR_FRETE_UNIDADE = configFrete.TIPO_COBRANCA_PESAGEM_VALOR.ToDecimal();
		}
		else if (retorno.TIPO_COBRANCA_FRETE == "PE")
		{
			retorno.PERCENTUAL_FRETE = configFrete.TIPO_COBRANCA_PERCENTUAL_VALOR.ToDecimal();
		}
		else if (retorno.TIPO_COBRANCA_FRETE == "TP")
		{
			retorno.VALOR_FRETE_UNIDADE = calculoFrete.VALOR_FRETE_FIXA_PESO;
		}
		else if (retorno.TIPO_COBRANCA_FRETE == "TF")
		{
			retorno.VALOR_TAXA_FIXA = calculoFrete.VALOR_FRETE_FIXA_VALOR;
		}
	}

	private RetornoCalcularValorFreteVO CalculaValorFreteRegiao(PedidoVendaMO pedidoVenda)
	{
		FreteVO freteVO;
		if (pedidoVenda.TIPO_ENTREGA == "TR")
		{
			RegTransBLL regTransBLL = new RegTransBLL();
			freteVO = regTransBLL.ObterConfiguracaoFreteRegTrans(pedidoVenda);
		}
		else
		{
			RegiaoBLL regiaoBLL = new RegiaoBLL();
			freteVO = regiaoBLL.ObterConfiguracaoFreteRegiao(pedidoVenda);
		}
		if (freteVO == null)
		{
			if (pedidoVenda.TIPO_ENTREGA == "TR")
			{
				MyException ex = new MyException();
				ex.AddAviso("Não existe frete cadastrado nessa faixa de CEP para essa transportadora.");
			}
			return null;
		}
		RetornoCalcularValorFreteVO retornoCalcularValorFreteVO = CarregaParametroCalcularValorFreteRegioes(pedidoVenda, freteVO);
		CalcularCustoFinanceiro(pedidoVenda, retornoCalcularValorFreteVO);
		VerificarFreteMinimoIsencaoFreteRegiao(pedidoVenda, freteVO, retornoCalcularValorFreteVO);
		MontaRetornoFreteRegiao(freteVO, retornoCalcularValorFreteVO);
		return retornoCalcularValorFreteVO;
	}

	private RetornoCalcularValorFreteVO CarregaParametroCalcularValorFreteRegioes(PedidoVendaMO pedidoVenda, FreteVO configFrete)
	{
		RetornoCalcularValorFreteVO retornoCalcularValorFreteVO = new RetornoCalcularValorFreteVO();
		if (configFrete.TIPO_COBRANCA_FRETE == "KG")
		{
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = SomarPesoItens(pedidoVenda, configFrete.VALOR_FRETE_UNIDADE);
		}
		else if (configFrete.TIPO_COBRANCA_FRETE == "CU")
		{
			decimal num = pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
			{
				decimal qUANTIDADE = x.QUANTIDADE;
				decimal? vOLUME = x.VOLUME;
				decimal? num2 = (decimal?)qUANTIDADE * vOLUME * (decimal?)configFrete.VALOR_FRETE_UNIDADE;
				return num2.ToDouble();
			}).ToDecimal();
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = num * configFrete.TIPO_COBRANCA_CUBAGEM_VALOR.ToDecimal();
		}
		else if (configFrete.TIPO_COBRANCA_FRETE == "PE")
		{
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.PRECO_UNITARIO.ToDecimal() * x.QUANTIDADE * configFrete.PERCENTUAL_FRETE);
		}
		else if (configFrete.TIPO_COBRANCA_FRETE == "TP")
		{
			decimal pesoTotal = SomarPesoItens(pedidoVenda, 0m);
			RegTransBLL regTransBLL = new RegTransBLL();
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = regTransBLL.ObterValorFretePeloRegTransPeso(configFrete, pedidoVenda, pesoTotal);
		}
		else if (configFrete.TIPO_COBRANCA_FRETE == "TP")
		{
			retornoCalcularValorFreteVO.VALOR_TOTAL_FRETE = configFrete.VALOR_TAXA_FIXA;
		}
		return retornoCalcularValorFreteVO;
	}

	private void VerificarFreteMinimoIsencaoFreteRegiao(PedidoVendaMO pedidoVenda, FreteVO configFrete, RetornoCalcularValorFreteVO retorno)
	{
		if (retorno.VALOR_TOTAL_FRETE < configFrete.VALOR_FRETE_MINIMO && (configFrete.CALCULO_FRETE_APARTIR <= 0m || retorno.VALOR_TOTAL_FRETE < configFrete.CALCULO_FRETE_APARTIR))
		{
			retorno.VALOR_TOTAL_FRETE = configFrete.VALOR_FRETE_MINIMO;
		}
		if (pedidoVenda.TIPO_ENTREGA == "TR" && ConfigERP.PAR_CFG.ACRESCIMO_FRETE)
		{
			return;
		}
		retorno.VALOR_TOTAL_FRETE = ValorTotalPedidoVenda(pedidoVenda);
		if (configFrete.ISENCAO)
		{
			decimal vALOR_TOTAL_FRETE = retorno.VALOR_TOTAL_FRETE;
			decimal? iSENCAO_VALOR_MINIMO_PEDIDO = configFrete.ISENCAO_VALOR_MINIMO_PEDIDO;
			if ((vALOR_TOTAL_FRETE > iSENCAO_VALOR_MINIMO_PEDIDO.GetValueOrDefault()) & iSENCAO_VALOR_MINIMO_PEDIDO.HasValue)
			{
				retorno.VALOR_TOTAL_FRETE = 0m;
				return;
			}
		}
		retorno.VALOR_TOTAL_FRETE = configFrete.VALOR_TAXA_FIXA;
	}

	private void MontaRetornoFreteRegiao(FreteVO configFrete, RetornoCalcularValorFreteVO retorno)
	{
		retorno.TIPO_COBRANCA_FRETE = configFrete.TIPO_COBRANCA_FRETE;
		retorno.VALOR_FRETE_UNIDADE = configFrete.VALOR_FRETE_UNIDADE;
		retorno.PERCENTUAL_FRETE = configFrete.PERCENTUAL_FRETE;
		retorno.VALOR_TAXA_FIXA = configFrete.VALOR_TAXA_FIXA;
		retorno.ISENCAO_VALOR_MINIMO_PEDIDO = configFrete.ISENCAO_VALOR_MINIMO_PEDIDO.ToDecimal();
		retorno.VALOR_FRETE_MINIMO = configFrete.VALOR_FRETE_MINIMO;
		retorno.ISENCAO_FRETE = configFrete.ISENCAO;
		retorno.CALCULA_FRETE_CIF = configFrete.CALCULAR_FRETE_CIF;
		retorno.CALCULA_FRETE_FOB = configFrete.CALCULAR_FRETE_FOB;
	}

	private decimal ValorTotalPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		decimal num = default(decimal);
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			num += iTEN.PRECO_UNITARIO.ToDecimal() * iTEN.QUANTIDADE * (1m - iTEN.DESCONTO_APLICADO.ToDecimal());
		}
		return num * (1m - pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal());
	}

	private decimal SomarPesoItens(PedidoVendaMO pedidoVenda, decimal VALOR_FRETE_UNIDADE)
	{
		string text = "BRT";
		if (ConfigERP.PARAMETROS_TELA.VENDA.PESO_LIQ_SUBSTITUI_PESO_BRT_NO_CALCULO_FRETE)
		{
			text = "LIQ";
		}
		if (VALOR_FRETE_UNIDADE == 0m)
		{
			VALOR_FRETE_UNIDADE = 1m;
		}
		decimal num = default(decimal);
		if (text == "LIQ")
		{
			return pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
			{
				decimal num3 = x.QUANTIDADE * x.PESO_LIQUIDO.ToDecimal() * VALOR_FRETE_UNIDADE;
				return Math.Round(num3.ToDecimal(), 3, MidpointRounding.AwayFromZero);
			}).ToDecimal();
		}
		return pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
		{
			decimal num2 = x.QUANTIDADE * x.PESO_BRUTO.ToDecimal() * VALOR_FRETE_UNIDADE;
			return Math.Round(num2.ToDecimal(), 3, MidpointRounding.AwayFromZero);
		}).ToDecimal();
	}

	private void CalcularCustoFinanceiro(PedidoVendaMO pedidoVenda, RetornoCalcularValorFreteVO retorno)
	{
		if (ConfigERP.PARAMETROS_TELA.VENDA.CALCULAR_CUSTO_FINANCEIRO_SOBRE_VALOR_DO_FRETE && retorno.VALOR_TOTAL_FRETE > 0m)
		{
			PromocaoBLL promocaoBLL = new PromocaoBLL();
			decimal num = promocaoBLL.ObterCoeficienteParcela(pedidoVenda.SEQ_PROMOCAO.Value);
			short tOTAL_PARCELAS = pedidoVenda.PROMOCAO.TOTAL_PARCELAS;
			retorno.VALOR_TOTAL_FRETE *= 1m / num * (decimal)tOTAL_PARCELAS;
		}
	}

	private RetornoCalcularValorFreteVO CalcularValorFretePorEstado(PedidoVendaMO pedidoVenda)
	{
		RetornoCalcularValorFreteVO result = new RetornoCalcularValorFreteVO();
		if (pedidoVenda.TIPO_ENTREGA == "EN" || (pedidoVenda.TIPO_ENTREGA == "TR" && !ConfigERP.PAR_CFG.ACRESCIMO_FRETE && pedidoVenda.CODIGO_FORNECEDOR > 0))
		{
			result = CalcularValorFrete(pedidoVenda);
		}
		else
		{
			ZerarFrete(pedidoVenda, null);
		}
		return result;
	}
}
