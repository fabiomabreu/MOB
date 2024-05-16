using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class ClienteBLL : EntidadeBaseBLL<ClienteMO>
{
	protected override EntidadeBaseDAL<ClienteMO> GetInstanceDAL()
	{
		return new ClienteDAL();
	}

	public ObservacaoPedidoMO ObterMensagemExpedicaoPadrao(ClienteMO cliente)
	{
		if (!cliente.CODIGO_TEXTO_EXPEDICAO.HasValue || !(cliente.CODIGO_TEXTO_EXPEDICAO > 0))
		{
			return null;
		}
		ObservacaoPedidoMO observacaoPedidoMO = new ObservacaoPedidoMO();
		observacaoPedidoMO.CODIGO_TEXTO = cliente.CODIGO_TEXTO_EXPEDICAO.Value;
		observacaoPedidoMO.SETOR = "EXPEDICAO";
		return observacaoPedidoMO;
	}

	public void AtualizaTransportadora(PedidoVendaMO pedidoVenda)
	{
		bool aTUALIZA_TRANSPORTADORA_DO_CLIENTE = ConfigERP.PARAMETROS_TELA.VENDA.ATUALIZA_TRANSPORTADORA_DO_CLIENTE;
		if (pedidoVenda.TIPO_ENTREGA == "TR" && aTUALIZA_TRANSPORTADORA_DO_CLIENTE)
		{
			(BaseDAL as ClienteDAL).AtualizaTransportadora(pedidoVenda);
		}
	}

	public BoolEnum VerificarSePrimeiraCompra(int codigoCliente)
	{
		bool value = (BaseDAL as ClienteDAL).VerificarSeEhPrimeiraCompra(codigoCliente);
		return (BoolEnum)Convert.ToInt32(value);
	}

	public bool FaltaAlgumDocumentoParaPermitirVenda(ClienteMO cliente)
	{
		return (BaseDAL as ClienteDAL).FaltaAlgumDocumentoParaPermitirVenda(cliente);
	}

	public bool SituacaoCreditoValido(ClienteMO cliente)
	{
		return (BaseDAL as ClienteDAL).SituacaoCreditoValido(cliente);
	}

	public void AtualizaCondicaoComercialPadrao(PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PARAMETROS_TELA.VENDA.ATUALIZA_COND_COMERCIAIS_DO_CLIENTE)
		{
			PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
			(BaseDAL as ClienteDAL).AtualizaCondicaoComercialPadrao_Cliente(pedidoVenda.TIPO_PEDIDO, pedidoVenda.CLIENTE);
			(BaseDAL as ClienteDAL).AtualizaCondicaoComercialPadrao_ClienteEmpresa(pedidoVenda);
			(BaseDAL as ClienteDAL).AtualizaCondComercialPadrao_ClienteEmpresaFormaPagamento(pedidoVenda);
			if (ConfigERP.PARAMETROS_TELA.CLIENTE.ATUALIZA_AUTO_ASSOC_CLIENTE_X_COND_DE_PAGTO)
			{
				(BaseDAL as ClienteDAL).AtualizaCondComercialPadrao_ClienteCondicaoPagto(pedidoVenda);
			}
		}
	}

	public bool VerificaICMSDiferido(ClienteMO clienteMO)
	{
		ClienteDAL clienteDAL = new ClienteDAL();
		return clienteDAL.VerificaICMSDiferido(clienteMO);
	}

	public ClienteMO CarregarClientePeloCodigo(int codigoCliente)
	{
		ClienteMO clienteMO = new ClienteMO();
		clienteMO.CODIGO_CLIENTE = codigoCliente;
		return ObterUnicoPeloExemplo(clienteMO, "ENDERECOS", "FORMAS_PAGAMENTO", "TRIBUTACAO");
	}

	public void ValidarClienteParaVenda(PedidoVendaMO pedidoVenda)
	{
		MyException ex = new MyException();
		if (!pedidoVenda.CLIENTE.ATIVO.ToBool())
		{
			ex.AddErro("O cliente {0} - {1} está invativo", pedidoVenda.CLIENTE.CODIGO_CLIENTE, pedidoVenda.CLIENTE.NOME);
		}
		if (!pedidoVenda.TIPO_PEDIDO.VENDA_ESPECIAL && ConfigERP.PAR_CFG.BLOQ_NF_PF)
		{
			if (pedidoVenda.CLIENTE.TIPO_PESSOA == "F")
			{
				ex.AddErro("Não é permitida venda para Pessoa Física. Cliente: {0}.", pedidoVenda.CLIENTE.CODIGO_CLIENTE);
			}
			else if (!ValidarDocumentosHelper.ValidaCNPJ(pedidoVenda.CLIENTE.CNPJ_CPF))
			{
				ex.AddErro("Para este Tipo de Pedido, o cliente: {0}, deve ser Pessoa Jurídica com CNPJ válido.", pedidoVenda.CLIENTE.CODIGO_CLIENTE);
			}
		}
		if (ConfigERP.PARAMETROS_TELA.CLIENTE.OBRIGA_CADASTRO_DOS_DOCUMENTOS_DE_SEGMENTO_DO_CLIENTE && FaltaAlgumDocumentoParaPermitirVenda(pedidoVenda.CLIENTE))
		{
			ex.AddErro("Existem documentos associados ao segmento do cliente que precisam ser inclusos no cadastro do cliente.");
		}
		if (!SituacaoCreditoValido(pedidoVenda.CLIENTE) || string.IsNullOrEmpty(pedidoVenda.CLIENTE.SITUACAO_CREDITO))
		{
			ex.AddErro("O Cliente: {0}, sem Situação de Crédito cadastrada.", pedidoVenda.CLIENTE.CODIGO_CLIENTE);
		}
		ClienteMO cLIENTE = pedidoVenda.CLIENTE;
		if (cLIENTE != null)
		{
			string eSTADO = cLIENTE.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "FA").ESTADO;
			if (pedidoVenda.IE_VALIDA == null)
			{
				pedidoVenda.IE_VALIDA = new InscricaoEstadualVO();
			}
			if (cLIENTE.TIPO_INSCRICAO != "I")
			{
				pedidoVenda.IE_VALIDA.CLIENTE = ValidarDocumentosHelper.ValidarInscricaoEstadual(cLIENTE.TIPO_PESSOA, cLIENTE.TIPO_INSCRICAO, cLIENTE.INSCRICAO, eSTADO);
			}
			else
			{
				pedidoVenda.IE_VALIDA.CLIENTE = true;
			}
		}
		ex.ThrowException();
	}

	public void ValidarEnderecos(ClienteMO cliente)
	{
		MyException ex = new MyException();
		if (cliente.ENDERECOS.Exists((EnderecoClienteMO x) => string.IsNullOrEmpty(x.LOGRADOURO) || string.IsNullOrEmpty(x.NUMERO) || string.IsNullOrEmpty(x.CODIGO_PAIS)))
		{
			ex.AddErro("O endereço do cliente, está desatualizado. Os campos Logradouro, Número e País devem estar preenchidos");
		}
		EnderecoClienteMO enderecoClienteMO = cliente.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "EN");
		if (enderecoClienteMO == null || enderecoClienteMO.CODIGO_PAIS != "BRA")
		{
			ex.AddErro("Não é permitido venda para cliente cujo país seja diferente de Brasil.");
		}
		ex.ThrowException();
	}

	public ClienteMO ObterClienteParaPedidoVenda(int codigoCliente)
	{
		ClienteMO exampleInstance = new ClienteMO
		{
			CODIGO_CLIENTE = codigoCliente
		};
		return ObterUnicoPeloExemplo(exampleInstance, "ENDERECOS", "FORMAS_PAGAMENTO", "TRIBUTACAO", "CLIENTE_DIA_VENCIMENTO");
	}

	private decimal BuscaValorLimitePedidoPF(ClienteMO cliente)
	{
		ClienteDAL clienteDAL = (ClienteDAL)BaseDAL;
		return clienteDAL.BuscaValorLimitePedidoPF(cliente, LoginERP.EMPRESA_LOGADA.CODIGO_EMPRESA);
	}

	private decimal BuscaValorPedidosMes(ClienteMO cliente)
	{
		ClienteDAL clienteDAL = (ClienteDAL)BaseDAL;
		return clienteDAL.BuscaValorPedidosMes(cliente);
	}

	public void ValidarLimiteDeVenda(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PAR_CFG.PEDIDO_PF_X_PJ || pedidoVenda.CLIENTE.TIPO_PESSOA != "F")
		{
			return;
		}
		MyException ex = new MyException();
		decimal num = BuscaValorLimitePedidoPF(pedidoVenda.CLIENTE);
		if (num > 0m)
		{
			decimal value = BuscaValorPedidosMes(pedidoVenda.CLIENTE);
			decimal? vALOR_TOTAL = pedidoVenda.VALOR_TOTAL;
			decimal? num2 = (decimal?)value + vALOR_TOTAL;
			decimal num3 = Math.Round((num2 - (decimal?)num).ToDecimal(), 2, MidpointRounding.AwayFromZero);
			decimal? num4 = num2;
			decimal num5 = num;
			if ((num4.GetValueOrDefault() > num5) & num4.HasValue)
			{
				ex.AddErro("O limite de compra do cliente {0} foi ultrapassado em R${1}.", pedidoVenda.CLIENTE.CODIGO_CLIENTE, num3);
			}
		}
		ex.ThrowException();
	}
}
