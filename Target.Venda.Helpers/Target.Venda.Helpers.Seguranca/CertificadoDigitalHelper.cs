using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Target.Venda.Helpers.Seguranca;

public class CertificadoDigitalHelper
{
	public string NumeroSerie { get; set; }

	public string NomCompleto { get; set; }

	public DateTime Validade { get; set; }

	public string Senha { get; set; }

	public string Pessoa { get; set; }

	public string CNPJ { get; set; }

	public byte[] ArquivoCertificado { get; set; }

	public X509Certificate2 ObterCertificadoByBinario(byte[] arquivoCertificado, string senhaCertificado)
	{
		if (arquivoCertificado == null || arquivoCertificado.Length < 1)
		{
			throw new ArgumentException("O parâmetro arquivo esta vazio.");
		}
		if (string.IsNullOrEmpty(senhaCertificado))
		{
			throw new ArgumentException("O parâmetro senha está vazio.");
		}
		X509Certificate2 x509Certificate = new X509Certificate2();
		x509Certificate.Import(arquivoCertificado, senhaCertificado, X509KeyStorageFlags.MachineKeySet);
		return x509Certificate;
	}

	public CertificadoDigitalHelper Converter_x509_Model(X509Certificate2 x509cert)
	{
		CertificadoDigitalHelper certificadoDigitalHelper = new CertificadoDigitalHelper();
		certificadoDigitalHelper.NomCompleto = x509cert.Subject;
		certificadoDigitalHelper.NumeroSerie = x509cert.SerialNumber;
		certificadoDigitalHelper.Validade = x509cert.NotAfter;
		certificadoDigitalHelper.ArquivoCertificado = x509cert.RawData;
		string text = x509cert.Subject.Split(',').First();
		certificadoDigitalHelper.CNPJ = "";
		string text2 = x509cert.Subject.Substring(x509cert.Subject.IndexOf("CN="), x509cert.Subject.IndexOf(','));
		certificadoDigitalHelper.Pessoa = text2.Replace("CN=", "");
		certificadoDigitalHelper.Validade = Convert.ToDateTime(x509cert.GetExpirationDateString());
		return certificadoDigitalHelper;
	}
}
