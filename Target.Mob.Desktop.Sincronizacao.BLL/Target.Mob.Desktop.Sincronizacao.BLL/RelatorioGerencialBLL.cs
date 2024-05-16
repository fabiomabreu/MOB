using System;
using System.IO;
using System.Linq;
using Target.Mob.Common.IO;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class RelatorioGerencialBLL
{
	public static void GravarRelatorio(DbConnection connTargetMob, string pathOrigem, string pathDestino)
	{
		try
		{
			if (!Directory.Exists(pathOrigem))
			{
				Directory.CreateDirectory(pathOrigem);
			}
			if (!Directory.Exists(pathDestino))
			{
				Directory.CreateDirectory(pathDestino);
			}
			foreach (VendedorTO item in VendedorBLL.SelectCarga(connTargetMob.GetConnection()))
			{
				string path = pathOrigem + "\\ID_" + item.Id + "_COD_" + StringUtil.RemoveSpecialCharacters(item.CodigoVendedor.Trim());
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
			string[] directories = Directory.GetDirectories(pathOrigem);
			if (directories.Length == 0)
			{
				return;
			}
			string text = "";
			string text2 = "";
			string[] array = directories;
			foreach (string path2 in array)
			{
				string[] files = Directory.GetFiles(path2);
				if (files.Length == 0)
				{
					continue;
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(path2);
				string text3 = pathDestino + "\\" + directoryInfo.Name;
				if (!Directory.Exists(text3))
				{
					Directory.CreateDirectory(text3);
				}
				string[] array2 = files;
				foreach (string obj in array2)
				{
					text = Path.GetFileName(obj);
					text2 = Path.Combine(text3, text);
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
					File.Move(obj, text2);
					if (new FileInfo(text).Extension.ToString() != ".ZIP")
					{
						if (File.Exists(text2 + ".ZIP"))
						{
							File.Delete(text2 + ".ZIP");
						}
						ZipFile.Compacta(text2, text2 + ".ZIP");
						File.Delete(text2);
					}
				}
				directoryInfo = new DirectoryInfo(text3);
				GravarRelatorioBanco(directoryInfo, connTargetMob);
				Directory.Delete(text3, recursive: true);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static void GravarRelatorioBanco(DirectoryInfo dirInfo, DbConnection connTargetMob)
	{
		RelatorioGerencialTO relatorioGerencialTO = new RelatorioGerencialTO();
		VendedorRelatorioTO vendedorRelatorioTO = new VendedorRelatorioTO();
		try
		{
			FileInfo[] files = dirInfo.GetFiles("*.ZIP");
			foreach (FileInfo fileInfo in files)
			{
				int num = dirInfo.Name.ToString().IndexOf("ID_") + "ID_".Length;
				int length = dirInfo.Name.ToString().IndexOf("_COD_") - num;
				string text = dirInfo.Name.ToString().Substring(num, length);
				vendedorRelatorioTO.IdVendedor = Convert.ToInt32(text.Trim());
				VendedorRelatorioTO[] array = VendedorRelatorioDAL.Select(connTargetMob, vendedorRelatorioTO);
				if (array.Length == 0)
				{
					continue;
				}
				relatorioGerencialTO.IDVendedor = array.First().IdVendedor;
				relatorioGerencialTO.NomeArquivo = fileInfo.Name;
				relatorioGerencialTO.ArquivoRelatorio = File.ReadAllBytes(fileInfo.FullName);
				relatorioGerencialTO.DtRecebimento = DateTime.Now;
				if (Exists(connTargetMob, relatorioGerencialTO))
				{
					RelatorioGerencialTO[] array2 = Select_Sem_Arquivo(connTargetMob, relatorioGerencialTO);
					foreach (RelatorioGerencialTO relatorioGerencialTO2 in array2)
					{
						if (!relatorioGerencialTO2.DtImportacao.HasValue)
						{
							relatorioGerencialTO2.DtImportacao = DateTime.Now;
							Update(connTargetMob, relatorioGerencialTO2);
						}
					}
					Insert(connTargetMob, relatorioGerencialTO);
					File.Delete(fileInfo.FullName);
				}
				else
				{
					Insert(connTargetMob, relatorioGerencialTO);
					File.Delete(fileInfo.FullName);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static void SetTransmitido(DbConnection connection, RelatorioGerencialTO relatorioGeralTO)
	{
		RelatorioGerencialTO[] array = Select_Arquivo(connection, relatorioGeralTO);
		foreach (RelatorioGerencialTO relatorioGerencialTO in array)
		{
			relatorioGeralTO.NomeArquivo = relatorioGerencialTO.NomeArquivo;
			relatorioGeralTO.IDVendedor = relatorioGerencialTO.IDVendedor;
			relatorioGeralTO.CodigoVendedor = relatorioGerencialTO.CodigoVendedor;
			relatorioGeralTO.ArquivoRelatorio = relatorioGerencialTO.ArquivoRelatorio;
			relatorioGeralTO.DtRecebimento = relatorioGerencialTO.DtRecebimento;
			relatorioGeralTO.DtImportacao = DateTime.Now;
			Update(connection, relatorioGeralTO);
		}
	}

	public static bool Exists(DbConnection connection, RelatorioGerencialTO value)
	{
		return RelatorioGerencialDAL.Exists(connection, value);
	}

	public static RelatorioGerencialTO[] Select_Sem_Arquivo(DbConnection connection, RelatorioGerencialTO value)
	{
		RelatorioGerencialTO[] array = RelatorioGerencialDAL.Select_Sem_Arquivo(connection, value);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static RelatorioGerencialTO[] Select_Arquivo(DbConnection connection, RelatorioGerencialTO value)
	{
		RelatorioGerencialTO[] array = RelatorioGerencialDAL.Select_Arquivo(connection, value);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, RelatorioGerencialTO value)
	{
		RelatorioGerencialDAL.Insert(connection, value);
	}

	internal static void Update(DbConnection connection, RelatorioGerencialTO value)
	{
		RelatorioGerencialDAL.Update(connection, value);
	}
}
