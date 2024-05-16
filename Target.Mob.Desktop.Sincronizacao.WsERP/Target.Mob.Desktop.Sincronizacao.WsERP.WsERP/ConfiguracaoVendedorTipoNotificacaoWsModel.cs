using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorTipoNotificacaoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorTipoNotificacaoWsModel : INotifyPropertyChanged
{
	private int? idTipoNotificacaoField;

	private int? idConfiguracaoVendedorField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IdTipoNotificacao
	{
		get
		{
			return idTipoNotificacaoField;
		}
		set
		{
			idTipoNotificacaoField = value;
			RaisePropertyChanged("IdTipoNotificacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IdConfiguracaoVendedor
	{
		get
		{
			return idConfiguracaoVendedorField;
		}
		set
		{
			idConfiguracaoVendedorField = value;
			RaisePropertyChanged("IdConfiguracaoVendedor");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
