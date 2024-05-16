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
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Business.Entidade;

public class ItemPedidoLocalBLL : EntidadeBaseBLL<ItemPedidoLocalMO>
{
	protected override EntidadeBaseDAL<ItemPedidoLocalMO> GetInstanceDAL()
	{
		return new ItemPedidoLocalDAL();
	}

	public TipoPedidoLocalMO GerarItensLocais(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			iTEN.ITENS_LOCAIS = new List<ItemPedidoLocalMO>();
		}
		TipoPedidoLocalBLL tipoPedidoLocalBLL = new TipoPedidoLocalBLL();
		TipoPedidoLocalMO tipoPedidoLocalMO = new TipoPedidoLocalMO();
		tipoPedidoLocalMO.CODIGO_EMPRESA = LoginERP.EMPRESA_LOGADA.CODIGO_EMPRESA;
		tipoPedidoLocalMO.TIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO.CODIGO_TIPO_PEDIDO;
		TipoPedidoLocalMO LocalMesmaEmpresa = tipoPedidoLocalBLL.ObterUnicoPeloExemplo(tipoPedidoLocalMO);
		foreach (ItemPedidoMO iTEN2 in pedidoVenda.ITENS)
		{
			if (pedidoVenda.TIPO_PEDIDO.OUTROS_LOCAIS_ESTOQUE)
			{
				List<ItemPedidoLocalMO> collection = GerarItemLocalOutrosLocais(iTEN2, pedidoVenda, LocalMesmaEmpresa);
				iTEN2.ITENS_LOCAIS.AddRange(collection);
			}
			else
			{
				ItemPedidoLocalMO item = GerarItemLocalMesmaEmpresa(iTEN2, pedidoVenda, LocalMesmaEmpresa);
				iTEN2.ITENS_LOCAIS.Add(item);
			}
		}
		RemoverItensLocaisInvalidos(pedidoVenda);
		TratarTransferenciaEfetiva(pedidoVenda);
		pedidoVenda.ITENS.ForEach(delegate(ItemPedidoMO x)
		{
			x.ITENS_LOCAIS.ForEach(delegate(ItemPedidoLocalMO y)
			{
				LocalMesmaEmpresa.CODIGO_EMPRESA = y.CODIGO_EMPRESA_LOCAL_ESTOQUE;
				LocalMesmaEmpresa.CODIGO_LOCAL = y.CODIGO_LOCAL;
			});
		});
		return LocalMesmaEmpresa;
	}

	private static void TratarTransferenciaEfetiva(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			foreach (ItemPedidoLocalMO iTENS_LOCAI in iTEN.ITENS_LOCAIS)
			{
				if (iTEN.SITUACAO == "FE")
				{
					iTEN.TRANSFERENCIA_EFETIVA = BoolEnum.True;
				}
				else if (iTEN.SITUACAO == "AB" || iTEN.SITUACAO == "PE")
				{
					iTEN.TRANSFERENCIA_EFETIVA = null;
				}
			}
		}
	}

	private void RemoverItensLocaisInvalidos(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			List<ItemPedidoLocalMO> iTENS_LOCAIS = iTEN.ITENS_LOCAIS.FindAll(delegate(ItemPedidoLocalMO x)
			{
				bool flag = x.CODIGO_EMPRESA_LOCAL_ESTOQUE > 0;
				bool flag2 = !string.IsNullOrEmpty(x.CODIGO_LOCAL);
				bool flag3 = x.QUANTIDADE > 0m;
				return flag && flag2 && flag3;
			});
			iTEN.ITENS_LOCAIS = iTENS_LOCAIS;
		}
	}

	private List<ItemPedidoLocalMO> GerarItemLocalOutrosLocais(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda, TipoPedidoLocalMO LocalMesmaEmpresa)
	{
		List<ItemPedidoLocalMO> list = new List<ItemPedidoLocalMO>();
		TipoPedidoOutrosLocaisBLL tipoPedidoOutrosLocaisBLL = new TipoPedidoOutrosLocaisBLL();
		TipoPedidoOutrosLocaisMO tipoPedidoOutrosLocaisMO = new TipoPedidoOutrosLocaisMO();
		tipoPedidoOutrosLocaisMO.CODIGO_TIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO.CODIGO_TIPO_PEDIDO;
		List<TipoPedidoOutrosLocaisMO> source = tipoPedidoOutrosLocaisBLL.ObterPeloExemplo(tipoPedidoOutrosLocaisMO);
		source = source.OrderBy((TipoPedidoOutrosLocaisMO x) => x.ORDEM).ToList();
		decimal num = itemPedido.QUANTIDADE;
		bool mANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA = ConfigERP.PARAMETROS_TELA.TRANSFERENCIA_ESTOQUE.MANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA;
		foreach (TipoPedidoOutrosLocaisMO item2 in source)
		{
			decimal num2 = ObterQuantidadeEstoque(itemPedido, item2);
			decimal num3 = QuantidadeUtilizadaOutroItem(itemPedido, item2, pedidoVenda);
			decimal num4 = num2 - num3;
			if (!(num4 == 0m))
			{
				if (num4 >= num)
				{
					ItemPedidoLocalMO item = GerarItemPedidoLocal(itemPedido, LocalMesmaEmpresa, item2, num);
					list.Add(item);
					num = default(decimal);
					break;
				}
				if (mANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA && itemPedido.INDICE_RELACAO == "MAIOR" && num4 > itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal())
				{
					decimal quantidade = Math.Truncate(num4 / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal()) * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
					ItemPedidoLocalMO itemPedidoLocalMO = GerarItemPedidoLocal(itemPedido, LocalMesmaEmpresa, item2, quantidade);
					list.Add(itemPedidoLocalMO);
					num -= itemPedidoLocalMO.QUANTIDADE;
				}
				else if (num4 > 0m)
				{
					ItemPedidoLocalMO itemPedidoLocalMO2 = GerarItemPedidoLocal(itemPedido, LocalMesmaEmpresa, item2, num4);
					list.Add(itemPedidoLocalMO2);
					num -= itemPedidoLocalMO2.QUANTIDADE;
				}
			}
		}
		if (num > 0m)
		{
			TratarQuantidadeRestante(itemPedido, LocalMesmaEmpresa, list, source, num, pedidoVenda.TIPO_PEDIDO.OUTROS_LOCAIS_ESTOQUE_FALTA_CD_EMP.Value, pedidoVenda.TIPO_PEDIDO.OUTROS_LOCAIS_ESTOQUE_FALTA_CD_LOCAL);
		}
		return list;
	}

	private decimal ObterQuantidadeEstoque(ItemPedidoMO itemPedido, TipoPedidoOutrosLocaisMO ItemLocal)
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		EstoqueMO estoqueMO = new EstoqueMO();
		estoqueMO.CODIGO_LOCAL = ItemLocal.CODIGO_LOCAL;
		estoqueMO.CODIGO_EMPRESA = ItemLocal.CODIGO_EMPRESA;
		estoqueMO.CODIGO_PRODUTO = itemPedido.CODIGO_PRODUTO;
		if (ConfigHelper.getBoolAppConfig("ReservarEstoqueComCorte"))
		{
			return estoqueBLL.ObterQuantidadeDisponivelReservada(estoqueMO, SessaoErpManager.CURRENT.SESSAO_DB_TEMP.NOME_TABELA_TEMPORARIA);
		}
		return estoqueBLL.ObterQuantidadeDisponivel(estoqueMO);
	}

	private void TratarQuantidadeRestante(ItemPedidoMO itemPedido, TipoPedidoLocalMO LocalMesmaEmpresa, List<ItemPedidoLocalMO> Locais, List<TipoPedidoOutrosLocaisMO> OutrosLocais, decimal quantidade, int? cdEmpFaltaEstOutrosLocais = null, string cdLocalFaltaEstOutrosLocais = null)
	{
		if (Locais.Count > 0 && Locais.FirstOrDefault((ItemPedidoLocalMO x) => x.CODIGO_LOCAL == cdLocalFaltaEstOutrosLocais && x.CODIGO_EMPRESA_LOCAL_ESTOQUE == cdEmpFaltaEstOutrosLocais) != null)
		{
			ItemPedidoLocalMO itemPedidoLocalMO = Locais.First();
			if (cdLocalFaltaEstOutrosLocais != null && cdEmpFaltaEstOutrosLocais.HasValue)
			{
				itemPedidoLocalMO = Locais.FirstOrDefault((ItemPedidoLocalMO x) => x.CODIGO_EMPRESA_LOCAL_ESTOQUE == cdEmpFaltaEstOutrosLocais && x.CODIGO_LOCAL == cdLocalFaltaEstOutrosLocais);
			}
			itemPedidoLocalMO.QUANTIDADE += quantidade;
			itemPedidoLocalMO.QUATIDADE_UNIDADE_PEDIDA = itemPedidoLocalMO.QUANTIDADE / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			if (itemPedido.INDICE_RELACAO.ToUpper() == "MENOR")
			{
				itemPedidoLocalMO.QUATIDADE_UNIDADE_PEDIDA = itemPedidoLocalMO.QUANTIDADE * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
			}
			return;
		}
		TipoPedidoOutrosLocaisMO tipoPedidoOutrosLocaisMO = new TipoPedidoOutrosLocaisMO();
		ProdutoDAL produtoDAL = new ProdutoDAL();
		int empresaVende = produtoDAL.VerificaVendaProduto(itemPedido, LocalMesmaEmpresa, ConfigERP.PAR_CFG.UTILIZA_WMS);
		tipoPedidoOutrosLocaisMO = ((empresaVende == 0) ? OutrosLocais.FirstOrDefault((TipoPedidoOutrosLocaisMO x) => x.CODIGO_EMPRESA == cdEmpFaltaEstOutrosLocais && x.CODIGO_LOCAL == cdLocalFaltaEstOutrosLocais) : OutrosLocais.FirstOrDefault((TipoPedidoOutrosLocaisMO x) => x.CODIGO_EMPRESA == empresaVende));
		if (tipoPedidoOutrosLocaisMO == null)
		{
			tipoPedidoOutrosLocaisMO = OutrosLocais.First();
		}
		ItemPedidoLocalMO item = GerarItemPedidoLocal(itemPedido, LocalMesmaEmpresa, tipoPedidoOutrosLocaisMO, quantidade);
		Locais.Add(item);
	}

	private ItemPedidoLocalMO GerarItemPedidoLocal(ItemPedidoMO itemPedido, TipoPedidoLocalMO LocalMesmaEmpresa, TipoPedidoOutrosLocaisMO ItemLocal, decimal quantidade)
	{
		ItemPedidoLocalMO itemPedidoLocalMO = new ItemPedidoLocalMO();
		itemPedidoLocalMO.SEQ = itemPedido.SEQ.ToShort();
		itemPedidoLocalMO.CODIGO_EMPRESA_LOCAL_ESTOQUE = ItemLocal.CODIGO_EMPRESA;
		itemPedidoLocalMO.CODIGO_LOCAL = ItemLocal.CODIGO_LOCAL;
		itemPedidoLocalMO.CODIGO_PRODUTO = itemPedido.CODIGO_PRODUTO;
		itemPedidoLocalMO.UNIDADE_ESTOQUE = itemPedido.UNIDADE;
		itemPedidoLocalMO.QUANTIDADE = quantidade;
		decimal qUATIDADE_UNIDADE_PEDIDA = quantidade / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
		if (itemPedido.INDICE_RELACAO.ToUpper() == "MENOR")
		{
			qUATIDADE_UNIDADE_PEDIDA = quantidade * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
		}
		bool mANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA = ConfigERP.PARAMETROS_TELA.TRANSFERENCIA_ESTOQUE.MANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA;
		if (itemPedido.INDICE_RELACAO.ToUpper() == "MAIOR" && mANTEM_PRODUTOS_COM_A_UNIDADE_DIGITADA_NO_PEDIDO_DE_VENDA && quantidade > itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal())
		{
			qUATIDADE_UNIDADE_PEDIDA = Math.Truncate(quantidade / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal());
		}
		itemPedidoLocalMO.UNIDADE_PEDIDA = itemPedido.UNIDADE_PEDIDA;
		itemPedidoLocalMO.QUATIDADE_UNIDADE_PEDIDA = qUATIDADE_UNIDADE_PEDIDA;
		if (ItemLocal.CODIGO_EMPRESA == LocalMesmaEmpresa.CODIGO_EMPRESA && ItemLocal.CODIGO_LOCAL == LocalMesmaEmpresa.CODIGO_LOCAL)
		{
			itemPedidoLocalMO.SITUACAO = "FE";
			itemPedidoLocalMO.TRANSFERENCIA_EFETIVA = BoolEnum.True;
		}
		else
		{
			itemPedidoLocalMO.SITUACAO = "AB";
			itemPedidoLocalMO.TRANSFERENCIA_EFETIVA = BoolEnum.False;
		}
		return itemPedidoLocalMO;
	}

	private decimal QuantidadeUtilizadaOutroItem(ItemPedidoMO itemPedido, TipoPedidoOutrosLocaisMO Local, PedidoVendaMO pedidoVenda)
	{
		decimal result = default(decimal);
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => x.CODIGO_PRODUTO == itemPedido.CODIGO_PRODUTO && x.SEQ != itemPedido.SEQ);
		foreach (ItemPedidoMO item in list)
		{
			result += item.ITENS_LOCAIS.Where((ItemPedidoLocalMO x) => x.CODIGO_LOCAL == Local.CODIGO_LOCAL && x.CODIGO_EMPRESA_LOCAL_ESTOQUE == Local.CODIGO_EMPRESA && x.CODIGO_PRODUTO == item.CODIGO_PRODUTO).Sum((ItemPedidoLocalMO s) => s.QUANTIDADE);
		}
		return result;
	}

	private ItemPedidoLocalMO GerarItemLocalMesmaEmpresa(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda, TipoPedidoLocalMO LocalMesmaEmpresa)
	{
		ItemPedidoLocalMO itemPedidoLocalMO = new ItemPedidoLocalMO();
		itemPedidoLocalMO.SEQ = itemPedido.SEQ.ToShort();
		itemPedidoLocalMO.CODIGO_EMPRESA_LOCAL_ESTOQUE = LocalMesmaEmpresa.CODIGO_EMPRESA;
		itemPedidoLocalMO.CODIGO_EMPRESA = LocalMesmaEmpresa.CODIGO_EMPRESA;
		itemPedidoLocalMO.CODIGO_LOCAL = LocalMesmaEmpresa.CODIGO_LOCAL;
		itemPedidoLocalMO.CODIGO_PRODUTO = itemPedido.CODIGO_PRODUTO;
		itemPedidoLocalMO.QUANTIDADE = itemPedido.QUANTIDADE;
		itemPedidoLocalMO.UNIDADE_ESTOQUE = itemPedido.UNIDADE;
		if (itemPedido.INDICE_RELACAO.ToUpper() == "MAIOR")
		{
			itemPedidoLocalMO.QUATIDADE_UNIDADE_PEDIDA = itemPedidoLocalMO.QUANTIDADE / itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
		}
		else
		{
			itemPedidoLocalMO.QUATIDADE_UNIDADE_PEDIDA = itemPedidoLocalMO.QUANTIDADE * itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal();
		}
		itemPedidoLocalMO.UNIDADE_PEDIDA = itemPedido.UNIDADE_PEDIDA;
		itemPedidoLocalMO.SITUACAO = "FE";
		itemPedidoLocalMO.TRANSFERENCIA_EFETIVA = BoolEnum.True;
		return itemPedidoLocalMO;
	}
}
