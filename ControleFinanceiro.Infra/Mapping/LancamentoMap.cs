using ControleFinanceiro.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ControleFinanceiro.Infra.Mapping
{
    public class LancamentoMap : EntityTypeConfiguration<Lancamento>
    {
        public LancamentoMap()
        {
            ToTable("Lancamento");
            HasKey(x => x.Id);
        }
    }
}
