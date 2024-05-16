using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace Target.Mob.Desktop.GCS;

public class GCSController
{
	private string _cnpj;

	private string _bucketName;

	private Configuration _appConfig;

	private readonly string fileConfig = "Target.Mob.Desktop.Servico.ERP.Principal.exe";

	private StorageClient _storage;

	public GCSController(string CNPJ)
	{
		_cnpj = CNPJ;
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		_appConfig = ConfigurationManager.OpenExeConfiguration(Path.Combine(directoryName, fileConfig));
		AppSettingsSection appSettingsSection = (AppSettingsSection)_appConfig.GetSection("appSettings");
		_bucketName = appSettingsSection.Settings["BucketNameGCS"].Value;
		GoogleCredential googleCredential = null;
		string googleStorageCredentials = Resources.GoogleStorageCredentials;
		googleCredential = GoogleCredential.FromStream(new MemoryStream(Encoding.ASCII.GetBytes(googleStorageCredentials)));
		_storage = StorageClient.Create(googleCredential);
	}

	public void EnviarIndenizacao(int IndenizacaoID, byte[] file, string filePath)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(file, 0, file.Length);
		string objectName = $"comercial/recursoIndenizacao/{_cnpj}/{IndenizacaoID}/{filePath}";
		_storage.UploadObjectAsync(_bucketName, objectName, null, memoryStream);
	}

	public bool FindByName(string fileNameOnBucket)
	{
		_storage = StorageClient.Create();
		if (_storage.ListObjects(_bucketName, fileNameOnBucket).Count() > 0)
		{
			return true;
		}
		return false;
	}

	public bool DeleteFile(string fileNameOnBucket)
	{
		try
		{
			_storage.DeleteObject(_storage.GetObject(_bucketName, fileNameOnBucket));
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
