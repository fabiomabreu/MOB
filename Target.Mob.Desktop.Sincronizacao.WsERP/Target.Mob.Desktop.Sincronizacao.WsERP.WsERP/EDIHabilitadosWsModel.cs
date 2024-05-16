using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EDIHabilitadosWsModel : INotifyPropertyChanged
{
	private bool? cobrancaField;

	private string chaveField;

	private DateTime? dataHabilitacaoField;

	private string cNPJField;

	private int? idLayoutEDIField;

	private int? idCadastroEDIField;

	[XmlElement(IsNullable = true, Order = 0)]
	public bool? Cobranca
	{
		get
		{
			return cobrancaField;
		}
		set
		{
			cobrancaField = value;
			RaisePropertyChanged("Cobranca");
		}
	}

	[XmlElement(Order = 1)]
	public string Chave
	{
		get
		{
			return chaveField;
		}
		set
		{
			chaveField = value;
			RaisePropertyChanged("Chave");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public DateTime? DataHabilitacao
	{
		get
		{
			return dataHabilitacaoField;
		}
		set
		{
			dataHabilitacaoField = value;
			RaisePropertyChanged("DataHabilitacao");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(IsNullable = true, Order = 4)]
	public int? IdLayoutEDI
	{
		get
		{
			return idLayoutEDIField;
		}
		set
		{
			idLayoutEDIField = value;
			RaisePropertyChanged("IdLayoutEDI");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? IdCadastroEDI
	{
		get
		{
			return idCadastroEDIField;
		}
		set
		{
			idCadastroEDIField = value;
			RaisePropertyChanged("IdCadastroEDI");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
