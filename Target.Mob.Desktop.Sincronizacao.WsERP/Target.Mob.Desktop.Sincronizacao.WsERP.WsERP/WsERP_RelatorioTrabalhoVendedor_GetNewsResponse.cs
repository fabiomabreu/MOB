using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RelatorioTrabalhoVendedor_GetNewsResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RelatorioTrabalhoVendedor_GetNewsResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfListOfInt32 WsERP_RelatorioTrabalhoVendedor_GetNewsResult;

	public WsERP_RelatorioTrabalhoVendedor_GetNewsResponse()
	{
	}

	public WsERP_RelatorioTrabalhoVendedor_GetNewsResponse(RetornoWsModelOfListOfInt32 WsERP_RelatorioTrabalhoVendedor_GetNewsResult)
	{
		this.WsERP_RelatorioTrabalhoVendedor_GetNewsResult = WsERP_RelatorioTrabalhoVendedor_GetNewsResult;
	}
}
