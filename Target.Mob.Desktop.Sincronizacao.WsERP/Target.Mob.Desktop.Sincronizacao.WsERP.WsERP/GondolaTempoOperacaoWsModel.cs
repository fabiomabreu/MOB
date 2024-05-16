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
public class GondolaTempoOperacaoWsModel : INotifyPropertyChanged
{
	private int codigoField;

	private int codigoClienteField;

	private DateTime dataInicioField;

	private DateTime dataFimField;

	private bool transmitidoField;

	private bool excluidoField;

	private int numeroPedidoField;

	private int idPedVdaField;

	[XmlElement(Order = 0)]
	public int Codigo
	{
		get
		{
			return codigoField;
		}
		set
		{
			codigoField = value;
			RaisePropertyChanged("Codigo");
		}
	}

	[XmlElement(Order = 1)]
	public int CodigoCliente
	{
		get
		{
			return codigoClienteField;
		}
		set
		{
			codigoClienteField = value;
			RaisePropertyChanged("CodigoCliente");
		}
	}

	[XmlElement(Order = 2)]
	public DateTime DataInicio
	{
		get
		{
			return dataInicioField;
		}
		set
		{
			dataInicioField = value;
			RaisePropertyChanged("DataInicio");
		}
	}

	[XmlElement(Order = 3)]
	public DateTime DataFim
	{
		get
		{
			return dataFimField;
		}
		set
		{
			dataFimField = value;
			RaisePropertyChanged("DataFim");
		}
	}

	[XmlElement(Order = 4)]
	public bool Transmitido
	{
		get
		{
			return transmitidoField;
		}
		set
		{
			transmitidoField = value;
			RaisePropertyChanged("Transmitido");
		}
	}

	[XmlElement(Order = 5)]
	public bool Excluido
	{
		get
		{
			return excluidoField;
		}
		set
		{
			excluidoField = value;
			RaisePropertyChanged("Excluido");
		}
	}

	[XmlElement(Order = 6)]
	public int NumeroPedido
	{
		get
		{
			return numeroPedidoField;
		}
		set
		{
			numeroPedidoField = value;
			RaisePropertyChanged("NumeroPedido");
		}
	}

	[XmlElement(Order = 7)]
	public int IdPedVda
	{
		get
		{
			return idPedVdaField;
		}
		set
		{
			idPedVdaField = value;
			RaisePropertyChanged("IdPedVda");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
