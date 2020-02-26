using System.Collections.Generic;
using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Infra.Context;
using ControleFinanceiro.Dominio.Repositorios;
using System.Data.Entity;
using System.Linq;

namespace ControleFinanceiro.Infra.Repositorios
{
    public class MetaRepositorio : IMetaRepositorio
    { 

        private ControleFinanceiroContext _db;

        public MetaRepositorio()
        {
            _db = new ControleFinanceiroContext();
        }

        public void Incluir(Meta meta)
        {
            _db.Metas.Add(meta);
            _db.SaveChanges();
        }


        public void Alterar(Meta meta)
        {
            _db.Entry(meta).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Meta Buscar(int id)
        {
            return _db.Metas.Find(id);
        }

        public void Deletar(int id)
        {
            var meta = Buscar(id);
            _db.Metas.Remove(meta);
            _db.SaveChanges();
        }

        public IList<Meta> Listar()
        {
            return _db.Metas.ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
