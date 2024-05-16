using System;
using System.Text;
using Target.Venda.Installer.View.Common;

namespace Target.Venda.Installer.View;

public static class InstalacaoSilenciosa
{
	private static StringBuilder _sb = new StringBuilder();

	public static void Instalar()
	{
		try
		{
			CommonInstaller.MENSAGENS += MENSAGENS;
			CommonInstaller.Load(INSTALACAO_SILENCIOSA: true);
			CommonInstaller.ValidarUsuarioCadastrado();
			CommonInstaller.Install();
			CommonInstaller.IniciarServicos();
		}
		catch (Exception ex)
		{
			_sb.AppendLine(ex.Message);
			CommonInstaller.GravarLog(ex, _sb);
		}
	}

	private static void MENSAGENS(string message)
	{
		_sb.AppendLine(message);
	}
}
