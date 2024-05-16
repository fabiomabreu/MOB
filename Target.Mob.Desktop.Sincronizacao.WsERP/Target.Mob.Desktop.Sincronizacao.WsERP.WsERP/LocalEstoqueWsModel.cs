using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(LocalEstoqueModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class LocalEstoqueWsModel : INotifyPropertyChanged
{
	private int? iDLocalEstoqueField;

	private int? codigoEmpresaField;

	private string localField;

	private bool? ativoField;

	private byte[] rowIdField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDLocalEstoque
	{
		get
		{
			return iDLocalEstoqueField;
		}
		set
		{
			iDLocalEstoqueField = value;
			RaisePropertyChanged("IDLocalEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
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

	[XmlElement(Order = 2)]
	public string Local
	{
		get
		{
			return localField;
		}
		set
		{
			localField = value;
			RaisePropertyChanged("Local");
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

	[XmlElement(DataType = "base64Binary", Order = 4)]
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
