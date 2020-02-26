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

        public float TotalPorcentagemMetaInvestir { get; set; }

        public decimal TotalMetaInvestir { get; set; }

        public decimal TotalDisponivelInvestir { get; set; }

        public float TotalPorcentagemMetaGastar { get; set; }

        public decimal TotalMetaGastar { get; set; }

        public decimal TotalGastosLivres { get; set; }

        public decimal TotalGastosEssenciais { get; set; }

        public decimal TotalGastos { get; set; }

        

    }
}