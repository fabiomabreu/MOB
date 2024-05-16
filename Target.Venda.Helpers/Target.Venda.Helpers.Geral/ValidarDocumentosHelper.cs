using System;
using System.Runtime.InteropServices;

namespace Target.Venda.Helpers.Geral;

public static class ValidarDocumentosHelper
{
	private static object _lock = new object();

	public static bool ValidaCNPJ(string vrCNPJ)
	{
		long num = Convert.ToInt64(vrCNPJ);
		if (num == 0)
		{
			return false;
		}
		string text = vrCNPJ.Replace(".", "");
		text = text.Replace("/", "");
		text = text.Replace("-", "");
		string text2 = "6543298765432";
		int[] array = new int[14];
		int[] array2 = new int[2] { 0, 0 };
		int[] array3 = new int[2] { 0, 0 };
		bool[] array4 = new bool[2] { false, false };
		try
		{
			for (int i = 0; i < 14; i++)
			{
				array[i] = int.Parse(text.Substring(i, 1));
				if (i <= 11)
				{
					array2[0] += array[i] * int.Parse(text2.Substring(i + 1, 1));
				}
				if (i <= 12)
				{
					array2[1] += array[i] * int.Parse(text2.Substring(i, 1));
				}
			}
			for (int i = 0; i < 2; i++)
			{
				array3[i] = array2[i] % 11;
				if (array3[i] == 0 || array3[i] == 1)
				{
					array4[i] = array[12 + i] == 0;
				}
				else
				{
					array4[i] = array[12 + i] == 11 - array3[i];
				}
			}
			return array4[0] && array4[1];
		}
		catch
		{
			return false;
		}
	}

	public static bool ValidaCPF(string vrCPF)
	{
		string text = vrCPF.Replace(".", "");
		text = text.Replace("-", "");
		if (text.Length != 11)
		{
			return false;
		}
		bool flag = true;
		for (int i = 1; i < 11 && flag; i++)
		{
			if (text[i] != text[0])
			{
				flag = false;
			}
		}
		if (flag || text == "12345678909")
		{
			return false;
		}
		int[] array = new int[11];
		for (int j = 0; j < 11; j++)
		{
			array[j] = int.Parse(text[j].ToString());
		}
		int num = 0;
		for (int k = 0; k < 9; k++)
		{
			num += (10 - k) * array[k];
		}
		int num2 = num % 11;
		if (num2 == 1 || num2 == 0)
		{
			if (array[9] != 0)
			{
				return false;
			}
		}
		else if (array[9] != 11 - num2)
		{
			return false;
		}
		num = 0;
		for (int l = 0; l < 10; l++)
		{
			num += (11 - l) * array[l];
		}
		num2 = num % 11;
		if (num2 == 1 || num2 == 0)
		{
			if (array[10] != 0)
			{
				return false;
			}
		}
		else if (array[10] != 11 - num2)
		{
			return false;
		}
		return true;
	}

	public static bool ValidarInscricaoEstadual(string tipoPessoa, string tipoInscricao, string inscricao, string estado)
	{
		bool flag = false;
		switch (tipoInscricao)
		{
		case "E":
			inscricao = StringHelper.LimparFormat(inscricao);
			if (!ValidarInscricaoEstadual(inscricao, estado))
			{
				flag = true;
			}
			break;
		case "I":
			if (tipoPessoa == "J" && inscricao.Trim().ToUpper() != "ISENTO")
			{
				flag = true;
			}
			break;
		case "M":
			if (string.IsNullOrEmpty(inscricao))
			{
				flag = true;
				break;
			}
			goto default;
		default:
			if (string.IsNullOrEmpty(tipoInscricao))
			{
				flag = true;
			}
			break;
		}
		return !flag;
	}

	public static bool ValidarInscricaoEstadual(string inscricao, string estado)
	{
		lock (_lock)
		{
			int value = ConsisteInscricaoEstadual(inscricao, estado);
			return !Convert.ToBoolean(value);
		}
	}

	[DllImport("DllInscE32.dll")]
	public static extern int ConsisteInscricaoEstadual(string vInsc, string vUF);
}
