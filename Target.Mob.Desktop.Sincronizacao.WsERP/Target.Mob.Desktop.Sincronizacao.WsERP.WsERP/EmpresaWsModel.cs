using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(EmpresaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class EmpresaWsModel : INotifyPropertyChanged
{
	private int? iDEmpresaField;

	private int? codigoEmpresaField;

	private string razaoSocialField;

	private string nomeFantaziaField;

	private string cGCField;

	private bool? ativoField;

	private byte[] rowIdField;

	private string enderecoField;

	private string numeroField;

	private string complementoField;

	private string bairroField;

	private string municipioField;

	private int? cepField;

	private string estadoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDEmpresa
	{
		get
		{
			return iDEmpresaField;
		}
		set
		{
			iDEmpresaField = value;
			RaisePropertyChanged("IDEmpresa");
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
	public string RazaoSocial
	{
		get
		{
			return razaoSocialField;
		}
		set
		{
			razaoSocialField = value;
			RaisePropertyChanged("RazaoSocial");
		}
	}

	[XmlElement(Order = 3)]
	public string NomeFantazia
	{
		get
		{
			return nomeFantaziaField;
		}
		set
		{
			nomeFantaziaField = value;
			RaisePropertyChanged("NomeFantazia");
		}
	}

	[XmlElement(Order = 4)]
	public string CGC
	{
		get
		{
			return cGCField;
		}
		set
		{
			cGCField = value;
			RaisePropertyChanged("CGC");
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

	[XmlElement(Order = 7)]
	public string Endereco
	{
		get
		{
			return enderecoField;
		}
		set
		{
			enderecoField = value;
			RaisePropertyChanged("Endereco");
		}
	}

	[XmlElement(Order = 8)]
	public string Numero
	{
		get
		{
			return numeroField;
		}
		set
		{
			numeroField = value;
			RaisePropertyChanged("Numero");
		}
	}

	[XmlElement(Order = 9)]
	public string Complemento
	{
		get
		{
			return complementoField;
		}
		set
		{
			complementoField = value;
			RaisePropertyChanged("Complemento");
		}
	}

	[XmlElement(Order = 10)]
	public string Bairro
	{
		get
		{
			return bairroField;
		}
		set
		{
			bairroField = value;
			RaisePropertyChanged("Bairro");
		}
	}

	[XmlElement(Order = 11)]
	public string Municipio
	{
		get
		{
			return municipioField;
		}
		set
		{
			municipioField = value;
			RaisePropertyChanged("Municipio");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public int? Cep
	{
		get
		{
			return cepField;
		}
		set
		{
			cepField = value;
			RaisePropertyChanged("Cep");
		}
	}

	[XmlElement(Order = 13)]
	public string Estado
	{
		get
		{
			return estadoField;
		}
		set
		{
			estadoField = value;
			RaisePropertyChanged("Estado");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
