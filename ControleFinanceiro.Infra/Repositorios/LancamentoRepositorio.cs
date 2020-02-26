using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Repositorios;
using ControleFinanceiro.Infra.Context;

namespace ControleFinanceiro.Infra.Repositorios
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        private ControleFinanceiroContext _db;

        public LancamentoRepositorio()
        {
            _db = new ControleFinanceiroContext();
        }
        public void Incluir(Lancamento lancamento)
        {
            _db.Lancamentos.Add(lancamento);
            _db.SaveChanges();
        }

        public void Alterar(Lancamento lancamento)
        {
            _db.Entry(lancamento).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Lancamento Buscar(int id)
        {
            return _db.Lancamentos.Find(id);
        }

        public void Deletar(int id)
        {
            var lancamento = Buscar(id);
            _db.Lancamentos.Remove(lancamento);
            _db.SaveChanges();
        }

        public IList<Lancamento> Listar()
        {
            return _db.Lancamentos.ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
