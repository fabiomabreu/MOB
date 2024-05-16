using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WsERP_RelatorioTrabalhoVendedor_GetResponse", WrapperNamespace = "Target.WsERP", IsWrapped = true)]
public class WsERP_RelatorioTrabalhoVendedor_GetResponse
{
	[MessageBodyMember(Namespace = "Target.WsERP", Order = 0)]
	public RetornoWsModelOfRelatorioTrabalhoVendedorWsModel WsERP_RelatorioTrabalhoVendedor_GetResult;

	public WsERP_RelatorioTrabalhoVendedor_GetResponse()
	{
	}

	public WsERP_RelatorioTrabalhoVendedor_GetResponse(RetornoWsModelOfRelatorioTrabalhoVendedorWsModel WsERP_RelatorioTrabalhoVendedor_GetResult)
	{
		this.WsERP_RelatorioTrabalhoVendedor_GetResult = WsERP_RelatorioTrabalhoVendedor_GetResult;
	}
}
