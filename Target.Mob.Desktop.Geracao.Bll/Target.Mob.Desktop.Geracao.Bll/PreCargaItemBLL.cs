using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Bll;

public class PreCargaItemBLL
{
	private string _NomeProcedure;

	public string NomeProcedure
	{
		get
		{
			return _NomeProcedure;
		}
		set
		{
			_NomeProcedure = value;
		}
	}

	public PreCargaItemBLL(string nomeProcedure)
	{
		NomeProcedure = nomeProcedure;
	}

	public void Gera(object eventosAtivos)
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_PreCarga_CarregaDados, NomeProcedure, new VendedorTO());
		try
		{
			geracaoItemBLL.Inicia();
			using (SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob))
			{
				using SqlCommand sqlCommand = new SqlCommand(NomeProcedure, sqlConnection);
				sqlConnection.Open();
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 0;
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("PreCargaItemBLL", "Gera", ex.Message);
		}
		finally
		{
			((CountdownEvent)eventosAtivos).Signal();
		}
	}
}
