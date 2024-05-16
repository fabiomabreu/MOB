using System;
using System.Text;
using Target.Mob.Desktop.Installer.ERP.View.Common;

namespace Target.Mob.Desktop.Installer.ERP.View;

public static class InstalacaoSilenciosa
{
	private static StringBuilder _sb = new StringBuilder();

	public static void Instalar()
	{
		try
		{
			CommonInstaller.MENSAGENS += MENSAGENS;
			CommonInstaller.Load();
			CommonInstaller.Install();
			CommonInstaller.IniciarServicos();
		}
		catch (Exception ex)
		{
			CommonInstaller.GravarLog(ex, _sb);
		}
	}

	private static void MENSAGENS(string message)
	{
		_sb.AppendLine(message);
	}
}
