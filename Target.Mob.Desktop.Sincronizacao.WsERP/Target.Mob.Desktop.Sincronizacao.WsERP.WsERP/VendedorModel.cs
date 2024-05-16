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
public class VendedorModel : VendedorWsModel
{
	private int? ordemExibicaoField;

	private TipoGrupoModel tipoGrupoModelField;

	private DispositivoMovelModel dispositivoMovelModelField;

	private ConfiguracaoVendedorModel configuracaoVendedorModelField;

	private byte[] rowIdProdutoImagemField;

	private byte[] rowIdImagemField;

	private bool? emailSemAutenticacaoField;

	private string chaveDispositivoMovelField;

	private string versaoAndroidField;

	private string versaoSDKField;

	private string versaoGooglePlayServicesField;

	private string versaoMobField;

	private string chaveDispositivoMovelSupervisorField;

	private string chaveDispositivoMovelRelatorioField;

	private bool? utilizaSincronizacaoViaAPI_MOBField;

	private bool? instalacaoAutomaticaField;

	private bool? permiteInstalarMOBRelatoriosField;

	private bool? permiteInstalarMOBSupervisorField;

	private string dispositivoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? OrdemExibicao
	{
		get
		{
			return ordemExibicaoField;
		}
		set
		{
			ordemExibicaoField = value;
			RaisePropertyChanged("OrdemExibicao");
		}
	}

	[XmlElement(Order = 1)]
	public TipoGrupoModel TipoGrupoModel
	{
		get
		{
			return tipoGrupoModelField;
		}
		set
		{
			tipoGrupoModelField = value;
			RaisePropertyChanged("TipoGrupoModel");
		}
	}

	[XmlElement(Order = 2)]
	public DispositivoMovelModel DispositivoMovelModel
	{
		get
		{
			return dispositivoMovelModelField;
		}
		set
		{
			dispositivoMovelModelField = value;
			RaisePropertyChanged("DispositivoMovelModel");
		}
	}

	[XmlElement(Order = 3)]
	public ConfiguracaoVendedorModel ConfiguracaoVendedorModel
	{
		get
		{
			return configuracaoVendedorModelField;
		}
		set
		{
			configuracaoVendedorModelField = value;
			RaisePropertyChanged("ConfiguracaoVendedorModel");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 4)]
	public byte[] RowIdProdutoImagem
	{
		get
		{
			return rowIdProdutoImagemField;
		}
		set
		{
			rowIdProdutoImagemField = value;
			RaisePropertyChanged("RowIdProdutoImagem");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 5)]
	public byte[] RowIdImagem
	{
		get
		{
			return rowIdImagemField;
		}
		set
		{
			rowIdImagemField = value;
			RaisePropertyChanged("RowIdImagem");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public bool? EmailSemAutenticacao
	{
		get
		{
			return emailSemAutenticacaoField;
		}
		set
		{
			emailSemAutenticacaoField = value;
			RaisePropertyChanged("EmailSemAutenticacao");
		}
	}

	[XmlElement(Order = 7)]
	public string ChaveDispositivoMovel
	{
		get
		{
			return chaveDispositivoMovelField;
		}
		set
		{
			chaveDispositivoMovelField = value;
			RaisePropertyChanged("ChaveDispositivoMovel");
		}
	}

	[XmlElement(Order = 8)]
	public string VersaoAndroid
	{
		get
		{
			return versaoAndroidField;
		}
		set
		{
			versaoAndroidField = value;
			RaisePropertyChanged("VersaoAndroid");
		}
	}

	[XmlElement(Order = 9)]
	public string VersaoSDK
	{
		get
		{
			return versaoSDKField;
		}
		set
		{
			versaoSDKField = value;
			RaisePropertyChanged("VersaoSDK");
		}
	}

	[XmlElement(Order = 10)]
	public string VersaoGooglePlayServices
	{
		get
		{
			return versaoGooglePlayServicesField;
		}
		set
		{
			versaoGooglePlayServicesField = value;
			RaisePropertyChanged("VersaoGooglePlayServices");
		}
	}

	[XmlElement(Order = 11)]
	public string VersaoMob
	{
		get
		{
			return versaoMobField;
		}
		set
		{
			versaoMobField = value;
			RaisePropertyChanged("VersaoMob");
		}
	}

	[XmlElement(Order = 12)]
	public string ChaveDispositivoMovelSupervisor
	{
		get
		{
			return chaveDispositivoMovelSupervisorField;
		}
		set
		{
			chaveDispositivoMovelSupervisorField = value;
			RaisePropertyChanged("ChaveDispositivoMovelSupervisor");
		}
	}

	[XmlElement(Order = 13)]
	public string ChaveDispositivoMovelRelatorio
	{
		get
		{
			return chaveDispositivoMovelRelatorioField;
		}
		set
		{
			chaveDispositivoMovelRelatorioField = value;
			RaisePropertyChanged("ChaveDispositivoMovelRelatorio");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public bool? UtilizaSincronizacaoViaAPI_MOB
	{
		get
		{
			return utilizaSincronizacaoViaAPI_MOBField;
		}
		set
		{
			utilizaSincronizacaoViaAPI_MOBField = value;
			RaisePropertyChanged("UtilizaSincronizacaoViaAPI_MOB");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public bool? InstalacaoAutomatica
	{
		get
		{
			return instalacaoAutomaticaField;
		}
		set
		{
			instalacaoAutomaticaField = value;
			RaisePropertyChanged("InstalacaoAutomatica");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public bool? PermiteInstalarMOBRelatorios
	{
		get
		{
			return permiteInstalarMOBRelatoriosField;
		}
		set
		{
			permiteInstalarMOBRelatoriosField = value;
			RaisePropertyChanged("PermiteInstalarMOBRelatorios");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public bool? PermiteInstalarMOBSupervisor
	{
		get
		{
			return permiteInstalarMOBSupervisorField;
		}
		set
		{
			permiteInstalarMOBSupervisorField = value;
			RaisePropertyChanged("PermiteInstalarMOBSupervisor");
		}
	}

	[XmlElement(Order = 18)]
	public string Dispositivo
	{
		get
		{
			return dispositivoField;
		}
		set
		{
			dispositivoField = value;
			RaisePropertyChanged("Dispositivo");
		}
	}
}
