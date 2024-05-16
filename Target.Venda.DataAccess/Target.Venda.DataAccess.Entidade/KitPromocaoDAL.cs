using System;
using System.Linq.Expressions;
using System.Text;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class KitPromocaoDAL : EntidadeBaseDAL<KitPromocaoMO>
{
	protected override Expression<Func<KitPromocaoMO, bool>> GetWhere(Expression<Func<KitPromocaoMO, bool>> whereClause, KitPromocaoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public void AlterarVigenciaKitPromocao(AlterarVigenciaVO parametro)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" UPDATE kit_prom\r\n                                    SET descricao = descricao ");
			if (parametro.DATA_INICIO.HasValue)
			{
				stringBuilder.AppendFormat(", validade_de = '{0}' ", parametro.DATA_INICIO.Value.ToString("yyyy-MM-dd"));
			}
			if (parametro.DATA_FIM.HasValue)
			{
				stringBuilder.AppendFormat(", validade_ate = '{0}' ", parametro.DATA_FIM.Value.ToString("yyyy-MM-dd"));
			}
			stringBuilder.AppendFormat(" WHERE seq_kit = {0} ", parametro.SEQ_KIT);
			ExecutarSqlCommand(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
