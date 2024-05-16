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
public class ConfiguracaoVendedorTipoNotificacaoModel : ConfiguracaoVendedorTipoNotificacaoWsModel
{
	private int idConfiguracaoVendedorTipoNotificacaoField;

	[XmlElement(Order = 0)]
	public int IdConfiguracaoVendedorTipoNotificacao
	{
		get
		{
			return idConfiguracaoVendedorTipoNotificacaoField;
		}
		set
		{
			idConfiguracaoVendedorTipoNotificacaoField = value;
			RaisePropertyChanged("IdConfiguracaoVendedorTipoNotificacao");
		}
	}
}
