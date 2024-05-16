using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class CargaControleEntidadeDAL
{
	private const string SELECT = "tgtmob_uspCargaControleEntidade_Select";

	private string _connStringTargetERP;

	public CargaControleEntidadeDAL(string connStringTargetERP)
	{
		_connStringTargetERP = connStringTargetERP;
	}

	public static List<CargaControleEntidadeTO> Select(string connStringTargetERP)
	{
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		List<CargaControleEntidadeTO> result = new List<CargaControleEntidadeTO>();
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaControleEntidade_Select", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			result = CreateInstance(sqlCommand.ExecuteReader());
		}
		sqlConnection.Close();
		return result;
	}

	private static List<CargaControleEntidadeTO> CreateInstance(SqlDataReader dr)
	{
		List<CargaControleEntidadeTO> list = new List<CargaControleEntidadeTO>();
		while (dr.Read())
		{
			CargaControleEntidadeTO cargaControleEntidadeTO = new CargaControleEntidadeTO();
			cargaControleEntidadeTO.idCargaControleEntidade = GetDataReader.GetInt32(dr, "idCargaControleEntidade");
			cargaControleEntidadeTO.entidadeNome = GetDataReader.GetString(dr, "entidadeNome");
			cargaControleEntidadeTO.entidadeTipoRestricao = GetDataReader.GetBoolean(dr, "entidadeTipoRestricao");
			cargaControleEntidadeTO.commandSqlOnda = GetDataReader.GetInt32(dr, "commandSqlOnda");
			cargaControleEntidadeTO.commandSqlEntidadeRestricaoNomeVendedor = GetDataReader.GetString(dr, "commandSqlEntidadeRestricaoNomeVendedor");
			cargaControleEntidadeTO.commandSqlEntidadeRestricaoNomePromotor = GetDataReader.GetString(dr, "commandSqlEntidadeRestricaoNomePromotor");
			cargaControleEntidadeTO.commandSqlEntidadeRestricaoNomeSupervisor = GetDataReader.GetString(dr, "commandSqlEntidadeRestricaoNomeSupervisor");
			cargaControleEntidadeTO.commandSqlEntidadeRestricaoColumn = GetDataReader.GetString(dr, "commandSqlEntidadeRestricaoColumn");
			cargaControleEntidadeTO.commandSqlColumnKey = GetDataReader.GetString(dr, "commandSqlColumnKey");
			cargaControleEntidadeTO.commandSqlQuery = GetDataReader.GetString(dr, "commandSqlQuery");
			cargaControleEntidadeTO.commandSqlTabelasUtilizadas = GetDataReader.GetString(dr, "commandSqlTabelasUtilizadas");
			cargaControleEntidadeTO.commandSqlColumnDados = GetDataReader.GetString(dr, "commandSqlColumnDados");
			cargaControleEntidadeTO.ativo = GetDataReader.GetBoolean(dr, "ativo");
			cargaControleEntidadeTO.rowid = GetDataReader.GetByteArray(dr, "rowid");
			cargaControleEntidadeTO.ultimaExecucaoTempoMs = GetDataReader.GetInt32(dr, "ultimaExecucaoTempoMs");
			cargaControleEntidadeTO.tipoSistema = GetDataReader.GetString(dr, "tipoSistema");
			list.Add(cargaControleEntidadeTO);
		}
		return list;
	}

	public void ExecSqlProc(string sqlProcName)
	{
		using SqlConnection sqlConnection = new SqlConnection(_connStringTargetERP);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand(sqlProcName, sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.CommandTimeout = 5400;
			sqlCommand.Parameters.Clear();
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}
}
