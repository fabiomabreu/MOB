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
public class EnviarProdutoPainelTO : VersaoTO
{
	private string dIRETORIO_INSTALADOField;

	private bool cONTROLA_LICENCAField;

	private int qUANTIDADE_LICENCASField;

	[XmlElement(Order = 0)]
	public string DIRETORIO_INSTALADO
	{
		get
		{
			return dIRETORIO_INSTALADOField;
		}
		set
		{
			dIRETORIO_INSTALADOField = value;
			RaisePropertyChanged("DIRETORIO_INSTALADO");
		}
	}

	[XmlElement(Order = 1)]
	public bool CONTROLA_LICENCA
	{
		get
		{
			return cONTROLA_LICENCAField;
		}
		set
		{
			cONTROLA_LICENCAField = value;
			RaisePropertyChanged("CONTROLA_LICENCA");
		}
	}

	[XmlElement(Order = 2)]
	public int QUANTIDADE_LICENCAS
	{
		get
		{
			return qUANTIDADE_LICENCASField;
		}
		set
		{
			qUANTIDADE_LICENCASField = value;
			RaisePropertyChanged("QUANTIDADE_LICENCAS");
		}
	}
}
