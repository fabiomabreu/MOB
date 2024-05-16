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
public class DispositivoMovelModel : INotifyPropertyChanged
{
	private int? iDDispositivoMovelField;

	private string descricaoField;

	private bool? ativoField;

	private int? iDSistemaOperacionalVersaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDDispositivoMovel
	{
		get
		{
			return iDDispositivoMovelField;
		}
		set
		{
			iDDispositivoMovelField = value;
			RaisePropertyChanged("IDDispositivoMovel");
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

	[XmlElement(IsNullable = true, Order = 2)]
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

	[XmlElement(IsNullable = true, Order = 3)]
	public int? IDSistemaOperacionalVersao
	{
		get
		{
			return iDSistemaOperacionalVersaoField;
		}
		set
		{
			iDSistemaOperacionalVersaoField = value;
			RaisePropertyChanged("IDSistemaOperacionalVersao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
