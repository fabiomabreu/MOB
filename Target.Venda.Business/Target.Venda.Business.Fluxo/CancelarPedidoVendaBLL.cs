using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.Factory;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Fluxo;

public class CancelarPedidoVendaBLL : FluxoBaseBLL, ICancelarPedidoVendaBLL, IFluxoBaseBLL
{
	private RetornoCancelarPedidoVendaVO _retornoCancelarPedidoVenda;

	private IModuloEstoqueBLL iEstoqueBLL;

	private IModuloSistemaBLL iSistemaBLL;

	private IModuloVendaBLL iVendaBLL;

	private IModuloComercialBLL iComercialBLL;

	public RetornoCancelarPedidoVendaVO Executar(ParametrosCancelarPedidoVO parametroCancelarPedidoVenda)
	{
		_retornoCancelarPedidoVenda = new RetornoCancelarPedidoVendaVO();
		ExecutarCancelamento(parametroCancelarPedidoVenda);
		return _retornoCancelarPedidoVenda;
	}

	private void ExecutarCancelamento(ParametrosCancelarPedidoVO parametroCancelarPedidoVenda)
	{
		RetornaMensagemAviso("Iniciando Fluxo: Cancelar Pedido ERP");
		InicializarFluxo();
		RetornaMensagemAviso("Validar Parâmetro de Cancelar Pedido");
		iVendaBLL.ValidarParametroCancelarPedido(parametroCancelarPedidoVenda);
		RetornaMensagemAviso("Criar do Sessao Usuario");
		iSistemaBLL.CriarSessaoUsuario(parametroCancelarPedidoVenda.CODIGO_USUARIO, parametroCancelarPedidoVenda.CODIGO_EMPRESA, parametroCancelarPedidoVenda.NOME_PROGRAMA);
		RetornaMensagemAviso("Obter Pedido Venda pelo Id");
		PedidoVendaMO pedidoVenda = iVendaBLL.ObterPedidoVendaPeloID(parametroCancelarPedidoVenda.CODIGO_EMPRESA, parametroCancelarPedidoVenda.NUMERO_PEDIDO);
		RetornaMensagemAviso("Pedido não atingiu o Valor Mínimo.");
		RetornaMensagemAviso("Abre a Transação");
		try
		{
			TransactionManager.ExecutarComTransacao(delegate
			{
				RetornaMensagemAviso("Atualiza horário reserva de estoque");
				iEstoqueBLL.AtualizarHorarioReservaEstoque();
				RetornaMensagemAviso("Cancela as Verbas do Pedido (Fabricante/Vendedor/Equipe/Empresa)");
				iComercialBLL.CancelarVerbaPedido(pedidoVenda);
				RetornaMensagemAviso("Cancelando Pedido");
				iVendaBLL.CancelarPedido(pedidoVenda);
				RetornaMensagemAviso("Encerra a Transação - Commit");
				_retornoCancelarPedidoVenda.RESULTADO_PROCESSO = ResultadoProcessoEnum.SUCESSO;
			});
		}
		catch (Exception)
		{
			RetornaMensagemAviso("Encerra a Transação - RollBack");
			_retornoCancelarPedidoVenda.RESULTADO_PROCESSO = ResultadoProcessoEnum.FALHOU;
			throw;
		}
		finally
		{
			iSistemaBLL.EncerrarSessaoUsuario();
			_retornoCancelarPedidoVenda.LOG_PROCESSO = LogEventosProcesso.ToString();
			GC.Collect();
		}
	}

	private void InicializarFluxo()
	{
		iEstoqueBLL = BusinessFactory.GetEstoqueBLL();
		iEstoqueBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iSistemaBLL = BusinessFactory.GetSistemaBLL();
		iSistemaBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iVendaBLL = BusinessFactory.GetVendaBLL();
		iVendaBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iComercialBLL = BusinessFactory.GetComercialBLL();
		iComercialBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
	}
}
