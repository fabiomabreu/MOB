using System;
using System.Net.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Model;

namespace Target.Mob.Desktop.Api.BLL;

public class LogApiBLL
{
	public static int Insert(string stringConnTargetErp, string username, string bodyHeader, string bodyRequest, HttpResponseMessage response, string ip)
	{
		LogApiTO logApiTO = new LogApiTO();
		logApiTO.Acao = response.RequestMessage.Method.Method.ToString();
		logApiTO.Data = DateTime.Now;
		logApiTO.Rota = response.RequestMessage.RequestUri.AbsoluteUri;
		logApiTO.Ip = ip;
		logApiTO.Usuario = username;
		logApiTO.RequestHeader = bodyHeader;
		logApiTO.RequestBody = bodyRequest;
		logApiTO.Response = ((response.Content == null) ? "" : response.Content.ReadAsStringAsync().Result);
		logApiTO.StatusCode = Convert.ToInt32(response.StatusCode);
		return LogApiDAL.Insert(stringConnTargetErp, logApiTO);
	}
}
