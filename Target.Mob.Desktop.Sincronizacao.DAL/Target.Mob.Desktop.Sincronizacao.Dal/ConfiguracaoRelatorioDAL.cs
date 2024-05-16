using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class ConfiguracaoRelatorioDAL
{
	private const string INSERT = "uspConfiguracaoRelatorioIns";

	private const string UPDATE = "uspConfiguracaoRelatorioUpd";

	private const string DELETE = "uspConfiguracaoRelatorioDel";

	private const string SELECT = "uspConfiguracaoRelatorioSel";

	private const string EXISTS = "";

	private const string COUNT = "";

	public static void Insert(DbConnection connection, ConfiguracaoRelatorioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Diretorio", instance.Diretorio);
		connection.AddParameters("@TamanhoMaximo", instance.TamanhoMaximo);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspConfiguracaoRelatorioIns");
		instance.IDConfiguracaoRelatorio = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, ConfiguracaoRelatorioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDConfiguracaoRelatorio", instance.IDConfiguracaoRelatorio);
		connection.AddParameters("@Diretorio", instance.Diretorio);
		connection.AddParameters("@TamanhoMaximo", instance.TamanhoMaximo);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspConfiguracaoRelatorioUpd");
	}

	public static void Delete(DbConnection connection, ConfiguracaoRelatorioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDConfiguracaoRelatorio", instance.IDConfiguracaoRelatorio);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspConfiguracaoRelatorioDel");
	}

	public static ConfiguracaoRelatorioTO[] Select(DbConnection connection, ConfiguracaoRelatorioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDConfiguracaoRelatorio", instance.IDConfiguracaoRelatorio);
		connection.AddParameters("@Diretorio", instance.Diretorio);
		connection.AddParameters("@TamanhoMaximo", instance.TamanhoMaximo);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspConfiguracaoRelatorioSel"));
	}

	public static int Count(DbConnection connection, int? IDConfiguracaoRelatorio, string Diretorio, int? TamanhoMaximo)
	{
		connection.ClearParameters();
		connection.AddParameters("@IDConfiguracaoRelatorio", IDConfiguracaoRelatorio);
		connection.AddParameters("@Diretorio", Diretorio);
		connection.AddParameters("@TamanhoMaximo", TamanhoMaximo);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, ""));
	}

	private static ConfiguracaoRelatorioTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ConfiguracaoRelatorioTO configuracaoRelatorioTO = new ConfiguracaoRelatorioTO();
				configuracaoRelatorioTO.IDConfiguracaoRelatorio = rs.GetInteger("IDConfiguracaoRelatorio");
				configuracaoRelatorioTO.Diretorio = rs.GetString("Diretorio");
				configuracaoRelatorioTO.TamanhoMaximo = rs.GetInteger("TamanhoMaximo");
				arrayList.Add(configuracaoRelatorioTO);
			}
		}
		return (ConfiguracaoRelatorioTO[])arrayList.ToArray(typeof(ConfiguracaoRelatorioTO));
	}
}
