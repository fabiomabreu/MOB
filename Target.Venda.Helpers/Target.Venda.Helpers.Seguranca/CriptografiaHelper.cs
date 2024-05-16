using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Target.Venda.Helpers.Seguranca;

public static class CriptografiaHelper
{
	private static byte[] key = new byte[0];

	private static byte[] IV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };

	private static string chave = "010101000110000101110010011001110110010101110100010101100110010101101110011001000110000101110011";

	public static string Criptografar_ConnectionString(string texto)
	{
		try
		{
			string empty = string.Empty;
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(texto);
			sqlConnectionStringBuilder.Password = Criptografar_RijndaelManaged(sqlConnectionStringBuilder.Password);
			return sqlConnectionStringBuilder.ConnectionString.Replace("\"", "");
		}
		catch (Exception)
		{
			return texto;
		}
	}

	public static string Descriptografar_ConnectionString(string texto)
	{
		try
		{
			texto = texto.Replace("\"", "");
			string empty = string.Empty;
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(texto);
			string text = Descriptografar_RijndaelManaged(sqlConnectionStringBuilder.Password);
			if (!string.IsNullOrEmpty(text))
			{
				sqlConnectionStringBuilder.Password = text;
			}
			return sqlConnectionStringBuilder.ConnectionString.Replace("\"", "");
		}
		catch (Exception)
		{
			return texto;
		}
	}

	public static string Criptografar_MD5(string password)
	{
		HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
		byte[] bytes = Encoding.ASCII.GetBytes(password);
		byte[] bytes2 = hashAlgorithm.ComputeHash(bytes);
		return Encoding.ASCII.GetString(bytes2);
	}

	public static string Criptografar_RijndaelManaged(string texto)
	{
		try
		{
			byte[] rgbIV = new byte[32]
			{
				122, 10, 30, 20, 15, 39, 21, 43, 53, 69,
				48, 58, 60, 71, 98, 12, 33, 11, 192, 232,
				77, 80, 99, 108, 210, 28, 34, 24, 222, 134,
				202, 94
			};
			MemoryStream memoryStream = new MemoryStream();
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			byte[] bytes = Encoding.Default.GetBytes(texto);
			int length = chave.Length;
			if (length >= 16)
			{
				chave = chave.Substring(0, 16);
			}
			else
			{
				length = chave.Length;
				int qtd = 16 - length;
				chave += StrDup(qtd, "X");
			}
			byte[] bytes2 = Encoding.Default.GetBytes(chave.ToCharArray());
			rijndaelManaged.BlockSize = 256;
			rijndaelManaged.FeedbackSize = 256;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(bytes2, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private static string StrDup(int qtd, string texto)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < qtd; i++)
		{
			stringBuilder.Append(texto);
		}
		return stringBuilder.ToString();
	}

	public static string Descriptografar_RijndaelManaged(string texto)
	{
		try
		{
			byte[] rgbIV = new byte[32]
			{
				122, 10, 30, 20, 15, 39, 21, 43, 53, 69,
				48, 58, 60, 71, 98, 12, 33, 11, 192, 232,
				77, 80, 99, 108, 210, 28, 34, 24, 222, 134,
				202, 94
			};
			string empty = string.Empty;
			MemoryStream memoryStream = new MemoryStream();
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			if (!string.IsNullOrEmpty(texto) && texto.Replace(" ", "").Length % 4 == 0)
			{
				byte[] buffer = Convert.FromBase64String(texto);
				int length = chave.Length;
				if (length >= 16)
				{
					chave = chave.Substring(0, 16);
				}
				else
				{
					length = chave.Length;
					int qtd = 16 - length;
					chave += StrDup(qtd, "X");
				}
				byte[] bytes = Encoding.Default.GetBytes(chave.ToCharArray());
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.BlockSize = 256;
				rijndaelManaged.FeedbackSize = 256;
				memoryStream = new MemoryStream(buffer);
				byte[] array = new byte[texto.Length];
				try
				{
					CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Read);
					cryptoStream.Read(array, 0, array.Length);
					memoryStream.Close();
					cryptoStream.Close();
				}
				catch (Exception)
				{
					return "";
				}
				empty = Encoding.Default.GetString(array);
				return empty.Trim(default(char));
			}
			return "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Criptografar_DESCrypto(string stringToEncrypt, string SEncryptionKey)
	{
		if (string.IsNullOrEmpty(stringToEncrypt))
		{
			return "";
		}
		try
		{
			key = Encoding.UTF8.GetBytes(SEncryptionKey);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes = Encoding.Default.GetBytes(stringToEncrypt);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Descriptografar_DESCrypto(string stringToDecrypt, string sEncryptionKey)
	{
		if (string.IsNullOrEmpty(stringToDecrypt))
		{
			return "";
		}
		byte[] array = new byte[stringToDecrypt.Length + 1];
		try
		{
			key = Encoding.UTF8.GetBytes(sEncryptionKey);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			array = Convert.FromBase64String(stringToDecrypt);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(key, IV), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			Encoding @default = Encoding.Default;
			return @default.GetString(memoryStream.ToArray());
		}
		catch (Exception)
		{
			return "";
		}
	}
}
