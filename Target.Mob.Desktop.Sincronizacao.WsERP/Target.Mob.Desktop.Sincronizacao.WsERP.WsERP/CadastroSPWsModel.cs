using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(CadastroSPModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class CadastroSPWsModel : INotifyPropertyChanged
{
	private int? iDCadastroSPField;

	private string descricaoField;

	private string textoField;

	private bool? ativoField;

	private bool? automaticaField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDCadastroSP
	{
		get
		{
			return iDCadastroSPField;
		}
		set
		{
			iDCadastroSPField = value;
			RaisePropertyChanged("IDCadastroSP");
		}
	}

	[XmlElement(Order = 1)]
	public string Descricao
	{
		get
		{
			return descricaoField;
		}
		set
		{
			descricaoField = value;
			RaisePropertyChanged("Descricao");
		}
	}

	[XmlElement(Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
	public bool? Ativo
	{
		get
		{
			return ativoField;
		}
		set
		{
			ativoField = value;
			RaisePropertyChanged("Ativo");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? Automatica
	{
		get
		{
			return automaticaField;
		}
		set
		{
			automaticaField = value;
			RaisePropertyChanged("Automatica");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
