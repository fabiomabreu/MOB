using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class RegTransDAL : EntidadeBaseDAL<RegTransMO>
{
	protected override Expression<Func<RegTransMO, bool>> GetWhere(Expression<Func<RegTransMO, bool>> whereClause, RegTransMO exemplo)
	{
		throw new NotImplementedException();
	}

	public RegTransMO ObterRegTransPeloCep(int codigoFornecedor, int cep)
	{
		try
		{
			string select = " SELECT   cd_forn, seq_reg\r\n                                     FROM regtrans a\r\n                                     WHERE isnull(ativo,0) = 1\r\n                                     AND   cd_forn = {0}\r\n                                     AND   cep_de >= {1}\r\n                                     AND   cep_ate <= {1} ";
			RegTransMO regTransMO = ExecutarScalarSQL<RegTransMO>(select, new object[2] { codigoFornecedor, cep });
			return ObterPeloID(regTransMO.CODIGO_FORNECEDOR, regTransMO.SEQ_REG);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public decimal? ObterValorFretePeloRegTransPeso(decimal seqReg, int codigoFornecedor, decimal pesoTotal)
	{
		try
		{
			string select = " SELECT valor\r\n\t\t\t\t                     FROM regtrans_peso\r\n\t\t\t\t                    WHERE seq_reg = {0}\r\n                                      AND cd_forn = {1}\r\n\t\t\t\t                      AND {2} BETWEEN peso_inicial AND peso_final ";
			return ExecutarScalarSQL<decimal?>(select, new object[3] { seqReg, codigoFornecedor, pesoTotal });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}
}
