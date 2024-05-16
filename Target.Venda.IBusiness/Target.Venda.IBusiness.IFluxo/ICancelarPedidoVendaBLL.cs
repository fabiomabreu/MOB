using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Visao;

namespace Target.Venda.IBusiness.IFluxo;

public interface ICancelarPedidoVendaBLL : IFluxoBaseBLL
{
	RetornoCancelarPedidoVendaVO Executar(ParametrosCancelarPedidoVO parametroCancelarPedidoVenda);
}
