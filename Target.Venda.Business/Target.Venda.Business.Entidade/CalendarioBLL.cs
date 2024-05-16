using System;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class CalendarioBLL : EntidadeBaseBLL<CalendarioMO>
{
	protected override EntidadeBaseDAL<CalendarioMO> GetInstanceDAL()
	{
		return new CalendarioDAL();
	}

	public DateTime ObterProximoDiaUltil(int cdEmpresa, DateTime dataPrimeiroVencimento)
	{
		return (BaseDAL as CalendarioDAL).ObterProximoDiaUltil(cdEmpresa, dataPrimeiroVencimento);
	}

	public int CalculaQuantidadeDias(DateTime dataInicial, DateTime dataFinal, bool somenteDiasUteis, int cdEmpresa)
	{
		return (BaseDAL as CalendarioDAL).CalculaQuantidadeDias(dataInicial, dataFinal, somenteDiasUteis, cdEmpresa);
	}
}
