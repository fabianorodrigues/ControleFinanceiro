using ControleFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Dominio.Repositorios
{
    public interface ILancamentoRepositorio : IDisposable
    {
        void Incluir(Lancamento meta);

        void Alterar(Lancamento meta);

        void Deletar(int id);

        Lancamento Buscar(int id);

        IList<Lancamento> Listar();
    }
}
