using System.IO;
using Ionic.Zlib;

namespace Target.Mob.Desktop.Api.Filters;

public class CompressionHelper
{
	public static byte[] GzipByte(byte[] str)
	{
		if (str == null)
		{
			return null;
		}
		using MemoryStream memoryStream = new MemoryStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestSpeed))
		{
			gZipStream.Write(str, 0, str.Length);
		}
		return memoryStream.ToArray();
	}
}
