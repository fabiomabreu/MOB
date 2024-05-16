using Target.Venda.Model.Base.Delegate;

namespace Target.Venda.IBusiness.Base;

public interface IFluxoBaseBLL
{
	event RetornoMensagensHandler EventRetornoMensagem;
}
