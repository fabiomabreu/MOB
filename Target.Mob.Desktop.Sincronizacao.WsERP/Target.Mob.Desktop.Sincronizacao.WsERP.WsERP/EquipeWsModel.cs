using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(EquipeModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EquipeWsModel : INotifyPropertyChanged
{
	private string cdEquipeField;

	private string descricaoField;

	private string cdVendSupField;

	private bool? ativoField;

	private string cdGerenciaField;

	private int? codigoEmpresaField;

	private byte[] rowIdField;

	[XmlElement(Order = 0)]
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

	[XmlElement(Order = 2)]
	public string CdVendSup
	{
		get
		{
			return cdVendSupField;
		}
		set
		{
			cdVendSupField = value;
			RaisePropertyChanged("CdVendSup");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
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

	[XmlElement(Order = 4)]
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

	[XmlElement(IsNullable = true, Order = 5)]
	public int? CodigoEmpresa
	{
		get
		{
			return codigoEmpresaField;
		}
		set
		{
			codigoEmpresaField = value;
			RaisePropertyChanged("CodigoEmpresa");
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
