using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(GerenciaPromotorModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class GerenciaPromotorWsModel : INotifyPropertyChanged
{
	private int? gerenciaPromotorIdField;

	private int? cdEmpField;

	private string cdGerenciaField;

	private string descricaoField;

	private string cdPromotorGerenteField;

	private bool? ativoField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
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
	public string CdGerencia
	{
		get
		{
			return cdGerenciaField;
		}
		set
		{
			cdGerenciaField = value;
			RaisePropertyChanged("CdGerencia");
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
	public string CdPromotorGerente
	{
		get
		{
			return cdPromotorGerenteField;
		}
		set
		{
			cdPromotorGerenteField = value;
			RaisePropertyChanged("CdPromotorGerente");
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

	[XmlElement(DataType = "base64Binary", Order = 6)]
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
