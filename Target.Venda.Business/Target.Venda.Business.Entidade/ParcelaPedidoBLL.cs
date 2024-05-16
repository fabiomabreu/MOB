using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class ParcelaPedidoBLL : EntidadeBaseBLL<ParcelaPedidoMO>
{
	protected override EntidadeBaseDAL<ParcelaPedidoMO> GetInstanceDAL()
	{
		return new ParcelaPedidoDAL();
	}

	public DateTime ObterDataPrimeiroVencimento(PedidoVendaMO pedidoVenda)
	{
		DateTime dataAtual = DateTimeHelper.ObterDataHoraAtualBancoDados();
		PromocaoMO pROMOCAO = pedidoVenda.PROMOCAO;
		if (pROMOCAO.DATA_BASE == "EP" && pedidoVenda.DATA_ENTREGA.HasValue)
		{
			dataAtual = pedidoVenda.DATA_ENTREGA.Value;
		}
		else if (pROMOCAO.DATA_BASE == "FA")
		{
			dataAtual = pedidoVenda.DATA_PREVISAO_FATURAMENTO.ToDateTime();
		}
		DateTime dateTime = DateTimeHelper.FormartarDataPeloTipo(dataAtual, TipoDateTime.Data);
		if (pROMOCAO.DATA_BASE == "EP" && pROMOCAO.INICIO_PRAZO == "DD")
		{
			dateTime = CalendarioERP.SomaDiasUteis(pedidoVenda.CODIGO_EMPRESA, dateTime, 1);
		}
		if (pROMOCAO.INICIO_PRAZO == "FS")
		{
			while (dateTime.DayOfWeek != 0)
			{
				dateTime = dateTime.AddDays(1.0);
			}
			dateTime = CalendarioERP.SomaDiasUteis(pedidoVenda.CODIGO_EMPRESA, dateTime, 1);
		}
		else if (pROMOCAO.INICIO_PRAZO == "FD")
		{
			dateTime = ((dateTime.Day <= 10) ? new DateTime(dateTime.Year, dateTime.Month, 11, 0, 0, 0) : ((dateTime.Day <= 20) ? new DateTime(dateTime.Year, dateTime.Month, 21, 0, 0, 0) : ((dateTime.Month != 12) ? new DateTime(dateTime.Year, dateTime.Month + 1, 1, 0, 0, 0) : new DateTime(dateTime.Year + 1, 1, 1, 0, 0, 0))));
		}
		else if (pROMOCAO.INICIO_PRAZO == "FQ")
		{
			dateTime = ((dateTime.Day <= 15) ? new DateTime(dateTime.Year, dateTime.Month, 16, 0, 0, 0) : ((dateTime.Month != 12) ? new DateTime(dateTime.Year, dateTime.Month + 1, 1, 0, 0, 0) : new DateTime(dateTime.Year + 1, 1, 1, 0, 0, 0)));
		}
		else if (pROMOCAO.INICIO_PRAZO == "FM")
		{
			dateTime = ((dateTime.Month != 12) ? new DateTime(dateTime.Year, dateTime.Month + 1, 1, 0, 0, 0) : new DateTime(dateTime.Year + 1, 1, 1, 0, 0, 0));
		}
		if (ConfigERP.PAR_CFG.TITREC_PROX_DIA_UTIL)
		{
			dateTime = dateTime.AddDays(1.0);
			dateTime = CalendarioERP.BuscaProximoDiaUtil(pedidoVenda.CODIGO_EMPRESA, dateTime);
		}
		return dateTime;
	}

	public ParcelaPrazoDiferenciadoVO ObterPrazoDiferenciado(PedidoVendaMO pedidoVenda)
	{
		ParcelaPrazoDiferenciadoVO parcelaPrazoDiferenciadoVO = new ParcelaPrazoDiferenciadoVO();
		if (!pedidoVenda.PROMOCAO.CONSIDERA_PRAZO_FIXO_PRODUTO.ToBool() && !ConfigERP.PAR_CFG.CONSIDERA_PRAZO_MEDIO_PROM)
		{
			parcelaPrazoDiferenciadoVO.VALOR_TOTAL_PRAZO_PADRAO = pedidoVenda.VALOR_TOTAL.ToDecimal();
			return parcelaPrazoDiferenciadoVO;
		}
		List<ParcelaPrazoDiferenciadoItemVO> list = (from i in pedidoVenda.ITENS
			where i.PRAZO_MEDIO_MAXIMO > 0
			group i by i.PRAZO_MEDIO_MAXIMO into r
			select new ParcelaPrazoDiferenciadoItemVO
			{
				PRAZO_MEDIO = r.Key.ToInt(),
				VALOR = r.Sum((ItemPedidoMO x) => SomarTotalItem(pedidoVenda, x))
			}).ToList();
		if (!pedidoVenda.PROMOCAO.CONSIDERA_PRAZO_FIXO_PRODUTO.ToBool())
		{
			list.RemoveAll(delegate(ParcelaPrazoDiferenciadoItemVO x)
			{
				decimal num = x.PRAZO_MEDIO;
				decimal? pRAZO_MEDIO = pedidoVenda.PROMOCAO.PRAZO_MEDIO;
				return (num >= pRAZO_MEDIO.GetValueOrDefault()) & pRAZO_MEDIO.HasValue;
			});
		}
		parcelaPrazoDiferenciadoVO.VALOR_TOTAL_PRAZO_DIFERENCIADO = Math.Round(list.Sum((ParcelaPrazoDiferenciadoItemVO x) => x.VALOR), 2, MidpointRounding.AwayFromZero);
		parcelaPrazoDiferenciadoVO.VALOR_TOTAL_PRAZO_PADRAO = pedidoVenda.VALOR_TOTAL.ToDecimal() - parcelaPrazoDiferenciadoVO.VALOR_TOTAL_PRAZO_DIFERENCIADO;
		parcelaPrazoDiferenciadoVO.VALORES = list;
		return parcelaPrazoDiferenciadoVO;
	}

	private decimal SomarTotalItem(PedidoVendaMO pedidoVenda, ItemPedidoMO item)
	{
		decimal num = pedidoVenda.PERCENTUAL_DESCONTO_GERAL.ToDecimal();
		if (ConfigERP.PAR_CFG.UNID_PEDIDA)
		{
			return Math.Round(item.TOTAL_PEDIDA * (1m - num), 2, MidpointRounding.AwayFromZero);
		}
		return Math.Round(item.TOTAL * (1m - num), 2, MidpointRounding.AwayFromZero);
	}

	public List<ParcelaPedidoMO> GerarParcelasPelaCondicaoPagamento(PedidoVendaMO pedidoVenda, decimal valorTotalPrazoPadrao, DateTime DataPrimeiroVencimento)
	{
		if (valorTotalPrazoPadrao == 0m)
		{
			return new List<ParcelaPedidoMO>();
		}
		List<ParcelaPedidoMO> list = new List<ParcelaPedidoMO>();
		PromocaoParcelasBLL promocaoParcelasBLL = new PromocaoParcelasBLL();
		List<PromocaoParcelasMO> list2 = promocaoParcelasBLL.ObterPromocaoParcelaPelaSeqPromocao(pedidoVenda.SEQ_PROMOCAO.Value);
		PromocaoMO pROMOCAO = pedidoVenda.PROMOCAO;
		if (pedidoVenda.FORMA_PAGAMENTO == "CC")
		{
			list2.RemoveAll((PromocaoParcelasMO x) => x.NUMERO_PARCELA > pedidoVenda.QTDE_PARCELAS_CARTAO_CREDITO);
			pROMOCAO.TOTAL_PARCELAS = (short)list2.Count;
		}
		decimal num = default(decimal);
		foreach (PromocaoParcelasMO item in list2)
		{
			ParcelaPedidoMO parcelaPedidoMO = new ParcelaPedidoMO();
			DateTime dateTime = default(DateTime);
			if (pROMOCAO.TIPO_PRAZO == "D")
			{
				dateTime = DataPrimeiroVencimento.AddDays(item.QUANTIDADE_PRAZO.ToInt());
			}
			else if (pROMOCAO.TIPO_PRAZO == "M")
			{
				dateTime = DataPrimeiroVencimento.AddMonths(item.QUANTIDADE_PRAZO.ToInt());
			}
			if (pROMOCAO.VENCIMENTO_FIXO.ToBool())
			{
				parcelaPedidoMO.DATA_PARCELA = item.DATA_VENCIMENTO_FIXO.Value;
			}
			else
			{
				parcelaPedidoMO.DATA_PARCELA = dateTime.AddDays(pedidoVenda.CLIENTE.DIAS_PRORROGACAO_VENCIMENTO.ToInt());
			}
			parcelaPedidoMO.VALOR_PARCELA = Math.Round(valorTotalPrazoPadrao / (decimal)pROMOCAO.TOTAL_PARCELAS, 2, MidpointRounding.AwayFromZero);
			num += parcelaPedidoMO.VALOR_PARCELA;
			parcelaPedidoMO.TIPO_TITULO = pedidoVenda.FORMA_PAGAMENTO;
			parcelaPedidoMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			parcelaPedidoMO.DATA_PARCELA_SUGERIDA = parcelaPedidoMO.DATA_PARCELA;
			list.Add(parcelaPedidoMO);
		}
		list.First().VALOR_PARCELA += valorTotalPrazoPadrao - num;
		return list;
	}

	public void GerarParcelasPrazoDiferenciado(PedidoVendaMO pedidoVenda, List<ParcelaPedidoMO> parcelas, ParcelaPrazoDiferenciadoVO prazoDiferenciado, DateTime DataPrimeiroVencimento)
	{
		if (prazoDiferenciado.VALORES == null)
		{
			return;
		}
		decimal num = default(decimal);
		foreach (ParcelaPrazoDiferenciadoItemVO vALORE in prazoDiferenciado.VALORES)
		{
			DateTime data = DataPrimeiroVencimento.AddDays(vALORE.PRAZO_MEDIO);
			ParcelaPedidoMO parcelaPedidoMO = parcelas.Find((ParcelaPedidoMO x) => x.DATA_PARCELA == data);
			if (parcelaPedidoMO != null)
			{
				parcelaPedidoMO.VALOR_PARCELA += vALORE.VALOR;
			}
			else
			{
				ParcelaPedidoMO parcelaPedidoMO2 = new ParcelaPedidoMO();
				parcelaPedidoMO2.DATA_PARCELA = data;
				parcelaPedidoMO2.VALOR_PARCELA = vALORE.VALOR;
				parcelaPedidoMO2.TIPO_TITULO = pedidoVenda.FORMA_PAGAMENTO;
				parcelaPedidoMO2.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
				parcelaPedidoMO2.DATA_PARCELA_SUGERIDA = parcelaPedidoMO2.DATA_PARCELA;
				parcelas.Add(parcelaPedidoMO2);
			}
			num += vALORE.VALOR;
		}
		decimal num2 = prazoDiferenciado.VALOR_TOTAL_PRAZO_DIFERENCIADO - num;
		if (parcelas.Count > 0)
		{
			parcelas.OrderBy((ParcelaPedidoMO x) => x.DATA_PARCELA).First().VALOR_PARCELA += num2;
		}
	}

	public void ValidarParcelasPedido(PedidoVendaMO pedidoVenda, List<ParcelaPedidoMO> parcelas)
	{
		decimal num = pedidoVenda.VALOR_TOTAL.ToDecimal();
		parcelas = parcelas.OrderBy((ParcelaPedidoMO x) => x.DATA_PARCELA).ToList();
		if (num == 0m)
		{
			new MyException("Pedido com valor zerado").ThrowException();
		}
		decimal num2 = parcelas.Sum((ParcelaPedidoMO s) => s.VALOR_PARCELA);
		if (num != num2)
		{
			new MyException("Valor total do pedido é diferente da soma das parcelas").ThrowException();
		}
		parcelas.RemoveAll((ParcelaPedidoMO x) => x.VALOR_PARCELA <= 0m);
		short seqParcela = 0;
		parcelas.ForEach(delegate(ParcelaPedidoMO x)
		{
			seqParcela++;
			x.SEQ_PARCELA_PEDIDO = seqParcela;
			x.VALOR_PARCELA = Math.Round(x.VALOR_PARCELA, 2, MidpointRounding.AwayFromZero);
		});
		pedidoVenda.PARCELAS = parcelas;
	}
}
