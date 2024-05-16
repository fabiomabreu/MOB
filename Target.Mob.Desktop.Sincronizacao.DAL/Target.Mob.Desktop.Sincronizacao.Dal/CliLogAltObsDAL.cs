using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class CliLogAltObsDAL
{
	private const string INSERT = "uspCliLogAltObsInsert";

	private const string UPDATE = "uspCliLogAltObsUpdate";

	private const string DELETE = "uspCliLogAltObsDelete";

	private const string SELECT = "uspCliLogAltObsSelect";

	private const string EXISTS = "uspCliLogAltObsExists";

	public static void Insert(DbConnection connection, CliLogAltObsTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.AddParameters("@tipo_obs", instance.RetornaTipoObs());
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliLogAltObsInsert");
	}

	public static void Update(DbConnection connection, CliLogAltObsTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.AddParameters("@tipo_obs", instance.RetornaTipoObs());
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCliLogAltObsUpdate");
	}

	public static void Delete(DbConnection connection, CliLogAltObsTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCliLogAltObsDelete");
	}

	public static CliLogAltObsTO[] Select(DbConnection connection, int? CdClien)
	{
		return Select(connection, CdClien, null, null);
	}

	public static CliLogAltObsTO[] Select(DbConnection connection, int? CdClien, int? CdTexto)
	{
		return Select(connection, CdClien, CdTexto, null);
	}

	public static CliLogAltObsTO[] Select(DbConnection connection, int? CdClien, int? CdTexto, string TipoObs)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_texto", CdTexto);
		connection.AddParameters("@tipo_obs", TipoObs);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCliLogAltObsSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdClien, int? CdTexto, string TipoObs)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_texto", CdTexto);
		connection.AddParameters("@tipo_obs", TipoObs);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliLogAltObsExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static CliLogAltObsTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CliLogAltObsTO cliLogAltObsTO = new CliLogAltObsTO();
				cliLogAltObsTO.CdClien = rs.GetInteger("cd_clien");
				cliLogAltObsTO.CdTexto = rs.GetInteger("cd_texto");
				switch (rs.GetString("tipo_obs"))
				{
				case "EQUIFAX":
					cliLogAltObsTO.TipoObs = TipoObsCliLog.Equifax;
					break;
				case "EXPEDICAO":
					cliLogAltObsTO.TipoObs = TipoObsCliLog.Expedicao;
					break;
				case "NF":
					cliLogAltObsTO.TipoObs = TipoObsCliLog.NF;
					break;
				case "CREDITO":
					cliLogAltObsTO.TipoObs = TipoObsCliLog.Credito;
					break;
				case "ALERTA":
					cliLogAltObsTO.TipoObs = TipoObsCliLog.Alerta;
					break;
				case "GERAL":
					cliLogAltObsTO.TipoObs = TipoObsCliLog.Geral;
					break;
				default:
					cliLogAltObsTO.TipoObs = TipoObsCliLog.Geral;
					break;
				}
				arrayList.Add(cliLogAltObsTO);
			}
		}
		return (CliLogAltObsTO[])arrayList.ToArray(typeof(CliLogAltObsTO));
	}
}
