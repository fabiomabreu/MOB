using System;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Base;

[Serializable]
public class EntidadeBaseMO
{
	[NotMapped]
	public StatusModelEnum STATUS_ENTIDADE { get; set; }
}
