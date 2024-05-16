using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;

namespace Target.Venda.Business.Entidade;

public class TextoBLL : EntidadeBaseBLL<TextoMO>
{
	protected override EntidadeBaseDAL<TextoMO> GetInstanceDAL()
	{
		return new TextoDAL();
	}

	public TextoMO CopiarTextoParaNovo(int codTexto)
	{
		TextoMO obj_para_mapear = ObterUnicoPeloExemplo(new TextoMO
		{
			CODIGO_TEXTO = codTexto
		}, "LINHAS_TEXTO");
		TextoMO textoMO = ConvertObjectToClass.Executar<TextoMO>(obj_para_mapear, Array.Empty<string>());
		EventoDAL eventoDAL = new EventoDAL();
		textoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		textoMO.CODIGO_TEXTO = eventoDAL.GerarSeq("seq_txt");
		if (textoMO.LINHAS_TEXTO == null)
		{
			textoMO.LINHAS_TEXTO = new List<LinhaTextoMO>();
		}
		foreach (LinhaTextoMO item in textoMO.LINHAS_TEXTO)
		{
			item.TEXTO = StringHelper.RemoverEspacosAmaisEntrePalavras(item.TEXTO);
			item.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
			item.CODIGO_TEXTO = textoMO.CODIGO_TEXTO;
		}
		Salvar(textoMO);
		(BaseDAL as TextoDAL).GerarLogTextoLinha(textoMO.CODIGO_TEXTO, LoginERP.USUARIO_LOGADO.CODIGO_USUARIO);
		return textoMO;
	}
}
