using ControleFinanceiro.Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.ViewModels
{
    public class LancamentoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Valor:")]
        public decimal Valor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Data:")]
        public DateTime Data { get; set; }

        [Display(Name = "Categoria:")]
        public ECategoria Categoria { get; set; }

        [Display(Name = "Lançamento Mensal ?:")]
        public bool LancamentoMensal { get; set; }
    }
}