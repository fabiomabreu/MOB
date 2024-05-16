using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoPedidoEletronicoAbertoDAL : EntidadeBaseDAL<EventoPedidoEletronicoAbertoMO>
{
	protected override Expression<Func<EventoPedidoEletronicoAbertoMO, bool>> GetWhere(Expression<Func<EventoPedidoEletronicoAbertoMO, bool>> whereClause, EventoPedidoEletronicoAbertoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public override void Delete(EventoPedidoEletronicoAbertoMO objeto)
	{
		string comando = "DELETE FROM evento_pdel_ab WHERE seq_evento = {0}";
		ExecutarSqlCommand(comando, objeto.SEQ_EVENTO);
	}
}
