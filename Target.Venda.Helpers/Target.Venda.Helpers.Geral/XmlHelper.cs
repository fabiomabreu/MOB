using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Target.Venda.Helpers.Geral;

public static class XmlHelper
{
	private static bool _validouSchema = true;

	public static bool CheckSignature(XmlNodeList tagVal)
	{
		string xml = tagVal[0].OuterXml.ToString();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.LoadXml(xml);
		SignedXml signedXml = new SignedXml(xmlDocument);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Signature");
		signedXml.LoadXml((XmlElement)elementsByTagName[0]);
		IEnumerator enumerator = signedXml.KeyInfo.GetEnumerator();
		enumerator.MoveNext();
		KeyInfoX509Data keyInfoX509Data = (KeyInfoX509Data)enumerator.Current;
		X509Certificate2 x509Certificate = (X509Certificate2)keyInfoX509Data.Certificates[0];
		return signedXml.CheckSignature(x509Certificate.PublicKey.Key);
	}

	public static bool ValidarSchema(XmlDocument xdoc, string schema_location)
	{
		return _validouSchema;
	}

	private static void ValidationHandler(object sender, ValidationEventArgs args)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Erro ao Validar Schema XML: {args.Message}");
		if (args.Exception != null)
		{
			stringBuilder.AppendLine($"Detalhes: {args.Exception.Message}");
			stringBuilder.AppendLine(args.Exception.StackTrace);
		}
		_validouSchema = false;
		Exception ex = new Exception(stringBuilder.ToString());
		throw ex;
	}

	public static string ObjectToXml<T>(T objeto)
	{
		StringWriter stringWriter = new StringWriter();
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		xmlSerializer.Serialize(stringWriter, objeto);
		return stringWriter.ToString();
	}

	public static T XmlToObject<T>(Type tipo, string xmlText)
	{
		StringReader textReader = new StringReader(xmlText);
		XmlSerializer xmlSerializer = new XmlSerializer(tipo);
		object obj = xmlSerializer.Deserialize(textReader);
		return (T)obj;
	}
}
