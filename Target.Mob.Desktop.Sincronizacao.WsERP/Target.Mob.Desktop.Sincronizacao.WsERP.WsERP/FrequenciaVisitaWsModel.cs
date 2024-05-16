using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(FrequenciaVisitaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class FrequenciaVisitaWsModel : INotifyPropertyChanged
{
	private int? frequenciaVisitaIDField;

	private string descricaoField;

	private string tipoFrequenciaField;

	private int? quantidadeField;

	private bool? ativoField;

	private byte[] rowIDField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? FrequenciaVisitaID
	{
		get
		{
			return frequenciaVisitaIDField;
		}
		set
		{
			frequenciaVisitaIDField = value;
			RaisePropertyChanged("FrequenciaVisitaID");
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
	public string TipoFrequencia
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

	[XmlElement(IsNullable = true, Order = 3)]
	public int? Quantidade
	{
		get
		{
			return quantidadeField;
		}
		set
		{
			quantidadeField = value;
			RaisePropertyChanged("Quantidade");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
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

	[XmlElement(DataType = "base64Binary", Order = 5)]
	public byte[] RowID
	{
		get
		{
			return rowIDField;
		}
		set
		{
			rowIDField = value;
			RaisePropertyChanged("RowID");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
