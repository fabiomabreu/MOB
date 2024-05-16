using System.Collections.Generic;

namespace Target.Mob.Desktop.Api.Model;

public class ImagemClienteTO
{
	public string CodigoVendedor { get; set; }

	public int CodigoCliente { get; set; }

	public bool ClienteBdMovimento { get; set; }

	public string CnpjCpf { get; set; }

	public List<ArquivoImagemClienteTO> Arquivos { get; set; }

	public string Erro { get; set; }
}
