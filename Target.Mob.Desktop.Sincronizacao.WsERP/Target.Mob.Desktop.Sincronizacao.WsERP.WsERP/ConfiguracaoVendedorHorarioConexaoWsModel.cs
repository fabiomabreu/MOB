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
public class ConfiguracaoVendedorHorarioConexaoWsModel : INotifyPropertyChanged
{
	private int idConfiguracaoVendedorHorarioConexaoField;

	private int? idConfiguracaoVendedorField;

	private int? codigoDiaSemanaVisitaField;

	private DateTime? horarioInicioField;

	private DateTime? horarioFimField;

	[XmlElement(Order = 0)]
	public int IdConfiguracaoVendedorHorarioConexao
	{
		get
		{
			return idConfiguracaoVendedorHorarioConexaoField;
		}
		set
		{
			idConfiguracaoVendedorHorarioConexaoField = value;
			RaisePropertyChanged("IdConfiguracaoVendedorHorarioConexao");
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
	public DateTime? HorarioInicio
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

	[XmlElement(IsNullable = true, Order = 4)]
	public DateTime? HorarioFim
	{
		get
		{
			return horarioFimField;
		}
		set
		{
			horarioFimField = value;
			RaisePropertyChanged("HorarioFim");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
