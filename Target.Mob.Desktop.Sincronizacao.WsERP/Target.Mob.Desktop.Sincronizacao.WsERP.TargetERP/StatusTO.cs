using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[XmlType(Namespace = "http://tempuri.org/")]
public enum StatusTO
{
	CURRENT,
	ADICIONADO,
	EDITADO,
	DELETADO
}
