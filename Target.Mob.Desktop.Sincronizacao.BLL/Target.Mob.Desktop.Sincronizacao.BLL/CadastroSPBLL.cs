using System;
using System.Data;
using System.IO;
using System.Text;
using Target.Mob.Common.IO;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class CadastroSPBLL
{
	public static void GerarRelatorioPreDefinidos(DbConnection connTargetERP, CadastroSPTO cadastroTO, int? idVendedor, string codigoVendedor, string pathDestinoRaiz)
	{
		DataTable dataTable = null;
		try
		{
			string[] array = ScriptExecutor.SplitScript(cadastroTO.Texto);
			string[] array2 = array;
			foreach (string texto in array2)
			{
				cadastroTO.Texto = texto;
				CriarProc(connTargetERP, cadastroTO);
			}
			if (array[1] == null)
			{
				return;
			}
			dataTable = RelatorioPreDefinidoBLL.Select(connTargetERP, cadastroTO, codigoVendedor);
			if (dataTable.Rows.Count <= 3)
			{
				return;
			}
			int? num = idVendedor;
			string text = "\\ID_" + num + "_COD_" + StringUtil.RemoveSpecialCharacters(codigoVendedor);
			if (!Directory.Exists(pathDestinoRaiz + text + "\\temp"))
			{
				Directory.CreateDirectory(pathDestinoRaiz + text + "\\temp");
			}
			int num2 = 0;
			string empty = string.Empty;
			string empty2 = string.Empty;
			empty = cadastroTO.Descricao + ".TGT";
			string text2 = empty;
			num2 = empty.Length - 12;
			empty = text2.Substring(12, num2);
			empty2 = pathDestinoRaiz + text;
			File.CreateText(empty2 + "\\temp\\" + empty).Dispose();
			using (StreamWriter streamWriter = new StreamWriter(empty2 + "\\temp\\" + empty, append: true, Encoding.UTF8))
			{
				foreach (DataRow row in dataTable.Rows)
				{
					streamWriter.WriteLine(row[0]);
				}
			}
			ZipFile.Compacta(empty2 + "\\temp\\" + empty, empty2 + "\\temp\\" + empty + ".ZIP");
			File.Delete(empty2 + "\\temp\\" + empty);
			if (File.Exists(empty2 + "\\" + empty + ".ZIP"))
			{
				File.Delete(empty2 + "\\" + empty + ".ZIP");
			}
			File.Move(empty2 + "\\temp\\" + empty + ".ZIP", empty2 + "\\" + empty + ".ZIP");
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static bool CriarProc(DbConnection connection, CadastroSPTO cadastroSPTO)
	{
		return CadastroSPDAL.CriarProc(connection, cadastroSPTO);
	}

	public static bool Exists(DbConnection connection, int? id)
	{
		return CadastroSPDAL.Exists(connection, id);
	}

	public static CadastroSPTO[] Select(DbConnection connection, CadastroSPTO cadastroSPTO)
	{
		CadastroSPTO[] array = CadastroSPDAL.Select(connection, cadastroSPTO);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, CadastroSPTO CadastroSP)
	{
		CadastroSPDAL.Insert(connection, CadastroSP);
	}

	internal static void Update(DbConnection connection, CadastroSPTO CadastroSP)
	{
		CadastroSPDAL.Update(connection, CadastroSP);
	}
}
