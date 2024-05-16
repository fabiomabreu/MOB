using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class UsuarioBLL : EntidadeBaseBLL<UsuarioMO>
{
	protected override EntidadeBaseDAL<UsuarioMO> GetInstanceDAL()
	{
		return new UsuarioDAL();
	}

	public bool ValidarCodigoUsuario(string codigoUsuario)
	{
		return (BaseDAL as UsuarioDAL).ValidarCodigoUsuario(codigoUsuario);
	}
}
