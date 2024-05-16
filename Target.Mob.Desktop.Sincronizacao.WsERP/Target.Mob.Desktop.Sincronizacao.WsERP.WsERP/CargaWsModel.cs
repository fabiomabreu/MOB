using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(CargaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class CargaWsModel : INotifyPropertyChanged
{
	private int? codigoCargaField;

	private DateTime? dataGeracaoField;

	private int? iDVersaoCargaField;

	private int? iDGeracaoField;

	private int? iDTipoCargaTRField;

	private byte[] arquivoCargaField;

	private int? iDVendedorField;

	private string linkField;

	private int? majorField;

	private int? minorField;

	private int? buildField;

	private int? revisionField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? CodigoCarga
	{
		get
		{
			return codigoCargaField;
		}
		set
		{
			codigoCargaField = value;
			RaisePropertyChanged("CodigoCarga");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public DateTime? DataGeracao
	{
		get
		{
			return dataGeracaoField;
		}
		set
		{
			dataGeracaoField = value;
			RaisePropertyChanged("DataGeracao");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? IDVersaoCarga
	{
		get
		{
			return iDVersaoCargaField;
		}
		set
		{
			iDVersaoCargaField = value;
			RaisePropertyChanged("IDVersaoCarga");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public int? IDGeracao
	{
		get
		{
			return iDGeracaoField;
		}
		set
		{
			iDGeracaoField = value;
			RaisePropertyChanged("IDGeracao");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public int? IDTipoCargaTR
	{
		get
		{
			return iDTipoCargaTRField;
		}
		set
		{
			iDTipoCargaTRField = value;
			RaisePropertyChanged("IDTipoCargaTR");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 5)]
	public byte[] ArquivoCarga
	{
		get
		{
			return arquivoCargaField;
		}
		set
		{
			arquivoCargaField = value;
			RaisePropertyChanged("ArquivoCarga");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
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

	[XmlElement(Order = 7)]
	public string Link
	{
		get
		{
			return linkField;
		}
		set
		{
			linkField = value;
			RaisePropertyChanged("Link");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public int? Major
	{
		get
		{
			return majorField;
		}
		set
		{
			majorField = value;
			RaisePropertyChanged("Major");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? Minor
	{
		get
		{
			return minorField;
		}
		set
		{
			minorField = value;
			RaisePropertyChanged("Minor");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public int? Build
	{
		get
		{
			return buildField;
		}
		set
		{
			buildField = value;
			RaisePropertyChanged("Build");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? Revision
	{
		get
		{
			return revisionField;
		}
		set
		{
			revisionField = value;
			RaisePropertyChanged("Revision");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
