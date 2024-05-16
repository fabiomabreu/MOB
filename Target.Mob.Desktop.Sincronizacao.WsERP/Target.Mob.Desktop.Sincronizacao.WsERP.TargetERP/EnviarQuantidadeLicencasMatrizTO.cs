using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class EnviarQuantidadeLicencasMatrizTO : INotifyPropertyChanged
{
	private string cNPJField;

	private int cODIGO_PRODUTOField;

	private int qUANTIDADE_LICENCASField;

	private int qUANTIDADE_LICENCAS_PROXIMOField;

	private int qUANTIDADE_LICENCAS_FUTUROField;

	private int iD_DISTRIBUIDORAField;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 1)]
	public int CODIGO_PRODUTO
	{
		get
		{
			return cODIGO_PRODUTOField;
		}
		set
		{
			cODIGO_PRODUTOField = value;
			RaisePropertyChanged("CODIGO_PRODUTO");
		}
	}

	[XmlElement(Order = 2)]
	public int QUANTIDADE_LICENCAS
	{
		get
		{
			return qUANTIDADE_LICENCASField;
		}
		set
		{
			qUANTIDADE_LICENCASField = value;
			RaisePropertyChanged("QUANTIDADE_LICENCAS");
		}
	}

	[XmlElement(Order = 3)]
	public int QUANTIDADE_LICENCAS_PROXIMO
	{
		get
		{
			return qUANTIDADE_LICENCAS_PROXIMOField;
		}
		set
		{
			qUANTIDADE_LICENCAS_PROXIMOField = value;
			RaisePropertyChanged("QUANTIDADE_LICENCAS_PROXIMO");
		}
	}

	[XmlElement(Order = 4)]
	public int QUANTIDADE_LICENCAS_FUTURO
	{
		get
		{
			return qUANTIDADE_LICENCAS_FUTUROField;
		}
		set
		{
			qUANTIDADE_LICENCAS_FUTUROField = value;
			RaisePropertyChanged("QUANTIDADE_LICENCAS_FUTURO");
		}
	}

	[XmlElement(Order = 5)]
	public int ID_DISTRIBUIDORA
	{
		get
		{
			return iD_DISTRIBUIDORAField;
		}
		set
		{
			iD_DISTRIBUIDORAField = value;
			RaisePropertyChanged("ID_DISTRIBUIDORA");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
