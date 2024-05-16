using System.Collections.Generic;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class PromotorTO
{
	public int? PromotorId { get; set; }

	public string CdPromotor { get; set; }

	public string Cgc { get; set; }

	public string Inscricao { get; set; }

	public string Nome { get; set; }

	public string Endereco { get; set; }

	public string Bairro { get; set; }

	public string Municipio { get; set; }

	public string Estado { get; set; }

	public int? Cep { get; set; }

	public string TpPessoa { get; set; }

	public bool? Ativo { get; set; }

	public int? CdCepMunicipio { get; set; }

	public string Logradouro { get; set; }

	public string Numero { get; set; }

	public string Complemento { get; set; }

	public string CdPais { get; set; }

	public string Distrito { get; set; }

	public string NomeGuerra { get; set; }

	public int? EquipePromotorId { get; set; }

	public decimal? Latitude { get; set; }

	public decimal? Longitude { get; set; }

	public string Email { get; set; }

	public byte? MontagemRotVisitaId { get; set; }

	public bool? UtilizaPocket { get; set; }

	public byte[] RowId { get; set; }

	public List<ContPromotorTO> ListContPromotor { get; set; }

	public List<TelPromotorTO> ListTelPromotor { get; set; }
}
