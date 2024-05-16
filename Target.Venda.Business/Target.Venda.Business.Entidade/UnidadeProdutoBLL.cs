using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class UnidadeProdutoBLL : EntidadeBaseBLL<UnidadeProdutoMO>
{
	protected override EntidadeBaseDAL<UnidadeProdutoMO> GetInstanceDAL()
	{
		return new UnidadeProdutoDAL();
	}

	public UnidadeProdutoMO ObterMenorUnidadeElegivel(int codigoProduto, decimal quantidade)
	{
		return (BaseDAL as UnidadeProdutoDAL).ObterMenorUnidadeElegivel(codigoProduto, quantidade);
	}

	public void UtilizaVendaMenorUnidade(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		List<string> list = new List<string>();
		list.Add("UNL");
		list.Add("RJD");
		list.Add("AFD");
		list.Add("MOI");
		bool flag = list.Contains(ConfigERP.PAR_CFG.SIGLA_CLIENTE);
		bool flag2 = itemPedido.QUANTIDADE < itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
		bool flag3 = itemPedido.INDICE_RELACAO == "MAIOR";
		if (flag3 && flag2 && !flag && AlterarParaMenorUnidade(itemPedido))
		{
			TratarAlteracaoUnidade(itemPedido);
		}
	}

	public void CarregarMaiorUnidadeVendaItem(ItemPedidoMO itemPedido)
	{
		bool fATURA_NA_MAIOR_UNID_DE_VENDA_POSSIVEL = ConfigERP.PARAMETROS_TELA.VENDA.FATURA_NA_MAIOR_UNID_DE_VENDA_POSSIVEL;
		bool flag = ConfigERP.PAR_CFG.UNID_PEDIDA || ConfigERP.PAR_CFG.UNID_VDA_VAR;
		bool flag2 = itemPedido.UNIDADE_PEDIDA == itemPedido.UNIDADE_VENDA;
		if ((!flag && !fATURA_NA_MAIOR_UNID_DE_VENDA_POSSIVEL) || flag2)
		{
			return;
		}
		UnidadeProdutoMO unidadeProdutoMO = new UnidadeProdutoMO();
		unidadeProdutoMO.CODIGO_PRODUTO = itemPedido.CODIGO_PRODUTO;
		unidadeProdutoMO.UNIDADE_VENDA = itemPedido.UNIDADE_PEDIDA;
		UnidadeProdutoMO unidadeProdutoMO2 = (from x in ObterPeloExemplo(unidadeProdutoMO)
			orderby x.QUANTIDADE_UNIDADE descending
			select x).FirstOrDefault();
		itemPedido.FATOR_PRECO = unidadeProdutoMO2.FATOR_PRECO;
		unidadeProdutoMO = new UnidadeProdutoMO();
		unidadeProdutoMO.CODIGO_PRODUTO = itemPedido.CODIGO_PRODUTO;
		unidadeProdutoMO.UNIDADE_VENDA = itemPedido.UNIDADE_PEDIDA;
		unidadeProdutoMO.VENDA = BoolEnum.True;
		UnidadeProdutoMO unidadeProdutoMO3 = (from x in ObterPeloExemplo(unidadeProdutoMO)
			orderby x.QUANTIDADE_UNIDADE descending
			select x).FirstOrDefault();
		if (unidadeProdutoMO3 == null)
		{
			unidadeProdutoMO = new UnidadeProdutoMO();
			unidadeProdutoMO.CODIGO_PRODUTO = itemPedido.CODIGO_PRODUTO;
			unidadeProdutoMO.VENDA = BoolEnum.True;
			unidadeProdutoMO.UNIDADE_VENDA = itemPedido.UNIDADE;
			unidadeProdutoMO3 = (from x in ObterPeloExemplo(unidadeProdutoMO)
				orderby x.QUANTIDADE_UNIDADE descending
				select x).FirstOrDefault();
		}
		if (unidadeProdutoMO3 != null && itemPedido.UNIDADE_VENDA != unidadeProdutoMO3.UNIDADE_VENDA)
		{
			itemPedido.UNIDADE_VENDA = unidadeProdutoMO3.UNIDADE_VENDA;
			itemPedido.INDICE_RELACAO_VENDA = unidadeProdutoMO3.INDICE_RELACAO;
			itemPedido.FATOR_ESTOQUE_VENDA = unidadeProdutoMO3.FATOR_ESTOQUE;
		}
	}

	public bool AlterarParaMenorUnidade(ItemPedidoMO itemPedido)
	{
		UnidadeProdutoMO unidadeProdutoMO = ObterMenorUnidadeElegivel(itemPedido.CODIGO_PRODUTO, itemPedido.QUANTIDADE);
		if (unidadeProdutoMO != null)
		{
			itemPedido.UNIDADE_PEDIDA = unidadeProdutoMO.UNIDADE_VENDA;
			itemPedido.UNIDADE_VENDA = unidadeProdutoMO.UNIDADE_VENDA;
			itemPedido.FATOR_ESTOQUE_PEDIDA = unidadeProdutoMO.FATOR_ESTOQUE.ToDouble();
			itemPedido.FATOR_ESTOQUE_VENDA = unidadeProdutoMO.FATOR_ESTOQUE.ToDecimal();
			itemPedido.INDICE_RELACAO_VENDA = unidadeProdutoMO.INDICE_RELACAO;
			itemPedido.INDICE_RELACAO = unidadeProdutoMO.INDICE_RELACAO;
			return true;
		}
		itemPedido.STATUS_ENTIDADE = StatusModelEnum.DELETADO;
		return false;
	}

	public void TratarAlteracaoUnidade(ItemPedidoMO itemPedido)
	{
		if (itemPedido.FATOR_ESTOQUE_PEDIDA == 0.0)
		{
			itemPedido.QUANTIDADE = 0m;
			itemPedido.QUANTIDADE_UNIDADE_PEDIDA = default(decimal);
			itemPedido.QUANTIDADE_UNIDADE_VENDA = default(decimal);
			itemPedido.VALOR_UNITARIO_VENDA = default(decimal);
			itemPedido.VALOR_UNITARIO_PEDIDA = default(decimal);
		}
		else if (itemPedido.INDICE_RELACAO == "MAIOR")
		{
			itemPedido.QUANTIDADE -= itemPedido.QUANTIDADE % itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			decimal value = itemPedido.QUANTIDADE / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			itemPedido.QUANTIDADE_UNIDADE_PEDIDA = value;
			itemPedido.QUANTIDADE_UNIDADE_VENDA = value;
			decimal? pRECO_UNITARIO = itemPedido.PRECO_UNITARIO;
			decimal value2 = 1;
			decimal? dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
			decimal? num = pRECO_UNITARIO * ((decimal?)value2 - dESCONTO_APLICADO) * (decimal?)itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			itemPedido.VALOR_UNITARIO_VENDA = num.ToDecimal();
			itemPedido.VALOR_UNITARIO_PEDIDA = num.ToDecimal();
		}
		else if (itemPedido.INDICE_RELACAO == "MENOR")
		{
			decimal value3 = itemPedido.QUANTIDADE * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			itemPedido.QUANTIDADE_UNIDADE_PEDIDA = value3;
			itemPedido.QUANTIDADE_UNIDADE_VENDA = value3;
			decimal? pRECO_UNITARIO2 = itemPedido.PRECO_UNITARIO;
			decimal value2 = 1;
			decimal? dESCONTO_APLICADO = itemPedido.DESCONTO_APLICADO;
			decimal? num2 = pRECO_UNITARIO2 * ((decimal?)value2 - dESCONTO_APLICADO) / (decimal?)itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			itemPedido.VALOR_UNITARIO_VENDA = num2.ToDecimal();
			itemPedido.VALOR_UNITARIO_PEDIDA = num2.ToDecimal();
		}
		if (itemPedido.QUANTIDADE <= 0m)
		{
			itemPedido.STATUS_ENTIDADE = StatusModelEnum.DELETADO;
		}
		else
		{
			itemPedido.ESTOQUE_INSUFICIENTE = false;
		}
	}

	public UnidadeVariavelVO ObterMaiorUnidadeVariavel(ItemPedidoMO item)
	{
		UnidadeProdutoDAL unidadeProdutoDAL = new UnidadeProdutoDAL();
		return unidadeProdutoDAL.ObterMaiorUnidadeVariavel(item);
	}

	public void CarregarMaiorUnidadeVariavelProdutoItensPedido(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PARAMETROS_TELA.VENDA.FATURA_NA_MAIOR_UNID_DE_VENDA_POSSIVEL || !ConfigERP.PAR_CFG.UNID_VDA_VAR || pedidoVenda.CLIENTE.NAO_FATURAR_MAIOR_UNIDADE.ToBool())
		{
			return;
		}
		List<ItemPedidoMO> iTENS = pedidoVenda.ITENS;
		foreach (ItemPedidoMO item in iTENS)
		{
			UnidadeVariavelVO unidadeVariavelVO = ObterMaiorUnidadeVariavel(item);
			if (unidadeVariavelVO != null)
			{
				item.UNIDADE_VENDA = unidadeVariavelVO.UNIDADE_VENDA;
				item.INDICE_RELACAO_VENDA = unidadeVariavelVO.INDICE_RELACAO;
				item.FATOR_ESTOQUE_VENDA = unidadeVariavelVO.FATOR_ESTOQUE.ToDecimal();
				item.QUANTIDADE_UNIDADE_VENDA = item.QUANTIDADE / item.FATOR_ESTOQUE_VENDA.ToDecimal();
				item.VALOR_UNITARIO_VENDA = item.PRECO_UNITARIO * (decimal?)item.FATOR_ESTOQUE_VENDA.ToDecimal();
			}
		}
	}

	public void ValidarUnidadeItensPedido(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			bool flag = iTEN.UNIDADE_VENDA == iTEN.UNIDADE_PEDIDA;
			bool flag2 = iTEN.FATOR_ESTOQUE_VENDA.ToDecimal() != iTEN.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			if (flag && flag2)
			{
				throw new MyException("Unidade de venda igual a pedida com fatores diferentes");
			}
			UnidadeProdutoMO unidadeProdutoMO = ObterPeloID(iTEN.CODIGO_PRODUTO, iTEN.UNIDADE_VENDA);
			if (!unidadeProdutoMO.ATIVO.ToBool())
			{
				throw new MyException("Unidade de venda invativa");
			}
			if (!unidadeProdutoMO.VENDA.ToBool())
			{
				throw new MyException("Unidade não é uma unidade de venda");
			}
		}
	}
}
