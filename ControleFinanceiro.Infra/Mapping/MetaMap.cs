using ControleFinanceiro.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ControleFinanceiro.Infra.Mapping
{
    public class MetaMap : EntityTypeConfiguration<Meta>
    {
        public MetaMap()
        {
            ToTable("Meta");
            HasKey(x => x.Id);
            Property(x => x.Destino).HasMaxLength(60).IsRequired();
            Property(x => x.Porcentagem).IsRequired();
        }
    }
}
