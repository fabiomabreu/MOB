using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class AcaoComercialBLL : EntidadeBaseBLL<AcaoComercialMO>
{
	protected override EntidadeBaseDAL<AcaoComercialMO> GetInstanceDAL()
	{
		return new AcaoComercialDAL();
	}

	public List<AcaoComercialVO> ObterAcaoComercialPedido(PedidoEletronicoMO pedidoEletronicoMO)
	{
		return (BaseDAL as AcaoComercialDAL).ObterSeqAcaoComercial(pedidoEletronicoMO);
	}

	public void EnviarEmailEncerramentoAcaoComercial(List<AcaoComercialEncerradaVO> acaoComercialProdutoEnc)
	{
		VerbaFabricanteCFGAvisoBLL verbaFabricanteCFGAvisoBLL = new VerbaFabricanteCFGAvisoBLL();
		List<DestinatarioEmailVO> list = verbaFabricanteCFGAvisoBLL.ObterDestinatariosEmailVerbaFabricante();
		if (list == null || list.Count == 0)
		{
			return;
		}
		List<EmailVO> list2 = GerarEmailEncerramentoAcaoComercial(acaoComercialProdutoEnc);
		foreach (DestinatarioEmailVO itemDestinatario in list)
		{
			list2.ForEach(delegate(EmailVO e)
			{
				e.DESTINATARIO = itemDestinatario;
			});
		}
		EmailBLL emailBLL = new EmailBLL();
		emailBLL.GerarEnvioEmailERP(list2);
	}

	private List<EmailVO> GerarEmailEncerramentoAcaoComercial(List<AcaoComercialEncerradaVO> acaoComercialProdutoEnc)
	{
		List<EmailVO> list = new List<EmailVO>();
		foreach (AcaoComercialEncerradaVO item in acaoComercialProdutoEnc)
		{
			EmailVO emailVO = null;
			switch (item.MOTIVO_ENCERRAMENTO)
			{
			case "EZ":
				emailVO = MontarEmailEncerramentoItemAcaoComercial(item, "Falta de estoque do produto");
				break;
			case "LV":
				emailVO = MontarEmailEncerramentoItemAcaoComercial(item, "Quantidade limite de venda atingida");
				break;
			case "LVL":
				emailVO = MontarEmailEncerramentoAcaoComercial(item, "Valor limite de venda atingido");
				break;
			}
			if (emailVO != null)
			{
				list.Add(emailVO);
			}
		}
		return list;
	}

	private EmailVO MontarEmailEncerramentoAcaoComercial(AcaoComercialEncerradaVO acaoComercialEnc, string desricaoMotivo)
	{
		EmailVO emailVO = new EmailVO();
		emailVO.ASSUNTO = "Ação comercial encerrado";
		string mENSAGEM = $"A ação comercial {acaoComercialEnc.SEQ_ACAO_COMERCIAL} - {acaoComercialEnc.DESCRICAO_ACAO_COMERCIAL}, foi encerrada pelo motivo {desricaoMotivo}";
		emailVO.MENSAGEM = mENSAGEM;
		return emailVO;
	}

	private EmailVO MontarEmailEncerramentoItemAcaoComercial(AcaoComercialEncerradaVO acaoComercialEnc, string desricaoMotivo)
	{
		EmailVO emailVO = new EmailVO();
		emailVO.ASSUNTO = "Item de ação comercial encerrado";
		string mENSAGEM = $"O produto {acaoComercialEnc.CODIGO_PRODUTO} - {acaoComercialEnc.DESCRICAO_PRODUTO}, na ação comercial {acaoComercialEnc.SEQ_ACAO_COMERCIAL} - {acaoComercialEnc.DESCRICAO_ACAO_COMERCIAL}, foi encerrado pelo motivo {desricaoMotivo}";
		emailVO.MENSAGEM = mENSAGEM;
		return emailVO;
	}

	public List<AcaoComercialEncerradaVO> ObterAcaoComercialEncerradas(PedidoVendaMO pedidoVenda)
	{
		return (BaseDAL as AcaoComercialDAL).ObterAcaoComercialEncerradas(pedidoVenda);
	}

	public void EncerrarAcaoComercial(AcaoComercialEncerradaVO acaoComercialEncerrada, PedidoVendaMO pedidoVenda)
	{
		AcaoComercialMO acaoComercialMO = ObterPeloID(acaoComercialEncerrada.SEQ_ACAO_COMERCIAL);
		switch (acaoComercialMO.TIPO_APLICACAO_VALOR)
		{
		case "TPR":
			EncerrarAcaoComercialTipoAplicacaoValorTrp(pedidoVenda, acaoComercialMO);
			break;
		case "PRE":
			EncerrarAcaoComercialTipoAplicacaoValorPre(pedidoVenda, acaoComercialMO);
			break;
		case "POS":
			EncerrarAcaoComercialTipoAplicacaoValorPos(pedidoVenda, acaoComercialMO);
			break;
		}
		AcaoComercialDAL acaoComercialDAL = (AcaoComercialDAL)BaseDAL;
		acaoComercialDAL.EncerrarAcaoComercial(acaoComercialMO.SEQ_ACAO_COMERCIAL);
		AlterarVigenciaAcaoComercial(pedidoVenda, acaoComercialMO, acaoComercialEncerrada);
	}

	private void AlterarVigenciaAcaoComercial(PedidoVendaMO pedidoVenda, AcaoComercialMO acaoComercial, AcaoComercialEncerradaVO acaoComercialEncerrada)
	{
		DateTime value = DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.Data);
		AlterarVigenciaVO alterarVigenciaVO = new AlterarVigenciaVO();
		alterarVigenciaVO.SEQ_ACAO_COMERCIAL = acaoComercial.SEQ_ACAO_COMERCIAL;
		alterarVigenciaVO.DATA_INICIO = null;
		alterarVigenciaVO.DATA_FIM = value;
		if (acaoComercial.SEQ_KIT.HasValue)
		{
			alterarVigenciaVO.SEQ_KIT = Convert.ToInt32(acaoComercial.SEQ_KIT);
		}
		(BaseDAL as AcaoComercialDAL).AlterarVigenciaAcaoComercial(alterarVigenciaVO);
		if ((acaoComercial.TIPO_ACAO_COMERCIAL == "PFI" || acaoComercial.TIPO_ACAO_COMERCIAL == "PFL") && acaoComercial.SEQ_KIT > 0)
		{
			KitPromocaoBLL kitPromocaoBLL = new KitPromocaoBLL();
			kitPromocaoBLL.AlterarVigenciaKitPromocao(alterarVigenciaVO);
		}
		EventoAcaoComercialBLL eventoAcaoComercialBLL = new EventoAcaoComercialBLL();
		eventoAcaoComercialBLL.GerarEventoAlteracaoVirgenciaAcaoComercial(acaoComercialEncerrada, LoginERP.USUARIO_LOGADO);
	}

	private void EncerrarAcaoComercialTipoAplicacaoValorPos(PedidoVendaMO pedidoVenda, AcaoComercialMO acaoComercial)
	{
		AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
		decimal num = acaoComercialBLL.ObterValorUtilizadoAcaoComercial(acaoComercial);
		if (num > 0m)
		{
			VerbaFabricanteLancamentoBLL verbaFabricanteLancamentoBLL = new VerbaFabricanteLancamentoBLL();
			string codigoTipoLancAjuste = "ACOF";
			verbaFabricanteLancamentoBLL.GerarLancamentoVerbaFabricante(pedidoVenda, codigoTipoLancAjuste, num, acaoComercial);
		}
	}

	private void EncerrarAcaoComercialTipoAplicacaoValorPre(PedidoVendaMO pedidoVenda, AcaoComercialMO acaoComercial)
	{
		AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
		VerbaFabricanteLancamentoBLL verbaFabricanteLancamentoBLL = new VerbaFabricanteLancamentoBLL();
		decimal num = acaoComercialBLL.ObterValorUtilizadoAcaoComercial(acaoComercial);
		bool flag = num > 0m && num != acaoComercial.VALOR;
		bool flag2 = num == 0m;
		bool flag3 = acaoComercial.VALOR > 0m;
		if (flag)
		{
			string text = "";
			decimal num2 = default(decimal);
			if (num > acaoComercial.VALOR)
			{
				text = "ACCD";
				num2 = num - acaoComercial.VALOR;
			}
			else
			{
				text = "ACCC";
				num2 = acaoComercial.VALOR - num;
			}
			verbaFabricanteLancamentoBLL.GerarLancamentoVerbaFabricante(pedidoVenda, text, num2, acaoComercial);
		}
		else if (flag2 && flag3)
		{
			string codigoTipoLancAjuste = "ACCR";
			verbaFabricanteLancamentoBLL.GerarLancamentoVerbaFabricante(pedidoVenda, codigoTipoLancAjuste, num, acaoComercial);
		}
	}

	private decimal ObterValorUtilizadoAcaoComercial(AcaoComercialMO acaoComercial)
	{
		return (BaseDAL as AcaoComercialDAL).ObterValorUtilizadoAcaoComercial(acaoComercial.SEQ_ACAO_COMERCIAL);
	}

	private void EncerrarAcaoComercialTipoAplicacaoValorTrp(PedidoVendaMO pedidoVenda, AcaoComercialMO acaoComercial)
	{
		AcaoComercialProdutoBLL acaoComercialProdutoBLL = new AcaoComercialProdutoBLL();
		List<AcaoComercialEncerradaVO> list = ObterProdutosDaAcaoComercialEncerrada(acaoComercial.SEQ_ACAO_COMERCIAL);
		foreach (AcaoComercialEncerradaVO item in list)
		{
			acaoComercialProdutoBLL.AtualizarPrecoProdutoAcaoComercial(item, "ENC", pedidoVenda);
		}
		acaoComercialProdutoBLL.EncerrarTodosProdutosAcaoComercial(acaoComercial.SEQ_ACAO_COMERCIAL);
	}

	private List<AcaoComercialEncerradaVO> ObterProdutosDaAcaoComercialEncerrada(int seqAcaoComercial)
	{
		return (BaseDAL as AcaoComercialDAL).ObterProdutosDaAcaoComercialEncerrada(seqAcaoComercial);
	}

	public void AssociarAcaoComercialItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		try
		{
			AcaoComercialVO acaoComercialVO = pedidoVenda.ACOES_COMERCIAIS.Find(delegate(AcaoComercialVO x)
			{
				decimal? sEQ_ITEM = x.SEQ_ITEM;
				decimal num = itemPedido.SEQ;
				return (sEQ_ITEM.GetValueOrDefault() == num) & sEQ_ITEM.HasValue;
			});
			if (acaoComercialVO != null)
			{
				itemPedido.SEQ_ACAO_COMERCIAL = acaoComercialVO.SEQ_ACAO_COMERCIAL;
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw;
		}
	}

	public void AtualizarAcaoComercialProdutoEncerradas(PedidoVendaMO pedidoVenda)
	{
		AcaoComercialProdutoBLL acaoComercialProdutoBLL = new AcaoComercialProdutoBLL();
		List<AcaoComercialEncerradaVO> list = acaoComercialProdutoBLL.ObterAcaoComercialProdutoEncerradas(pedidoVenda, ConfigERP.PAR_CFG);
		list.ForEach(delegate(AcaoComercialEncerradaVO x)
		{
			acaoComercialProdutoBLL.EncerrarAcaoComercialProduto(x, pedidoVenda);
		});
		if (list.Count > 0)
		{
			EnviarEmailEncerramentoAcaoComercial(list);
		}
	}

	public void AtualizarAcaoComercialEncerradas(PedidoVendaMO pedidoVenda)
	{
		List<AcaoComercialEncerradaVO> list = ObterAcaoComercialEncerradas(pedidoVenda);
		list.ForEach(delegate(AcaoComercialEncerradaVO x)
		{
			EncerrarAcaoComercial(x, pedidoVenda);
		});
		if (list.Count > 0)
		{
			EnviarEmailEncerramentoAcaoComercial(list);
		}
	}
}
