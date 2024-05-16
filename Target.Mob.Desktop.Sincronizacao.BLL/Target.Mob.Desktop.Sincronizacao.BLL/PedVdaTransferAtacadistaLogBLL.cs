using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class PedVdaTransferAtacadistaLogBLL
{
	internal static void Limpa(DbConnection connTargetErp)
	{
		PedVdaTransferAtacadistaLogDAL.Limpa(connTargetErp);
	}

	internal static PedVdaTransferAtacadistaLogTO[] Gera(DbConnection connTargetErp, string emailSmtpServidor, int emailSmtpPort, string emailUser, string emailPassword, bool emailUseSSL, string emailFrom)
	{
		PedVdaTransferAtacadistaLogTO[] array = new List<PedVdaTransferAtacadistaLogTO>().ToArray();
		List<string[]> list = PedVdaTransferAtacadistaLogDAL.PedidosPendentes(connTargetErp);
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		foreach (string[] item in list)
		{
			int cdEmp = Convert.ToInt32(item[0]);
			int nuPed = Convert.ToInt32(item[1]);
			string text = item[2];
			string path = directoryName + "\\EmailTransfer\\" + text + "_template_body_item.html";
			string text2 = directoryName + "\\EmailTransfer\\" + text + "_template_body.html";
			if (!File.Exists(text2))
			{
				throw new Exception("Template HTML não localizado: " + text2);
			}
			if (!File.Exists(path))
			{
				throw new Exception("Template Itens HTML não localizado: " + text2);
			}
			string htmlTemplateItens = File.ReadAllText(path, Encoding.UTF8);
			string htmlTemplate = File.ReadAllText(text2, Encoding.UTF8);
			PedVdaTransferAtacadistaLogTO[] second = PedVdaTransferAtacadistaLogDAL.Gera(connTargetErp, cdEmp, nuPed, emailSmtpServidor, emailSmtpPort, emailUser, emailPassword, emailUseSSL, emailFrom, htmlTemplateItens, htmlTemplate, text);
			array = array.Concat(second).ToArray();
		}
		return array.ToArray();
	}

	internal static void AtualizaStatus(DbConnection connTargetErp, int idPedVdaTransferAtacadistaLog, bool envioOk, string emailEnvioMsg)
	{
		PedVdaTransferAtacadistaLogDAL.AtualizaStatus(connTargetErp, idPedVdaTransferAtacadistaLog, envioOk, emailEnvioMsg);
	}
}
