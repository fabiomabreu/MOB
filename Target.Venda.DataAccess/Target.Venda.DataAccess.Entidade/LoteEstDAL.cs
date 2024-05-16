using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class LoteEstDAL : EntidadeBaseDAL<LoteEstMO>
{
	protected override Expression<Func<LoteEstMO, bool>> GetWhere(Expression<Func<LoteEstMO, bool>> whereClause, LoteEstMO exemplo)
	{
		throw new NotImplementedException();
	}

	public List<LoteEstMO> ObterLotesDisponiveis(int cdEmp, string cdLocal, int cdProd, DateTime? dtValidadeIni, DateTime? dtValidadeFim, bool EscolhaLoteAuto)
	{
		try
		{
			if (!dtValidadeIni.HasValue)
			{
				dtValidadeIni = Convert.ToDateTime("1900-01-01");
			}
			if (!dtValidadeFim.HasValue)
			{
				dtValidadeFim = DateTime.MaxValue;
			}
			string text = "";
			string text2 = "";
			if (EscolhaLoteAuto)
			{
				text = "+ ISNULL(e.qtde, 0)";
				text2 = "\r\n\t\t\t\t\tLEFT JOIN ( SELECT\t\r\n\t\t\t\t\t\t\t\t\tee.qtde,\r\n\t\t\t\t\t\t\t\t\tee.cd_emp,\r\n\t\t\t\t\t\t\t\t\tee.cd_local,\r\n\t\t\t\t\t\t\t\t\tee.cd_prod,\r\n\t\t\t\t\t\t\t\t\tee.seq_lote\r\n\t\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\t\twms_estoque ee\r\n\t\t\t\t\t\t\t\t\tJOIN wms_end w\r\n\t\t\t\t\t\t\t\t\t\tON\tee.cd_emp = w.cd_emp\r\n\t\t\t\t\t\t\t\t\t\tAND\tee.cd_local = w.cd_local\r\n\t\t\t\t\t\t\t\t\t\tAND\tee.seq_wms_end = w.seq_wms_end\r\n\t\t\t\t\t\t\t\t\t\tAND\tw.end_inicial = 1\t) as e\r\n\t\t\t\t\t\t\tON\tl.cd_emp = e.cd_emp\r\n\t\t\t\t\t\t\tAND\tl.cd_local = e.cd_local\r\n\t\t\t\t\t\t\tAND\tl.cd_prod = e.cd_prod\r\n\t\t\t\t\t\t\tAND\tl.seq_lote = e.seq_lote";
			}
			string select = "\r\n                        SELECT \r\n                            l.seq_lote SEQ_LOTE,\r\n                            l.qtde QTDE,\r\n                            (l.qtde_pend_pedv " + text + " ) QTDE_PEND_PEDV,\r\n                            lp.dt_validade DT_VALIDADE_LOTE\r\n                        FROM\r\n                            vi_lote_est l\r\n                            JOIN lote_prd lp\r\n                            ON lp.cd_prod = l.cd_prod\r\n                            AND lp.seq_lote = l.seq_lote\r\n\t\t\t\t\t\t\t" + text2 + "\r\n                        WHERE\r\n                            lp.ativo = 1\r\n                        AND l.cd_emp = {0}\r\n                        AND l.cd_local = {1}\r\n                        AND l.cd_prod = {2}\r\n                        AND l.qtde > 0\r\n                        AND (l.qtde - (l.qtde_pend_pedv" + text + ") ) > 0\r\n                        AND lp.indefinido = 0 \r\n                        AND lp.dt_validade >= {3}\r\n                        AND lp.dt_validade <= {4} \r\n                        ORDER BY lp.dt_validade, \r\n                                 l.seq_lote";
			return ExecutarSelectSQL<LoteEstMO>(select, new object[5] { cdEmp, cdLocal, cdProd, dtValidadeIni, dtValidadeFim });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
