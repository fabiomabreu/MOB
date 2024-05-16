using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class RelatorioTrabalhoVendedorTO
{
	public int? IdRelatorioTrabalhoVendedor { get; set; }

	public DateTime? Data { get; set; }

	public int? IdVendedor { get; set; }

	public string CodigoVendedor { get; set; }

	public string Nome { get; set; }

	public int? QtdeVisitasRoteiroProgramadas { get; set; }

	public int? QtdeVisitasRoteiroRealizadas { get; set; }

	public int? QtdeVisitasForaRoteiro { get; set; }

	public int? QtdePedidos { get; set; }

	public int? QtdePedidosRoteiro { get; set; }

	public int? QtdePedidosRoteiroCliente { get; set; }

	public int? QtdePedidosForaRoteiro { get; set; }

	public int? QtdePedidosForaRoteiroCliente { get; set; }

	public decimal? KmRodado { get; set; }

	public DateTime? DataInicioTrabalho { get; set; }

	public DateTime? DataFimTrabalho { get; set; }

	public int? TempoImprodutivo { get; set; }

	public int? TempoCliente { get; set; }

	public int? TempoClienteRota { get; set; }

	public int? TempoClienteFora { get; set; }

	public int? TempoAlmoco { get; set; }

	public int? TempoTotal { get; set; }

	public DateTime? DataInicioAlmoco { get; set; }

	public DateTime? DataFimAlmoco { get; set; }

	public decimal? KmRodadoTotal { get; set; }

	public decimal? KmAjudaCusto { get; set; }

	public decimal? KmPrevistoInicio { get; set; }

	public decimal? KmPrevistoFim { get; set; }

	public decimal? KmPrevistoRoteiro { get; set; }

	public byte[] RowId { get; set; }

	public string KmAjudaCustoDescricao { get; set; }
}
