using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ServicoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ServicoWsModel : INotifyPropertyChanged
{
	private int? iDServicoField;

	private bool? statusField;

	private string nomeField;

	private ConfiguracaoServicoWsModel[] configuracaoServicoField;

	private bool? principalField;

	private int? codigoServicoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDServico
	{
		get
		{
			return iDServicoField;
		}
		set
		{
			iDServicoField = value;
			RaisePropertyChanged("IDServico");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public bool? Status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
			RaisePropertyChanged("Status");
		}
	}

	[XmlElement(Order = 2)]
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

	[XmlArray(Order = 3)]
	public ConfiguracaoServicoWsModel[] ConfiguracaoServico
	{
		get
		{
			return configuracaoServicoField;
		}
		set
		{
			configuracaoServicoField = value;
			RaisePropertyChanged("ConfiguracaoServico");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? Principal
	{
		get
		{
			return principalField;
		}
		set
		{
			principalField = value;
			RaisePropertyChanged("Principal");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public int? CodigoServico
	{
		get
		{
			return codigoServicoField;
		}
		set
		{
			codigoServicoField = value;
			RaisePropertyChanged("CodigoServico");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
