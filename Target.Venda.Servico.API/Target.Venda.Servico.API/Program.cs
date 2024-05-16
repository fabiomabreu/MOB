using System.ServiceProcess;

namespace Target.Venda.Servico.API;

internal static class Program
{
	private static void Main()
	{
		ServiceBase[] services = new ServiceBase[1]
		{
			new TargetVendaAPI()
		};
		ServiceBase.Run(services);
	}
}
