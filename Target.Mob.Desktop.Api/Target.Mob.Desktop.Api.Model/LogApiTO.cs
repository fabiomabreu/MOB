using System;

namespace Target.Mob.Desktop.Api.Model;

public class LogApiTO
{
	public int Idlog { get; set; }

	public string Acao { get; set; }

	public DateTime Data { get; set; }

	public string Rota { get; set; }

	public string Ip { get; set; }

	public string Usuario { get; set; }

	public string RequestHeader { get; set; }

	public string RequestBody { get; set; }

	public string Response { get; set; }

	public int StatusCode { get; set; }
}
