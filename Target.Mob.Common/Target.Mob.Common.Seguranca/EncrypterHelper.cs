using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Target.Mob.Common.Log;

namespace Target.Mob.Common.Seguranca;

public static class EncrypterHelper
{
	private static byte[] key = new byte[0];

	private static byte[] IV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };

	public static string chave = "tgtsis10";

	public static string EncrypterMD5(string password)
	{
		HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
		byte[] bytes = Encoding.ASCII.GetBytes(password);
		byte[] bytes2 = hashAlgorithm.ComputeHash(bytes);
		return Encoding.ASCII.GetString(bytes2);
	}

	public static string Decifrar(string stringToDecrypt, string sEncryptionKey)
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
			return Encoding.Default.GetString(memoryStream.ToArray());
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Cifrar(string stringToEncrypt, string SEncryptionKey)
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

	public static string Criptografia_RijndaelManaged(string texto)
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
			LogEvento.WriteEntry("EncrypterHelper.Criptografia_RijndaelManaged", ex.Message, EventLogEntryType.Error);
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

	public static string Descriptografia_RijndaelManaged(string texto)
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
			_ = string.Empty;
			MemoryStream memoryStream = new MemoryStream();
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
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
			rijndaelManaged = new RijndaelManaged
			{
				BlockSize = 256,
				FeedbackSize = 256
			};
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
			return Encoding.Default.GetString(array).Trim(default(char));
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string Criptografia_ConnectionString(string texto)
	{
		try
		{
			_ = string.Empty;
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(texto);
			sqlConnectionStringBuilder.Password = Criptografia_RijndaelManaged(sqlConnectionStringBuilder.Password);
			return sqlConnectionStringBuilder.ConnectionString.Replace("\"", "");
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("EncrypterHelper.Criptografia_ConnectionString", ex.Message, EventLogEntryType.Error);
			return texto;
		}
	}

	public static string Criptografia_ConnectionPasswordString(string texto)
	{
		try
		{
			return Criptografia_RijndaelManaged(texto);
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("EncrypterHelper.Criptografia_ConnectionPasswordString", ex.Message, EventLogEntryType.Error);
			return texto;
		}
	}

	public static string Descriptografia_ConnectionString(string texto)
	{
		try
		{
			_ = string.Empty;
			texto = texto.Replace("\"", "");
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(texto);
			string text = Descriptografia_RijndaelManaged(sqlConnectionStringBuilder.Password);
			if (!string.IsNullOrEmpty(text))
			{
				sqlConnectionStringBuilder.Password = text;
			}
			return sqlConnectionStringBuilder.ConnectionString;
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("EncrypterHelper.Descriptografia_ConnectionString", ex.Message, EventLogEntryType.Error);
			return texto;
		}
	}

	public static string Descriptografia_ConnectionPasswordString(string texto)
	{
		try
		{
			return Descriptografia_RijndaelManaged(texto);
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("EncrypterHelper.Descriptografia_ConnectionPasswordString", ex.Message, EventLogEntryType.Error);
			return texto;
		}
	}
}
