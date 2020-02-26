using ControleFinanceiro.Dominio.Entidades;
using System.Collections.Generic;

namespace ControleFinanceiro.ViewModels
{
    public class OrcamentoViewModel
    {
        public OrcamentoViewModel()
        {
            Lancamentos = new List<Lancamento>();
            Metas = new List<Meta>();
        }

        public List<Lancamento> Lancamentos { get; set; }
        
        public IList<Meta> Metas { get; set; }

        public decimal TotalRendas { get; set; }

        public float TotalPorcentagemInvestir { get; set; }

        public decimal TotalInvestir { get; set; }

        public decimal TotalDisponivelInvestir { get; set; }

        public float TotalPorcentagemGastar { get; set; }

        public decimal TotalGastar { get; set; }

        public decimal TotalGastosLivres { get; set; }

        public decimal TotalGastosEssenciais { get; set; }

        public decimal TotalGastos { get; set; }

        

    }
}