using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorVisitaDiasSemanaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorVisitaDiasSemanaWsModel : INotifyPropertyChanged
{
	private int? iDConfiguracaoVendedorVisitaDiasSemanaField;

	private int? iDConfiguracaoVendedorField;

	private int? iDDiaSemanaVisitaField;

	private DiaSemanaVisitaWsModel diadasemanaField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoVendedorVisitaDiasSemana
	{
		get
		{
			return iDConfiguracaoVendedorVisitaDiasSemanaField;
		}
		set
		{
			iDConfiguracaoVendedorVisitaDiasSemanaField = value;
			RaisePropertyChanged("IDConfiguracaoVendedorVisitaDiasSemana");
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
	public int? IDDiaSemanaVisita
	{
		get
		{
			return iDDiaSemanaVisitaField;
		}
		set
		{
			iDDiaSemanaVisitaField = value;
			RaisePropertyChanged("IDDiaSemanaVisita");
		}
	}

	[XmlElement(Order = 3)]
	public DiaSemanaVisitaWsModel Diadasemana
	{
		get
		{
			return diadasemanaField;
		}
		set
		{
			diadasemanaField = value;
			RaisePropertyChanged("Diadasemana");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
