using System.Collections.Generic;
using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Visao;

namespace Target.Venda.IBusiness.IFluxo;

public interface ILiberarMultiplosPedidosEletronicosBLL : IFluxoBaseBLL
{
	List<RetornoLiberarPedidoEletronicoVO> ExecutarMultiplosPedidos(List<ParametrosLiberarPedidoEletronicoVO> listaParametrosLiberarPedidoEle);
}
