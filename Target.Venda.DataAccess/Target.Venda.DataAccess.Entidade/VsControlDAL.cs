using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class VsControlDAL : EntidadeBaseDAL<VsControlMO>
{
	protected override Expression<Func<VsControlMO, bool>> GetWhere(Expression<Func<VsControlMO, bool>> whereClause, VsControlMO exemplo)
	{
		if (exemplo.OCORRENCIA > 0)
		{
			whereClause = whereClause.And((VsControlMO x) => x.OCORRENCIA == exemplo.OCORRENCIA);
		}
		if (exemplo.SEQ > 0)
		{
			whereClause = whereClause.And((VsControlMO x) => x.SEQ == exemplo.SEQ);
		}
		return whereClause;
	}

	public bool BuscaVsControl(int Ocorrencia, int Seq)
	{
		string select = "\r\n\t\t\tSELECT\tCAST(1 AS BIT)\r\n\t\t\tFROM\tVsControl\r\n\t\t\tWHERE\tOcorrencia = {0}\r\n\t\t\tAND\t\tSeq = {1}";
		if (!ExecutarScalarSQL<bool?>(select, new object[2] { Ocorrencia, Seq }).HasValue)
		{
			return false;
		}
		return true;
	}
}
