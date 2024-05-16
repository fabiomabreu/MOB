using System.Data.Entity.ModelConfiguration;
using Target.Venda.Model.Base;

namespace Target.Venda.DataAccess.EntityMapping;

public class BaseMap<T> : EntityTypeConfiguration<T> where T : EntidadeBaseMO
{
}
