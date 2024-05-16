using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(MonitGerarDadosModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class MonitGerarDadosWsModel : INotifyPropertyChanged
{
	private DateTime dtUltimaAtualizacaoField;

	private int tempoUltimaAtualizacaoField;

	private int maiorTempoDoDiaField;

	private int menorTempoDoDiaField;

	private int mediaTempoDoDiaField;

	private int qtdeDeAtualizacoesDoDiaField;

	private int intervaloDoDiaField;

	private string versaoRetaguardaUltimaAtualizacaoField;

	[XmlElement(Order = 0)]
	public DateTime DtUltimaAtualizacao
	{
		get
		{
			return dtUltimaAtualizacaoField;
		}
		set
		{
			dtUltimaAtualizacaoField = value;
			RaisePropertyChanged("DtUltimaAtualizacao");
		}
	}

	[XmlElement(Order = 1)]
	public int TempoUltimaAtualizacao
	{
		get
		{
			return tempoUltimaAtualizacaoField;
		}
		set
		{
			tempoUltimaAtualizacaoField = value;
			RaisePropertyChanged("TempoUltimaAtualizacao");
		}
	}

	[XmlElement(Order = 2)]
	public int MaiorTempoDoDia
	{
		get
		{
			return maiorTempoDoDiaField;
		}
		set
		{
			maiorTempoDoDiaField = value;
			RaisePropertyChanged("MaiorTempoDoDia");
		}
	}

	[XmlElement(Order = 3)]
	public int MenorTempoDoDia
	{
		get
		{
			return menorTempoDoDiaField;
		}
		set
		{
			menorTempoDoDiaField = value;
			RaisePropertyChanged("MenorTempoDoDia");
		}
	}

	[XmlElement(Order = 4)]
	public int MediaTempoDoDia
	{
		get
		{
			return mediaTempoDoDiaField;
		}
		set
		{
			mediaTempoDoDiaField = value;
			RaisePropertyChanged("MediaTempoDoDia");
		}
	}

	[XmlElement(Order = 5)]
	public int QtdeDeAtualizacoesDoDia
	{
		get
		{
			return qtdeDeAtualizacoesDoDiaField;
		}
		set
		{
			qtdeDeAtualizacoesDoDiaField = value;
			RaisePropertyChanged("QtdeDeAtualizacoesDoDia");
		}
	}

	[XmlElement(Order = 6)]
	public int IntervaloDoDia
	{
		get
		{
			return intervaloDoDiaField;
		}
		set
		{
			intervaloDoDiaField = value;
			RaisePropertyChanged("IntervaloDoDia");
		}
	}

	[XmlElement(Order = 7)]
	public string VersaoRetaguardaUltimaAtualizacao
	{
		get
		{
			return versaoRetaguardaUltimaAtualizacaoField;
		}
		set
		{
			versaoRetaguardaUltimaAtualizacaoField = value;
			RaisePropertyChanged("VersaoRetaguardaUltimaAtualizacao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
