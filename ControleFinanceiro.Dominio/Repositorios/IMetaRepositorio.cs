using ControleFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Dominio.Repositorios
{
    public interface IMetaRepositorio : IDisposable
    {
        void Incluir(Meta meta);

        void Alterar(Meta meta);

        void Deletar(int id);

        Meta Buscar(int id);

        IList<Meta> Listar(); 
    }
}
