namespace ControleFinanceiro.Dominio.Entidades
{
    public sealed class Conta
    {
        public Conta(string nome, decimal saldo, bool cartaoCredito, decimal faturaCartao)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.CartaoCredito = cartaoCredito;
            this.FaturaCartao = faturaCartao;
        }

        public string Nome { get; }

        public decimal Saldo { get; }

        public bool CartaoCredito { get; }

        public decimal FaturaCartao { get; }
    }
}
