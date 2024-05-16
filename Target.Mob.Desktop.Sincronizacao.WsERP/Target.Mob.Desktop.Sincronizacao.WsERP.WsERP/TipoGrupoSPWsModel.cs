using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(TipoGrupoSPModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class TipoGrupoSPWsModel : INotifyPropertyChanged
{
	private int? iDTipoGrupoSPField;

	private int? iDTipoGrupoField;

	private int? iDCadastroSPField;

	private VendedorWsModel vendedorField;

	private TipoGrupoWsModel tipoGrupoField;

	private CadastroSPWsModel cadastroSPField;

	private TipoGrupoWsModel[] listTipoGrupoWsField;

	private CadastroSPWsModel[] listaCadastroSPWsField;

	private VendedorWsModel[] listaVendedorWsField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDTipoGrupoSP
	{
		get
		{
			return iDTipoGrupoSPField;
		}
		set
		{
			iDTipoGrupoSPField = value;
			RaisePropertyChanged("IDTipoGrupoSP");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IDTipoGrupo
	{
		get
		{
			return iDTipoGrupoField;
		}
		set
		{
			iDTipoGrupoField = value;
			RaisePropertyChanged("IDTipoGrupo");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public int? IDCadastroSP
	{
		get
		{
			return iDCadastroSPField;
		}
		set
		{
			iDCadastroSPField = value;
			RaisePropertyChanged("IDCadastroSP");
		}
	}

	[XmlElement(Order = 3)]
	public VendedorWsModel Vendedor
	{
		get
		{
			return vendedorField;
		}
		set
		{
			vendedorField = value;
			RaisePropertyChanged("Vendedor");
		}
	}

	[XmlElement(Order = 4)]
	public TipoGrupoWsModel TipoGrupo
	{
		get
		{
			return tipoGrupoField;
		}
		set
		{
			tipoGrupoField = value;
			RaisePropertyChanged("TipoGrupo");
		}
	}

	[XmlElement(Order = 5)]
	public CadastroSPWsModel CadastroSP
	{
		get
		{
			return cadastroSPField;
		}
		set
		{
			cadastroSPField = value;
			RaisePropertyChanged("CadastroSP");
		}
	}

	[XmlArray(Order = 6)]
	public TipoGrupoWsModel[] ListTipoGrupoWs
	{
		get
		{
			return listTipoGrupoWsField;
		}
		set
		{
			listTipoGrupoWsField = value;
			RaisePropertyChanged("ListTipoGrupoWs");
		}
	}

	[XmlArray(Order = 7)]
	public CadastroSPWsModel[] ListaCadastroSPWs
	{
		get
		{
			return listaCadastroSPWsField;
		}
		set
		{
			listaCadastroSPWsField = value;
			RaisePropertyChanged("ListaCadastroSPWs");
		}
	}

	[XmlArray(Order = 8)]
	public VendedorWsModel[] ListaVendedorWs
	{
		get
		{
			return listaVendedorWsField;
		}
		set
		{
			listaVendedorWsField = value;
			RaisePropertyChanged("ListaVendedorWs");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
