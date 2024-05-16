using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PagamentoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PagamentoWsModel : INotifyPropertyChanged
{
	private int idPagamentoField;

	private int idPgtoMobField;

	private DateTime dataPgtoField;

	private int codigoClienteField;

	private string formaPgtoField;

	private double valorPgtoField;

	private string codigoVendedorField;

	[XmlElement(Order = 0)]
	public int IdPagamento
	{
		get
		{
			return idPagamentoField;
		}
		set
		{
			idPagamentoField = value;
			RaisePropertyChanged("IdPagamento");
		}
	}

	[XmlElement(Order = 1)]
	public int IdPgtoMob
	{
		get
		{
			return idPgtoMobField;
		}
		set
		{
			idPgtoMobField = value;
			RaisePropertyChanged("IdPgtoMob");
		}
	}

	[XmlElement(Order = 2)]
	public DateTime DataPgto
	{
		get
		{
			return dataPgtoField;
		}
		set
		{
			dataPgtoField = value;
			RaisePropertyChanged("DataPgto");
		}
	}

	[XmlElement(Order = 3)]
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

	[XmlElement(Order = 4)]
	public string FormaPgto
	{
		get
		{
			return formaPgtoField;
		}
		set
		{
			formaPgtoField = value;
			RaisePropertyChanged("FormaPgto");
		}
	}

	[XmlElement(Order = 5)]
	public double ValorPgto
	{
		get
		{
			return valorPgtoField;
		}
		set
		{
			valorPgtoField = value;
			RaisePropertyChanged("ValorPgto");
		}
	}

	[XmlElement(Order = 6)]
	public string CodigoVendedor
	{
		get
		{
			return codigoVendedorField;
		}
		set
		{
			codigoVendedorField = value;
			RaisePropertyChanged("CodigoVendedor");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
