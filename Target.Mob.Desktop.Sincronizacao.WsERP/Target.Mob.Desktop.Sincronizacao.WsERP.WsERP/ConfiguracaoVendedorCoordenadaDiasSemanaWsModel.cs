using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorCoordenadaDiasSemanaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorCoordenadaDiasSemanaWsModel : INotifyPropertyChanged
{
	private int idConfiguracaoVendedorCoordenadaDiasSemanaField;

	private int? idConfiguracaoVendedorField;

	private int? codigoDiaSemanaVisitaField;

	private DateTime? horarioInicioCoordenadaField;

	private DateTime? horarioFimCoordenadaField;

	[XmlElement(Order = 0)]
	public int IdConfiguracaoVendedorCoordenadaDiasSemana
	{
		get
		{
			return idConfiguracaoVendedorCoordenadaDiasSemanaField;
		}
		set
		{
			idConfiguracaoVendedorCoordenadaDiasSemanaField = value;
			RaisePropertyChanged("IdConfiguracaoVendedorCoordenadaDiasSemana");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IdConfiguracaoVendedor
	{
		get
		{
			return idConfiguracaoVendedorField;
		}
		set
		{
			idConfiguracaoVendedorField = value;
			RaisePropertyChanged("IdConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? CodigoDiaSemanaVisita
	{
		get
		{
			return codigoDiaSemanaVisitaField;
		}
		set
		{
			codigoDiaSemanaVisitaField = value;
			RaisePropertyChanged("CodigoDiaSemanaVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public DateTime? HorarioInicioCoordenada
	{
		get
		{
			return horarioInicioCoordenadaField;
		}
		set
		{
			horarioInicioCoordenadaField = value;
			RaisePropertyChanged("HorarioInicioCoordenada");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public DateTime? HorarioFimCoordenada
	{
		get
		{
			return horarioFimCoordenadaField;
		}
		set
		{
			horarioFimCoordenadaField = value;
			RaisePropertyChanged("HorarioFimCoordenada");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
