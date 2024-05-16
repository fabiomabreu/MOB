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
public class LocalEstoqueModel : LocalEstoqueWsModel
{
	private int? iDConfiguracaoVendedorField;

	private bool? statusField;

	private EmpresaModel empresaModelField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoVendedor
	{
		get
		{
			return iDConfiguracaoVendedorField;
		}
		set
		{
			iDConfiguracaoVendedorField = value;
			RaisePropertyChanged("IDConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public bool? Status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
			RaisePropertyChanged("Status");
		}
	}

	[XmlElement(Order = 2)]
	public EmpresaModel EmpresaModel
	{
		get
		{
			return empresaModelField;
		}
		set
		{
			empresaModelField = value;
			RaisePropertyChanged("EmpresaModel");
		}
	}
}
