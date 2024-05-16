using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_MotivoNaoVenda_SetImportResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_MotivoNaoVenda_SetImportResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfBoolean WsERP_MotivoNaoVenda_SetImportResult;

	public WsERP_MotivoNaoVenda_SetImportResponse()
	{
	}

	public WsERP_MotivoNaoVenda_SetImportResponse(RetornoWsModelOfBoolean WsERP_MotivoNaoVenda_SetImportResult)
	{
		this.WsERP_MotivoNaoVenda_SetImportResult = WsERP_MotivoNaoVenda_SetImportResult;
	}
}
