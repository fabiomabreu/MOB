using System;

namespace Target.Mob.Desktop.Api.Model;

public class IndenizacaoTO
{
	public int? IndenizacaoID { get; set; }

	public DateTime? DataInclusao { get; set; }

	public int? CdClien { get; set; }

	public string CdVend { get; set; }

	public int? CdEmp { get; set; }

	public byte? IndenizacaoStatusID { get; set; }

	public byte? IndenizacaoTipoCreditoID { get; set; }

	public decimal? PercIndenizacao { get; set; }

	public decimal? PercProxVenda { get; set; }

	public decimal? ValorTotal { get; set; }

	public DateTime? DataNotaFiscalCliente { get; set; }

	public int? NumeroNotaFiscalCliente { get; set; }

	public DateTime? DataVencimentoBoletoCliente { get; set; }

	public decimal? ValorCreditoAplicado { get; set; }

	public decimal? ValorCreditoRestante { get; set; }

	public string UUID { get; set; }

	public IndenizacaoItemTO[] IndenizacaoItem { get; set; }

	public IndenizacaoHistoricoTO[] IndenizacaoHistorico { get; set; }

	public IndenizacaoTO()
	{
	}

	public IndenizacaoTO(int indenizacaoID)
	{
		IndenizacaoID = indenizacaoID;
	}

	public IndenizacaoTO(string uuid)
	{
		UUID = uuid;
	}
}
