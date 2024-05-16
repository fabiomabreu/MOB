using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Modulo;

public class ModuloComercialBLL : ModuloBaseBLL, IModuloComercialBLL, IModuloBaseBLL
{
	public void CarregarTrocaPedido(PedidoVendaMO pedidoVenda)
	{
		TrocaBLL trocaBLL = new TrocaBLL();
		pedidoVenda.TROCA = trocaBLL.ObterTrocaPedidoVenda(pedidoVenda);
	}

	public void AssociarTrocaPedido(PedidoVendaMO pedidoVenda)
	{
		if (pedidoVenda.TROCA != null)
		{
			TrocaBLL trocaBLL = new TrocaBLL();
			trocaBLL.AssociarTrocaPedido(pedidoVenda, pedidoVenda.TROCA);
			EventoBLL eventoBLL = new EventoBLL();
			eventoBLL.GerarEventoTroca(pedidoVenda.TROCA, LoginERP.USUARIO_LOGADO);
		}
	}

	public void ValidarTroca(PedidoVendaMO pedidoVenda)
	{
		TrocaBLL trocaBLL = new TrocaBLL();
		if (trocaBLL.ExisteTrocaNoPedido(pedidoVenda))
		{
			trocaBLL.ValidarTrocaPedido(pedidoVenda);
		}
	}

	public void CalcularVerbaPedido(PedidoVendaMO pedidoVenda)
	{
		VerbaBLL verbaBLL = new VerbaBLL();
		verbaBLL.CalcularVerbaPedido(pedidoVenda);
	}

	public void EfetivarVerbaPedido(PedidoVendaMO pedidoVenda)
	{
		VerbaBLL verbaBLL = new VerbaBLL();
		verbaBLL.TratarVerbaFabricante(pedidoVenda);
		LancamentoVerbaBLL lancamentoVerbaBLL = new LancamentoVerbaBLL();
		lancamentoVerbaBLL.EfetivaVerba(pedidoVenda);
	}

	public void CancelarVerbaPedido(PedidoVendaMO pedidoVenda)
	{
		LancamentoVerbaBLL lancamentoVerbaBLL = new LancamentoVerbaBLL();
		lancamentoVerbaBLL.CancelarVerba(pedidoVenda);
	}

	public void CalcularVerbaFabricanteItensPedido(PedidoVendaMO pedidoVenda)
	{
		VerbaBLL verbaBLL = new VerbaBLL();
		verbaBLL.CalcularVerbaFabricanteItensPedido(pedidoVenda);
	}

	public void CarregarAcaoComercial(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
		acaoComercialBLL.AssociarAcaoComercialItemPedido(itemPedido, pedidoVenda);
	}

	public void CarregarCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PAR_CFG.UTILIZA_CAMPANHA && (!ConfigERP.PAR_CFG.UTILIZA_CAMPANHA || !ConfigERP.PAR_CFG.CAMPANHA_UTILIZA_FILA_APUR))
		{
			CampanhaBLL campanhaBLL = new CampanhaBLL();
			pedidoVenda.CAMPANHAID = campanhaBLL.BuscaCampanhaAtiva(pedidoVenda);
			if (pedidoVenda.CAMPANHAID.HasValue && pedidoVenda.CAMPANHAID > 0)
			{
				campanhaBLL.InsereItPedvCampanha(pedidoEletronico, pedidoVenda);
				campanhaBLL.AplicaDescontosCampanha(pedidoEletronico, pedidoVenda);
			}
		}
	}

	public void DeletarCampanha(PedidoEletronicoMO pedidoEletronico)
	{
		if (ConfigERP.PAR_CFG.UTILIZA_CAMPANHA && (!ConfigERP.PAR_CFG.UTILIZA_CAMPANHA || !ConfigERP.PAR_CFG.CAMPANHA_UTILIZA_FILA_APUR))
		{
			CampanhaBLL campanhaBLL = new CampanhaBLL();
			campanhaBLL.DeletaItPedvCampanha(pedidoEletronico);
		}
	}

	public void AtualizaItPedvCampanha(PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PAR_CFG.UTILIZA_CAMPANHA && (!ConfigERP.PAR_CFG.UTILIZA_CAMPANHA || !ConfigERP.PAR_CFG.CAMPANHA_UTILIZA_FILA_APUR))
		{
			CampanhaBLL campanhaBLL = new CampanhaBLL();
			campanhaBLL.AtualizaItPedvCampanha(pedidoEletronico, pedidoVenda);
		}
	}

	public void AtualizarAcaoComercialFabricante(PedidoVendaMO pedidoVenda)
	{
		AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
		acaoComercialBLL.AtualizarAcaoComercialProdutoEncerradas(pedidoVenda);
		acaoComercialBLL.AtualizarAcaoComercialEncerradas(pedidoVenda);
	}
}
