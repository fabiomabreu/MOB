using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Target.Venda.Helpers.Internet;

public class FTPHelper
{
	private string host = null;

	private string user = null;

	private string pass = null;

	private FtpWebRequest ftpRequest = null;

	private FtpWebResponse ftpResponse = null;

	private Stream ftpStream = null;

	private int bufferSize = 2048;

	public FTPHelper(string hostIP, string userName, string password)
	{
		host = hostIP;
		user = userName;
		pass = password;
	}

	public void download(string remoteFile, string localFile)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + remoteFile);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "RETR";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			FileStream fileStream = new FileStream(localFile, FileMode.Create);
			byte[] buffer = new byte[bufferSize];
			int num = ftpStream.Read(buffer, 0, bufferSize);
			try
			{
				while (num > 0)
				{
					fileStream.Write(buffer, 0, num);
					num = ftpStream.Read(buffer, 0, bufferSize);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			fileStream.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex2)
		{
			throw new Exception(ex2.Message);
		}
	}

	public void upload(string remoteFile, string localFile)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + remoteFile);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "STOR";
			ftpStream = ftpRequest.GetRequestStream();
			FileStream fileStream = new FileStream(localFile, FileMode.Open);
			byte[] buffer = new byte[bufferSize];
			int num = fileStream.Read(buffer, 0, bufferSize);
			try
			{
				while (num != 0)
				{
					ftpStream.Write(buffer, 0, num);
					num = fileStream.Read(buffer, 0, bufferSize);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			fileStream.Close();
			ftpStream.Close();
			ftpRequest = null;
		}
		catch (WebException ex2)
		{
			throw new WebException(ex2.Message + " - " + localFile);
		}
		catch (Exception ex3)
		{
			throw new Exception(ex3.Message + " - " + localFile);
		}
	}

	public void delete(string deleteFile)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "DELE";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public void rename(string currentFileNameAndPath, string newFileName)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "RENAME";
			ftpRequest.RenameTo = newFileName;
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public void createDirectory(string newDirectory)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "MKD";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpResponse.Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public string getFileCreatedDateTime(string fileName)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + fileName);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "MDTM";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string text = null;
			try
			{
				text = streamReader.ReadToEnd();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			return text;
		}
		catch (Exception ex2)
		{
			throw new Exception(ex2.Message);
		}
	}

	public string getFileSize(string fileName)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + fileName);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "SIZE";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string result = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					result = streamReader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			return result;
		}
		catch (Exception ex2)
		{
			throw new Exception(ex2.Message);
		}
	}

	public List<string> directoryListSimple(string directory)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "NLST";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			using StreamReader streamReader = new StreamReader(ftpStream);
			List<string> list = new List<string>();
			try
			{
				while (!streamReader.EndOfStream)
				{
					list.Add(streamReader.ReadLine());
				}
			}
			catch (WebException ex)
			{
				throw new WebException(ex.Message + " - " + host + "/" + directory);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message + " - " + host + "/" + directory);
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			return list;
		}
		catch (WebException ex3)
		{
			throw new WebException(ex3.Message + " - " + host + "/" + directory);
		}
		catch (Exception ex4)
		{
			throw new Exception(ex4.Message + " - " + host + "/" + directory);
		}
	}

	public string[] directoryListDetailed(string directory)
	{
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory);
			ftpRequest.Credentials = new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			ftpRequest.Method = "LIST";
			ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
			ftpStream = ftpResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string text = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					text = text + streamReader.ReadLine() + "|";
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			streamReader.Close();
			ftpStream.Close();
			ftpResponse.Close();
			ftpRequest = null;
			try
			{
				return text.Split("|".ToCharArray());
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
		}
		catch (Exception ex3)
		{
			throw new Exception(ex3.Message);
		}
	}
}
