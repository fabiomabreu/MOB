using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(TipoFrequenciaVisitaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class TipoFrequenciaVisitaWsModel : INotifyPropertyChanged
{
	private int? iDTipoFrequenciaVisitaField;

	private string codigoTipoFrequenciaVisitaField;

	private string descricaoTipoFrequenciaVisitaField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDTipoFrequenciaVisita
	{
		get
		{
			return iDTipoFrequenciaVisitaField;
		}
		set
		{
			iDTipoFrequenciaVisitaField = value;
			RaisePropertyChanged("IDTipoFrequenciaVisita");
		}
	}

	[XmlElement(Order = 1)]
	public string CodigoTipoFrequenciaVisita
	{
		get
		{
			return codigoTipoFrequenciaVisitaField;
		}
		set
		{
			codigoTipoFrequenciaVisitaField = value;
			RaisePropertyChanged("CodigoTipoFrequenciaVisita");
		}
	}

	[XmlElement(Order = 2)]
	public string DescricaoTipoFrequenciaVisita
	{
		get
		{
			return descricaoTipoFrequenciaVisitaField;
		}
		set
		{
			descricaoTipoFrequenciaVisitaField = value;
			RaisePropertyChanged("DescricaoTipoFrequenciaVisita");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
