using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(DiaSemanaVisitaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class DiaSemanaVisitaWsModel : INotifyPropertyChanged
{
	private int? iDDiaSemanaVisitaField;

	private string codigoDiaSemanaVisitaField;

	private string descricaoDiaSemanaVisitaField;

	[XmlElement(IsNullable = true, Order = 0)]
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

	[XmlElement(Order = 1)]
	public string CodigoDiaSemanaVisita
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

	[XmlElement(Order = 2)]
	public string DescricaoDiaSemanaVisita
	{
		get
		{
			return descricaoDiaSemanaVisitaField;
		}
		set
		{
			descricaoDiaSemanaVisitaField = value;
			RaisePropertyChanged("DescricaoDiaSemanaVisita");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
