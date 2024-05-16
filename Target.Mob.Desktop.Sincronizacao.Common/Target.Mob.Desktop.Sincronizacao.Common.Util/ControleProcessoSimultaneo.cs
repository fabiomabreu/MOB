using System;
using System.Data;
using Target.Mob.Common.Seguranca;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public class ControleProcessoSimultaneo : IDisposable
{
	private const string INSERT = "tgtmob_uspControleProcessoSimultaneoInsert";

	private const string COUNT = "tgtmob_uspControleProcessoSimultaneoCount";

	private string _NomeProcesso;

	private DbConnection _DbConnection;

	private bool _Disposed;

	public ControleProcessoSimultaneo(string stringConnection, string nomeProcesso)
	{
		_NomeProcesso = nomeProcesso;
		_DbConnection = new DbConnection(stringConnection);
	}

	public void IniciaProcesso()
	{
		_DbConnection.Open();
		_DbConnection.BeginTransaction();
		_DbConnection.ClearParameters();
		_DbConnection.AddParameters("@NomeProcesso", _NomeProcesso);
		_DbConnection.AddParameters("@NomeMaquina", Seguranca.getHostName());
		_DbConnection.ExecuteNonQuery(CommandType.StoredProcedure, "tgtmob_uspControleProcessoSimultaneoInsert");
		_DbConnection.ClearParameters();
		_DbConnection.AddParameters("@NomeProcesso", _NomeProcesso);
		if (Convert.ToInt32(_DbConnection.ExecuteScalar(CommandType.StoredProcedure, "tgtmob_uspControleProcessoSimultaneoCount")) > 1)
		{
			EncerraProcesso();
			throw new Exception($"O processso {_NomeProcesso} já está em execução");
		}
	}

	public void EncerraProcesso()
	{
		try
		{
			_DbConnection.RollbackTransaction();
			_DbConnection.Close();
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
			if (disposing && _DbConnection != null)
			{
				EncerraProcesso();
				_DbConnection.Dispose();
			}
			_Disposed = true;
		}
	}

	~ControleProcessoSimultaneo()
	{
		Dispose(disposing: false);
	}
}
