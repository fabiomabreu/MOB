using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(AnotacaoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class AnotacaoWsModel : INotifyPropertyChanged
{
	private int? iDAnotacaoField;

	private int? codigoAnotacaoField;

	private int? codigoCategoriaAnotacaoField;

	private DateTime? dataHoraField;

	private int? codigoEmpresaField;

	private int? numeroPedVdaField;

	private string textoField;

	private int? iDVendedorField;

	private int? codigoClienteField;

	private bool? clienteBDMovimentoField;

	private string cnpjCpfClienteField;

	private int? codigoClienteProspeccaoField;

	private DateTime? dtLembreteField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDAnotacao
	{
		get
		{
			return iDAnotacaoField;
		}
		set
		{
			iDAnotacaoField = value;
			RaisePropertyChanged("IDAnotacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? CodigoAnotacao
	{
		get
		{
			return codigoAnotacaoField;
		}
		set
		{
			codigoAnotacaoField = value;
			RaisePropertyChanged("CodigoAnotacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? CodigoCategoriaAnotacao
	{
		get
		{
			return codigoCategoriaAnotacaoField;
		}
		set
		{
			codigoCategoriaAnotacaoField = value;
			RaisePropertyChanged("CodigoCategoriaAnotacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? DataHora
	{
		get
		{
			return dataHoraField;
		}
		set
		{
			dataHoraField = value;
			RaisePropertyChanged("DataHora");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public int? CodigoEmpresa
	{
		get
		{
			return codigoEmpresaField;
		}
		set
		{
			codigoEmpresaField = value;
			RaisePropertyChanged("CodigoEmpresa");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? NumeroPedVda
	{
		get
		{
			return numeroPedVdaField;
		}
		set
		{
			numeroPedVdaField = value;
			RaisePropertyChanged("NumeroPedVda");
		}
	}

	[XmlElement(Order = 6)]
	public string Texto
	{
		get
		{
			return textoField;
		}
		set
		{
			textoField = value;
			RaisePropertyChanged("Texto");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public int? IDVendedor
	{
		get
		{
			return iDVendedorField;
		}
		set
		{
			iDVendedorField = value;
			RaisePropertyChanged("IDVendedor");
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

	[XmlElement(Order = 10)]
	public string CnpjCpfCliente
	{
		get
		{
			return cnpjCpfClienteField;
		}
		set
		{
			cnpjCpfClienteField = value;
			RaisePropertyChanged("CnpjCpfCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? CodigoClienteProspeccao
	{
		get
		{
			return codigoClienteProspeccaoField;
		}
		set
		{
			codigoClienteProspeccaoField = value;
			RaisePropertyChanged("CodigoClienteProspeccao");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public DateTime? DtLembrete
	{
		get
		{
			return dtLembreteField;
		}
		set
		{
			dtLembreteField = value;
			RaisePropertyChanged("DtLembrete");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
