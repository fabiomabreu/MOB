using System.Collections;
using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class PedVdaTransferAtacadistaLogDAL
{
	private const string LIMPA = "uspPedVdaTransferAtacadistaLogLimpa";

	private const string PEDIDOS_PENDENTES = "uspPedVdaTransferAtacadistaLogPedidosPendentes";

	private const string GERA = "uspPedVdaTransferAtacadistaLogGera";

	private const string ATUALIZA_STATUS = "uspPedVdaTransferAtacadistaLogAtualizaStatus";

	public static void Limpa(DbConnection connTargetErp)
	{
		connTargetErp.ClearParameters();
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaTransferAtacadistaLogLimpa");
	}

	public static List<string[]> PedidosPendentes(DbConnection connTargetErp)
	{
		connTargetErp.ClearParameters();
		BasicRS basicRS = connTargetErp.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaTransferAtacadistaLogPedidosPendentes");
		List<string[]> list = new List<string[]>();
		using (basicRS)
		{
			while (basicRS.MoveNext())
			{
				int integer = basicRS.GetInteger("CdEmp");
				int integer2 = basicRS.GetInteger("NuPed");
				string @string = basicRS.GetString("SiglaClien");
				list.Add(new string[3]
				{
					integer.ToString(),
					integer2.ToString(),
					@string
				});
			}
			return list;
		}
	}

	public static PedVdaTransferAtacadistaLogTO[] Gera(DbConnection connTargetErp, int cdEmp, int nuPed, string emailSmtpServidor, int emailSmtpPort, string emailUser, string emailPassword, bool emailUseSSL, string emailFrom, string htmlTemplateItens, string htmlTemplate, string siglaClien)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@cdEmp", cdEmp);
		connTargetErp.AddParameters("@nuPed", nuPed);
		connTargetErp.AddParameters("@emailSmtpServidor", emailSmtpServidor);
		connTargetErp.AddParameters("@emailSmtpPort", emailSmtpPort);
		connTargetErp.AddParameters("@emailUser", emailUser);
		connTargetErp.AddParameters("@emailPassword", emailPassword);
		connTargetErp.AddParameters("@emailUseSSL", emailUseSSL);
		connTargetErp.AddParameters("@emailFrom", emailFrom);
		connTargetErp.AddParameters("@htmlTemplateItens", htmlTemplateItens).SqlDbType = SqlDbType.VarChar;
		connTargetErp.AddParameters("@htmlTemplate", htmlTemplate).SqlDbType = SqlDbType.VarChar;
		return CreateInstances(connTargetErp.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaTransferAtacadistaLogGera_" + siglaClien));
	}

	public static void AtualizaStatus(DbConnection connTargetErp, int idPedVdaTransferAtacadistaLog, bool envioOk, string emailEnvioMsg)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@idPedVdaTransferAtacadistaLog", idPedVdaTransferAtacadistaLog);
		connTargetErp.AddParameters("@envioOk", envioOk);
		connTargetErp.AddParameters("@emailEnvioMsg", emailEnvioMsg);
		connTargetErp.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaTransferAtacadistaLogAtualizaStatus");
	}

	private static PedVdaTransferAtacadistaLogTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PedVdaTransferAtacadistaLogTO pedVdaTransferAtacadistaLogTO = new PedVdaTransferAtacadistaLogTO();
				pedVdaTransferAtacadistaLogTO.IdPedVdaTransferAtacadistaLog = rs.GetInteger("IdPedVdaTransferAtacadistaLog");
				pedVdaTransferAtacadistaLogTO.Data = rs.GetDateTime("Data");
				pedVdaTransferAtacadistaLogTO.CdEmp = rs.GetInteger("CdEmp");
				pedVdaTransferAtacadistaLogTO.NuPed = rs.GetInteger("NuPed");
				pedVdaTransferAtacadistaLogTO.EmailSmtpServidor = rs.GetString("EmailSmtpServidor");
				pedVdaTransferAtacadistaLogTO.EmailSmtpPort = rs.GetInteger("EmailSmtpPort");
				pedVdaTransferAtacadistaLogTO.EmailUser = rs.GetString("EmailUser");
				pedVdaTransferAtacadistaLogTO.EmailPassword = rs.GetString("EmailPassword");
				pedVdaTransferAtacadistaLogTO.EmailUseSSL = rs.GetBoolean("EmailUseSSL");
				pedVdaTransferAtacadistaLogTO.EmailFrom = rs.GetString("EmailFrom");
				pedVdaTransferAtacadistaLogTO.EmailTo = rs.GetString("EmailTo");
				pedVdaTransferAtacadistaLogTO.EmailCc = rs.GetString("EmailCc");
				pedVdaTransferAtacadistaLogTO.EmailSubject = rs.GetString("EmailSubject");
				pedVdaTransferAtacadistaLogTO.EmailBody = rs.GetString("EmailBody");
				pedVdaTransferAtacadistaLogTO.EmailBodyIsHtml = rs.GetBoolean("EmailBodyIsHtml");
				pedVdaTransferAtacadistaLogTO.EmailEnvioSituacao = rs.GetInteger("EmailEnvioSituacao");
				pedVdaTransferAtacadistaLogTO.EmailEnvioMsg = rs.GetString("EmailEnvioMsg");
				arrayList.Add(pedVdaTransferAtacadistaLogTO);
			}
		}
		return (PedVdaTransferAtacadistaLogTO[])arrayList.ToArray(typeof(PedVdaTransferAtacadistaLogTO));
	}
}
