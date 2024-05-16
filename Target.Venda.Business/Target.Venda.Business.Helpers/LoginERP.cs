using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Helpers;

public static class LoginERP
{
	public static UsuarioMO USUARIO_LOGADO
	{
		get
		{
			return SessaoErpManager.CURRENT.USUARIO;
		}
		set
		{
			SessaoErpManager.CURRENT.USUARIO = value;
		}
	}

	public static EmpresaMO EMPRESA_LOGADA
	{
		get
		{
			return SessaoErpManager.CURRENT.EMPRESA;
		}
		set
		{
			SessaoErpManager.CURRENT.EMPRESA = value;
		}
	}

	public static string PROGRAMA_ORIGEM
	{
		get
		{
			return SessaoErpManager.CURRENT.PROGRAMA_ORIGEM;
		}
		set
		{
			SessaoErpManager.CURRENT.PROGRAMA_ORIGEM = value;
		}
	}
}
