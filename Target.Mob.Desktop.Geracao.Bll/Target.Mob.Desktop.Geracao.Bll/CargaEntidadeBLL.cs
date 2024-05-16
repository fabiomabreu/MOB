using Target.Mob.Desktop.Geracao.Dal;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaEntidadeBLL
{
	public static string[] SelectDadosVendedor(string stringConnTargetErp, string codigoVendedor, string idCargaEntidade)
	{
		return CargaEntidadeDAL.SelectDadosVendedor(stringConnTargetErp, codigoVendedor, idCargaEntidade);
	}
}
