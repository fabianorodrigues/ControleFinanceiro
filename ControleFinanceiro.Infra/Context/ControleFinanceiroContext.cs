using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Infra.Mapping;
using System.Data.Entity;

namespace ControleFinanceiro.Infra.Context
{
    public class ControleFinanceiroContext : DbContext
    {
        public ControleFinanceiroContext()
            : base("ControleFinanceiro")
        {

        }

        public DbSet<Meta> Metas { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MetaMap());
            modelBuilder.Configurations.Add(new LancamentoMap());
        }
    }
}
