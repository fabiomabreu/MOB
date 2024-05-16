using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ClientePermCompModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ClientePermCompWsModel : INotifyPropertyChanged
{
	private int codigoClienteField;

	private int? codigoDocumentoField;

	private string numeroDocumentoField;

	private DateTime? dtVencimentoField;

	private string sitRegularField;

	private bool? excluidoField;

	[XmlElement(Order = 0)]
	public int CodigoCliente
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

	[XmlElement(IsNullable = true, Order = 1)]
	public int? CodigoDocumento
	{
		get
		{
			return codigoDocumentoField;
		}
		set
		{
			codigoDocumentoField = value;
			RaisePropertyChanged("CodigoDocumento");
		}
	}

	[XmlElement(Order = 2)]
	public string NumeroDocumento
	{
		get
		{
			return numeroDocumentoField;
		}
		set
		{
			numeroDocumentoField = value;
			RaisePropertyChanged("NumeroDocumento");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? DtVencimento
	{
		get
		{
			return dtVencimentoField;
		}
		set
		{
			dtVencimentoField = value;
			RaisePropertyChanged("DtVencimento");
		}
	}

	[XmlElement(Order = 4)]
	public string SitRegular
	{
		get
		{
			return sitRegularField;
		}
		set
		{
			sitRegularField = value;
			RaisePropertyChanged("SitRegular");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public bool? Excluido
	{
		get
		{
			return excluidoField;
		}
		set
		{
			excluidoField = value;
			RaisePropertyChanged("Excluido");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
