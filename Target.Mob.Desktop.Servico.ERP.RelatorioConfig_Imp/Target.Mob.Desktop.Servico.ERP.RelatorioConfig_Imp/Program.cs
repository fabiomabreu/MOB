using System.ServiceProcess;

namespace Target.Mob.Desktop.Servico.ERP.RelatorioConfig_Imp;

internal static class Program
{
	private static void Main()
	{
		ServiceBase.Run(new ServiceBase[1]
		{
			new RelatorioConfig_Import()
		});
	}
}
