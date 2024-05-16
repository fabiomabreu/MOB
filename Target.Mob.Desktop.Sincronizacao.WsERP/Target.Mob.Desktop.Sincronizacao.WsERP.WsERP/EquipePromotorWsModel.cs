using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(EquipePromotorModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EquipePromotorWsModel : INotifyPropertyChanged
{
	private int? equipePromotorIdField;

	private int? cdEmpField;

	private string cdEquipeField;

	private string descricaoField;

	private string cdPromotorSupervisorField;

	private bool? ativoField;

	private int? gerenciaPromotorIdField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? EquipePromotorId
	{
		get
		{
			return equipePromotorIdField;
		}
		set
		{
			equipePromotorIdField = value;
			RaisePropertyChanged("EquipePromotorId");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? CdEmp
	{
		get
		{
			return cdEmpField;
		}
		set
		{
			cdEmpField = value;
			RaisePropertyChanged("CdEmp");
		}
	}

	[XmlElement(Order = 2)]
	public string CdEquipe
	{
		get
		{
			return cdEquipeField;
		}
		set
		{
			cdEquipeField = value;
			RaisePropertyChanged("CdEquipe");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
	public string CdPromotorSupervisor
	{
		get
		{
			return cdPromotorSupervisorField;
		}
		set
		{
			cdPromotorSupervisorField = value;
			RaisePropertyChanged("CdPromotorSupervisor");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
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

	[XmlElement(IsNullable = true, Order = 6)]
	public int? GerenciaPromotorId
	{
		get
		{
			return gerenciaPromotorIdField;
		}
		set
		{
			gerenciaPromotorIdField = value;
			RaisePropertyChanged("GerenciaPromotorId");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 7)]
	public byte[] RowId
	{
		get
		{
			return rowIdField;
		}
		set
		{
			rowIdField = value;
			RaisePropertyChanged("RowId");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
