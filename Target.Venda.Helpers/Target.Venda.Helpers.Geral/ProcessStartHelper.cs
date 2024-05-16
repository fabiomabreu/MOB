using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Target.Venda.Helpers.Geral;

public static class ProcessStartHelper
{
	public static bool InvocarExecutavel(string pathExe, List<string> parametros, int timeOutSegundos)
	{
		StringBuilder args = new StringBuilder();
		parametros.ForEach(delegate(string i)
		{
			args.AppendFormat(" {0}", i);
		});
		using Process process = new Process();
		ProcessStartInfo startInfo = new ProcessStartInfo(pathExe, args.ToString());
		process.StartInfo = startInfo;
		process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		process.Start();
		int milliseconds = timeOutSegundos * 1000;
		return !process.WaitForExit(milliseconds);
	}
}
