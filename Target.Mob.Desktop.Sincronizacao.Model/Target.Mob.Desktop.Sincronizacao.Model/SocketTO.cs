using System.Collections.Generic;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class SocketTO
{
	public string IdCargaEntidade { get; set; }

	public string Token { get; set; }

	public string CNPJ { get; set; }

	public string ChaveDispositivo { get; set; }

	public string IdVendedor { get; set; }

	public string CodigoVendedor { get; set; }

	public string Acao { get; set; }

	public string AcaoRetag { get; set; }

	public string Parametros { get; set; }

	public string[] MensagemRetorno { get; set; }

	public string TotalRows { get; set; }

	public string MensagemErro { get; set; }

	public string TipoCliente { get; set; }

	public string Sistema { get; set; }

	public List<string> Documentos { get; set; }
}
