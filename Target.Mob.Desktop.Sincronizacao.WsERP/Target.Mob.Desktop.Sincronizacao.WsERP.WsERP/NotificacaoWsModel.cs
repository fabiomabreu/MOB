using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(NotificacaoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class NotificacaoWsModel : INotifyPropertyChanged
{
	private int? idNotificacaoRetaguardaField;

	private int? idTipoNotificacaoField;

	private int idVendedorField;

	private string tituloField;

	private string descricaoField;

	private DateTime? dtTransmitidoField;

	private DateTime? dataPublicacaoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IdNotificacaoRetaguarda
	{
		get
		{
			return idNotificacaoRetaguardaField;
		}
		set
		{
			idNotificacaoRetaguardaField = value;
			RaisePropertyChanged("IdNotificacaoRetaguarda");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IdTipoNotificacao
	{
		get
		{
			return idTipoNotificacaoField;
		}
		set
		{
			idTipoNotificacaoField = value;
			RaisePropertyChanged("IdTipoNotificacao");
		}
	}

	[XmlElement(Order = 2)]
	public int IdVendedor
	{
		get
		{
			return idVendedorField;
		}
		set
		{
			idVendedorField = value;
			RaisePropertyChanged("IdVendedor");
		}
	}

	[XmlElement(Order = 3)]
	public string Titulo
	{
		get
		{
			return tituloField;
		}
		set
		{
			tituloField = value;
			RaisePropertyChanged("Titulo");
		}
	}

	[XmlElement(Order = 4)]
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

	[XmlElement(IsNullable = true, Order = 5)]
	public DateTime? DtTransmitido
	{
		get
		{
			return dtTransmitidoField;
		}
		set
		{
			dtTransmitidoField = value;
			RaisePropertyChanged("DtTransmitido");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public DateTime? DataPublicacao
	{
		get
		{
			return dataPublicacaoField;
		}
		set
		{
			dataPublicacaoField = value;
			RaisePropertyChanged("DataPublicacao");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
