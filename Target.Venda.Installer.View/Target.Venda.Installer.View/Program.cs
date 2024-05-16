using System;
using System.Windows.Forms;

namespace Target.Venda.Installer.View;

internal static class Program
{
	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new frmServiceInstaller());
	}
}
