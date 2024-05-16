using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Target.Mob.Desktop.Geracao.Bll;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Installer.ERP.View.Common;

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
		foreach (FileInfo fileInfo in files)
		{
			fileInfo.CopyTo(Path.Combine(destination.FullName, fileInfo.Name));
		}
		DirectoryInfo[] directories = source.GetDirectories();
		foreach (DirectoryInfo directoryInfo in directories)
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
		return true;
	}

	public static bool OdbcConnectionValidate(string stringConnection, string targetErpDbName)
	{
		return true;
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
		using SqlConnection sqlConnection = new SqlConnection(stringConnection);
		sqlConnection.Open();
		string result = (string)new SqlCommand("SELECT TOP 1 senha_sql_novo_usuario FROM par_cfg", sqlConnection).ExecuteScalar();
		sqlConnection.Close();
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
			sqlCommand.Parameters.AddWithValue("@DbName", serverName.Replace("[", "").Replace("]", ""));
			num = (int)sqlCommand.ExecuteScalar();
			sqlConnection.Close();
		}
		return num == 1;
	}

	public static void UpdateTemplateSQLite(string stringConnection, string dbPath, int idVersaoCarga)
	{
		ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLiteTO = new ConfiguracaoTemplateSQLiteTO();
		configuracaoTemplateSQLiteTO.IdVersaoCarga = idVersaoCarga;
		configuracaoTemplateSQLiteTO.Template = File.ReadAllBytes(dbPath);
		using SqlConnection sqlConnection = new SqlConnection(stringConnection);
		sqlConnection.Open();
		ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLiteTO2 = ConfiguracaoTemplateSQLiteBLL.Select(sqlConnection, new ConfiguracaoTemplateSQLiteTO
		{
			IdVersaoCarga = idVersaoCarga
		}).FirstOrDefault();
		if (configuracaoTemplateSQLiteTO2 != null)
		{
			ConfiguracaoTemplateSQLiteBLL.Delete(sqlConnection, configuracaoTemplateSQLiteTO2);
		}
		ConfiguracaoTemplateSQLiteBLL.Insert(sqlConnection, configuracaoTemplateSQLiteTO);
		sqlConnection.Close();
	}
}
