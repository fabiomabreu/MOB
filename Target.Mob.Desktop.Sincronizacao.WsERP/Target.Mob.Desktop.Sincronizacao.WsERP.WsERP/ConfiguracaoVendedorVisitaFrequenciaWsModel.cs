using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorVisitaFrequenciaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorVisitaFrequenciaWsModel : INotifyPropertyChanged
{
	private int? iDConfiguracaoVendedorVisitaFrequenciaField;

	private int? iDConfiguracaoVendedorField;

	private int? iDTipoFrequenciaVisitaField;

	private TipoFrequenciaVisitaWsModel tipoFrequenciaField;

	private int? frequenciaVisitaIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoVendedorVisitaFrequencia
	{
		get
		{
			return iDConfiguracaoVendedorVisitaFrequenciaField;
		}
		set
		{
			iDConfiguracaoVendedorVisitaFrequenciaField = value;
			RaisePropertyChanged("IDConfiguracaoVendedorVisitaFrequencia");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IDConfiguracaoVendedor
	{
		get
		{
			return iDConfiguracaoVendedorField;
		}
		set
		{
			iDConfiguracaoVendedorField = value;
			RaisePropertyChanged("IDConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
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

	[XmlElement(Order = 3)]
	public TipoFrequenciaVisitaWsModel TipoFrequencia
	{
		get
		{
			return tipoFrequenciaField;
		}
		set
		{
			tipoFrequenciaField = value;
			RaisePropertyChanged("TipoFrequencia");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public int? FrequenciaVisitaId
	{
		get
		{
			return frequenciaVisitaIdField;
		}
		set
		{
			frequenciaVisitaIdField = value;
			RaisePropertyChanged("FrequenciaVisitaId");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
