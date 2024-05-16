using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Target.Venda.Helpers.Seguranca;

namespace Target.Venda.Helpers.ProcessoSimultaneo;

public class ControleProcessoSimultaneo : IDisposable
{
	private const string INSERT = "TgtEdi_uspControleProcessoSimultaneoInsert";

	private const string COUNT = "TgtEdi_uspControleProcessoSimultaneoCount";

	private string _NomeProcesso;

	private DbConnection _ConnTargetERP;

	private bool _Disposed = false;

	public ControleProcessoSimultaneo(string nomeProcesso)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(directoryName + "\\Target.EDI.Servico.Principal.exe");
			ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
			_NomeProcesso = nomeProcesso;
			string text = connectionStringsSection.ConnectionStrings["DATABASE"].ConnectionString;
			string text2 = CriptografiaHelper.Descriptografar_ConnectionString(text);
			if (!string.IsNullOrEmpty(text2))
			{
				text = text2;
			}
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(text);
			text2 = CriptografiaHelper.Descriptografar_ConnectionString(sqlConnectionStringBuilder.Password);
			if (!string.IsNullOrEmpty(text2))
			{
				sqlConnectionStringBuilder.Password = text2;
			}
			text = sqlConnectionStringBuilder.ToString().Replace("\"", "");
			_ConnTargetERP = new DbConnection(text);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void IniciaProcesso()
	{
		_ConnTargetERP.Open();
		_ConnTargetERP.BeginTransaction();
		_ConnTargetERP.ClearParameters();
		_ConnTargetERP.AddParameters("@NomeProcesso", _NomeProcesso);
		_ConnTargetERP.AddParameters("@NomeMaquina", Environment.MachineName);
		_ConnTargetERP.ExecuteNonQuery(CommandType.StoredProcedure, "TgtEdi_uspControleProcessoSimultaneoInsert");
		_ConnTargetERP.ClearParameters();
		_ConnTargetERP.AddParameters("@NomeProcesso", _NomeProcesso);
		object value = _ConnTargetERP.ExecuteScalar(CommandType.StoredProcedure, "TgtEdi_uspControleProcessoSimultaneoCount");
		if (Convert.ToInt32(value) > 1)
		{
			EncerraProcesso();
			throw new Exception($"O processso {_NomeProcesso} já está em execução");
		}
	}

	public void EncerraProcesso()
	{
		try
		{
			_ConnTargetERP.RollbackTransaction();
			_ConnTargetERP.Close();
		}
		catch (Exception)
		{
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Dispose(bool disposing)
	{
		if (!_Disposed)
		{
			if (disposing && _ConnTargetERP != null)
			{
				EncerraProcesso();
				_ConnTargetERP.Dispose();
			}
			_Disposed = true;
		}
	}

	~ControleProcessoSimultaneo()
	{
		Dispose(disposing: false);
	}
}
