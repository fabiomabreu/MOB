using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class EmailDAL : EntidadeBaseDAL<EmailMO>
{
	protected override Expression<Func<EmailMO, bool>> GetWhere(Expression<Func<EmailMO, bool>> whereClause, EmailMO exemplo)
	{
		throw new NotImplementedException();
	}

	public int IncluirRegistroEmail(EmailVO email)
	{
		try
		{
			string procedure = "usp_email_inclui";
			List<SqlParameter> parameters = ObterParametrosUspEmailIncluir(email);
			int returnValue = 0;
			IncluirEmailVO incluirEmailVO = ExecutarStoredProcedureScalar<IncluirEmailVO>(procedure, parameters, out returnValue);
			if (returnValue < 0)
			{
				throw new Exception(incluirEmailVO.MENSAGEM_ERRO);
			}
			return incluirEmailVO.SEQ_EMAIL.Value;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private List<SqlParameter> ObterParametrosUspEmailIncluir(EmailVO email)
	{
		List<SqlParameter> list = new List<SqlParameter>();
		list.Add(new SqlParameter("@par_nu_seq_email_conta", email.DESTINATARIO.SEQ_EMAIL_CONTA));
		list.Add(new SqlParameter("@par_str_destinatario", email.DESTINATARIO.ENDERECO_EMAIL));
		if (email.DESTINATARIO_COPIA != null)
		{
			list.Add(new SqlParameter("@par_str_destinatario_copia", email.DESTINATARIO.SEQ_EMAIL_CONTA));
		}
		else
		{
			list.Add(new SqlParameter("@par_str_destinatario_copia", ""));
		}
		list.Add(new SqlParameter("@par_str_assunto", email.ASSUNTO));
		list.Add(new SqlParameter("@par_str_mensagem", email.MENSAGEM));
		int num = 0;
		SqlParameter sqlParameter = new SqlParameter("@rpar_nu_seq_email", num);
		sqlParameter.Direction = ParameterDirection.InputOutput;
		list.Add(sqlParameter);
		string empty = string.Empty;
		SqlParameter sqlParameter2 = new SqlParameter("@rpar_str_msg_erro", empty);
		sqlParameter2.Direction = ParameterDirection.InputOutput;
		list.Add(sqlParameter2);
		list.Add(new SqlParameter("@par_boo_formato_html", email.FORMATO_HTML));
		return list;
	}
}
