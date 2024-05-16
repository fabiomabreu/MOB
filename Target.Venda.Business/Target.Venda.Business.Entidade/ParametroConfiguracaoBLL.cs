using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class ParametroConfiguracaoBLL : EntidadeBaseBLL<ParametroConfiguracaoMO>
{
	protected override EntidadeBaseDAL<ParametroConfiguracaoMO> GetInstanceDAL()
	{
		return new ParametroConfiguracaoDAL();
	}

	public ConfiguracaoVO ObterParametroConfiguracao(int codigoEmpresa)
	{
		ParametroConfiguracaoDAL parametroConfiguracaoDAL = BaseDAL as ParametroConfiguracaoDAL;
		return parametroConfiguracaoDAL.ObterParametroConfiguracao(codigoEmpresa);
	}
}
