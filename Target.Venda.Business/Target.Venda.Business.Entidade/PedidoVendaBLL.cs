using System;
using System.Collections.Generic;
using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.Business.Texto;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Parametro;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class PedidoVendaBLL : EntidadeBaseBLL<PedidoVendaMO>
{
	protected override EntidadeBaseDAL<PedidoVendaMO> GetInstanceDAL()
	{
		return new PedidoVendaDAL();
	}

	public override void Salvar(PedidoVendaMO pedidoVenda)
	{
		try
		{
			base.Salvar(pedidoVenda);
			PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
			PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
			pedidoEletronicoBLL.AtualizarNumeroPedidoERP(pedidoVenda, pEDIDO_ELETRONICO);
			if (VersaoDAL.VERSAO_ERP_ATUAL.MAJOR > 11 || VersaoDAL.VERSAO_ERP_ATUAL.MINOR > 2 || VersaoDAL.VERSAO_ERP_ATUAL.BUILD > 25 || (VersaoDAL.VERSAO_ERP_ATUAL.BUILD >= 25 && VersaoDAL.VERSAO_ERP_ATUAL.REVISION >= 8))
			{
				pedidoEletronicoBLL.AtualizaVersaoLiberacaoTargetVendasPedVdaEle(pEDIDO_ELETRONICO);
			}
			CampanhaBLL campanhaBLL = new CampanhaBLL();
			campanhaBLL.CampanhaItPedvDescontosGera(pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	protected override void Inserir(PedidoVendaMO objeto)
	{
		PreInsert(objeto);
		base.Inserir(objeto);
	}

	private void PreInsert(PedidoVendaMO objeto)
	{
		GerarSeqObservacoes(objeto);
		TratarInsertNulos(objeto);
	}

	private void TratarInsertNulos(PedidoVendaMO pedidoVenda)
	{
		pedidoVenda.CONSIGNACAO_CONCLUIDA = pedidoVenda.CONSIGNACAO_CONCLUIDA.HasValue && pedidoVenda.CONSIGNACAO_CONCLUIDA.ToBool();
		pedidoVenda.CODIGO_TEXTO = (pedidoVenda.CODIGO_TEXTO.HasValue ? pedidoVenda.CODIGO_TEXTO.ToInt() : 0);
		pedidoVenda.CFOP_SR = (pedidoVenda.CFOP_SR.HasValue ? pedidoVenda.CFOP_SR.ToInt() : 0);
		pedidoVenda.QUANTIDADE_IMP_SEPARACAO = (pedidoVenda.QUANTIDADE_IMP_SEPARACAO.HasValue ? pedidoVenda.QUANTIDADE_IMP_SEPARACAO : new int?(0));
		pedidoVenda.QUANTIDADE_IMP_ORCAMENTO = (pedidoVenda.QUANTIDADE_IMP_ORCAMENTO.HasValue ? pedidoVenda.QUANTIDADE_IMP_ORCAMENTO : new byte?(0));
		pedidoVenda.URGENTE = (pedidoVenda.URGENTE.HasValue ? pedidoVenda.URGENTE.Value : BoolEnum.False);
		pedidoVenda.DESMENBRAR_QUEBRA_NOTA_FISCAL = (pedidoVenda.DESMENBRAR_QUEBRA_NOTA_FISCAL.HasValue ? pedidoVenda.DESMENBRAR_QUEBRA_NOTA_FISCAL.Value : BoolEnum.False);
		pedidoVenda.SEQ_LOCAL_FATURAMENTO = (pedidoVenda.SEQ_LOCAL_FATURAMENTO.HasValue ? pedidoVenda.SEQ_LOCAL_FATURAMENTO.Value : 0);
		pedidoVenda.CARTAO_CREDITO_NUMERO = ((pedidoVenda.CARTAO_CREDITO_NUMERO != null) ? pedidoVenda.CARTAO_CREDITO_NUMERO : "");
		pedidoVenda.CARTAO_CREDITO_PROPRIETARIO = ((pedidoVenda.CARTAO_CREDITO_PROPRIETARIO != null) ? pedidoVenda.CARTAO_CREDITO_PROPRIETARIO : "");
		pedidoVenda.CARTAO_CREDITO_TIPO = ((pedidoVenda.CARTAO_CREDITO_TIPO != null) ? pedidoVenda.CARTAO_CREDITO_TIPO : "");
		pedidoVenda.CARTAO_CREDITO_COMPLEMENTO = ((pedidoVenda.CARTAO_CREDITO_COMPLEMENTO != null) ? pedidoVenda.CARTAO_CREDITO_COMPLEMENTO : "");
		pedidoVenda.CARTAO_CREDITO_DATA_EXPIRACAO_MES = ((pedidoVenda.CARTAO_CREDITO_DATA_EXPIRACAO_MES != null) ? pedidoVenda.CARTAO_CREDITO_DATA_EXPIRACAO_MES : "");
		pedidoVenda.CARTAO_CREDITO_DATA_EXPIRACAO_ANO = ((pedidoVenda.CARTAO_CREDITO_DATA_EXPIRACAO_ANO != null) ? pedidoVenda.CARTAO_CREDITO_DATA_EXPIRACAO_ANO : "");
		pedidoVenda.CARTAO_CREDITO_CPF_PROPRIETARIO = ((pedidoVenda.CARTAO_CREDITO_CPF_PROPRIETARIO != null) ? pedidoVenda.CARTAO_CREDITO_CPF_PROPRIETARIO : "");
		pedidoVenda.VALOR_DESPESAS_ACESSORIAS = (pedidoVenda.VALOR_DESPESAS_ACESSORIAS.HasValue ? pedidoVenda.VALOR_DESPESAS_ACESSORIAS : new decimal?(default(decimal)));
		pedidoVenda.EXPORT_UF_EMBARQUE = ((pedidoVenda.EXPORT_UF_EMBARQUE != null) ? pedidoVenda.EXPORT_UF_EMBARQUE : "");
		pedidoVenda.EXPORT_LOCAL_EMBARQUE = ((pedidoVenda.EXPORT_LOCAL_EMBARQUE != null) ? pedidoVenda.EXPORT_LOCAL_EMBARQUE : "");
		pedidoVenda.IMPORT_VALOR_SISCOMEX = (pedidoVenda.IMPORT_VALOR_SISCOMEX.HasValue ? pedidoVenda.IMPORT_VALOR_SISCOMEX : new decimal?(default(decimal)));
		pedidoVenda.PERCENTUAL_DESCONTO_GERACAO_AUTOMATICA = (pedidoVenda.PERCENTUAL_DESCONTO_GERACAO_AUTOMATICA.HasValue ? pedidoVenda.PERCENTUAL_DESCONTO_GERACAO_AUTOMATICA : new decimal?(default(decimal)));
		pedidoVenda.VALOR_FRETE_ALTERADO_MANUAL = ((!pedidoVenda.VALOR_FRETE_ALTERADO_MANUAL.HasValue) ? new bool?(false) : pedidoVenda.VALOR_FRETE_ALTERADO_MANUAL);
		pedidoVenda.ST_REMUNERADO_INST = ((pedidoVenda.ST_REMUNERADO_INST != null) ? pedidoVenda.ST_REMUNERADO_INST : "NO");
		pedidoVenda.PREVISAO_VENDA_FLUXO_CAIXA = (pedidoVenda.PREVISAO_VENDA_FLUXO_CAIXA.HasValue ? pedidoVenda.PREVISAO_VENDA_FLUXO_CAIXA : new BoolEnum?(BoolEnum.True));
		pedidoVenda.CODIGO_CLIENTE_OUTRO_CLIENTE = ((pedidoVenda.CODIGO_CLIENTE_OUTRO_CLIENTE == 0) ? pedidoVenda.CODIGO_CLIENTE_OUTRO_CLIENTE : null);
		pedidoVenda.NUMERO_DIAS_DESCONTO_FINANCEIRO = (pedidoVenda.NUMERO_DIAS_DESCONTO_FINANCEIRO.HasValue ? pedidoVenda.NUMERO_DIAS_DESCONTO_FINANCEIRO : new short?(0));
		decimal? pERCENTUAL_DESCONTO_FINANCEIRO = pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO;
		pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO = (((pERCENTUAL_DESCONTO_FINANCEIRO.GetValueOrDefault() == default(decimal)) & pERCENTUAL_DESCONTO_FINANCEIRO.HasValue) ? null : pedidoVenda.PERCENTUAL_DESCONTO_FINANCEIRO);
		pedidoVenda.VALOR_FRETE = ((!pedidoVenda.VALOR_FRETE.HasValue) ? new decimal?(default(decimal)) : pedidoVenda.VALOR_FRETE);
		pedidoVenda.VALOR_DESCONTO_FINANCEIRO = ((!pedidoVenda.VALOR_DESCONTO_FINANCEIRO.HasValue) ? new decimal?(default(decimal)) : pedidoVenda.VALOR_DESCONTO_FINANCEIRO);
	}

	private void GerarSeqObservacoes(PedidoVendaMO objeto)
	{
		if (objeto.OBSERVACOES == null || objeto.OBSERVACOES.Count == 0)
		{
			return;
		}
		objeto.OBSERVACOES = objeto.OBSERVACOES.OrderBy((ObservacaoPedidoMO x) => x.CODIGO_TEXTO).ToList();
		short num = 0;
		foreach (ObservacaoPedidoMO oBSERVACO in objeto.OBSERVACOES)
		{
			num = (oBSERVACO.SEQ = (short)(num + 1));
		}
	}

	public ResultadoLiberarPedidoErpVO ProcessarLiberacaoPedidoErp(ParametrosLiberarPedidoErpVO paramLiberacaoPedidoErp, PedidoVendaMO pedidoVenda)
	{
		ResultadoLiberarPedidoErpVO resultadoLiberarPedidoErpVO = (BaseDAL as PedidoVendaDAL).ProcessarLiberacaoPedidoErp(paramLiberacaoPedidoErp);
		if (resultadoLiberarPedidoErpVO.OCORREU_ERRO)
		{
			string menssage = GerarMensagemErroLiberacaoPedido(resultadoLiberarPedidoErpVO.CODIGO_ERRO, resultadoLiberarPedidoErpVO.DADOS_RETORNO.MENSAGEM_ERRO);
			new MyException(menssage).ThrowException();
		}
		if (!resultadoLiberarPedidoErpVO.CONTEM_DADOS)
		{
			return resultadoLiberarPedidoErpVO;
		}
		if (VerificarSeUtilizaNFe(pedidoVenda))
		{
			ValidarInscricaoEstadualDaTransportadora(resultadoLiberarPedidoErpVO, pedidoVenda);
			ValidarInscricaoEstadualDoCliente(resultadoLiberarPedidoErpVO, pedidoVenda);
		}
		resultadoLiberarPedidoErpVO.ERROS = ObterErrosLiberacaoPedido(resultadoLiberarPedidoErpVO.DADOS_RETORNO.NOME_TABELA_TEMP);
		return resultadoLiberarPedidoErpVO;
	}

	private void ValidarInscricaoEstadualDaTransportadora(ResultadoLiberarPedidoErpVO retorno, PedidoVendaMO pedidoVenda)
	{
		FornecedorMO fORNECEDOR = pedidoVenda.FORNECEDOR;
		if (fORNECEDOR != null && fORNECEDOR.CODIGO_FORNECEDOR != 0 && !pedidoVenda.IE_VALIDA.TRANSPORTADORA)
		{
		}
	}

	private void ValidarInscricaoEstadualDoCliente(ResultadoLiberarPedidoErpVO retorno, PedidoVendaMO pedidoVenda)
	{
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		string eSTADO = cLIENTE.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "FA").ESTADO;
		if (!pedidoVenda.IE_VALIDA.CLIENTE)
		{
		}
	}

	private bool VerificarSeUtilizaNFe(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PAR_CFG.UTILIZA_NFE)
		{
			return false;
		}
		if (!(BaseDAL as PedidoVendaDAL).VerificarPedidoGeraNotaFiscal(pedidoVenda))
		{
			return false;
		}
		return true;
	}

	private string GerarMensagemErroLiberacaoPedido(int codigoErro, string mensagemErroBase)
	{
		string result = string.Empty;
		switch (codigoErro)
		{
		case -100:
			result = mensagemErroBase;
			break;
		case -200:
			result = GerarMensagemErroLiberacaoPedido200(mensagemErroBase);
			break;
		case -300:
			result = GerarMensagemErroLiberacaoPedido300(mensagemErroBase);
			break;
		}
		return result;
	}

	private string GerarMensagemErroLiberacaoPedido300(string mensagemErroBase)
	{
		if (string.IsNullOrEmpty(mensagemErroBase))
		{
			return string.Empty;
		}
		if (mensagemErroBase.PadRight(1) != ";")
		{
			mensagemErroBase += ";";
		}
		string text = string.Empty;
		while (!string.IsNullOrEmpty(mensagemErroBase))
		{
			int num = mensagemErroBase.IndexOf(',');
			string text2 = mensagemErroBase.PadLeft(num).Trim();
			int num2 = num + 1;
			int length = mensagemErroBase.Length - num2;
			mensagemErroBase = mensagemErroBase.Substring(num2, length).Trim();
			num = mensagemErroBase.IndexOf(',');
			num2 = num + 1;
			length = mensagemErroBase.Length - num2;
			string text3 = mensagemErroBase.PadLeft(num);
			mensagemErroBase = mensagemErroBase.Substring(num2, length).Trim();
			int num3 = mensagemErroBase.IndexOf(';');
			num2 = num3 + 1;
			length = mensagemErroBase.Length - num2;
			string text4 = mensagemErroBase.PadLeft(num3);
			mensagemErroBase = mensagemErroBase.Substring(num2, length).Trim();
			string text5 = new string(' ', 23 - text2.Length);
			string text6 = new string(' ', 23 - text3.Length);
			text = text + text2 + text5 + text3 + text6 + text4 + MensagemString.ENTER;
		}
		return "AVISO" + "O(s) produto(s) listado(s) abaixo está(ão) com informação(ões) incompleta(s) de Grupo de Categoria." + "Necessário cadastrar Grupo de Categoria de Armazenagem do(s) Endereço(s) de Separação associado(s) ao(s) seguinte(s) produto(s)" + MensagemString.ENTER + MensagemString.ENTER + "Pedido                  Produto                  Endereço" + MensagemString.ENTER + text + MensagemString.ENTER;
	}

	private string GerarMensagemErroLiberacaoPedido200(string mensagemErroBase)
	{
		if (string.IsNullOrEmpty(mensagemErroBase))
		{
			return string.Empty;
		}
		if (mensagemErroBase.PadRight(1) != ";")
		{
			mensagemErroBase += ";";
		}
		string text = string.Empty;
		while (!string.IsNullOrEmpty(mensagemErroBase))
		{
			int num = mensagemErroBase.IndexOf(',');
			string text2 = mensagemErroBase.PadLeft(num);
			int num2 = num + 1;
			int length = mensagemErroBase.Length - num2;
			mensagemErroBase = mensagemErroBase.Substring(num2, length).Trim();
			int num3 = mensagemErroBase.IndexOf(';');
			string text3 = mensagemErroBase.PadLeft(num3);
			num2 = num3 + 1;
			length = mensagemErroBase.Length - num2;
			mensagemErroBase = mensagemErroBase.Substring(num2, length).Trim();
			int count = 23 - text2.Length;
			string text4 = new string(' ', count);
			text = text + text2 + text4 + text3 + MensagemString.ENTER;
		}
		return string.IsNullOrEmpty(text) ? ("Existe(m) produtos(s) vencidos ou sem saldo no estoque." + "Por favor ajuste o pedido realizando o corte do produto e/ou alterando o lote para dar continuidade à separação." + "OPERAÇÃO CANCELADA.") : ("Os produtos listados abaixo estão vencidos ou sem saldo no estoque." + "Por favor ajuste o pedido realizando o corte do produto e/ou alterando o lote para dar continuidade à separação." + "OPERAÇÃO CANCELADA." + MensagemString.ENTER + MensagemString.ENTER + "Pedido                  Produto" + MensagemString.ENTER + text + MensagemString.ENTER);
	}

	public void CancelarPedido(PedidoVendaMO pedidoVenda)
	{
		(BaseDAL as PedidoVendaDAL).CancelarPedido(pedidoVenda, pedidoVenda.TIPO_PEDIDO);
	}

	public void CalcularImposto(PedidoVendaMO pedidoVenda, ItemPedidoMO item, bool UtilizaApiImposto, string WebServiceUrl)
	{
		ImpostoPedidoVendaRequest impostoPedidoVendaRequest = new ImpostoPedidoVendaRequest();
		impostoPedidoVendaRequest.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		impostoPedidoVendaRequest.TIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO.CODIGO_TIPO_PEDIDO;
		impostoPedidoVendaRequest.CODIGO_PRODUTO = item.CODIGO_PRODUTO;
		if (item.BONIFICADO.ToBool())
		{
			impostoPedidoVendaRequest.PRECO_TABELA = 0m;
		}
		else if (item.INDICE_RELACAO == "MAIOR")
		{
			impostoPedidoVendaRequest.PRECO_TABELA = (item.PRECO_BASICO.ToDouble() * item.FATOR_ESTOQUE_PEDIDA).ToDecimal();
		}
		else if (item.INDICE_RELACAO == "MENOR")
		{
			impostoPedidoVendaRequest.PRECO_TABELA = (item.PRECO_BASICO.ToDouble() / item.FATOR_ESTOQUE_PEDIDA).ToDecimal();
		}
		impostoPedidoVendaRequest.UF = LoginERP.EMPRESA_LOGADA.ESTADO;
		impostoPedidoVendaRequest.CODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE;
		impostoPedidoVendaRequest.PERCENTUAL_DESCONTO = item.DESCONTO_APLICADO.ToDecimal();
		impostoPedidoVendaRequest.QUANTIDADE_UNIDADE_PEDIDA = item.QUANTIDADE_UNIDADE_PEDIDA.ToDecimal();
		impostoPedidoVendaRequest.QUANTIDADE_UNIDADE_ESTOQUE = item.QUANTIDADE.ToDecimal();
		impostoPedidoVendaRequest.VALOR_UNITARIO_VENDA = item.VALOR_UNITARIO_PEDIDA.ToDecimal();
		impostoPedidoVendaRequest.VALOR_FRETE_ITEM = item.VALOR_FRETE_ITEM.ToDecimal();
		impostoPedidoVendaRequest.VALOR_DESCONTO_GERAL = item.VALOR_DESCONTO_GERAL.ToDecimal();
		impostoPedidoVendaRequest.BONIFICADO = item.BONIFICADO.ToBool();
		ImpostosPedidoVendaResponse impostoCalculado = CalculadorImpostoERP.CalcularImpostoPedidoVenda(impostoPedidoVendaRequest, pedidoVenda.CLIENTE, pedidoVenda.TIPO_PEDIDO, ConfigERP.PAR_CFG, UtilizaApiImposto, WebServiceUrl);
		AplicarImpostoItem(impostoCalculado, pedidoVenda, item);
	}

	private void AplicarImpostoItem(ImpostosPedidoVendaResponse impostoCalculado, PedidoVendaMO pedido, ItemPedidoMO item)
	{
		item.VALOR_IPI = Math.Round(impostoCalculado.VALOR_IPI, 2, MidpointRounding.AwayFromZero);
		item.VALOR_ICMS_SUBST = Math.Round(impostoCalculado.VALOR_SUBST_TRIB, 2, MidpointRounding.AwayFromZero);
		item.VALOR_ST_UNITARIO_ADIC_ITEM = default(decimal);
		if (item.QUANTIDADE > 0m && item.ST_ADICIONAL_ITEM)
		{
			item.VALOR_ST_UNITARIO_ADIC_ITEM = Math.Round((impostoCalculado.VALOR_SUBST_TRIB / item.QUANTIDADE).ToDecimal(), 2, MidpointRounding.AwayFromZero);
			item.VALOR_ICMS_SUBST = item.VALOR_ST_UNITARIO_ADIC_ITEM * (decimal?)item.QUANTIDADE;
		}
		decimal num = Math.Round(impostoCalculado.VALOR_RESSARCIMENTO_ICMS, 2, MidpointRounding.AwayFromZero);
		item.VALOR_IMPOSTOS = item.VALOR_IPI.ToDecimal() + item.VALOR_ICMS_SUBST.ToDecimal() + num;
		item.VALOR_DEBITO_ICMS = Math.Round(impostoCalculado.VALOR_ICMS, 2, MidpointRounding.AwayFromZero);
		item.VALOR_DEBITO_PIS = Math.Round(impostoCalculado.VALOR_PIS, 2, MidpointRounding.AwayFromZero);
		item.VALOR_DEBITO_COFINS = Math.Round(impostoCalculado.VALOR_COFINS, 2, MidpointRounding.AwayFromZero);
		item.VALOR_ICMS_DESONERADO = Math.Round(impostoCalculado.VALOR_ICMS_DESONERADO, 2, MidpointRounding.AwayFromZero);
	}

	public List<ErroErpVO> ObterErrosLiberacaoPedido(string nomeTabelaTemporaria)
	{
		return (BaseDAL as PedidoVendaDAL).ObterErrosLiberacaoPedido(nomeTabelaTemporaria);
	}

	public void AtualizaPrazoMedioPedido(PedidoVendaMO pedidoVenda)
	{
		if (!Convert.ToBoolean(pedidoVenda.PROMOCAO.FLEXIVEL))
		{
			return;
		}
		DateTime dateTime = pedidoVenda.DATA_PREVISAO_FATURAMENTO.ToDateTime();
		if (ConfigERP.PAR_CFG.TITREC_PROX_DIA_UTIL)
		{
			dateTime = dateTime.AddDays(1.0);
			dateTime = CalendarioERP.BuscaProximoDiaUtil(pedidoVenda.CODIGO_EMPRESA, dateTime);
		}
		int num = 0;
		int count = pedidoVenda.PARCELAS.Count;
		foreach (ParcelaPedidoMO pARCELA in pedidoVenda.PARCELAS)
		{
			num += (pARCELA.DATA_PARCELA - pedidoVenda.DATA_PEDIDO.Value).Days;
		}
		pedidoVenda.PRAZO_MEDIO = num / count;
	}

	public void CalcularPesoTotalPedido(PedidoVendaMO pedidoVenda)
	{
		decimal d = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.PESO_BRUTO.ToDecimal() * x.QUANTIDADE);
		pedidoVenda.PESO_TOTAL = Math.Round(d, 2, MidpointRounding.AwayFromZero);
		decimal d2 = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.PESO_LIQUIDO.ToDecimal() * x.QUANTIDADE);
		pedidoVenda.PESO_TOTAL_LIQUIDO = Math.Round(d2, 2, MidpointRounding.AwayFromZero);
	}

	public void CalcularVolumeTotalPedido(PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PAR_CFG.VOL_PEDVDA_TIPO == TipoVolumePedidoEnum.CALCULO_AUTOMATICO && ConfigERP.PAR_CFG.VOL_PEDVDA_ORIGEM == OrigemVolumePedidoEnum.PEDIDO_VENDA)
		{
			pedidoVenda.QUANTIDADE_VOLUMES = pedidoVenda.ITENS.Sum((ItemPedidoMO x) => x.QUANTIDADE_UNIDADE_VENDA);
		}
	}

	public void CarregaTransportadoraClienteNoPedido(PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PARAMETROS_TELA.VENDA.SUGERIR_TRANSPORTADORA_DO_CLIENTE && pedidoVenda.TIPO_ENTREGA == "TR" && pedidoVenda.CLIENTE.CODIGO_FORNECEDOR > 0)
		{
			pedidoVenda.CODIGO_FORNECEDOR = pedidoVenda.CLIENTE.CODIGO_FORNECEDOR;
		}
	}

	public void ValidarTransportadoraInformada(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.TIPO_ENTREGA == "TR" && !(pedidoVenda.CODIGO_FORNECEDOR > 0))
		{
			new MyException("Código da Transportadora deve ser informado para o Tipo de Entrega \"TR\".").ThrowException();
		}
		FornecedorMO fORNECEDOR = pedidoVenda.FORNECEDOR;
		if (fORNECEDOR != null && fORNECEDOR.CODIGO_FORNECEDOR > 0)
		{
			string eSTADO = fORNECEDOR.ENDERECOS.Find((EnderecoFornecedorMO x) => x.TIPO_ENDERECO == "FA").ESTADO;
			if (pedidoVenda.IE_VALIDA == null)
			{
				pedidoVenda.IE_VALIDA = new InscricaoEstadualVO();
			}
			pedidoVenda.IE_VALIDA.TRANSPORTADORA = ValidarDocumentosHelper.ValidarInscricaoEstadual(fORNECEDOR.TIPO_PESSOA, fORNECEDOR.TIPO_INSCRICAO, fORNECEDOR.INSCRICAO, eSTADO);
		}
	}

	public void ValidarDescontoGeral(PedidoVendaMO pedidoVenda)
	{
		decimal? vALOR_DESCONTO_GERAL = pedidoVenda.VALOR_DESCONTO_GERAL;
		if (!((vALOR_DESCONTO_GERAL.GetValueOrDefault() < default(decimal)) & vALOR_DESCONTO_GERAL.HasValue))
		{
			vALOR_DESCONTO_GERAL = pedidoVenda.PERCENTUAL_DESCONTO_GERAL;
			if (!((vALOR_DESCONTO_GERAL.GetValueOrDefault() < default(decimal)) & vALOR_DESCONTO_GERAL.HasValue))
			{
				return;
			}
		}
		if (ConfigERP.PAR_CFG.UTILIZA_NFE)
		{
			throw new MyException("Não é permitido o Desconto Geral negativo em pedidos NF-e.");
		}
	}

	public void CarregarCamposFixosPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		pedidoVenda.TIPO_PRODUTO_PEDIDO = "PR";
		pedidoVenda.PERCENTUAL_COMISSAO_VENDEDOR = 1m;
		pedidoVenda.PERCENTUAL_COMISSAO_LANCADOR = 0m;
		pedidoVenda.DISTRIBUIDOR = false;
		pedidoVenda.CODIGO_CLIENTE_DISTRIBUIDOR = 0;
		pedidoVenda.ENTREGA_OUTRO_CLIENTE = false;
		pedidoVenda.TIPO_DESCONTO_GERAL = "PE";
		pedidoVenda.CODIGO_EMPRESA = pedidoVenda.EMPRESA.CODIGO_EMPRESA;
		pedidoVenda.CODIGO_ROTA = pedidoVenda.CLIENTE.CODIGO_ROTA;
		pedidoVenda.SEQ_TRIBUTACAO_CLIENTE = pedidoVenda.CLIENTE.SEQ_TRIBUTACAO_CLIENTE;
		pedidoVenda.CODIGO_VENDEDOR_COMISSAO = pedidoVenda.CODIGO_VENDEDOR;
		pedidoVenda.CODIGO_VENDEDOR_VERBA = pedidoVenda.CODIGO_VENDEDOR;
		pedidoVenda.PRAZO_MEDIO = pedidoVenda.PROMOCAO.PRAZO_MEDIO;
		pedidoVenda.TIPO_VALOR_BASE_COMISSAO = ConfigERP.PAR_CFG.TP_VL_BASE_COMISSAO;
		pedidoVenda.LANCAMENTO_CREDITO_VERBA = ConfigERP.PAR_CFG.LANC_CRED_VERBA;
		if (VersaoDAL.VERSAO_ERP_ATUAL.MAJOR > 11 || VersaoDAL.VERSAO_ERP_ATUAL.MINOR > 2 || VersaoDAL.VERSAO_ERP_ATUAL.BUILD > 14 || (VersaoDAL.VERSAO_ERP_ATUAL.BUILD >= 14 && VersaoDAL.VERSAO_ERP_ATUAL.REVISION >= 1))
		{
			pedidoVenda.SEQ_TRIB_REG_EMP = pedidoVenda.EMPRESA.SEQ_TRIBUTACAO_REGIME;
		}
		if (!string.IsNullOrWhiteSpace(pedidoVenda.NUMERO_PEDIDO_CLIENTE) && pedidoVenda.NUMERO_PEDIDO_CLIENTE.Length > 20)
		{
			pedidoVenda.NUMERO_PEDIDO_CLIENTE = pedidoVenda.NUMERO_PEDIDO_CLIENTE.Substring(0, 20);
		}
	}

	public void CarregarDataFaturamentoEntregaPedido(PedidoVendaMO pedidoVenda)
	{
		pedidoVenda.DATA_ABERTURA_PEDIDO = DateTimeHelper.ObterDataHoraAtualBancoDados();
		DateTime date = pedidoVenda.DATA_ABERTURA_PEDIDO.Date;
		bool oBRIGA_INFORMACAO_DA_DATA_DE_ENTREGA_DO_PEDIDO = ConfigERP.PARAMETROS_TELA.VENDA.OBRIGA_INFORMACAO_DA_DATA_DE_ENTREGA_DO_PEDIDO;
		if ((!pedidoVenda.DATA_ENTREGA.HasValue || pedidoVenda.DATA_ENTREGA < date) && oBRIGA_INFORMACAO_DA_DATA_DE_ENTREGA_DO_PEDIDO)
		{
			pedidoVenda.DATA_ENTREGA = date;
		}
		if (!pedidoVenda.DATA_PREVISAO_FATURAMENTO.HasValue || pedidoVenda.DATA_PREVISAO_FATURAMENTO < date)
		{
			pedidoVenda.DATA_PREVISAO_FATURAMENTO = DateTimeHelper.FormartarDataPeloTipo(date, TipoDateTime.Data);
		}
	}

	public void CarregarTipoFretePedido(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		if (string.IsNullOrEmpty(pedidoEletronico.TIPO_FRETE))
		{
			if (!string.IsNullOrEmpty(pedidoVenda.CLIENTE.TIPO_FRETE))
			{
				pedidoVenda.TIPO_FRETE = pedidoVenda.CLIENTE.TIPO_FRETE;
			}
			else
			{
				pedidoVenda.TIPO_FRETE = "C";
			}
		}
		bool cOBRA_FRETE_QUANDO_FOR_ENTREGA = ConfigERP.PARAMETROS_TELA.VENDA.COBRA_FRETE_QUANDO_FOR_ENTREGA;
		if (pedidoVenda.TIPO_ENTREGA == "EN" && !cOBRA_FRETE_QUANDO_FOR_ENTREGA)
		{
			pedidoVenda.TIPO_FRETE = "C";
		}
		else if (pedidoVenda.TIPO_ENTREGA == "RE")
		{
			pedidoVenda.TIPO_FRETE = "F";
		}
	}

	public void ValidarParametroCancelamento(ParametrosCancelarPedidoVO paramCancelarPedidoVenda)
	{
		MyException ex = new MyException();
		ex.VerificarObjetoNull(paramCancelarPedidoVenda, "O parametros necessarios para o cancelamento do pedido venda não foram informados");
		if (string.IsNullOrEmpty(paramCancelarPedidoVenda.CODIGO_USUARIO))
		{
			ex.AddErro("{0} não informado no processo de cancelamento do pedido de venda.", "Código Usuário");
		}
		if (string.IsNullOrEmpty(paramCancelarPedidoVenda.NOME_PROGRAMA))
		{
			ex.AddErro("{0} não informado no processo de cancelamento do pedido de venda.", "Nome Programa");
		}
		if (paramCancelarPedidoVenda.CODIGO_EMPRESA == 0)
		{
			ex.AddErro("{0} não informado no processo de cancelamento do pedido de venda.", "Código Empresa");
		}
		if (paramCancelarPedidoVenda.NUMERO_PEDIDO == 0)
		{
			ex.AddErro("{0} não informado no processo de cancelamento do pedido de venda.", "Numero do Pedido");
		}
		if (!ex.ContemErro)
		{
			ValidarParametrosValoresInvalidos(paramCancelarPedidoVenda, ex);
		}
		ex.ThrowException();
	}

	private void ValidarParametrosValoresInvalidos(ParametrosCancelarPedidoVO paramCancelarPedidoVenda, MyException myException)
	{
		UsuarioBLL usuarioBLL = new UsuarioBLL();
		if (!usuarioBLL.ValidarCodigoUsuario(paramCancelarPedidoVenda.CODIGO_USUARIO))
		{
			myException.AddErro("{0} Inválido", "Código Usuário");
		}
		if (!ValidarNumeroPedidoVenda(paramCancelarPedidoVenda.CODIGO_EMPRESA, paramCancelarPedidoVenda.NUMERO_PEDIDO))
		{
			string text = $"Empresa: {paramCancelarPedidoVenda.CODIGO_EMPRESA}, Numero: {paramCancelarPedidoVenda.NUMERO_PEDIDO}";
			myException.AddErro("Não foi possivel encontrar pedido de venda pelos filtros. {0}", text);
		}
	}

	private bool ValidarNumeroPedidoVenda(int codigoEmpresa, int numeroPedido)
	{
		return (BaseDAL as PedidoVendaDAL).ValidarNumeroPedidoVenda(codigoEmpresa, numeroPedido);
	}

	public void ValidarLimiteDeVenda(PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PAR_CFG.PEDIDO_PF_X_PJ && !(ConfigERP.PAR_CFG.PERC_PEDIDO_PF_X_PJ <= 0m) && !(pedidoVenda.CLIENTE.TIPO_PESSOA != "F") && pedidoVenda.TIPO_PEDIDO.PEDIDO_PF_X_PJ)
		{
			MyException ex = new MyException();
			decimal pERC_PEDIDO_PF_X_PJ = ConfigERP.PAR_CFG.PERC_PEDIDO_PF_X_PJ;
			decimal? vALOR_TOTAL = pedidoVenda.VALOR_TOTAL;
			decimal value = BuscaValorTotalPedidosMes(SituacaoPedidoEnum.FATURADO, TipoPessoaEnum.FISICA);
			decimal value2 = BuscaValorTotalPedidosMes(SituacaoPedidoEnum.FATURADO, TipoPessoaEnum.JURIDICA);
			decimal value3 = BuscaValorTotalPedidosMes(SituacaoPedidoEnum.ABERTO, TipoPessoaEnum.FISICA);
			decimal value4 = BuscaValorTotalPedidosMes(SituacaoPedidoEnum.ABERTO, TipoPessoaEnum.JURIDICA);
			decimal? num = vALOR_TOTAL + (decimal?)value3 + (decimal?)value4 + (decimal?)value + (decimal?)value2;
			decimal? num2 = vALOR_TOTAL + (decimal?)value3 + (decimal?)value;
			decimal? num3 = num * (decimal?)pERC_PEDIDO_PF_X_PJ;
			decimal? num4 = num2 - num3;
			if (num2 > num3)
			{
				ex.AddErro("O pedido está com o valor de R${0} acima do permitido de {1}% das vendas totais para pessoa física.", Math.Round(num4.ToDecimal(), 2, MidpointRounding.AwayFromZero), Math.Round((pERC_PEDIDO_PF_X_PJ * 100m).ToDecimal(), 2, MidpointRounding.AwayFromZero));
			}
			ex.ThrowException();
		}
	}

	private decimal BuscaValorTotalPedidosMes(SituacaoPedidoEnum situacaoPedido, TipoPessoaEnum tipoPessoa)
	{
		PedidoVendaDAL pedidoVendaDAL = (PedidoVendaDAL)BaseDAL;
		return pedidoVendaDAL.BuscaValorTotalPedidosMes(situacaoPedido, tipoPessoa);
	}

	public void VerificaIntermediador(PedidoVendaMO pedidoVenda, bool? possuiIntermediador, string cnpjIntermediador)
	{
		if (possuiIntermediador.HasValue && possuiIntermediador.Value && !string.IsNullOrEmpty(cnpjIntermediador) && !string.IsNullOrWhiteSpace(cnpjIntermediador))
		{
			PedidoVendaDAL pedidoVendaDAL = (PedidoVendaDAL)BaseDAL;
			pedidoVendaDAL.VerificaIntermediador(pedidoVenda, cnpjIntermediador);
		}
	}
}
