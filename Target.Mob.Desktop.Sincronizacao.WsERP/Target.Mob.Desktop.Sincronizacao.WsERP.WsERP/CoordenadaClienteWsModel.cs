using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(CoordenadaClienteModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class CoordenadaClienteWsModel : INotifyPropertyChanged
{
	private int idCoordenadaClienteField;

	private int? idVendedorField;

	private DateTime? dtCoordenadaField;

	private decimal? latitudeField;

	private decimal? longitudeField;

	private int? codigoProvedorCoordenadaField;

	private bool? clienteBDMovimentoField;

	private string cNPJField;

	private int? codigoClienteField;

	private DateTime? dtRecebimentoField;

	private DateTime? dtImportacaoField;

	private string codigoTipoEnderecoField;

	private int? promotorIdField;

	[XmlElement(Order = 0)]
	public int IdCoordenadaCliente
	{
		get
		{
			return idCoordenadaClienteField;
		}
		set
		{
			idCoordenadaClienteField = value;
			RaisePropertyChanged("IdCoordenadaCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IdVendedor
	{
		get
		{
			return idVendedorField;
		}
		set
		{
			idVendedorField = value;
			RaisePropertyChanged("IdVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public DateTime? DtCoordenada
	{
		get
		{
			return dtCoordenadaField;
		}
		set
		{
			dtCoordenadaField = value;
			RaisePropertyChanged("DtCoordenada");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public decimal? Latitude
	{
		get
		{
			return latitudeField;
		}
		set
		{
			latitudeField = value;
			RaisePropertyChanged("Latitude");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public decimal? Longitude
	{
		get
		{
			return longitudeField;
		}
		set
		{
			longitudeField = value;
			RaisePropertyChanged("Longitude");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? CodigoProvedorCoordenada
	{
		get
		{
			return codigoProvedorCoordenadaField;
		}
		set
		{
			codigoProvedorCoordenadaField = value;
			RaisePropertyChanged("CodigoProvedorCoordenada");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public bool? ClienteBDMovimento
	{
		get
		{
			return clienteBDMovimentoField;
		}
		set
		{
			clienteBDMovimentoField = value;
			RaisePropertyChanged("ClienteBDMovimento");
		}
	}

	[XmlElement(Order = 7)]
	public string CNPJ
	{
		get
		{
			return cNPJField;
		}
		set
		{
			cNPJField = value;
			RaisePropertyChanged("CNPJ");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public int? CodigoCliente
	{
		get
		{
			return codigoClienteField;
		}
		set
		{
			codigoClienteField = value;
			RaisePropertyChanged("CodigoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public DateTime? DtRecebimento
	{
		get
		{
			return dtRecebimentoField;
		}
		set
		{
			dtRecebimentoField = value;
			RaisePropertyChanged("DtRecebimento");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public DateTime? DtImportacao
	{
		get
		{
			return dtImportacaoField;
		}
		set
		{
			dtImportacaoField = value;
			RaisePropertyChanged("DtImportacao");
		}
	}

	[XmlElement(Order = 11)]
	public string CodigoTipoEndereco
	{
		get
		{
			return codigoTipoEnderecoField;
		}
		set
		{
			codigoTipoEnderecoField = value;
			RaisePropertyChanged("CodigoTipoEndereco");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public int? PromotorId
	{
		get
		{
			return promotorIdField;
		}
		set
		{
			promotorIdField = value;
			RaisePropertyChanged("PromotorId");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
