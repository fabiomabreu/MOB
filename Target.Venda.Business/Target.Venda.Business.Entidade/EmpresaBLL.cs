using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EmpresaBLL : EntidadeBaseBLL<EmpresaMO>
{
	protected override EntidadeBaseDAL<EmpresaMO> GetInstanceDAL()
	{
		return new EmpresaDAL();
	}

	public bool ValidarCodigoEmpresa(int codigoEmpresa)
	{
		return (BaseDAL as EmpresaDAL).ValidarCodigoEmpresa(codigoEmpresa);
	}

	public void ValidarEndereco(EmpresaMO empresa)
	{
		if (string.IsNullOrEmpty(empresa.LOGRADOURO) || string.IsNullOrEmpty(empresa.NUMERO) || string.IsNullOrEmpty(empresa.CODIGO_PAIS))
		{
			throw new MyException("O endereço da empresa, está desatualizado. Os campos Logradouro, Número e País devem estar preenchidos");
		}
	}
}
