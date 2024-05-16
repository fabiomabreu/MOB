using Target.Venda.IBusiness.Base;

namespace Target.Venda.IBusiness.IModulo;

public interface IModuloContabilBLL : IModuloBaseBLL
{
	void ValidarParametrosMargemBruta();
}
