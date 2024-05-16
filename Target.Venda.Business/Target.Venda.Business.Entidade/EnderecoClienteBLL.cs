using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EnderecoClienteBLL : EntidadeBaseBLL<EnderecoClienteMO>
{
	protected override EntidadeBaseDAL<EnderecoClienteMO> GetInstanceDAL()
	{
		return new EnderecoClienteDAL();
	}
}
