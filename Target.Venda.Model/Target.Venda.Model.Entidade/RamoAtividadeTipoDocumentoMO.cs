using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("RamAtivTpDoc")]
public class RamoAtividadeTipoDocumentoMO : EntidadeBaseMO
{
	[Column("RamAtivTpDocID")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int RAMO_ATIVIDADE_TIPO_DOCUMENTO_ID { get; set; }

	[Column("CdDoc")]
	public int CODIGO_DOCUMENTO { get; set; }

	[Column("RamAtiv")]
	public string RAMO_ATIVIDADE { get; set; }
}
