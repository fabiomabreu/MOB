using System;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Target.Venda.Installer.View.Common;

public static class Util
{
	public static void TabShow(TabControl tabControl, TabPage tabPage)
	{
		foreach (TabPage tabPage2 in tabControl.TabPages)
		{
			tabControl.TabPages.Remove(tabPage2);
		}
		tabControl.TabPages.Add(tabPage);
	}

	public static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
	{
		if (!destination.Exists)
		{
			destination.Create();
		}
		FileInfo[] files = source.GetFiles();
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			fileInfo.CopyTo(Path.Combine(destination.FullName, fileInfo.Name));
		}
		DirectoryInfo[] directories = source.GetDirectories();
		DirectoryInfo[] array2 = directories;
		foreach (DirectoryInfo directoryInfo in array2)
		{
			string path = Path.Combine(destination.FullName, directoryInfo.Name);
			CopyDirectory(directoryInfo, new DirectoryInfo(path));
		}
	}

	public static void CopyDirectory(string source, string destination)
	{
		DirectoryInfo source2 = new DirectoryInfo(source);
		DirectoryInfo destination2 = new DirectoryInfo(destination);
		CopyDirectory(source2, destination2);
	}

	public static string BuildStringConnection(string dataSource, string initialCatalog, string userID, string password, bool windowsAuthentication, string ApplicationName)
	{
		return BuildStringConnection(dataSource, initialCatalog, userID, password, null, windowsAuthentication, ApplicationName);
	}

	public static string BuildStringConnection(string dataSource, string initialCatalog, string userID, string password, int? maxPoolSize, bool windowsAuthentication, string ApplicationName)
	{
		if (!maxPoolSize.HasValue || (maxPoolSize.HasValue && maxPoolSize == 0))
		{
			maxPoolSize = 100;
		}
		if (windowsAuthentication)
		{
			return $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security=SSPI; Max Pool Size={maxPoolSize}; MultipleActiveResultSets=True;  timeout= \"300\"; Application Name={ApplicationName}";
		}
		return $"Data Source={dataSource};Initial Catalog={initialCatalog};User Id={userID};Password={password}; Max Pool Size={maxPoolSize}; MultipleActiveResultSets=True; timeout= \"300\"; Application Name={ApplicationName}";
	}

	public static string BuildOdbcConnection(string odbcName, string password)
	{
		return $"DSN={odbcName};Uid=SUPER;Pwd={password}";
	}

	public static bool StringConnectionTest(string stringConnection)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(stringConnection);
			sqlConnection.Open();
			sqlConnection.Close();
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public static bool OdbcConnectionTest(string stringConnection)
	{
		try
		{
			using OdbcConnection odbcConnection = new OdbcConnection(stringConnection);
			odbcConnection.Open();
			odbcConnection.Close();
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public static bool OdbcConnectionValidate(string stringConnection, string targetErpDbName)
	{
		try
		{
			using OdbcConnection odbcConnection = new OdbcConnection(stringConnection);
			odbcConnection.Open();
			OdbcCommand odbcCommand = new OdbcCommand("SELECT db_name()", odbcConnection);
			string strA = (string)odbcCommand.ExecuteScalar();
			odbcConnection.Close();
			if (string.Compare(strA, targetErpDbName, ignoreCase: true) == 0)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static string VerificaConfiguracaoServicos(string stringConnection)
	{
		string result;
		using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
		{
			sqlConnection.Open();
			string cmdText = "SELECT \r\n\t\t\t\t\t\t\t\tEnderecoServidor\r\n\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\tTargetServicos\r\n\t\t\t\t\t\t\tWHERE\r\n\t\t\t\t\t\t\t\tDescricaoServico = 'TargetVendaApi'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			try
			{
				result = (string)sqlCommand.ExecuteScalar();
			}
			catch (Exception)
			{
				result = null;
			}
			sqlConnection.Close();
		}
		return result;
	}

	public static void InsereConfiguracaoServicos(string stringConnection, string enderecoServidor, int portaApi)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnection);
		sqlConnection.Open();
		string cmdText = "UPDATE \r\n\t\t\t\t\t\t\t\tTargetServicos\r\n\t\t\t\t\t\t\tSET\r\n\t\t\t\t\t\t\t\tEnderecoServidor = @Endereco,\r\n\t\t\t\t\t\t\t\tHostnameServidor = @Hostname,\r\n\t\t\t\t\t\t\t\tPortaAPI = @Porta,\r\n\t\t\t\t\t\t\t\tAtivo = 1\r\n\t\t\t\t\t\t\tWHERE \r\n\t\t\t\t\t\t\t\tTargetServicosID = 1";
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		sqlCommand.Parameters.AddWithValue("@Endereco", enderecoServidor);
		sqlCommand.Parameters.AddWithValue("@Hostname", Environment.MachineName.ToUpper());
		sqlCommand.Parameters.AddWithValue("@Porta", portaApi);
		int num = sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
		if (num != 0)
		{
		}
	}

	public static void AtualizaVersaoAPI(string stringConnection)
	{
		string text = "1.2.2.4";
		string value = text.Substring(0, 5);
		string value2 = text.Substring(6);
		using SqlConnection sqlConnection = new SqlConnection(stringConnection);
		sqlConnection.Open();
		string cmdText = "INSERT INTO TargetServicosVersao\r\n                            (\r\n                                    Versao,\r\n                                    Release,\r\n                                    Patch,\r\n                                    TargetServicosID,\r\n                                    DtAtualizacao\r\n                            )\r\n                            VALUES\r\n                            (\r\n                                    @Versao,\r\n                                    @Release,\r\n                                    0,\r\n                                    1,\r\n                                    GETDATE()\r\n                            )   ";
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		sqlCommand.Parameters.AddWithValue("@Versao", value);
		sqlCommand.Parameters.AddWithValue("@Release", value2);
		int num = sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
		if (num != 0)
		{
		}
	}

	public static string VerificaEnderecoIpLocal()
	{
		string empty = string.Empty;
		using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
		socket.Connect("8.8.8.8", 65530);
		IPEndPoint iPEndPoint = socket.LocalEndPoint as IPEndPoint;
		return iPEndPoint.Address.ToString();
	}

	public static bool VerificarDistribuidoraTeste(string stringConnection)
	{
		bool result = false;
		try
		{
			string cmdText = "select distinct isnull(restore_banco_teste, 0) from par_cfg";
			using SqlConnection sqlConnection = new SqlConnection(stringConnection);
			using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlConnection.Open();
			result = Convert.ToBoolean(sqlCommand.ExecuteScalar());
			sqlConnection.Close();
		}
		catch (Exception)
		{
			return result;
		}
		return result;
	}

	public static void CreateDatabase(string stringConnection, string dbName)
	{
		string format = "  --Obtem diretório padrão de criação dos scripts\r\n                                    DECLARE @SmoDefaultFile NVARCHAR(512)\r\n                                    EXEC MASTER.DBO.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer', N'DefaultData', @SmoDefaultFile OUTPUT\r\n\r\n                                    DECLARE @SmoDefaultLog NVARCHAR(512)\r\n                                    EXEC MASTER.DBO.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer', N'DefaultLog', @SmoDefaultLog OUTPUT\r\n \r\n                                    --Cria banco de dados\r\n                                    EXEC('\tCREATE DATABASE [{0}] ON PRIMARY \r\n\t\t                                    (\t\r\n\t\t\t                                    NAME = N''{0}'',\r\n\t\t\t                                    FILENAME = N''' + @SmoDefaultFile + '\\{0}.mdf'',\r\n\t\t\t                                    SIZE = 5GB,\r\n\t\t\t                                    MAXSIZE = UNLIMITED,\r\n\t\t\t                                    FILEGROWTH = 20%\r\n\t\t                                    )\r\n\t\t                                    LOG ON\r\n\t\t                                    (\t\r\n\t\t\t                                    NAME = N''{0}_Log'',\r\n\t\t\t                                    FILENAME = N''' + @SmoDefaultLog + '\\{0}_Log.ldf'',\r\n\t\t\t                                    SIZE = 200MB ,\r\n\t\t\t                                    MAXSIZE = UNLIMITED,\r\n\t\t\t                                    FILEGROWTH = 20%\r\n\t\t                                    )'\t)\r\n\r\n\r\n                                    --Seta o recovery mode\t\t\r\n                                    ALTER DATABASE [{0}] SET RECOVERY SIMPLE";
		using SqlConnection sqlConnection = new SqlConnection(stringConnection);
		using SqlCommand sqlCommand = new SqlCommand(string.Format(format, dbName.Trim()), sqlConnection);
		sqlConnection.Open();
		sqlCommand.CommandTimeout = 0;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	public static bool DatabaseExists(string stringConnection, string dbName)
	{
		int num = 0;
		using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
		{
			using SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE upper(name) = upper(@DbName)", sqlConnection);
			sqlConnection.Open();
			sqlCommand.Parameters.AddWithValue("@DbName", dbName);
			num = (int)sqlCommand.ExecuteScalar();
			sqlConnection.Close();
		}
		return num == 1;
	}

	public static string GetDefaultPassword(string stringConnection)
	{
		string result;
		using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
		{
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand("SELECT TOP 1 senha_sql_novo_usuario FROM par_cfg", sqlConnection);
			result = (string)sqlCommand.ExecuteScalar();
			sqlConnection.Close();
		}
		return result;
	}

	public static void BackupDatabase(string stringConnection, string dbName, string pathDestination)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnection);
		using SqlCommand sqlCommand = new SqlCommand($"BACKUP DATABASE [{dbName}] TO  DISK = N'{pathDestination}' WITH  INIT ,  NOUNLOAD ,  NAME = N'Backup_TargetEDI',  NOSKIP ,  STATS = 10,  DESCRIPTION = N'Backup_TargetEDI',  NOFORMAT", sqlConnection);
		sqlConnection.Open();
		sqlCommand.CommandTimeout = 0;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	public static bool LinkedServerExists(string stringConnection, string serverName)
	{
		int num = 0;
		using (SqlConnection sqlConnection = new SqlConnection(stringConnection))
		{
			using SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM sys.servers WHERE name = @DbName AND is_linked = 1", sqlConnection);
			sqlConnection.Open();
			sqlCommand.Parameters.AddWithValue("@DbName", serverName);
			num = (int)sqlCommand.ExecuteScalar();
			sqlConnection.Close();
		}
		return num == 1;
	}
}
