using System;
using Target.Venda.Business.Entidade;

namespace Target.Venda.Business.Helpers;

public static class CalendarioERP
{
	public static DateTime SomaDiasUteis(int codEmpresa, DateTime dataBase, int qtdeDias)
	{
		DateTime dateTime = default(DateTime);
		int num = 0;
		int num2 = 0;
		do
		{
			dateTime = dataBase.AddDays(qtdeDias + num);
			num2 = qtdeDias + num;
			CalendarioBLL calendarioBLL = new CalendarioBLL();
			num = calendarioBLL.CalculaQuantidadeDias(dataBase, dateTime, somenteDiasUteis: false, codEmpresa);
		}
		while (num2 - num != qtdeDias);
		return dateTime;
	}

	public static DateTime BuscaProximoDiaUtil(int cdEmpresa, DateTime dataPrimeiroVencimento)
	{
		dataPrimeiroVencimento = new DateTime(dataPrimeiroVencimento.Year, dataPrimeiroVencimento.Month, dataPrimeiroVencimento.Day);
		CalendarioBLL calendarioBLL = new CalendarioBLL();
		return calendarioBLL.ObterProximoDiaUltil(cdEmpresa, dataPrimeiroVencimento);
	}
}
