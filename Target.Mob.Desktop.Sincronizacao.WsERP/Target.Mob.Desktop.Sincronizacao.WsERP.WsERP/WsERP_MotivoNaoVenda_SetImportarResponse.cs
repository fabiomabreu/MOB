using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MotivoNaoVenda_SetImportarResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MotivoNaoVenda_SetImportarResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_MotivoNaoVenda_SetImportarResult;

	public WsERP_MotivoNaoVenda_SetImportarResponse()
	{
	}

	public WsERP_MotivoNaoVenda_SetImportarResponse(RetornoWsModelOfBoolean WsERP_MotivoNaoVenda_SetImportarResult)
	{
		this.WsERP_MotivoNaoVenda_SetImportarResult = WsERP_MotivoNaoVenda_SetImportarResult;
	}
}
