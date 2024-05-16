using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class EquipeDAL
{
	private const string SELECT = "uspEquipeSelect";

	public static EquipeTO[] Select(DbConnection connection, string CdEquipe, string Descricao, string CdVendSup, bool? Ativo, string CdGerencia, byte[] RowId, int? CodigoEmpresa)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_equipe", CdEquipe);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@cd_vend_sup", CdVendSup);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@cd_gerencia", CdGerencia);
		connection.AddParameters("@rowid", RowId);
		connection.AddParameters("@CodigoEmpresa", CodigoEmpresa);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEquipeSelect"));
	}

	private static EquipeTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				EquipeTO equipeTO = new EquipeTO();
				equipeTO.CdEquipe = rs.GetString("cd_equipe");
				equipeTO.Descricao = rs.GetString("descricao");
				equipeTO.CdVendSup = rs.GetString("cd_vend_sup");
				equipeTO.Ativo = rs.GetNullableBoolean("ativo");
				equipeTO.CdGerencia = rs.GetString("cd_gerencia");
				equipeTO.RowId = rs.GetArrayByte("rowid");
				equipeTO.CodigoEmpresa = rs.GetNullableInteger("CodigoEmpresa");
				arrayList.Add(equipeTO);
			}
		}
		return (EquipeTO[])arrayList.ToArray(typeof(EquipeTO));
	}
}
