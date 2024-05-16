using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class TGTIndicadorMesAnoTO : INotifyPropertyChanged
{
	private int idField;

	private string cNPJField;

	private string sIGLA_CLIENTEField;

	private string eMPRESAField;

	private int aNOField;

	private int mESField;

	private decimal fATURAMENTOField;

	private decimal mGBRT_VLField;

	private decimal mGBRT_PERCField;

	private decimal mGCTB_VLField;

	private decimal mGCTB_PERCField;

	private int cOBERTURAField;

	private int cLI_ATIVOField;

	private int mIX_PRODField;

	private int pRD_ATIVOField;

	private int mIX_FABRICField;

	private int fABRIC_ATIVOField;

	private int qTDE_PEDIDOSField;

	private int qTDE_ITENSField;

	private int vEND_POSITField;

	private int vEND_ATIVOField;

	private int qTDE_ROTEIROSField;

	private int qTDE_ENTREGASField;

	private decimal pESO_TOTALField;

	private decimal vL_CORTE_PRDField;

	private decimal vL_CORTE_LOGField;

	private decimal vL_DEVOLUCAOField;

	private int uSUARIO_ATIVOField;

	private DateTime dATAField;

	private byte[] rOWIDField;

	private int? cODIGO_EMPRESAField;

	private decimal? mEDIA_POR_DIAField;

	private decimal? fINANCEIROField;

	private int? qTDE_REENTREGASField;

	private decimal? mG_BRT_VL_MEDIOField;

	private decimal? mG_BRT_PERC_MEDIOField;

	[XmlElement(Order = 0)]
	public int ID
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
			RaisePropertyChanged("ID");
		}
	}

	[XmlElement(Order = 1)]
	public string CNPJ
	{
		get
		{
			return cNPJField;
		}
		set
		{
			cNPJField = value;
			RaisePropertyChanged("CNPJ");
		}
	}

	[XmlElement(Order = 2)]
	public string SIGLA_CLIENTE
	{
		get
		{
			return sIGLA_CLIENTEField;
		}
		set
		{
			sIGLA_CLIENTEField = value;
			RaisePropertyChanged("SIGLA_CLIENTE");
		}
	}

	[XmlElement(Order = 3)]
	public string EMPRESA
	{
		get
		{
			return eMPRESAField;
		}
		set
		{
			eMPRESAField = value;
			RaisePropertyChanged("EMPRESA");
		}
	}

	[XmlElement(Order = 4)]
	public int ANO
	{
		get
		{
			return aNOField;
		}
		set
		{
			aNOField = value;
			RaisePropertyChanged("ANO");
		}
	}

	[XmlElement(Order = 5)]
	public int MES
	{
		get
		{
			return mESField;
		}
		set
		{
			mESField = value;
			RaisePropertyChanged("MES");
		}
	}

	[XmlElement(Order = 6)]
	public decimal FATURAMENTO
	{
		get
		{
			return fATURAMENTOField;
		}
		set
		{
			fATURAMENTOField = value;
			RaisePropertyChanged("FATURAMENTO");
		}
	}

	[XmlElement(Order = 7)]
	public decimal MGBRT_VL
	{
		get
		{
			return mGBRT_VLField;
		}
		set
		{
			mGBRT_VLField = value;
			RaisePropertyChanged("MGBRT_VL");
		}
	}

	[XmlElement(Order = 8)]
	public decimal MGBRT_PERC
	{
		get
		{
			return mGBRT_PERCField;
		}
		set
		{
			mGBRT_PERCField = value;
			RaisePropertyChanged("MGBRT_PERC");
		}
	}

	[XmlElement(Order = 9)]
	public decimal MGCTB_VL
	{
		get
		{
			return mGCTB_VLField;
		}
		set
		{
			mGCTB_VLField = value;
			RaisePropertyChanged("MGCTB_VL");
		}
	}

	[XmlElement(Order = 10)]
	public decimal MGCTB_PERC
	{
		get
		{
			return mGCTB_PERCField;
		}
		set
		{
			mGCTB_PERCField = value;
			RaisePropertyChanged("MGCTB_PERC");
		}
	}

	[XmlElement(Order = 11)]
	public int COBERTURA
	{
		get
		{
			return cOBERTURAField;
		}
		set
		{
			cOBERTURAField = value;
			RaisePropertyChanged("COBERTURA");
		}
	}

	[XmlElement(Order = 12)]
	public int CLI_ATIVO
	{
		get
		{
			return cLI_ATIVOField;
		}
		set
		{
			cLI_ATIVOField = value;
			RaisePropertyChanged("CLI_ATIVO");
		}
	}

	[XmlElement(Order = 13)]
	public int MIX_PROD
	{
		get
		{
			return mIX_PRODField;
		}
		set
		{
			mIX_PRODField = value;
			RaisePropertyChanged("MIX_PROD");
		}
	}

	[XmlElement(Order = 14)]
	public int PRD_ATIVO
	{
		get
		{
			return pRD_ATIVOField;
		}
		set
		{
			pRD_ATIVOField = value;
			RaisePropertyChanged("PRD_ATIVO");
		}
	}

	[XmlElement(Order = 15)]
	public int MIX_FABRIC
	{
		get
		{
			return mIX_FABRICField;
		}
		set
		{
			mIX_FABRICField = value;
			RaisePropertyChanged("MIX_FABRIC");
		}
	}

	[XmlElement(Order = 16)]
	public int FABRIC_ATIVO
	{
		get
		{
			return fABRIC_ATIVOField;
		}
		set
		{
			fABRIC_ATIVOField = value;
			RaisePropertyChanged("FABRIC_ATIVO");
		}
	}

	[XmlElement(Order = 17)]
	public int QTDE_PEDIDOS
	{
		get
		{
			return qTDE_PEDIDOSField;
		}
		set
		{
			qTDE_PEDIDOSField = value;
			RaisePropertyChanged("QTDE_PEDIDOS");
		}
	}

	[XmlElement(Order = 18)]
	public int QTDE_ITENS
	{
		get
		{
			return qTDE_ITENSField;
		}
		set
		{
			qTDE_ITENSField = value;
			RaisePropertyChanged("QTDE_ITENS");
		}
	}

	[XmlElement(Order = 19)]
	public int VEND_POSIT
	{
		get
		{
			return vEND_POSITField;
		}
		set
		{
			vEND_POSITField = value;
			RaisePropertyChanged("VEND_POSIT");
		}
	}

	[XmlElement(Order = 20)]
	public int VEND_ATIVO
	{
		get
		{
			return vEND_ATIVOField;
		}
		set
		{
			vEND_ATIVOField = value;
			RaisePropertyChanged("VEND_ATIVO");
		}
	}

	[XmlElement(Order = 21)]
	public int QTDE_ROTEIROS
	{
		get
		{
			return qTDE_ROTEIROSField;
		}
		set
		{
			qTDE_ROTEIROSField = value;
			RaisePropertyChanged("QTDE_ROTEIROS");
		}
	}

	[XmlElement(Order = 22)]
	public int QTDE_ENTREGAS
	{
		get
		{
			return qTDE_ENTREGASField;
		}
		set
		{
			qTDE_ENTREGASField = value;
			RaisePropertyChanged("QTDE_ENTREGAS");
		}
	}

	[XmlElement(Order = 23)]
	public decimal PESO_TOTAL
	{
		get
		{
			return pESO_TOTALField;
		}
		set
		{
			pESO_TOTALField = value;
			RaisePropertyChanged("PESO_TOTAL");
		}
	}

	[XmlElement(Order = 24)]
	public decimal VL_CORTE_PRD
	{
		get
		{
			return vL_CORTE_PRDField;
		}
		set
		{
			vL_CORTE_PRDField = value;
			RaisePropertyChanged("VL_CORTE_PRD");
		}
	}

	[XmlElement(Order = 25)]
	public decimal VL_CORTE_LOG
	{
		get
		{
			return vL_CORTE_LOGField;
		}
		set
		{
			vL_CORTE_LOGField = value;
			RaisePropertyChanged("VL_CORTE_LOG");
		}
	}

	[XmlElement(Order = 26)]
	public decimal VL_DEVOLUCAO
	{
		get
		{
			return vL_DEVOLUCAOField;
		}
		set
		{
			vL_DEVOLUCAOField = value;
			RaisePropertyChanged("VL_DEVOLUCAO");
		}
	}

	[XmlElement(Order = 27)]
	public int USUARIO_ATIVO
	{
		get
		{
			return uSUARIO_ATIVOField;
		}
		set
		{
			uSUARIO_ATIVOField = value;
			RaisePropertyChanged("USUARIO_ATIVO");
		}
	}

	[XmlElement(Order = 28)]
	public DateTime DATA
	{
		get
		{
			return dATAField;
		}
		set
		{
			dATAField = value;
			RaisePropertyChanged("DATA");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 29)]
	public byte[] ROWID
	{
		get
		{
			return rOWIDField;
		}
		set
		{
			rOWIDField = value;
			RaisePropertyChanged("ROWID");
		}
	}

	[XmlElement(IsNullable = true, Order = 30)]
	public int? CODIGO_EMPRESA
	{
		get
		{
			return cODIGO_EMPRESAField;
		}
		set
		{
			cODIGO_EMPRESAField = value;
			RaisePropertyChanged("CODIGO_EMPRESA");
		}
	}

	[XmlElement(IsNullable = true, Order = 31)]
	public decimal? MEDIA_POR_DIA
	{
		get
		{
			return mEDIA_POR_DIAField;
		}
		set
		{
			mEDIA_POR_DIAField = value;
			RaisePropertyChanged("MEDIA_POR_DIA");
		}
	}

	[XmlElement(IsNullable = true, Order = 32)]
	public decimal? FINANCEIRO
	{
		get
		{
			return fINANCEIROField;
		}
		set
		{
			fINANCEIROField = value;
			RaisePropertyChanged("FINANCEIRO");
		}
	}

	[XmlElement(IsNullable = true, Order = 33)]
	public int? QTDE_REENTREGAS
	{
		get
		{
			return qTDE_REENTREGASField;
		}
		set
		{
			qTDE_REENTREGASField = value;
			RaisePropertyChanged("QTDE_REENTREGAS");
		}
	}

	[XmlElement(IsNullable = true, Order = 34)]
	public decimal? MG_BRT_VL_MEDIO
	{
		get
		{
			return mG_BRT_VL_MEDIOField;
		}
		set
		{
			mG_BRT_VL_MEDIOField = value;
			RaisePropertyChanged("MG_BRT_VL_MEDIO");
		}
	}

	[XmlElement(IsNullable = true, Order = 35)]
	public decimal? MG_BRT_PERC_MEDIO
	{
		get
		{
			return mG_BRT_PERC_MEDIOField;
		}
		set
		{
			mG_BRT_PERC_MEDIOField = value;
			RaisePropertyChanged("MG_BRT_PERC_MEDIO");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
