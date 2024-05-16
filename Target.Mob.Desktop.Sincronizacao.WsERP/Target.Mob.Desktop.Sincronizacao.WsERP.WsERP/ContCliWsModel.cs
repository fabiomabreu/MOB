using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ContCliModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ContCliWsModel : INotifyPropertyChanged
{
	private int? iDContCliField;

	private string nomeField;

	private string cargoField;

	private long? telefoneField;

	private string timeField;

	private string hobbyField;

	private string emailField;

	private DateTime? dtAniversarioField;

	private int? codigoClienteField;

	private short? seqField;

	private int? dDDField;

	private string tpTelField;

	private bool? emailComercialField;

	private string tipoOperacaoField;

	private bool? emailNFeField;

	private bool? emailFinanceiroField;

	private bool? enviaWhatsAppEcommerceField;

	private int? idCargoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDContCli
	{
		get
		{
			return iDContCliField;
		}
		set
		{
			iDContCliField = value;
			RaisePropertyChanged("IDContCli");
		}
	}

	[XmlElement(Order = 1)]
	public string Nome
	{
		get
		{
			return nomeField;
		}
		set
		{
			nomeField = value;
			RaisePropertyChanged("Nome");
		}
	}

	[XmlElement(Order = 2)]
	public string Cargo
	{
		get
		{
			return cargoField;
		}
		set
		{
			cargoField = value;
			RaisePropertyChanged("Cargo");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public long? Telefone
	{
		get
		{
			return telefoneField;
		}
		set
		{
			telefoneField = value;
			RaisePropertyChanged("Telefone");
		}
	}

	[XmlElement(Order = 4)]
	public string Time
	{
		get
		{
			return timeField;
		}
		set
		{
			timeField = value;
			RaisePropertyChanged("Time");
		}
	}

	[XmlElement(Order = 5)]
	public string Hobby
	{
		get
		{
			return hobbyField;
		}
		set
		{
			hobbyField = value;
			RaisePropertyChanged("Hobby");
		}
	}

	[XmlElement(Order = 6)]
	public string Email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
			RaisePropertyChanged("Email");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public DateTime? DtAniversario
	{
		get
		{
			return dtAniversarioField;
		}
		set
		{
			dtAniversarioField = value;
			RaisePropertyChanged("DtAniversario");
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
	public short? Seq
	{
		get
		{
			return seqField;
		}
		set
		{
			seqField = value;
			RaisePropertyChanged("Seq");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public int? DDD
	{
		get
		{
			return dDDField;
		}
		set
		{
			dDDField = value;
			RaisePropertyChanged("DDD");
		}
	}

	[XmlElement(Order = 11)]
	public string TpTel
	{
		get
		{
			return tpTelField;
		}
		set
		{
			tpTelField = value;
			RaisePropertyChanged("TpTel");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public bool? EmailComercial
	{
		get
		{
			return emailComercialField;
		}
		set
		{
			emailComercialField = value;
			RaisePropertyChanged("EmailComercial");
		}
	}

	[XmlElement(Order = 13)]
	public string TipoOperacao
	{
		get
		{
			return tipoOperacaoField;
		}
		set
		{
			tipoOperacaoField = value;
			RaisePropertyChanged("TipoOperacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public bool? EmailNFe
	{
		get
		{
			return emailNFeField;
		}
		set
		{
			emailNFeField = value;
			RaisePropertyChanged("EmailNFe");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public bool? EmailFinanceiro
	{
		get
		{
			return emailFinanceiroField;
		}
		set
		{
			emailFinanceiroField = value;
			RaisePropertyChanged("EmailFinanceiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public bool? EnviaWhatsAppEcommerce
	{
		get
		{
			return enviaWhatsAppEcommerceField;
		}
		set
		{
			enviaWhatsAppEcommerceField = value;
			RaisePropertyChanged("EnviaWhatsAppEcommerce");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public int? IdCargo
	{
		get
		{
			return idCargoField;
		}
		set
		{
			idCargoField = value;
			RaisePropertyChanged("IdCargo");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
