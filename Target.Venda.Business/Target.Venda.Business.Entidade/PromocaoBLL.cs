using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class PromocaoBLL : EntidadeBaseBLL<PromocaoMO>
{
	protected override EntidadeBaseDAL<PromocaoMO> GetInstanceDAL()
	{
		return new PromocaoDAL();
	}

	public decimal? ObterPrecoProdutoPelaPromocao(int codigoProduto, string codigoTabela, int seqPromocao, int? seqKit, Enum bonificado, int cdClien, int cdEmp)
	{
		return (BaseDAL as PromocaoDAL).ObterPrecoProdutoPelaPromocao(codigoProduto, codigoTabela, seqPromocao, seqKit, bonificado, cdClien, cdEmp);
	}

	public void TratarPrecoItemPedidoPeloCondicaoPagamento(ItemPedidoMO itemPedido, string codigoTabela, int seqPromocao, bool CLIENTE_PRECO_VENDA_4_DEC, int codigoCliente)
	{
		decimal? num = ObterPrecoProdutoPelaPromocao(itemPedido.CODIGO_PRODUTO, codigoTabela, seqPromocao, null, null, codigoCliente, itemPedido.CODIGO_EMPRESA);
		if (num.HasValue)
		{
			int decimals = ((ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC && (!ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && CLIENTE_PRECO_VENDA_4_DEC))) ? ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_QTDE : 2);
			decimal d = ((decimal?)Math.Round(num.ToDecimal(), decimals, MidpointRounding.AwayFromZero) * itemPedido.FATOR_PRECO).ToDecimal();
			itemPedido.PRECO_NOTA_FISCAL = Math.Round(d, 4, MidpointRounding.AwayFromZero);
		}
		else
		{
			MyException ex = new MyException($"O produto: {itemPedido.CODIGO_PRODUTO}, não está associado à condição de pagamento {seqPromocao}. Faça esta associação ou desassocie e associe novamente caso já exista a associação.");
			ex.ThrowException();
		}
	}

	public PromocaoMO ObterCondicaoPagamentoParaPedidoVenda(int? seqPromocao)
	{
		if (seqPromocao > 0)
		{
			PromocaoMO exampleInstance = new PromocaoMO
			{
				SEQ_PROMOCAO = seqPromocao.Value
			};
			PromocaoMO promocaoMO = ObterUnicoPeloExemplo(exampleInstance, "PROMOCAO_EMPRESA");
			KitPromocaoPagamentoMO exampleInstance2 = new KitPromocaoPagamentoMO
			{
				SEQ_PROMOCAO = seqPromocao.Value
			};
			KitPromocaoPagamentoBLL kitPromocaoPagamentoBLL = new KitPromocaoPagamentoBLL();
			promocaoMO.KIT_PROMOCAO_PAGAMENTO = new List<KitPromocaoPagamentoMO>();
			promocaoMO.KIT_PROMOCAO_PAGAMENTO = kitPromocaoPagamentoBLL.ObterPeloExemplo(exampleInstance2);
			PromocaoParcelasMO exampleInstance3 = new PromocaoParcelasMO
			{
				SEQ_PROMOCAO = seqPromocao.Value
			};
			PromocaoParcelasBLL promocaoParcelasBLL = new PromocaoParcelasBLL();
			promocaoMO.PARCELAS = new List<PromocaoParcelasMO>();
			promocaoMO.PARCELAS = promocaoParcelasBLL.ObterPeloExemplo(exampleInstance3);
			FormaPagamentoPromocaoMO exampleInstance4 = new FormaPagamentoPromocaoMO
			{
				SEQ_PROMOCAO = seqPromocao.Value
			};
			FormaPagamentoPromocaoBLL formaPagamentoPromocaoBLL = new FormaPagamentoPromocaoBLL();
			promocaoMO.FORMAS_PAGAMENTO = new List<FormaPagamentoPromocaoMO>();
			promocaoMO.FORMAS_PAGAMENTO = formaPagamentoPromocaoBLL.ObterPeloExemplo(exampleInstance4);
			return promocaoMO;
		}
		return null;
	}

	public bool PedidoAtingiuValorMinimo(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.TIPO_PEDIDO.IGNORAR_VALIDACAO_VALOR_MIN_PEDIDO)
		{
			return false;
		}
		VersaoERPVO versaoERPVO = new VersaoERPVO();
		versaoERPVO = VersaoDAL.VERSAO_ERP_ATUAL;
		if (versaoERPVO.MAJOR > 11 || versaoERPVO.MINOR > 2 || versaoERPVO.BUILD > 24 || (versaoERPVO.BUILD >= 24 && versaoERPVO.REVISION >= 1))
		{
			if (!ConfigERP.PAR_CFG.CANCPEDVLMINORIGPED)
			{
				return false;
			}
			if (!(BaseDAL as PromocaoDAL).CancelaPedidoVlMinPorOrigemPed(pedidoVenda.CODIGO_EMPRESA, pedidoVenda.ORIGEM_PEDIDO).ToBool())
			{
				return false;
			}
		}
		else if (!ConfigERP.PARAMETROS_TELA.VENDA.CANC_PEDIDO_VALOR_MENOR_QUE_O_MINIMO_DA_COND_PGTO)
		{
			return false;
		}
		PromocaoMO promocaoMO = ObterPeloID(pedidoVenda.SEQ_PROMOCAO);
		decimal vALOR_MINIMO_PEDIDO_VENDA = promocaoMO.VALOR_MINIMO_PEDIDO_VENDA;
		decimal? vALOR_TOTAL = pedidoVenda.VALOR_TOTAL;
		if ((vALOR_MINIMO_PEDIDO_VENDA > vALOR_TOTAL.GetValueOrDefault()) & vALOR_TOTAL.HasValue)
		{
			return true;
		}
		return false;
	}

	public void ValidarCondicaoPagamentoPedidoEletronico(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		MyException ex = new MyException();
		if (!pEDIDO_ELETRONICO.SEQ_PROMOCAO.HasValue || pEDIDO_ELETRONICO.SEQ_PROMOCAO.Value == 0 || pedidoVenda.PROMOCAO == null)
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Condição de Pagamento");
		}
		if (pedidoVenda.PROMOCAO != null)
		{
			if (!pedidoVenda.PROMOCAO.ATIVO.ToBool())
			{
				ex.AddErro("A condição de pagamento {0} não está ativa", pedidoVenda.PROMOCAO.DESCRICAO);
			}
			if (pedidoVenda.PROMOCAO.PROMOCAO_EMPRESA != null)
			{
				PromocaoEmpresaMO promocaoEmpresaMO = pedidoVenda.PROMOCAO.PROMOCAO_EMPRESA.Find((PromocaoEmpresaMO x) => x.CODIGO_EMPRESA == pedidoVenda.CODIGO_EMPRESA);
				if (!promocaoEmpresaMO.UTILIZA.ToBool())
				{
					ex.AddErro("A condição de pagamento {0} não está marcada para utilização na empresa do Pedido.", pedidoVenda.PROMOCAO.DESCRICAO);
				}
			}
		}
		if (!ex.ContemErro)
		{
			List<ProdutoNaoAssoiadoCondicaoPagamentoVO> list = (BaseDAL as PromocaoDAL).ObterItensPedidoNaoAssociadosCondicaoPagamento(pEDIDO_ELETRONICO);
			if (list.Count > 0)
			{
				StringBuilder sbMsg = new StringBuilder();
				sbMsg.AppendFormat("O pedido eletronico numero {0} da empresa {1} ", pEDIDO_ELETRONICO.NUMERO_PEDIDO_ELETRONICO, pEDIDO_ELETRONICO.CODIGO_EMPRESA_ELETRONICO);
				sbMsg.AppendFormat("não pode ser liberado pois os seguintes produtos não estão associados à condição de pagamento {0}:", list.First().DESCRICAO_PROMOCAO);
				list.ForEach(delegate(ProdutoNaoAssoiadoCondicaoPagamentoVO i)
				{
					string value = $"{i.CODIGO_PRODUTO} - {i.DESCRICAO_PRODUTO}";
					sbMsg.AppendLine(value);
				});
				sbMsg.AppendLine("Para a liberação, faça a associação dos produtos à condição de pagamento do pedido.");
				ex.AddErro(sbMsg.ToString());
			}
		}
		ex.ThrowException();
	}

	public decimal ObterCoeficienteParcela(int seqPromocao)
	{
		return (BaseDAL as PromocaoDAL).ObterCoeficienteParcela(seqPromocao);
	}
}
