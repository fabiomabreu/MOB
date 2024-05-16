using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoServicoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoServicoWsModel : INotifyPropertyChanged
{
	private int? iDConfiguracaoServicoField;

	private int? iDServicoField;

	private int? intervaloField;

	private short? diaField;

	private string horarioInicioField;

	private string horarioTerminoField;

	private bool? alteradoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoServico
	{
		get
		{
			return iDConfiguracaoServicoField;
		}
		set
		{
			iDConfiguracaoServicoField = value;
			RaisePropertyChanged("IDConfiguracaoServico");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
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

	[XmlElement(IsNullable = true, Order = 2)]
	public int? Intervalo
	{
		get
		{
			return intervaloField;
		}
		set
		{
			intervaloField = value;
			RaisePropertyChanged("Intervalo");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public short? Dia
	{
		get
		{
			return diaField;
		}
		set
		{
			diaField = value;
			RaisePropertyChanged("Dia");
		}
	}

	[XmlElement(Order = 4)]
	public string HorarioInicio
	{
		get
		{
			return horarioInicioField;
		}
		set
		{
			horarioInicioField = value;
			RaisePropertyChanged("HorarioInicio");
		}
	}

	[XmlElement(Order = 5)]
	public string HorarioTermino
	{
		get
		{
			return horarioTerminoField;
		}
		set
		{
			horarioTerminoField = value;
			RaisePropertyChanged("HorarioTermino");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public bool? Alterado
	{
		get
		{
			return alteradoField;
		}
		set
		{
			alteradoField = value;
			RaisePropertyChanged("Alterado");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
