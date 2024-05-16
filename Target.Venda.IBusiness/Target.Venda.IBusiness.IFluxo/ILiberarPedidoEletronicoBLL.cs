using Target.Venda.IBusiness.Base;
using Target.Venda.Model.Visao;

namespace Target.Venda.IBusiness.IFluxo;

public interface ILiberarPedidoEletronicoBLL : IFluxoBaseBLL
{
	RetornoLiberarPedidoEletronicoVO Executar(ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle);
}
