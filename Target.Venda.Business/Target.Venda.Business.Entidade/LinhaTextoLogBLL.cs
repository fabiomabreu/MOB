using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class LinhaTextoLogBLL : EntidadeBaseBLL<LinhaTextoLogMO>
{
	protected override EntidadeBaseDAL<LinhaTextoLogMO> GetInstanceDAL()
	{
		return new LinhaTextoLogDAL();
	}
}
