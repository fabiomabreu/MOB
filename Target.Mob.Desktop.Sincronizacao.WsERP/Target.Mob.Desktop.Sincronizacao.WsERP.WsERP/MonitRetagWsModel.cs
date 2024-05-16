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
public class MonitRetagWsModel : INotifyPropertyChanged
{
	private int idMonitRetagField;

	private MonitRetagCPUWsModel[] monitRetagCPUField;

	private MonitRetagEspacoLivreUnidadeWsModel[] monitRetagEspacoLivreUnidadeField;

	private MonitRetagInformacoesFileDBWsModel[] monitRetagInformacoesFileDBField;

	private DateTime dataField;

	private string versaoRetaguardaField;

	private long? espacoLivreDiscoAPPField;

	private long? utilizacaoCPUField;

	private int? qtdeServicosInstaladosField;

	private int? pedidosPendLibManualQtdeField;

	private DateTime? pedidosPendLibManualMaisAntigoField;

	private int? pedidosPendLibAutoQtdeField;

	private DateTime? pedidosPendLibAutoMaisAntigoField;

	private int? cargaPendEnvioQtdeField;

	private DateTime? cargaPendEnvioMaisAntigoField;

	private int? atendimentoPendEnvioQtdeField;

	private DateTime? atendimentoPendEnvioMaisAntigoField;

	private int? relatorioPendEnvioQtdeField;

	private DateTime? relatorioPendEnvioMaisAntigoField;

	[XmlElement(Order = 0)]
	public int IdMonitRetag
	{
		get
		{
			return idMonitRetagField;
		}
		set
		{
			idMonitRetagField = value;
			RaisePropertyChanged("IdMonitRetag");
		}
	}

	[XmlArray(Order = 1)]
	public MonitRetagCPUWsModel[] MonitRetagCPU
	{
		get
		{
			return monitRetagCPUField;
		}
		set
		{
			monitRetagCPUField = value;
			RaisePropertyChanged("MonitRetagCPU");
		}
	}

	[XmlArray(Order = 2)]
	public MonitRetagEspacoLivreUnidadeWsModel[] MonitRetagEspacoLivreUnidade
	{
		get
		{
			return monitRetagEspacoLivreUnidadeField;
		}
		set
		{
			monitRetagEspacoLivreUnidadeField = value;
			RaisePropertyChanged("MonitRetagEspacoLivreUnidade");
		}
	}

	[XmlArray(Order = 3)]
	public MonitRetagInformacoesFileDBWsModel[] MonitRetagInformacoesFileDB
	{
		get
		{
			return monitRetagInformacoesFileDBField;
		}
		set
		{
			monitRetagInformacoesFileDBField = value;
			RaisePropertyChanged("MonitRetagInformacoesFileDB");
		}
	}

	[XmlElement(Order = 4)]
	public DateTime Data
	{
		get
		{
			return dataField;
		}
		set
		{
			dataField = value;
			RaisePropertyChanged("Data");
		}
	}

	[XmlElement(Order = 5)]
	public string VersaoRetaguarda
	{
		get
		{
			return versaoRetaguardaField;
		}
		set
		{
			versaoRetaguardaField = value;
			RaisePropertyChanged("VersaoRetaguarda");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public long? EspacoLivreDiscoAPP
	{
		get
		{
			return espacoLivreDiscoAPPField;
		}
		set
		{
			espacoLivreDiscoAPPField = value;
			RaisePropertyChanged("EspacoLivreDiscoAPP");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public long? UtilizacaoCPU
	{
		get
		{
			return utilizacaoCPUField;
		}
		set
		{
			utilizacaoCPUField = value;
			RaisePropertyChanged("UtilizacaoCPU");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public int? QtdeServicosInstalados
	{
		get
		{
			return qtdeServicosInstaladosField;
		}
		set
		{
			qtdeServicosInstaladosField = value;
			RaisePropertyChanged("QtdeServicosInstalados");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public int? PedidosPendLibManualQtde
	{
		get
		{
			return pedidosPendLibManualQtdeField;
		}
		set
		{
			pedidosPendLibManualQtdeField = value;
			RaisePropertyChanged("PedidosPendLibManualQtde");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public DateTime? PedidosPendLibManualMaisAntigo
	{
		get
		{
			return pedidosPendLibManualMaisAntigoField;
		}
		set
		{
			pedidosPendLibManualMaisAntigoField = value;
			RaisePropertyChanged("PedidosPendLibManualMaisAntigo");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public int? PedidosPendLibAutoQtde
	{
		get
		{
			return pedidosPendLibAutoQtdeField;
		}
		set
		{
			pedidosPendLibAutoQtdeField = value;
			RaisePropertyChanged("PedidosPendLibAutoQtde");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public DateTime? PedidosPendLibAutoMaisAntigo
	{
		get
		{
			return pedidosPendLibAutoMaisAntigoField;
		}
		set
		{
			pedidosPendLibAutoMaisAntigoField = value;
			RaisePropertyChanged("PedidosPendLibAutoMaisAntigo");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public int? CargaPendEnvioQtde
	{
		get
		{
			return cargaPendEnvioQtdeField;
		}
		set
		{
			cargaPendEnvioQtdeField = value;
			RaisePropertyChanged("CargaPendEnvioQtde");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public DateTime? CargaPendEnvioMaisAntigo
	{
		get
		{
			return cargaPendEnvioMaisAntigoField;
		}
		set
		{
			cargaPendEnvioMaisAntigoField = value;
			RaisePropertyChanged("CargaPendEnvioMaisAntigo");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public int? AtendimentoPendEnvioQtde
	{
		get
		{
			return atendimentoPendEnvioQtdeField;
		}
		set
		{
			atendimentoPendEnvioQtdeField = value;
			RaisePropertyChanged("AtendimentoPendEnvioQtde");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public DateTime? AtendimentoPendEnvioMaisAntigo
	{
		get
		{
			return atendimentoPendEnvioMaisAntigoField;
		}
		set
		{
			atendimentoPendEnvioMaisAntigoField = value;
			RaisePropertyChanged("AtendimentoPendEnvioMaisAntigo");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public int? RelatorioPendEnvioQtde
	{
		get
		{
			return relatorioPendEnvioQtdeField;
		}
		set
		{
			relatorioPendEnvioQtdeField = value;
			RaisePropertyChanged("RelatorioPendEnvioQtde");
		}
	}

	[XmlElement(IsNullable = true, Order = 18)]
	public DateTime? RelatorioPendEnvioMaisAntigo
	{
		get
		{
			return relatorioPendEnvioMaisAntigoField;
		}
		set
		{
			relatorioPendEnvioMaisAntigoField = value;
			RaisePropertyChanged("RelatorioPendEnvioMaisAntigo");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
