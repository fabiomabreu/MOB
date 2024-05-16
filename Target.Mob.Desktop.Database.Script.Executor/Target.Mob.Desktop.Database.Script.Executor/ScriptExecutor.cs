using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Target.Mob.Desktop.Database.Script.Bll;
using Target.Mob.Desktop.Database.Script.Model;

namespace Target.Mob.Desktop.Database.Script.Executor;

public class ScriptExecutor
{
	public delegate void MessageOutputEventHandler(string message);

	private string _StringConnection;

	private bool _VersionScriptsUpdateControl;

	private string _StructurePath;

	private string _ProgrammabilityPath;

	private string _LoadDataPath;

	private string _RootPath;

	public event MessageOutputEventHandler OnMessageOutput;

	public ScriptExecutor(string stringConnection, string rootPath, bool versionScriptsUpdateControl)
	{
		_StringConnection = stringConnection;
		_VersionScriptsUpdateControl = versionScriptsUpdateControl;
		_RootPath = rootPath;
		_StructurePath = Path.Combine(rootPath, "01_Structure");
		_ProgrammabilityPath = Path.Combine(rootPath, "02_Programmability");
		_LoadDataPath = Path.Combine(rootPath, "03_LoadData");
	}

	public void Execute()
	{
		ExecuteVersionScripts(_StructurePath);
		ExecuteGenericScripts(_ProgrammabilityPath);
		ExecuteGenericScripts(_LoadDataPath);
	}

	private void ExecuteVersionScripts(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		if (!directoryInfo.Exists)
		{
			return;
		}
		DirectoryInfo[] directories = directoryInfo.GetDirectories("Ver_*", SearchOption.TopDirectoryOnly);
		foreach (DirectoryInfo directoryInfo2 in directories)
		{
			string strB = null;
			if (_VersionScriptsUpdateControl)
			{
				strB = GetLastScript(directoryInfo2);
			}
			FileInfo[] files = directoryInfo2.GetFiles(directoryInfo2.Name + "*.sql", SearchOption.TopDirectoryOnly);
			foreach (FileInfo fileInfo in files)
			{
				if (string.Compare(fileInfo.Name, strB, ignoreCase: true) > 0)
				{
					ExecuteScript(fileInfo, _VersionScriptsUpdateControl);
				}
			}
		}
	}

	private void ExecuteGenericScripts(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		if (directoryInfo.Exists)
		{
			FileInfo[] files = directoryInfo.GetFiles("*.sql", SearchOption.AllDirectories);
			foreach (FileInfo scriptFile in files)
			{
				ExecuteScript(scriptFile, updateControl: false);
			}
		}
	}

	private string GetLastScript(DirectoryInfo versionDirectory)
	{
		string empty = string.Empty;
		using SqlConnection sqlConnection = new SqlConnection(_StringConnection);
		sqlConnection.Open();
		empty = ((!_RootPath.Contains("ScriptTargetERP")) ? ControleAtualizacaoMobBLL.SelectMax(sqlConnection, versionDirectory.Name) : ControleAtualizacaoErpBLL.SelectMax(sqlConnection, versionDirectory.Name));
		sqlConnection.Close();
		return empty;
	}

	private string[] SplitScript(FileInfo file)
	{
		string text = File.ReadAllText(file.FullName);
		string[] array = new string[20]
		{
			"\r\nGO\r\n", "\r\ngo\r\n", "\r\nGo\r\n", "\r\ngO\r\n", " GO ", " go ", " Go ", " gO ", "\r\nGO ", "\r\ngo ",
			"\r\nGo ", "\r\ngO ", "\r\nGO", "\r\ngo", "\r\nGo", "\r\ngO", " GO\r\n", " go\r\n", " Go\r\n", " gO\r\n"
		};
		string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
		string[] array3 = array2;
		foreach (string text2 in array3)
		{
			string[] array4 = array;
			foreach (string oldValue in array4)
			{
				text2.Replace(oldValue, string.Empty);
			}
		}
		return array2;
	}

	private void ExecuteScript(FileInfo scriptFile, bool updateControl)
	{
		string[] source = new string[1] { "Ver_003.014_Mob_0003.sql" };
		this.OnMessageOutput($"Executando Script: {scriptFile.Name}");
		string[] array = SplitScript(scriptFile);
		using SqlConnection sqlConnection = new SqlConnection(_StringConnection);
		sqlConnection.Open();
		SqlTransaction sqlTransaction = null;
		bool flag = !source.Contains(scriptFile.Name);
		if (flag)
		{
			sqlTransaction = sqlConnection.BeginTransaction();
		}
		int num = 1;
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			using SqlCommand sqlCommand = new SqlCommand(array2[i], sqlConnection, sqlTransaction);
			sqlCommand.CommandTimeout = 0;
			sqlCommand.ExecuteNonQuery();
			this.OnMessageOutput($"Comando executado com sucesso... ({num})");
			num++;
		}
		if (updateControl)
		{
			ControleAtualizacaoTO controleAtualizacaoTO = new ControleAtualizacaoTO();
			controleAtualizacaoTO.Arquivo = scriptFile.Name;
			controleAtualizacaoTO.Diretorio = scriptFile.DirectoryName;
			if (_RootPath.Contains("ScriptTargetERP"))
			{
				ControleAtualizacaoErpBLL.Insert(sqlConnection, sqlTransaction, controleAtualizacaoTO);
			}
			else
			{
				ControleAtualizacaoMobBLL.Insert(sqlConnection, sqlTransaction, controleAtualizacaoTO);
			}
		}
		if (flag)
		{
			sqlTransaction.Commit();
		}
		sqlConnection.Close();
		this.OnMessageOutput(string.Empty);
	}
}
