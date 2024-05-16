using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class VerbaFabricanteCFGAvisoDAL : EntidadeBaseDAL<VerbaFabricanteCFGAvisoMO>
{
	protected override Expression<Func<VerbaFabricanteCFGAvisoMO, bool>> GetWhere(Expression<Func<VerbaFabricanteCFGAvisoMO, bool>> whereClause, VerbaFabricanteCFGAvisoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public List<DestinatarioEmailVO> ObterDestinatariosEmailVerbaFabricante()
	{
		try
		{
			string select = "  SELECT DISTINCT \r\n                                        u.cd_usuario AS CODIGO_USUARIO,\r\n                                        v.seq_email_conta AS SEQ_EMAIL_CONTA,\r\n                                        u.e_mail AS ENDERECO_EMAIL\r\n                                    FROM verba_fabr_cfg_avisos v\r\n                                    JOIN usuario u ON v.cd_usuario = u.cd_usuario\r\n                                    WHERE u.ativo = 1\r\n                                      AND rtrim(ltrim(ISNULL(u.e_mail,''))) != ''\r\n                                    ORDER BY v.seq_email_conta ";
			return ExecutarSelectSQL<DestinatarioEmailVO>(select, Array.Empty<object>());
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
