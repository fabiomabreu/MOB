using System;
using System.Globalization;
using Target.Venda.Helpers.Dao;
using Target.Venda.Helpers.Log;

namespace Target.Venda.Helpers.Geral;

public static class DateTimeHelper
{
	private static object _lock = new object();

	public static int ObterQuantidadeDiasUteis(DateTime initialDate, DateTime finalDate)
	{
		int num = 0;
		int num2 = 0;
		num = initialDate.Subtract(finalDate).Days;
		if (num < 0)
		{
			num *= -1;
		}
		for (int i = 1; i <= num; i++)
		{
			initialDate = initialDate.AddDays(1.0);
			if (initialDate.DayOfWeek != 0 && initialDate.DayOfWeek != DayOfWeek.Saturday)
			{
				num2++;
			}
		}
		if (num2 == 0)
		{
			num2 = 1;
		}
		return num2;
	}

	public static string ObterDiaSemanaPelaData(DateTime data, bool abreviada)
	{
		DayOfWeek dayOfWeek = data.DayOfWeek;
		string empty = string.Empty;
		empty = ((!abreviada) ? new CultureInfo("pt-BR").DateTimeFormat.GetDayName(dayOfWeek) : new CultureInfo("pt-BR").DateTimeFormat.GetAbbreviatedDayName(dayOfWeek));
		return StringHelper.RemoverAcentos(empty);
	}

	public static DateTime ObterDataHoraAtualBancoDados(TipoDateTime tipo = TipoDateTime.DataHoraSegundo)
	{
		try
		{
			lock (_lock)
			{
				DateTime minValue = DateTime.MinValue;
				string cmdText = "SELECT GETDATE() as DATA_ATUAL;";
				DateTime dataAtual = SqlServerHelper.executeScalar<DateTime>(cmdText);
				return FormartarDataPeloTipo(dataAtual, tipo);
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static DateTime FormartarDataPeloTipo(DateTime dataAtual, TipoDateTime tipo)
	{
		switch (tipo)
		{
		case TipoDateTime.DataHoraSegundo:
			dataAtual = new DateTime(dataAtual.Year, dataAtual.Month, dataAtual.Day, dataAtual.Hour, dataAtual.Minute, dataAtual.Second);
			break;
		case TipoDateTime.Data:
			dataAtual = new DateTime(dataAtual.Year, dataAtual.Month, dataAtual.Day, 0, 0, 0);
			break;
		case TipoDateTime.DataHora:
			dataAtual = new DateTime(dataAtual.Year, dataAtual.Month, dataAtual.Day, dataAtual.Hour, dataAtual.Minute, 0);
			break;
		}
		return dataAtual;
	}
}
