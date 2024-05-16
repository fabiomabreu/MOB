using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Modulo;

public class ModuloLogisticaBLL : ModuloBaseBLL, IModuloLogisticaBLL, IModuloBaseBLL
{
	public void CarregarMensagemExpedicao(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		if (pedidoVenda.OBSERVACOES == null)
		{
			pedidoVenda.OBSERVACOES = new List<ObservacaoPedidoMO>();
		}
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		List<ObservacaoPedidoMO> list = pedidoEletronicoBLL.ObterMensagensExpedicao(pEDIDO_ELETRONICO);
		if (list != null && list.Count > 0)
		{
			pedidoVenda.OBSERVACOES.RemoveAll((ObservacaoPedidoMO x) => x.SETOR == "EXPEDICAO");
			pedidoVenda.OBSERVACOES.AddRange(list);
			return;
		}
		ClienteBLL clienteBLL = new ClienteBLL();
		ObservacaoPedidoMO msgExpedicaoCliente = clienteBLL.ObterMensagemExpedicaoPadrao(pedidoVenda.CLIENTE);
		if (msgExpedicaoCliente == null)
		{
			return;
		}
		TransactionManager.ExecutarComTransacao(delegate
		{
			try
			{
				TextoBLL textoBLL = new TextoBLL();
				TextoMO textoMO = textoBLL.CopiarTextoParaNovo(msgExpedicaoCliente.CODIGO_TEXTO.ToInt());
				msgExpedicaoCliente.CODIGO_TEXTO = textoMO.CODIGO_TEXTO;
			}
			catch (Exception)
			{
				throw;
			}
		});
		pedidoVenda.OBSERVACOES.Add(msgExpedicaoCliente);
	}

	public void CarregarVolumesItensPedido(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.CarregarVolumeItensPedido(pedidoVenda);
	}

	public void CarregarVolumeItensPedidoSemInfoVolumes(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.CarregarVolumeItensPedidoSemInfoVolumes(pedidoVenda);
	}

	public void CalcularPesoTotalPedido(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.CalcularPesoTotalPedido(pedidoVenda);
	}

	public void GerarSiglaSeparacao(PedidoVendaMO pedidoVenda)
	{
		SiglaSeparacaoDAL siglaSeparacaoDAL = new SiglaSeparacaoDAL();
		SiglaSeparacaoMO siglaSeparacaoMO = siglaSeparacaoDAL.ObtemSiglaSeparacao(pedidoVenda.NUMERO_PEDIDO);
		pedidoVenda.SIGLA_SEPARACAO = siglaSeparacaoMO.SIGLA_SEPARACAO;
	}

	public void CalcularVolumeTotalPedido(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.CalcularVolumeTotalPedido(pedidoVenda);
	}

	public void CarregarTransportadoraPedido(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.CarregaTransportadoraClienteNoPedido(pedidoVenda);
		FornecedorBLL fornecedorBLL = new FornecedorBLL();
		pedidoVenda.FORNECEDOR = fornecedorBLL.ObterFornecedorPeloCodigo(pedidoVenda.CODIGO_FORNECEDOR);
	}

	public void ValidarTransportadora(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.ValidarTransportadoraInformada(pedidoVenda);
	}

	public void ValidarEnderecoPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		if (string.IsNullOrEmpty(pedidoVenda.TIPO_ENTREGA))
		{
			throw new MyException("Tipo de Entrega não foi informado");
		}
		EnderecoPedidoBLL enderecoPedidoBLL = new EnderecoPedidoBLL();
		enderecoPedidoBLL.ValidarEnderecoPedido(pedidoVenda);
		if (!ConfigERP.PAR_CFG.PERM_PED_VDA_END_DESATU)
		{
			ClienteBLL clienteBLL = new ClienteBLL();
			clienteBLL.ValidarEnderecos(pedidoVenda.CLIENTE);
			EmpresaBLL empresaBLL = new EmpresaBLL();
			empresaBLL.ValidarEndereco(pedidoVenda.EMPRESA);
		}
	}

	public void CalcularFrete(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		CalculadorFreteERP calculadorFreteERP = new CalculadorFreteERP();
		calculadorFreteERP.CalcularFrete(pedidoVenda, pedidoEletronico);
	}
}
