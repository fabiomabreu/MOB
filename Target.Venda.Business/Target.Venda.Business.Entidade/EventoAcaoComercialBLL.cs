using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class EventoAcaoComercialBLL : EntidadeBaseBLL<EventoAcaoComercialMO>
{
	protected override EntidadeBaseDAL<EventoAcaoComercialMO> GetInstanceDAL()
	{
		return new EventoAcaoComercialDAL();
	}

	public void GerarEventoEnceramentoAcaoComercial(AcaoComercialEncerradaVO acaoComercialEncerrada, UsuarioMO usuario)
	{
		EventoAcaoComercialMO eventoAcaoComercialMO = new EventoAcaoComercialMO();
		eventoAcaoComercialMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoAcaoComercialMO.CODIGO_PRODUTO = acaoComercialEncerrada.CODIGO_PRODUTO;
		eventoAcaoComercialMO.CODIGO_TIPO_OCORRENCIA_ACAO_COMERCIAL = "ENCI";
		eventoAcaoComercialMO.CODIGO_USUARIO = usuario.CODIGO_USUARIO;
		eventoAcaoComercialMO.SEQ_ACAO_COMERCIAL = acaoComercialEncerrada.SEQ_ACAO_COMERCIAL;
		Salvar(eventoAcaoComercialMO);
	}

	public void GerarEventoAlteracaoVirgenciaAcaoComercial(AcaoComercialEncerradaVO acaoComercialEncerrada, UsuarioMO usuario)
	{
		EventoAcaoComercialMO eventoAcaoComercialMO = new EventoAcaoComercialMO();
		eventoAcaoComercialMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoAcaoComercialMO.CODIGO_TIPO_OCORRENCIA_ACAO_COMERCIAL = "ALTV";
		eventoAcaoComercialMO.CODIGO_USUARIO = usuario.CODIGO_USUARIO;
		eventoAcaoComercialMO.SEQ_ACAO_COMERCIAL = acaoComercialEncerrada.SEQ_ACAO_COMERCIAL;
		eventoAcaoComercialMO.CODIGO_PRODUTO = acaoComercialEncerrada.CODIGO_PRODUTO;
		Salvar(eventoAcaoComercialMO);
	}
}
