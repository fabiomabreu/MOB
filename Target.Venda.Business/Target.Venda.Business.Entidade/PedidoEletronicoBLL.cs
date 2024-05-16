using System;
using System.Collections.Generic;
using System.Text;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.Business.Texto;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class PedidoEletronicoBLL : EntidadeBaseBLL<PedidoEletronicoMO>
{
	protected override EntidadeBaseDAL<PedidoEletronicoMO> GetInstanceDAL()
	{
		return new PedidoEletronicoDAL();
	}

	public List<ObservacaoPedidoMO> ObterMensagensExpedicao(PedidoEletronicoMO pedidoEletronico)
	{
		if (pedidoEletronico == null && pedidoEletronico.OBSERVACOES == null && pedidoEletronico.OBSERVACOES.Count <= 0)
		{
			return null;
		}
		List<ObservacaoPedidoEletronicoMO> list = pedidoEletronico.OBSERVACOES.FindAll((ObservacaoPedidoEletronicoMO x) => x.SETOR == "EXPEDICAO");
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		List<ObservacaoPedidoMO> listaObservaoPedido = new List<ObservacaoPedidoMO>();
		list.ForEach(delegate(ObservacaoPedidoEletronicoMO x)
		{
			ObservacaoPedidoMO item = ConvertHelper.ToObject<ObservacaoPedidoMO>(x, Array.Empty<string>());
			listaObservaoPedido.Add(item);
		});
		return listaObservaoPedido;
	}

	public void CancelarPedidoEletronico(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		if (pedidoVenda.NUMERO_PEDIDO > 0)
		{
			pEDIDO_ELETRONICO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
			pEDIDO_ELETRONICO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		}
		EventoPedidoEletronicoAbertoBLL eventoPedidoEletronicoAbertoBLL = new EventoPedidoEletronicoAbertoBLL();
		foreach (EventoPedidoEletronicoMO item in pEDIDO_ELETRONICO.EVENTOS_PEDIDO_ELETRONICO)
		{
			EventoPedidoEletronicoAbertoMO eVENTO_PEDIDO_ELETRONICO_AB = item.EVENTO_PEDIDO_ELETRONICO_AB;
			if (eVENTO_PEDIDO_ELETRONICO_AB != null)
			{
				eVENTO_PEDIDO_ELETRONICO_AB.STATUS_ENTIDADE = StatusModelEnum.DELETADO;
				eVENTO_PEDIDO_ELETRONICO_AB.EVENTO_PEDIDO_ELETRONICO = null;
				eventoPedidoEletronicoAbertoBLL.Salvar(item.EVENTO_PEDIDO_ELETRONICO_AB);
			}
		}
		EventoPedidoEletronicoBLL eventoPedidoEletronicoBLL = new EventoPedidoEletronicoBLL();
		EventoPedidoEletronicoMO exampleInstance = new EventoPedidoEletronicoMO
		{
			NUMERO_PEDIDO_ELETRONICO = pEDIDO_ELETRONICO.NUMERO_PEDIDO_ELETRONICO,
			CODIGO_EMPRESA_ELETRONICO = pEDIDO_ELETRONICO.CODIGO_EMPRESA_ELETRONICO
		};
		pEDIDO_ELETRONICO.EVENTOS_PEDIDO_ELETRONICO = eventoPedidoEletronicoBLL.ObterPeloExemplo(exampleInstance);
		foreach (EventoPedidoEletronicoMO item2 in pEDIDO_ELETRONICO.EVENTOS_PEDIDO_ELETRONICO)
		{
			item2.CODIGO_USUARIO_ENCERRAMENTO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
			item2.DATA_ENCERRAMENTO = pedidoVenda.DATA_ABERTURA_PEDIDO;
			item2.STATUS_ENTIDADE = StatusModelEnum.EDITADO;
			item2.EVENTO_PEDIDO_ELETRONICO_AB = null;
			item2.PEDVDAELETO = null;
			eventoPedidoEletronicoBLL.Salvar(item2);
		}
		if (pedidoVenda.ITENS == null || pedidoVenda.ITENS.Count == 0)
		{
			pEDIDO_ELETRONICO.SEM_ESTOQUE = BoolEnum.True;
			pEDIDO_ELETRONICO.SITUACAO = "CA";
			ItemPedidoEletronicoBLL itemPedidoEletronicoBLL = new ItemPedidoEletronicoBLL();
			itemPedidoEletronicoBLL.CancelarItensPedidoEletronicoSemEstoque(pEDIDO_ELETRONICO);
		}
		pEDIDO_ELETRONICO.SITUACAO = "CA";
		pEDIDO_ELETRONICO.CANCELAMENTO_MANUAL = false;
		pEDIDO_ELETRONICO.STATUS_ENTIDADE = StatusModelEnum.EDITADO;
		pEDIDO_ELETRONICO.EVENTOS_PEDIDO_ELETRONICO = null;
		Salvar(pEDIDO_ELETRONICO);
		(BaseDAL as PedidoEletronicoDAL).CancelaPedVdaEle(pEDIDO_ELETRONICO);
	}

	public void RealizarCorteItensPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO)
	{
		int? num = (BaseDAL as PedidoEletronicoDAL).RealizarCorteItensPedidoEletronico(pedidoEletronicoMO);
		if (num.HasValue && num == -100)
		{
			MyException ex = new MyException("O processo de Corte de Itens do Pedido Eletrônico não foi executado com sucesso.");
			ex.ThrowException();
		}
	}

	public void RealizarReservaCorteItensPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO, string nomeTabelaTemporaria)
	{
		int? num = (BaseDAL as PedidoEletronicoDAL).RealizarReservaCorteItensPedidoEletronico(pedidoEletronicoMO, nomeTabelaTemporaria);
		if (num.HasValue && num == -100)
		{
			MyException ex = new MyException("O processo de Corte de Itens do Pedido Eletrônico não foi executado com sucesso.");
			ex.ThrowException();
		}
	}

	public bool ValidarNumeroPedidoEletronico(int codigoEmpresa, int numeroPedido, int seq)
	{
		return (BaseDAL as PedidoEletronicoDAL).ValidarNumeroPedidoEletronico(codigoEmpresa, numeroPedido, seq);
	}

	public void AtualizarNumeroPedidoERP(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		pedidoEletronico.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		pedidoEletronico.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		(BaseDAL as PedidoEletronicoDAL).AtualizarNumeroPedidoERP(pedidoEletronico);
	}

	public void AtualizaVersaoLiberacaoTargetVendasPedVdaEle(PedidoEletronicoMO pedidoEletronico)
	{
		(BaseDAL as PedidoEletronicoDAL).AtualizaVersaoLiberacaoTargetVendasPedVdaEle(pedidoEletronico);
	}

	public List<PedidoEletronicoVO> ObterPedidosParaLiberar(PedidoEletronicoMO pedidoEletronicoMO)
	{
		return (BaseDAL as PedidoEletronicoDAL).ObterPedidosParaLiberar(pedidoEletronicoMO);
	}

	public string ValidarCadastrosItensPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO)
	{
		List<ProdutoNaoConfigVendaVO> list = (BaseDAL as PedidoEletronicoDAL).ObterItensPedidoEletronicoComProblemasCadastro(pedidoEletronicoMO);
		if (list == null || list.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Existem produtos não configurados para venda no pedido Eletronico: {0}", pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO);
		stringBuilder.AppendLine();
		foreach (ProdutoNaoConfigVendaVO item in list)
		{
			stringBuilder.AppendFormat("Produto: {0} - {1}", item.CODIGO_PRODUTO, item.DESCRICAO_PRODUTO);
			if (string.IsNullOrEmpty(item.DESCRICAO_GRUPO_COMISSAO))
			{
				stringBuilder.AppendLine($"Produto está sem grupo de comissão cadastrado");
			}
			if (string.IsNullOrEmpty(item.DESCRICAO_LOCAL_ESTOQUE))
			{
				stringBuilder.AppendLine($"Tipo de pedido está sem local de estoque definido");
			}
			decimal? vALOR_PRECO = item.VALOR_PRECO;
			if (!((vALOR_PRECO.GetValueOrDefault() > default(decimal)) & vALOR_PRECO.HasValue))
			{
				stringBuilder.AppendLine($"Produto está sem preço definido na tabela de preços {item.DESCRICAO_TABELA_PRECO}");
			}
			vALOR_PRECO = item.VALOR_PARCELA;
			if (!((vALOR_PRECO.GetValueOrDefault() > default(decimal)) & vALOR_PRECO.HasValue))
			{
				stringBuilder.AppendLine("Produto está sem valor de parcelas definido. Sugestão: reassociar os produtos a todas as condições de pagamento");
			}
			if (item.EXISTE_ICM_PROD.ToInt() <= 0)
			{
				stringBuilder.AppendLine(" Não está cadastrado o ICMS do produto para o estado do cliente");
			}
			if (string.IsNullOrEmpty(item.CODIGO_SITUACAO_TRIB))
			{
				stringBuilder.AppendLine($"Não está cadastrada a situação tributária ( {item.TIPO_SITUACAO_TRIB} ) para o estado do cliente");
			}
			if (item.EXISTE_TABELA_PRECO_EMPRESA.ToInt() <= 0)
			{
				stringBuilder.AppendLine("Tabela de preços não associada com a empresa do pedido");
			}
			if (item.EXISTE_PROMOCAO_EMPRESA.ToInt() <= 0)
			{
				stringBuilder.AppendLine(MensagemString.CONDICAO_PAGAMENTO_NAO_ASSOCIADA_EMPRESA);
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public PedidoVendaMO MontarPedidoVendaPeloPedidoEletronico(PedidoEletronicoMO pedidoEletronico)
	{
		PedidoVendaMO pedidoVendaMO = ConvertHelper.ToObject<PedidoVendaMO>(pedidoEletronico, new string[1] { "ITENS" });
		pedidoVendaMO.PEDIDO_ELETRONICO = pedidoEletronico;
		return pedidoVendaMO;
	}

	public List<ItemPedidoEletronicoMO> ObterItensPedidoEletronico(PedidoEletronicoMO pedidoEletronico)
	{
		ItemPedidoEletronicoBLL itemPedidoEletronicoBLL = new ItemPedidoEletronicoBLL();
		ItemPedidoEletronicoMO exampleInstance = new ItemPedidoEletronicoMO
		{
			CODIGO_EMPRESA_ELETRONICO = pedidoEletronico.CODIGO_EMPRESA_ELETRONICO,
			NUMERO_PEDIDO_ELETRONICO = pedidoEletronico.NUMERO_PEDIDO_ELETRONICO,
			SEQ_PEDIDO = pedidoEletronico.SEQ_PEDIDO_ELETRONICO
		};
		return itemPedidoEletronicoBLL.ObterPeloExemplo(exampleInstance);
	}

	public PedidoEletronicoMO ObterPedidoEletronicoParaPedidoVenda(int codigoEmpresa, int numeroPedido, int seqPedido)
	{
		PedidoEletronicoMO pedidoEletronicoMO = new PedidoEletronicoMO();
		pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO = numeroPedido;
		pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO = codigoEmpresa;
		pedidoEletronicoMO.SEQ_PEDIDO_ELETRONICO = seqPedido;
		PedidoEletronicoMO pedidoEletronicoMO2 = ObterUnicoPeloExemplo(pedidoEletronicoMO, "EVENTOS_PEDIDO_ELETRONICO.EVENTO_PEDIDO_ELETRONICO_AB", "OBSERVACOES", "ENDERECOS", "ITENS");
		TratarObservacoesPedidoEletronico(pedidoEletronicoMO2);
		return pedidoEletronicoMO2;
	}

	public void TratarObservacoesPedidoEletronico(PedidoEletronicoMO pedidoEletronico)
	{
		if (pedidoEletronico.OBSERVACOES.Count == 0)
		{
			return;
		}
		List<decimal> observacoesLinhas = (BaseDAL as PedidoEletronicoDAL).ObterObservacoesPossuemLinhas(pedidoEletronico);
		pedidoEletronico.OBSERVACOES.RemoveAll((ObservacaoPedidoEletronicoMO x) => !observacoesLinhas.Exists((decimal y) => y == x.SEQ));
	}

	public void ValidarParametroLiberacao(ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle)
	{
		MyException ex = new MyException();
		ex.VerificarObjetoNull(parametroLiberarPedidoEle, "O parametros necessarios para a liberaração do pedido eletronico não foram informados");
		if (parametroLiberarPedidoEle.CODIGO_EMPRESA_ELETRONICO == 0)
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Código Empresa");
		}
		if (string.IsNullOrEmpty(parametroLiberarPedidoEle.CODIGO_USUARIO))
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Código Usuário");
		}
		if (parametroLiberarPedidoEle.NUMERO_PEDIDO_ELETRONICO == 0)
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Numero");
		}
		if (parametroLiberarPedidoEle.NUMERO_SEQ_PEDIDO == 0)
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Seq");
		}
		if (string.IsNullOrEmpty(parametroLiberarPedidoEle.NOME_PROGRAMA))
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Nome Programa");
		}
		if (!ex.ContemErro)
		{
			ValidarParametrosValoresInvalidados(parametroLiberarPedidoEle, ex);
		}
		ex.ThrowException();
	}

	private void ValidarParametrosValoresInvalidados(ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle, MyException myException)
	{
		UsuarioBLL usuarioBLL = new UsuarioBLL();
		if (!usuarioBLL.ValidarCodigoUsuario(parametroLiberarPedidoEle.CODIGO_USUARIO))
		{
			myException.AddErro("{0} Inválido", "Código Usuário");
		}
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		if (!pedidoEletronicoBLL.ValidarNumeroPedidoEletronico(parametroLiberarPedidoEle.CODIGO_EMPRESA_ELETRONICO, parametroLiberarPedidoEle.NUMERO_PEDIDO_ELETRONICO, parametroLiberarPedidoEle.NUMERO_SEQ_PEDIDO))
		{
			string text = $"Empresa: {parametroLiberarPedidoEle.CODIGO_EMPRESA_ELETRONICO}, Numero: {parametroLiberarPedidoEle.NUMERO_PEDIDO_ELETRONICO}, Seq: {parametroLiberarPedidoEle.NUMERO_SEQ_PEDIDO}";
			myException.AddErro("Não foi possivel encontrar pedido eletronico pelos filtros. {0}", text);
		}
	}
}
