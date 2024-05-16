using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Base.Sessao;

namespace Target.Venda.Business.Helpers;

public static class SessaoErpManager
{
	private static string _Chave = "SESSAO_ERP";

	public static bool INICIALIZADA => SessionHelper.Initialized(_Chave);

	public static SessaoErpModel CURRENT => getCurrentSession();

	public static void Inicializar(string codigoUsuario, int codigoEmpresa, string codigoProgramaOrigem = null)
	{
		SessaoErpModel sessaoErpModel = new SessaoErpModel();
		sessaoErpModel.DATA_CRIACAO_SESSAO = DateTimeHelper.ObterDataHoraAtualBancoDados();
		sessaoErpModel.ID_SESSSAO = sessaoErpModel.ID_SESSSAO;
		sessaoErpModel.PROGRAMA_ORIGEM = ((codigoProgramaOrigem == null) ? string.Empty : codigoProgramaOrigem);
		SessionHelper.SetData("SESSAO_ERP", sessaoErpModel);
	}

	private static SessaoErpModel getCurrentSession()
	{
		if (!SessionHelper.Initialized(_Chave))
		{
			new MyException("Sessão do usuario não inicializada").ThrowException();
		}
		return (SessaoErpModel)SessionHelper.GetData("SESSAO_ERP");
	}

	public static void Encerrar()
	{
		SessionHelper.Destroy(_Chave);
	}
}
