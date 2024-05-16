using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaBLL
{
	public static List<CargaTO> Select(SqlConnection conexao, CargaTO carga)
	{
		return CargaDAL.Select(conexao, carga);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, CargaTO carga)
	{
		return CargaDAL.SelectDR(conexao, carga);
	}

	public static List<CargaTO> SelectSemArquivo(SqlConnection conexao, CargaTO carga)
	{
		return CargaDAL.SelectSemArquivo(conexao, carga);
	}

	public static DataTable SelectDT(SqlConnection conexao, CargaTO carga)
	{
		return CargaDAL.SelectDT(conexao, carga);
	}

	public static void Insert(SqlConnection conexao, CargaTO carga)
	{
		string mensagemErro = string.Empty;
		if (Validate(carga, out mensagemErro))
		{
			CargaDAL.Insert(conexao, carga);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Insert(SqlConnection conexao, SqlTransaction transaction, CargaTO carga)
	{
		string mensagemErro = string.Empty;
		if (Validate(carga, out mensagemErro))
		{
			CargaDAL.Insert(conexao, transaction, carga);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Update(SqlConnection conexao, CargaTO carga)
	{
		string mensagemErro = string.Empty;
		if (Validate(carga, out mensagemErro))
		{
			CargaDAL.Update(conexao, carga);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Delete(SqlConnection conexao, CargaTO carga)
	{
		CargaDAL.Delete(conexao, carga);
	}

	public static bool Exists(SqlConnection conexao, CargaTO carga)
	{
		return CargaDAL.Exists(conexao, carga);
	}

	public static bool ExistsCompleta(SqlConnection conexao, int? idVendedor, int? major, int? minor, int? build, int? revision)
	{
		return CargaDAL.ExistsCompleta(conexao, idVendedor, major, minor, build, revision);
	}

	public static void SetTransmitido(SqlConnection conexao, int? id)
	{
		CargaDAL.SetTransmitido(conexao, id);
	}

	private static bool Validate(CargaTO carga, out string mensagemErro)
	{
		mensagemErro = string.Empty;
		if (!carga.DataGeracao.HasValue)
		{
			mensagemErro = "Data de Geração Inválida!";
			return false;
		}
		return true;
	}

	public static List<CargaTO> SelectEnvio(SqlConnection sqlConnection, int? IdVendedor)
	{
		return CargaDAL.SelectEnvio(sqlConnection, IdVendedor);
	}

	public static void SelectMonitoramento(SqlConnection sqlConnection, ref int? CargaPendEnvioQtde, ref DateTime? CargaPendEnvioMaisAntigo)
	{
		CargaDAL.SelectMonitoramento(sqlConnection, ref CargaPendEnvioQtde, ref CargaPendEnvioMaisAntigo);
	}
}
