using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class RamoAtividadeTipoDocumentoDAL : EntidadeBaseDAL<RamoAtividadeTipoDocumentoMO>
{
	protected override Expression<Func<RamoAtividadeTipoDocumentoMO, bool>> GetWhere(Expression<Func<RamoAtividadeTipoDocumentoMO, bool>> whereClause, RamoAtividadeTipoDocumentoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
