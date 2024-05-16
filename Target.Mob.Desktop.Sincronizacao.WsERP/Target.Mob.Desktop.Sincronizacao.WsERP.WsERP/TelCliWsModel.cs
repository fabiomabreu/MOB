using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(TelCliModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class TelCliWsModel : INotifyPropertyChanged
{
	private int? iDTelCliField;

	private string dDDField;

	private long? telefoneField;

	private int? complementoField;

	private int? codigoClienteField;

	private string codigoTpTelField;

	private short? seqField;

	private string tipoOperacaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDTelCli
	{
		get
		{
			return iDTelCliField;
		}
		set
		{
			iDTelCliField = value;
			RaisePropertyChanged("IDTelCli");
		}
	}

	[XmlElement(Order = 1)]
	public string DDD
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

	[XmlElement(IsNullable = true, Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
	public int? Complemento
	{
		get
		{
			return complementoField;
		}
		set
		{
			complementoField = value;
			RaisePropertyChanged("Complemento");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
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

	[XmlElement(Order = 5)]
	public string CodigoTpTel
	{
		get
		{
			return codigoTpTelField;
		}
		set
		{
			codigoTpTelField = value;
			RaisePropertyChanged("CodigoTpTel");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
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

	[XmlElement(Order = 7)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
