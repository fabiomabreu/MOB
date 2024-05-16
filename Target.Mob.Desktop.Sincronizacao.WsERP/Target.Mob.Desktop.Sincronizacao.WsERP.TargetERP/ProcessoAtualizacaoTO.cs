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
public class ProcessoAtualizacaoTO : INotifyPropertyChanged
{
	private string[] pROCESSOS_ATUALIZACAOField;

	private string nOME_SCRIPTField;

	private string tRECHO_SCRIPTField;

	[XmlArray(Order = 0)]
	public string[] PROCESSOS_ATUALIZACAO
	{
		get
		{
			return pROCESSOS_ATUALIZACAOField;
		}
		set
		{
			pROCESSOS_ATUALIZACAOField = value;
			RaisePropertyChanged("PROCESSOS_ATUALIZACAO");
		}
	}

	[XmlElement(Order = 1)]
	public string NOME_SCRIPT
	{
		get
		{
			return nOME_SCRIPTField;
		}
		set
		{
			nOME_SCRIPTField = value;
			RaisePropertyChanged("NOME_SCRIPT");
		}
	}

	[XmlElement(Order = 2)]
	public string TRECHO_SCRIPT
	{
		get
		{
			return tRECHO_SCRIPTField;
		}
		set
		{
			tRECHO_SCRIPTField = value;
			RaisePropertyChanged("TRECHO_SCRIPT");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
