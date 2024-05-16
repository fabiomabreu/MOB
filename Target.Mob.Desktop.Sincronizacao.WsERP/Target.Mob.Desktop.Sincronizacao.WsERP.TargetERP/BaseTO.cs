using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[XmlInclude(typeof(ProdutoTO))]
[XmlInclude(typeof(ProdutoVersaoTO))]
[XmlInclude(typeof(UnetTO))]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public abstract class BaseTO : INotifyPropertyChanged
{
	private StatusTO sTATUS_ENTIDADEField;

	[XmlElement(Order = 0)]
	public StatusTO STATUS_ENTIDADE
	{
		get
		{
			return sTATUS_ENTIDADEField;
		}
		set
		{
			sTATUS_ENTIDADEField = value;
			RaisePropertyChanged("STATUS_ENTIDADE");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
