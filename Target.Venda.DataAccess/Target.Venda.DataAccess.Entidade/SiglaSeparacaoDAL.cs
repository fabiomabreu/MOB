using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class SiglaSeparacaoDAL : EntidadeBaseDAL<SiglaSeparacaoMO>
{
	protected override Expression<Func<SiglaSeparacaoMO, bool>> GetWhere(Expression<Func<SiglaSeparacaoMO, bool>> whereClause, SiglaSeparacaoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public SiglaSeparacaoMO ObtemSiglaSeparacao(int numeroPedidoVenda)
	{
		SiglaSeparacaoMO siglaSeparacaoMO = new SiglaSeparacaoMO();
		string select = " SELECT \r\n                                seq SEQ,\r\n                                sigla_separacao SIGLA_SEPARACAO\r\n                            FROM  sigla_separacao\r\n                            WHERE seq = ( " + numeroPedidoVenda + " %\r\n                            ( SELECT COUNT(*)\r\n                              FROM sigla_separacao) ) + 1 ";
		siglaSeparacaoMO = ExecutarScalarSQL<SiglaSeparacaoMO>(select, Array.Empty<object>());
		if (siglaSeparacaoMO == null || string.IsNullOrEmpty(siglaSeparacaoMO.SIGLA_SEPARACAO))
		{
			select = " SELECT \r\n                                seq SEQ,\r\n                                sigla_separacao SIGLA_SEPARACAO\r\n                         FROM sigla_separacao\r\n                         WHERE seq = ( SELECT MIN( s.seq )\r\n                                       FROM sigla_separacao s ) ";
			siglaSeparacaoMO = ExecutarScalarSQL<SiglaSeparacaoMO>(select, Array.Empty<object>());
		}
		return siglaSeparacaoMO;
	}
}
