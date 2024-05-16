using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TextoDAL : EntidadeBaseDAL<TextoMO>
{
	protected override Expression<Func<TextoMO, bool>> GetWhere(Expression<Func<TextoMO, bool>> whereClause, TextoMO exemplo)
	{
		if (exemplo.CODIGO_TEXTO > 0)
		{
			whereClause = whereClause.And((TextoMO x) => x.CODIGO_TEXTO == exemplo.CODIGO_TEXTO);
		}
		return whereClause;
	}

	public void GerarLogTextoLinha(int codigoTexto, string codigoUsuario)
	{
		try
		{
			int num = GerarSequencial("seq_txt_log");
			string comando = " INSERT INTO lin_txt_log\r\n\t\t\t\t\t\t    (\tcd_texto_log,\r\n\t\t\t\t\t\t\t    cd_texto_orig,\r\n\t\t\t\t\t\t\t    num_lin,\r\n\t\t\t\t\t\t\t    texto,\r\n\t\t\t\t\t\t\t    cd_usuario,\r\n\t\t\t\t\t\t\t    data\t)\r\n\t\t\t\t\t\t    SELECT\t\r\n\t\t\t\t\t\t\t    {0}         cd_texto_log,\r\n\t\t\t\t\t\t\t    t.cd_texto  cd_texto_orig,\r\n\t\t\t\t\t\t\t    t.num_lin   num_lin,\r\n\t\t\t\t\t\t\t    t.texto     texto,\r\n\t\t\t\t\t\t\t    {1}       cd_usuario,\r\n\t\t\t\t\t\t\t    GETDATE()\tdata\r\n\t\t\t\t\t\t    FROM\tlin_txt t\r\n\t\t\t\t\t\t    WHERE\tt.cd_texto = {2} ";
			ExecutarSqlCommand(comando, num, codigoUsuario, codigoTexto);
		}
		catch (Exception)
		{
			throw;
		}
	}
}
