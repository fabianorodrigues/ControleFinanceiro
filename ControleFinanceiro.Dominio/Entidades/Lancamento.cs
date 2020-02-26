using ControleFinanceiro.Dominio.Enums;
using System;

namespace ControleFinanceiro.Dominio.Entidades
{
    public sealed class Lancamento
    {
        public Lancamento()
        {

        }

        public Lancamento(string descricao, decimal valor, DateTime data, ECategoria categoria, bool lancamentoMensal)
        {
            this.Id = 0;
            this.Descricao = descricao;
            this.Valor = valor;
            this.Data = data;
            this.Categoria = categoria;
            this.LancamentoMensal = lancamentoMensal;
        }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public ECategoria Categoria { get; set; }

        public bool LancamentoMensal { get; set; }
    }
}
