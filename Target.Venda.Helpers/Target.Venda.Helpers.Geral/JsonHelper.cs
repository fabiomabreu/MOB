using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Target.Venda.Helpers.Geral;

public static class JsonHelper
{
	public static string JsonSerializer(object OBJETO)
	{
		DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(OBJETO.GetType());
		MemoryStream memoryStream = new MemoryStream();
		dataContractJsonSerializer.WriteObject(memoryStream, OBJETO);
		string @string = Encoding.UTF8.GetString(memoryStream.ToArray());
		memoryStream.Close();
		return @string;
	}

	public static T JsonDeserialize<T>(string jsonString)
	{
		DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
		MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
		return (T)dataContractJsonSerializer.ReadObject(stream);
	}

	public static dynamic ConverterStringJsonParaDynamic(string json)
	{
		return ConvertHelper.ToDynamicObjetoByStringJson(json);
	}
}
